using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace ADONET
{
    public class Program
    {
        const string SqlConnectionString = "Server=.;DataBase=MinionsDB;Integrated Security=true";
        public static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();
            InitialSetup(connection);
            GetVillainNames(connection);
            MinionNames(connection);
            AddMinion(connection);
            ChangeTownNamesCasing(connection);
            RemoveVillain(connection);
            PrintMinionNames(connection);
            IncreaseMinionAge(connection);
            IncreaseAgeStoredProcedure(connection);
        }

        private static void IncreaseAgeStoredProcedure(SqlConnection connection)
        {
            int id = int.Parse(Console.ReadLine());
            string execProcedureQuery = "EXEC usp_GetOlder @id";
            using var command = new SqlCommand(execProcedureQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            string selectQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";
            using var selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@Id", id);
            using var reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader[1]} years old");
            }
        }

        private static void IncreaseMinionAge(SqlConnection connection)
        {
            int[] minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string updateMinionsQuery = @"UPDATE Minions
            SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
            WHERE Id = @Id";
            foreach (var id in minionIds)
            {
                using var updateMinionsCommand = new SqlCommand(updateMinionsQuery, connection);
                updateMinionsCommand.Parameters.AddWithValue("@Id", id);
                updateMinionsCommand.ExecuteNonQuery();
            }

            string selectMinionsQuery = "SELECT Name, Age FROM Minions";
            using var selectCommand = new SqlCommand(selectMinionsQuery, connection);
            using var reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
        }

        private static void PrintMinionNames(SqlConnection connection)
        {
            var minionsQuery = "SELECT Name FROM Minions";
            using var selectCommand = new SqlCommand(minionsQuery, connection);
            using var reader = selectCommand.ExecuteReader();
            var minions = new List<string>();
            while (reader.Read())
            {
                minions.Add((string)reader[0]);
            }

            int counter = 0;
            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[0 + counter]);
                Console.WriteLine(minions[minions.Count - 1 - counter]);
                counter++;
            }

            if (minions.Count % 2 != 0)
            {
                Console.WriteLine(minions[minions.Count / 2]);
            }
        }

        private static void RemoveVillain(SqlConnection connection)
        {
            int id = int.Parse(Console.ReadLine());
            string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";
            using var villainNameCommand = new SqlCommand(villainNameQuery, connection);
            villainNameCommand.Parameters.AddWithValue("@villainId", id);
            var name = (string)villainNameCommand.ExecuteScalar();
            if (name == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            var deleteMinionsVillainsQuery = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
            var sqlDeleteMinionsVillainsCommand = new SqlCommand(deleteMinionsVillainsQuery, connection);
            sqlDeleteMinionsVillainsCommand.Parameters.AddWithValue("@villainId", id);
            var affectedRows = sqlDeleteMinionsVillainsCommand.ExecuteNonQuery();

            var deleteVillainQuery = "DELETE FROM Villains WHERE Id = @villainId";
            var sqlDeleteVillainsCommand = new SqlCommand(deleteVillainQuery, connection);
            sqlDeleteVillainsCommand.Parameters.AddWithValue("@villainId", id);
            sqlDeleteVillainsCommand.ExecuteNonQuery();

            Console.WriteLine($"{name} was deleted.");
            Console.WriteLine($"{affectedRows} minions were released.");
        }

        private static void ChangeTownNamesCasing(SqlConnection connection)
        {
            string countryName = Console.ReadLine();
            string updateTownNameQuery = @"UPDATE Towns
                                           SET Name = UPPER(Name)
                                           WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            string selectTownNamesQuery = @"SELECT t.Name 
                                            FROM Towns as t
                                            JOIN Countries AS c ON c.Id = t.CountryCode
                                            WHERE c.Name = @countryName";

            using var updateCommand = new SqlCommand(updateTownNameQuery, connection);
            updateCommand.Parameters.AddWithValue("@countryName", countryName);
            var affectedRows = updateCommand.ExecuteNonQuery();
            if (affectedRows == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{affectedRows} town names were affected.");
                using var selectCommand = new SqlCommand(selectTownNamesQuery, connection);
                selectCommand.Parameters.AddWithValue("@countryName", countryName);
                using (var reader = selectCommand.ExecuteReader())
                {
                    var towns = new List<string>();
                    while (reader.Read())
                    {
                        towns.Add((string)reader[0]);
                    }

                    Console.WriteLine($"[{string.Join(", ", towns)}]");
                }
            }
        }

        private static void AddMinion(SqlConnection connection)
        {
            string[] minionInput = Console.ReadLine().Split(' ');
            string[] villainInput = Console.ReadLine().Split(' ');
            string minionName = minionInput[1];
            int age = int.Parse(minionInput[2]);
            string town = minionInput[3];

            int? townId = GetTownId(connection, town);
            if (townId == null)
            {
                string createTownQuery = "INSERT INTO Towns (Name) VALUES (@townName)";
                using var sqlCommand = new SqlCommand(createTownQuery, connection);
                sqlCommand.Parameters.AddWithValue("@townName", town);
                sqlCommand.ExecuteNonQuery();
                townId = GetTownId(connection, town);
                Console.WriteLine($"Town {town} was added to the database.");
            }

            string villainName = villainInput[1];
            int? villainId = GetVillainId(connection, villainName);
            if (villainId == null)
            {
                string createVillain = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                using var sqlCommand = new SqlCommand(createVillain, connection);
                sqlCommand.Parameters.AddWithValue("@villainName", villainName);
                sqlCommand.ExecuteNonQuery();
                villainId = GetTownId(connection, town);
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            CreateMinion(connection, minionName, age, townId);

            var minionId = GetMinionId(connection, minionName);

            InsertMinionsVillains(connection, villainId, minionId);
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static void InsertMinionsVillains(SqlConnection connection, int? villainId, int? minionId)
        {
            var insertIntoMinionsVillains =
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
            using var sqlMinionsVillainsCommand = new SqlCommand(insertIntoMinionsVillains, connection);
            sqlMinionsVillainsCommand.Parameters.AddWithValue("@villainId", villainId);
            sqlMinionsVillainsCommand.Parameters.AddWithValue("@minionId", minionId);
            sqlMinionsVillainsCommand.ExecuteNonQuery();
        }

        private static int? GetMinionId(SqlConnection connection, string minionName)
        {
            var minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";
            using var sqlMinionIdCommand = new SqlCommand(minionIdQuery, connection);
            sqlMinionIdCommand.Parameters.AddWithValue("@Name", minionName);
            var minionId = sqlMinionIdCommand.ExecuteScalar();
            return (int?)minionId;
        }

        private static void CreateMinion(SqlConnection connection, string minionName, int age, int? townId)
        {
            string createMinion = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            using var sqlCreateMinionCommand = new SqlCommand(createMinion, connection);
            sqlCreateMinionCommand.Parameters.AddWithValue("@name", minionName);
            sqlCreateMinionCommand.Parameters.AddWithValue("@age", age);
            sqlCreateMinionCommand.Parameters.AddWithValue("@townId", townId);
            sqlCreateMinionCommand.ExecuteNonQuery();
        }

        private static int? GetVillainId(SqlConnection connection, string villainName)
        {
            string villainIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";
            using var sqlCommand = new SqlCommand(villainIdQuery, connection);
            sqlCommand.Parameters.AddWithValue("@Name", villainName);
            var villainId = sqlCommand.ExecuteScalar();
            return (int?)villainId;
        }

        private static int? GetTownId(SqlConnection connection, string town)
        {
            string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";
            using var sqlCommand = new SqlCommand(townIdQuery, connection);
            sqlCommand.Parameters.AddWithValue("@townName", town);
            var townId = sqlCommand.ExecuteScalar();
            return (int?)townId;
        }

        private static void MinionNames(SqlConnection connection)
        {
            int id = int.Parse(Console.ReadLine());
            string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";
            using var command = new SqlCommand(villainNameQuery, connection);
            command.Parameters.AddWithValue("@Id", id);
            var result = command.ExecuteScalar();

            string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

            if (result == null)
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Villain: {result}");
                using (var minionCommand = new SqlCommand(minionsQuery, connection))
                {
                    minionCommand.Parameters.AddWithValue("@Id", id);
                    using (var reader = minionCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }
            }
        }


        private static void GetVillainNames(SqlConnection connection)
        {
            var villainNameQuery = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                        FROM Villains AS v 
                                        JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                        GROUP BY v.Id, v.Name 
                                        HAVING COUNT(mv.VillainId) > 3 
                                        ORDER BY COUNT(mv.VillainId) DESC";

            using var command = new SqlCommand(villainNameQuery, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var name = reader[0];
                var count = reader[1];
                Console.WriteLine($"{name} - {count}");
            }
        }

        public static void InitialSetup(SqlConnection connection)
        {
            //CREATE DATABASE MinionsDB
            //string createDatabase = "CREATE DATABASE MinionsDB";

            var createTableStatements = GetCreateTableStatements();
            foreach (var query in createTableStatements)
            {
                ExecuteNonQuery(connection, query);
            }

            var insertDataStatements = GetInsertDataStatements();
            foreach (var query in insertDataStatements)
            {
                ExecuteNonQuery(connection, query);
            }
        }

        public static object ExecuteScalar(SqlConnection connection, string villainNameQuery)
        {
            using var command = new SqlCommand(villainNameQuery, connection);
            var result = command.ExecuteScalar();
            return result;
        }

        public static void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using var command = new SqlCommand(query, connection);
            var result = command.ExecuteNonQuery();
        }

        public static string[] GetInsertDataStatements()
        {
            var result = new string[]
            {
                "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')",
                "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)",
                "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)",
                "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')",
                "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)",
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)",
            };
            return result;
        }
        public static string[] GetCreateTableStatements()
        {
            var result = new string[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",
                "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",
                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))",
            };
            return result;
        }
    }
}
