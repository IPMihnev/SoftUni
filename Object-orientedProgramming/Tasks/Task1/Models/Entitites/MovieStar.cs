using Task1.Models.Interfaces;

namespace Task1.Models.Entitites
{
    public class MovieStar : IMovieStar
    {
        public MovieStar(
            string dateOfBirth,
            string name,
            string surname,
            string sex,
            string nationality
        )
        {
            DateOfBirth = dateOfBirth;
            Name = name;
            Surname = surname;
            Sex = sex;
            Nationality = nationality;
        }

        public string DateOfBirth { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
    }
}