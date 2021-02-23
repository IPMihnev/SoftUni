namespace ConsoleSnakeGame
{
    public class Node
    {
        public Node(Position position)
        {
            this.Value = position;
        }

        public Position Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}
