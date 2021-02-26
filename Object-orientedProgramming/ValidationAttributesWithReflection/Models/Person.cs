namespace ValidationAttributes.Models
{
    public class Person
    {
        public Person(string fullname, int age)
        {
            this.FullName = fullname;
            this.Age = age;
        }

        [MyRequired] 
        public string FullName { get; set; }

        [MyRange(12, 90)]
        public int Age { get; set; }
    }
}
