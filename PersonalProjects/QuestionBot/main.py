import openai
import discord

intents = discord.Intents.all()
client = discord.Client(intents=intents)

openai.api_key = "OPENAI_TOKEN"


@client.event
async def on_message(message):
    if message.content.startswith("!question "):
        question = message.content[10:]
        prompt = (f"{question}\n")
        try:
            response = openai.Completion.create(
                engine="text-davinci-002",
                prompt=prompt,
                max_tokens=1024,
                temperature=0.5

            )
            response_text = response.choices[0].text
            await message.channel.send(f"{message.author.mention} {response_text}")
        except openai.exceptions.OpenAiError as e:
            if e.status_code == 429:
                print("Too many requests, rate limited.")


client.run("DISCORD_TOKEN")
