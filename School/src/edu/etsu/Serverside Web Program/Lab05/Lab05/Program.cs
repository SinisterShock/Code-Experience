using Microsoft.Data.Sqlite;

namespace Lab05
{
    /// <summary>
    /// ORDER OF OPERATIONS FOR DB TRANSACTIONS IN .NET
    /// 1. Set up connection (using)
    /// 2. Open connection (connection.Open())
    /// 3. Set up command 
    /// 4. Set any params (if necessary)
    /// 5. Execute command
    /// </summary>
    public class Program
    {
        private static string connString = $"Data Source={FileRoot.root}{Path.DirectorySeparatorChar}data{Path.DirectorySeparatorChar}Lab04Database.db";
        private static string root = FileRoot.root;

        public static void Main(string[] args)
        {
            List<string> bookList = new List<string>();
            ReadBooks(bookList);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t---------------------Titles---------------------\n");
            foreach (string book in bookList)
            {
                Console.WriteLine($"\t{book}");
            }

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            WriteList(bookList);
            Console.WriteLine("Check the CSV file\n");

            
            ReadAuthor();
            Console.WriteLine("\n");
            ReadAuthorBooks();
            Console.ForegroundColor = ConsoleColor.Black;
        }

        // read a user by their id
        static void ReadBooks(List<string> bookList)
        {

            // this sets up the connection to test.db
            using (var connection = new SqliteConnection(connString))
            {
                // open the connection
                connection.Open();

                // create the command
                var command = connection.CreateCommand();

                // add text to the command
                command.CommandText =
                @"
                    SELECT Title
                    FROM Books
                    ORDER BY Title;
                ";

                

                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookList.Add(reader.GetString(0));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                }
            }
        }

        static void WriteList(List<string> bookList)
        {
            var file = root + "\\data" + "\\writelist.csv";
            using (var sw = new StreamWriter(file))
            {
                foreach (var book in bookList)
                {
                    sw.WriteLine($"{book}, ");
                }
            }
        }

        static void ReadAuthor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the author initial(Last Name) you want to search for: ");
            string initial = Console.ReadLine();

            // this sets up the connection to test.db
            using (var connection = new SqliteConnection(connString))
            {
                // open the connection
                connection.Open();

                // create the command
                var command = connection.CreateCommand();

                // add text to the command
                command.CommandText =
                @"
                    SELECT Last_Name, First_Name
                    FROM Authors
                    WHERE Last_Name like $initial;
                ";

                // command parameters
                command.Parameters.AddWithValue("$initial", initial + "%");

                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetString(0)}, {reader.GetString(1)}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                }
            }
        }

        static void ReadAuthorBooks()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the author last name you want to search for: ");
            string author = Console.ReadLine();

            // this sets up the connection to test.db
            using (var connection = new SqliteConnection(connString))
            {
                // open the connection
                connection.Open();

                // create the command
                var command = connection.CreateCommand();

                // add text to the command
                command.CommandText =
                @"
                    select Books.Title 
                    from Book_Author 
                    join Books on Books.Id = Book_Author.Book_Id 
                    join Authors on Authors.Id = Book_Author.Author_Id 
                    where Authors.Last_Name like $author;
                ";

                // command parameters
                command.Parameters.AddWithValue("$author", author);

                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetString(0)}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                }
            }
        }
        /*static List<Pokemon> ReadPokemonFromCSV()
        {
            var pokemonList = new List<Pokemon>();

            var file = root + "\\data" + "\\pokemon.csv";

            using (var sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var data = line.Split(",");

                    var dexNum = int.Parse(data[0]);
                    var name = data[1];
                    var level = int.Parse(data[2]);
                    var pType = data[3];
                    var sType = data[4];

                    pokemonList.Add(new Pokemon(dexNum, name, level, pType, sType));
                }
            }

            return pokemonList;
        }

        static List<Pokemon> ReadPokemonFromDb()
        {
            using (var connection = new SqliteConnection(connString))
            {
                connection.Open();
                List<Pokemon> twoTypes = new List<Pokemon>();
                var command = connection.CreateCommand();

                command.CommandText = @"SELECT * FROM Pokemon WHERE Secondary_Type is not ''";

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var dexNum = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var level = reader.GetInt32(2);
                        var pType = reader.GetString(3);
                        var sType = reader.GetString(4);

                        twoTypes.Add(new Pokemon(dexNum, name, level, pType, sType));
                    }
                }
                return twoTypes;
            }
        }

        static void WriteList(List<Pokemon> pokemonList)
        {
            var file = root + "\\data" + "\\writelist.csv";
            using (var sw = new StreamWriter(file))
            {
                foreach (var pokemon in pokemonList)
                {
                    sw.WriteLine(pokemon);
                }
            }
        }

        static void AddPokemonToDb(Pokemon p)
        {
            // set up connection
            using (var connection = new SqliteConnection(connString))
            {
                connection.Open();

                // this makes our code ~pretty
                var cmdText = @"INSERT INTO Pokemon VALUES ($num, $name, $lvl, $pt, $st)";

                using (var command = new SqliteCommand(cmdText, connection))
                {
                    // optional -- but it may help with faster transaction time
                    command.CommandType = System.Data.CommandType.Text;

                    // add in parameters with values
                    command.Parameters.AddWithValue("$num", p.DexNumber);
                    command.Parameters.AddWithValue("$name", p.Name);
                    command.Parameters.AddWithValue("$lvl", p.Level);
                    command.Parameters.AddWithValue("$pt", p.PrimaryType);
                    command.Parameters.AddWithValue("$st", p.SecondaryType);

                    // we have the command, now let's run it
                    // remember, nonquerys are non-select read transactions
                    // e.g., insert, update, delete, etc.

                    command.ExecuteNonQuery();
                }
            }
        }

        static void AddPokemonListToDb()
        {
            var pokemonList = ReadPokemonFromCSV();
            foreach (var pokemon in pokemonList)
            {
                AddPokemonToDb(pokemon);
            }
        }

        static void ClearPokemonFromDb()
        {
            using (var connection = new SqliteConnection(connString))
            {
                connection.Open();

                using (var command = new SqliteCommand(@"DELETE FROM pokemon;", connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }*/
    }
}