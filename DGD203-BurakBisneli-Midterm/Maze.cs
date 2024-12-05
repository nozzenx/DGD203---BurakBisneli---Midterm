using System.Numerics;

namespace DGD203_BurakBisneli_Midterm;


public static class Maze
{
    private static readonly Random Rnd = new Random(); // For generate random numbers.

    public record struct Vector(int X, int Y);

    private static int _width;
    private static int _height;

    public static List<Vector> Generate(int width, int height)
    {
        _width = width;
        _height = height;
        
        Vector mazeBoundary = new Vector(_width, _height); // Max space of maze can be
        List<Vector> maze = new List<Vector>(); // Listing the maze coordinates.

        List<Vector> roadStarts = new List<Vector>
        {
            new Vector(Rnd.Next(mazeBoundary.X), 0),
            new Vector(Rnd.Next(mazeBoundary.X), mazeBoundary.Y-1),
            new Vector(0, Rnd.Next(mazeBoundary.Y)),
            new Vector(mazeBoundary.X-1, Rnd.Next(mazeBoundary.Y)),
        };
        int randomStartingRoadIndex = Rnd.Next(roadStarts.Count);
        Vector randomStartingRoad = roadStarts[randomStartingRoadIndex];

        Vector roadStart = randomStartingRoad; // Starting cell of maze. It's random generated.
        
        maze.Add(roadStart); // Adding starting cell to maze.
        Vector currentRoad = roadStart; // Making our current pos to starting position
        List<Vector> neighborCells = new List<Vector>(); // Making a neighbour cells list for getting the cells we can go.

        Vector[] directions = new Vector[] // I used ChatGPT for suggestions, and it recommends that for more readable code. 
        {
            new Vector(1, 0),
            new Vector(-1, 0),
            new Vector(0, 1),
            new Vector(0, -1),
        };

        while (maze.Count < width * height) // We have width * height cells for total and if our mazes cells count > total cells we cant generate more road cells.
        {
            Console.WriteLine(currentRoad.X + ", " + currentRoad.Y); 

            foreach (var direction in directions) // For all possible directions we create a new road and add them to neighbour cells.
            {
                Vector newRoad = new Vector(currentRoad.X + direction.X, currentRoad.Y + direction.Y);
                if (newRoad.X >= 0 && newRoad.X < mazeBoundary.X && newRoad.Y >= 0 && newRoad.Y < mazeBoundary.Y &&
                    !maze.Contains(newRoad))
                {
                    neighborCells.Add(newRoad);
                }
            }


            if (neighborCells.Count == 0) // If no possible roads left we break the loop.
            {
                Console.WriteLine("No neighbors left.");
                break;
            }

            int randomCell = Rnd.Next(neighborCells.Count); // We choose random cell inside neighbour cells we add up.
            Vector nextCell = neighborCells[randomCell]; // Making the random cell our next cell.
            
            maze.Add(nextCell); // Adding the next cell to our maze road.
            currentRoad = nextCell; // And make our current position to next cell for creating the next road if possible.
            
            neighborCells.Clear(); // Clearing our neighbour cells because our current cell is different now and our neighbour cells going to change with that.

        }
        return maze;
    }

    public static void Print(List<Vector> maze)
    {
        char[,] grid = new char[_width, _height];

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                grid[x, y] = '\u2588';
            }
        }

        foreach (var cell in maze)
        {
            grid[cell.X, cell.Y] = '+';
        }

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                Console.Write(grid[x, y] + "  ");
            }
            Console.WriteLine();
        }
    }
}