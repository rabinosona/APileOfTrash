using System.IO;
using TaskDocWriter.Constants;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using TaskDocWriter.Models;
using System.Diagnostics;
using System.Xml.Linq;
using System.Linq;

namespace TaskDocWriter.Services
{
    /// <summary>
    /// The XMLWorkerService for working with XML files: it loads their content, saves req
    /// uired strings and checks for existence of the file at all.
    /// </summary>
    class XMLWorkerService
    {
        XmlDocument xmlDoc = new XmlDocument();
        private FileStream xmlFileStream;
        readonly string fileName;

        public XMLWorkerService(string fileName)
        {
            this.fileName = Directory.GetCurrentDirectory() + fileName;

            ConfigureXMLStream();
            CheckFile();
        }

        private void ConfigureXMLStream()
        {
            xmlFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
        }

        /// <summary>
        /// The method checks for existence of the file at start of the creating of the
        /// XMLWorker so we would know should we load the existing file or create a new
        /// one.
        /// </summary>
        /// <returns>void</returns>
        private void CheckFile()
        {
            xmlFileStream.Close();
            if (new FileInfo(fileName).Length == 0)
            {
                XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8);

                writer.WriteStartDocument();
                writer.WriteStartElement("users");
                writer.WriteEndElement();
                writer.Close();
            }
        }

        /// <summary>
        /// Overoading of the XML data loading, but the data is now loaded by the sear
        /// ch pattern.
        /// </summary>
        public void LoadDataFromFile(string tagPattern, List<UserModel> userList)
        {
            try
            {
                ConfigureXMLStream();

                xmlDoc.Load(xmlFileStream);
                XmlElement xElements = xmlDoc.DocumentElement;

                foreach (XmlElement element in xElements)
                {
                    if (element.Name == tagPattern)
                    {
                        string phone = "", email = "", surname = "";

                        foreach (XmlNode elementChild in element.ChildNodes)
                        {
                            if (elementChild.Name == "surname")
                            {
                                surname = elementChild.InnerText;
                            }
                            if (elementChild.Name == "phone")
                            {
                                phone = elementChild.InnerText;
                            }
                            if (elementChild.Name == "email")
                            {
                                email = elementChild.InnerText;
                            }
                        }

                        if (surname != "" && phone != "" && email != "")
                        {
                            UserModel user = new UserModel();
                            user.Surname = surname; user.Phone = phone; user.Email = email;
                            userList.Add(user);
                        }
                    }
                }

                xmlFileStream.Close();
            }
            catch (XmlException xmlE)
            {
                Debug.WriteLine(xmlE);
                xmlFileStream.Close();
            }
        }

        /// <summary>
        /// This method saves a one passed user model to the ListView
        /// in a users tag.
        /// </summary>
        /// <param name="addedUser"></param>
        public void SaveDataToFile(UserModel addedUser)
        {
            ConfigureXMLStream();

            XDocument doc = XDocument.Load(xmlFileStream);

            XElement users = doc.Element("users");

            users.Add(new XElement("user",
                new XElement("surname", addedUser.Surname),
                new XElement("phone", addedUser.Phone),
                new XElement("email", addedUser.Email))
                );

            xmlFileStream.SetLength(0);
            doc.Save(xmlFileStream);

            xmlFileStream.Close();
        }

        public void RemoveRecordingFromFile(UserModel removedUser)
        {
            ConfigureXMLStream();

            XDocument doc = XDocument.Load(xmlFileStream);
            XElement users = doc.Element("users");

            users.Elements().Where(
                x =>
                (x.Element("surname").Value == removedUser.Surname) 
                && (x.Element("phone").Value == removedUser.Phone) 
                && (x.Element("email").Value == removedUser.Email))
                .Remove();

            xmlFileStream.SetLength(0);
            doc.Save(xmlFileStream);

            xmlFileStream.Close();
        }
    }
}
