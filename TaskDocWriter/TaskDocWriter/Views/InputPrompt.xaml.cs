﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TaskDocWriter.Controllers;

namespace TaskDocWriter.Views
{
    /// <summary>
    /// Interaction logic for InputPrompt.xaml
    /// </summary>
    public partial class InputPrompt : Window
    {
        InputPromptController inputController;

        public InputPrompt()
        {
            InitializeComponent();

            inputController = new InputPromptController();
        }

        private void InputPromptButtonClick(object e, RoutedEventArgs data)
        {
            if (surnameBox.Text != "" && phoneBox.Text != "" && emailBox.Text != "")
            {
                inputController.SaveUserData(surnameBox.Text, phoneBox.Text, emailBox.Text);
                surnameBox.Clear();
                phoneBox.Clear();
                emailBox.Clear();

                this.Close();
            }
        }
    }
}