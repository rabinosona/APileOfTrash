import discord
import asyncio
import time
import getpass

client = discord.Client()

print("Enter your e-mail:")
email = input()
password = getpass.getpass("Enter your password: ")



@client.event
async def on_ready():
    print('Logged in as')
    print(client.user.name)
    print(client.user.id)
    print('------')
    number_of_messages = 0

    for i in client.get_all_channels().__iter__():
        try:
            time = i.created_at
            print(str(i.name) + ' ' + str(i.server))
            async for msg in client.logs_from(i, limit=1000000, after=time):
                if msg.author.id == client.user.id:
                    await client.delete_message(msg)
                    await asyncio.sleep(0.25)
        except Exception:
            print("It seems like the channel " + str(i.name) + ' ' + str(i.server) + ' is locked for user ' + client.user.name)
    client.close()

client.login(email, password)
client.run(email, password)
client.close()