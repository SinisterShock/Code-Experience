using InClassExampleConnections;
using Microsoft.Data.Sqlite;

public class Program
{
    private const string CONNECTION_STRING = "Data Source= C:\\Users\\saint\\Desktop\\C# projects\\Example Database\\ExampleDatabase.db";
    public static void Main(string[] args)
    {
        //ReadUser();
        Pokemon p = new Pokemon(1, "Bulbasaur", 1, "Grass", "");
        AddPokemonToDB(p);
    }

    static void ReadUser()
    {
        Console.WriteLine("Enter the user ID you want to search for: ");
        int enteredID = int.Parse(Console.ReadLine());

        using (var connection = new SqliteConnection(CONNECTION_STRING))
        {
            //open connection
            connection.Open();

            //create the command
            var command= connection.CreateCommand();

            //add text to the command
            command.CommandText =
            @"
                SELECT FirstName, LastName
                From Users
                WHERE id = $id;
            ";

            // command parameters
            command.Parameters.AddWithValue("$id", enteredID);

            try
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"The user's name that you selected is: {reader.GetString(0)} {reader.GetString(1)}");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    // doesn't currently work get starter code from week 8
    static void AddPokemonToDB(Pokemon p)
    {
        using (var connection = new SqliteConnection(CONNECTION_STRING))
        {
            connection.Open();

            var cmdText = @"INSERT INTO Pokemon VALUES ($DexNum, $Name, $Level, $PrimaryType, $SecondaryType)";
            using (var command = new SqliteCommand(cmdText, connection))
            {
                command.Parameters.AddWithValue("$DexNum", p.DexNum);
                command.Parameters.AddWithValue("$Name", p.Name);
                command.Parameters.AddWithValue("$Level", p.Level);
                command.Parameters.AddWithValue("$PrimaryType", p.PrimaryType);
                command.Parameters.AddWithValue("$SecondaryType", p.SecondaryType);
            }
        }
    }
}