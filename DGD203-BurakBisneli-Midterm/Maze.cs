namespace DGD203_BurakBisneli_Midterm;


public static class Maze
{
    private static Random _rnd = new Random();

    private record struct Vector(int X, int Y);
    

    public static void Generate(int width, int height)
    {
        Vector mazeBoundary = new Vector(width, height); // Max space of maze can be

        List<Vector> maze = new List<Vector>();


        Vector roadStart = new Vector(_rnd.Next(mazeBoundary.X), 0);

        maze.Add(roadStart);

        Vector currentRoad = roadStart;

        List<Vector> neighborCells = new List<Vector>();

        Vector[] directions = new Vector[]
        {
            new Vector(1, 0),
            new Vector(-1, 0),
            new Vector(0, 1),
            new Vector(0, -1),
        };

        while (maze.Count < width * height)
        {
            Console.WriteLine(currentRoad.X + ", " + currentRoad.Y);

            foreach (var direction in directions)
            {
                Vector newRoad = new Vector(currentRoad.X + direction.X, currentRoad.Y + direction.Y);
                if (newRoad.X >= 0 && newRoad.X < mazeBoundary.X && newRoad.Y >= 0 && newRoad.Y < mazeBoundary.Y &&
                    !maze.Contains(newRoad))
                {
                    neighborCells.Add(newRoad);
                }
            }


            if (neighborCells.Count == 0)
            {
                Console.WriteLine("No neighbors left.");
                break;
            }

            int randomCell = _rnd.Next(neighborCells.Count);
            Vector nextCell = neighborCells[randomCell];
            maze.Add(nextCell);
            currentRoad = nextCell;

            neighborCells.Clear();
        }
    }
}