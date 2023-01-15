# MTA2MzY3MjU5ODAzNjIyNjA1OA.Gc5EVb.Zb83DMaCoY6AoMRFjR2PQhfiBynG4JOgumDSXE
import discord
import random
import csv


intents = discord.Intents.all()
client = discord.Client(intents=intents)
queue = {}
queue_id = 0
team1 = []
team2 = []

@client.event
async def on_message(message):

    # queue creation command
    if message.content.startswith("!q"):
        global queue_id
        # check if there is a queue open
        if queue_id == 0:
            # if there is no current queue create the ID
            queue_id = random.randint(10000, 99999)
            # create the queue and add the user
            queue[queue_id] = []
            queue[queue_id].append(message.author.name)
            await message.channel.send("A new queue has been created with ID: " + str(queue_id))
        # if the user is in the queue respond
        elif message.author.name in queue[queue_id]:
            await message.channel.send("You are already in queue")
        # if the user is not in the queue and there is room add them
        elif len(queue[queue_id]) < 5:
            queue[queue_id].append(message.author.name)
            await message.channel.send(f"{message.author.name} has been added to the queue. {len(queue[queue_id])}/6")

        # when the queue hits 6 people create the teams
        elif len(queue[queue_id]) == 5:
            queue[queue_id].append(message.author.name)
            random.shuffle(queue[queue_id])
            global team1, team2
            team1 = queue[queue_id][:3]
            team2 = queue[queue_id][3:]
            await message.channel.send(f"Team 1: {', '.join(team1)} \nTeam 2: {', '.join(team2)}")
            await message.channel.send("For team captains use the !setteam1 and !setteam2 command")
            queue_id = 0
            queue.pop(queue_id)

    # allows to manually set teams (mainly used for captains or subs)
    elif message.content.startswith("!setteam1"):
        try:
            team1_list = message.content.split()[1].split(',')
            team1 = team1_list
            await message.channel.send(f"Team 1 has been updated: **{', '.join(team1)}**")
        except:
            await message.channel.send("An error occurred while updating team 1")

    elif message.content.startswith("!setteam2"):
        try:
            team2_list = message.content.split()[1].split(',')
            team2 = team2_list
            await message.channel.send(f"Team 2 has been updated: **{', '.join(team2)}**")
        except:
            await message.channel.send("An error occurred while updating team 2")

    # updates the csv file with win and loss results
    elif message.content.startswith("!winner"):

        if message.author.name in [player for player in team1]:
            winner = team1
            loser = team2
            check = True
        elif message.author.name in [player for player in team2]:
            winner = team2
            loser = team1
            check = True
        else:
            await message.channel.send("You are not in the current match")
            check = False
            return
        if check == True:
            with open("leaderboard.csv", "r") as file:
                reader = csv.DictReader(file)
                rows = list(reader)

            for player in winner + loser:
                if player not in [row["name"] for row in rows]:
                    rows.append({"name": player, "win": "0", "loss": "0"})

            for row in rows:
                if row["name"] in winner:
                    row["win"] = str(int(row["win"]) + 1)
                elif row["name"] in loser:
                    row["loss"] = str(int(row["loss"]) + 1)

            with open("leaderboard.csv", "w") as file:
                writer = csv.DictWriter(file, fieldnames=["name", "win", "loss"])
                writer.writeheader()
                writer.writerows(rows)

            await message.channel.send(f"{winner} has been recorded as the winner")
            check = False
        else:
            await message.channel.send("Can't record win")
            check = False


    # displays the leaderboard
    elif message.content.startswith("!leaderboard"):
        try:
            with open("leaderboard.csv", "r") as file:
                reader = csv.DictReader(file)
                rows = list(reader)
                leaderboard = "**LEADERBOARD**\n\n**Name | Win | Loss**\n"
                for row in rows:
                    leaderboard += f"**{row['name']}**: {row['win']} | {row['loss']}\n"
                await message.channel.send(leaderboard)
        except:
            await message.channel.send("An error occurred while trying to read the leaderboard.")

    # removes the queue and players from it
    elif message.content.startswith("!clear"):
        try:
            queue_to_remove = int(message.content.split()[1])
            if queue_to_remove == queue_id:
                queue.pop(queue_to_remove)
                queue_id = 0
                await message.channel.send(f"Queue {queue_to_remove} has been removed.")
            elif queue_to_remove in queue:
                queue.pop(queue_to_remove)
                await message.channel.send(f"Queue {queue_to_remove} has been removed.")
            else:
                await message.channel.send(f"Queue {queue_to_remove} not found.")
        except:
            await message.channel.send("An error occurred while removing the queue")

    # check the status of the queue
    elif message.content.startswith("!status"):
        if queue_id == 0:
            await message.channel.send("There is no current queue")
        elif queue_id in queue:
            await message.channel.send(f"The current queue {queue_id} has {len(queue[queue_id])}/6\nThe current players: {', '.join(queue[queue_id])}")
        else:
            await message.channel.send(f"An error occurred while trying to access queue {queue_id}")


    # lets the user leave the queue
    elif message.content.startswith("!leave"):
        if queue_id != 0 and message.author.name in queue[queue_id]:
            queue[queue_id].remove(message.author.name)
            await message.channel.send(f"{message.author.name} you have been removed from queue {queue_id}")
        else:
            await message.channel.send("You are not in a queue or the queue does not exist")

    elif message.content.startswith("!commands"):
        await message.channel.send("**!commands**: Displays all commands\n"
                                   "**!info**: Displays info about the bot\n"
                                   "**!q**: Adds the user into a 6man queue\n"
                                   "**!setteam1 <player1,player2,player3>**: Allow users to set up team1 manually, used for captain games or substitution (Player names are **Case Sensitive**)\n"
                                   "**!setteam2 <player1,player2,player3>**: Allow users to set up team2 manually, used for captain games or substitution (Player names are **Case Sensitive**)\n"
                                   "**!leave**: Removes the user the queue\n"
                                   "**!status**: Displays the status of the current queue\n"
                                   "**!clear <queue_id>**: Removes the queue and players from the pool\n"
                                   "**!winner**: Declares your team the winner of the match and updates the leaderboard\n"
                                   "**!leaderboard**: Displays the current leaderboard")

    elif message.content.startswith("!info"):
        await message.channel.send("I am the **Sinister 6Man Bot**\n"
                                   "- I was create by Sinister in January 2023\n"
                                   "- This is a personal bot built using python to be used to create random teams for 3v3 Rocket League.")

client.run('MTA2MzY3MjU5ODAzNjIyNjA1OA.Gc5EVb.Zb83DMaCoY6AoMRFjR2PQhfiBynG4JOgumDSXE')
