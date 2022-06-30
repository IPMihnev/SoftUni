using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Task1.Models.Entitites;

namespace Task1
{
    class Program
    {
       static void Main()
            => WriteToConsole(CreateModelsFromResources());

        private static List<MovieStar> CreateModelsFromResources()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\input.txt");
            var fileContent = File.ReadAllText(filePath);
            var movieStars = JsonConvert.DeserializeObject<List<MovieStar>>(fileContent);
            return movieStars;
        }

        private static void WriteToConsole(List<MovieStar> movieStars)
        {
            foreach (var movieStar in movieStars)
            {
                var date = DateTime.Parse(movieStar.DateOfBirth, CultureInfo.InvariantCulture);
                Console.WriteLine($"{movieStar.Name} {movieStar.Surname}");
                Console.WriteLine(movieStar.Sex);
                Console.WriteLine(movieStar.Nationality);
                Console.WriteLine($"{DateTime.Now.AddYears(-date.Year).Year} years old");
                Console.WriteLine();
            }
        }
    }
}
