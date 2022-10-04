namespace FootballLeague.ViewStore.Teams
{
    public class TeamViewStoreModel
    {
        public TeamViewStoreModel(int id, string name, string color, int score)
        {
            Id = id;
            Name = name;
            Color = color;
            Score = score;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public int Score { get; set; }
    }
}
