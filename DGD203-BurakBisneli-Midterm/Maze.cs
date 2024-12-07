using System.Numerics;

namespace DGD203_BurakBisneli_Midterm;


public static class Maze
{
    private static readonly Random Rnd = new Random(); // For generate random numbers.

    public record struct Vector(int X, int Y);

    private static int _width;
    private static int _height;

    private static Vector _mazeBoundary; // Max space of maze can be
    private static List<Vector> _maze = new List<Vector>();
    private static List<Vector> _walls = new List<Vector>();
    private static List<Vector> _neighborCells = new List<Vector>(); // Making a neighbour cells list for getting the cells we can go.

    private static readonly Vector[] Directions = new Vector[] // I used ChatGPT for suggestions, and it recommends that for more readable code. 
    {
        new Vector(1, 0),
        new Vector(-1, 0),
        new Vector(0, 1),
        new Vector(0, -1),
    };

    public static List<Vector> GenerateBaseRoad(int width, int height)
    {
        _width = width;
        _height = height;
        
        _mazeBoundary = new Vector(_width, _height);
        
        List<Vector> roadStarts = ChooseRandomStartingPoints(_mazeBoundary); // choosing random starting point inside 4 direction starting points.
        int randomStartingRoadIndex = Rnd.Next(roadStarts.Count);
        Vector randomStartingRoad = roadStarts[randomStartingRoadIndex];

        _maze.Add(randomStartingRoad); // Adding starting cell to maze.
        Vector currentRoad = randomStartingRoad; // Making our current pos to starting position
        
        
        while (_maze.Count < _width * _height) // We have width * height cells for total and if our mazes cells count > total cells we cant generate more road cells.
        {
            Console.WriteLine(currentRoad.X + ", " + currentRoad.Y); 

            foreach (var direction in Directions) // For all possible directions we create a new road and add them to neighbour cells.
            {
                Vector newRoad = new Vector(currentRoad.X + direction.X, currentRoad.Y + direction.Y);
                if (newRoad.X >= 0 && newRoad.X < _mazeBoundary.X && newRoad.Y >= 0 && newRoad.Y < _mazeBoundary.Y &&
                    !_maze.Contains(newRoad) && !_walls.Contains(newRoad))
                {
                    _neighborCells.Add(newRoad);
                }
            }


            if (_neighborCells.Count == 0) // If no possible roads left we break the loop.
            {
                Console.WriteLine("No neighbors left.");
                break;
            }

            int randomCell = Rnd.Next(_neighborCells.Count); // We choose random cell inside neighbour cells we add up.
            Vector nextCell = _neighborCells[randomCell]; // Making the random cell our next cell.

            _neighborCells.Remove(nextCell);

            foreach (Vector cell in _neighborCells)
            {
                _walls.Add(cell);
            }
            
            _maze.Add(nextCell); // Adding the next cell to our maze road.
            currentRoad = nextCell; // And make our current position to next cell for creating the next road if possible.
            
            _neighborCells.Clear(); // Clearing our neighbour cells because our current cell is different now and our neighbour cells going to change with that.

        }
        Console.WriteLine($"Maze Last Point Values: X:{_maze.Last().X}, Y:{_maze.Last().Y}");
        Console.WriteLine($"{width}x{height}");
        Console.WriteLine(_maze.Count);
        return _maze;
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
            grid[cell.X, cell.Y] = ' ';
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

    private static List<Vector> ChooseRandomStartingPoints(Vector boundary)
    {
        return
        [
            new Vector(Rnd.Next(boundary.X), 0),
            new Vector(Rnd.Next(boundary.X), boundary.Y-1),
            new Vector(0, Rnd.Next(boundary.Y)),
            new Vector(boundary.X-1, Rnd.Next(boundary.Y)),
        ];
    }

    private static void GenerateNpc(List<Vector> maze)
    {
       
    }

    public static List<Vector> GenerateConnectingRoads(List<Vector> maze)
    {
       
            Vector randomPointInMaze = maze[Rnd.Next(maze.Count)];
        Vector currentRoad = randomPointInMaze;
        
        foreach (var direction in Directions) // For all possible directions we create a new road and add them to neighbour cells.
        {
            Vector newRoad = new Vector(currentRoad.X + direction.X, currentRoad.Y + direction.Y);
            if (newRoad.X >= 0 && newRoad.X < _mazeBoundary.X && newRoad.Y >= 0 && newRoad.Y < _mazeBoundary.Y &&
                !_maze.Contains(newRoad) && _walls.Contains(newRoad))
            {
                _walls.Remove(newRoad);
                _neighborCells.Add(newRoad);
            }
            
        }
        currentRoad = _neighborCells[Rnd.Next(_neighborCells.Count)];
        maze.Add(currentRoad);
        _neighborCells.Clear();
        
        
        while (_maze.Count < _width * _height) // We have width * height cells for total and if our mazes cells count > total cells we cant generate more road cells.
        {
            Console.WriteLine(currentRoad.X + ", " + currentRoad.Y); 

            foreach (var direction in Directions) // For all possible directions we create a new road and add them to neighbour cells.
            {
                Vector newRoad = new Vector(currentRoad.X + direction.X, currentRoad.Y + direction.Y);
                if (newRoad.X >= 0 && newRoad.X < _mazeBoundary.X && newRoad.Y >= 0 && newRoad.Y < _mazeBoundary.Y &&
                    !_maze.Contains(newRoad) && !_walls.Contains(newRoad))
                {
                    _neighborCells.Add(newRoad);
                }
            }


            if (_neighborCells.Count == 0) // If no possible roads left we break the loop.
            {
                Console.WriteLine("No neighbors left.");
                break;
            }

            int randomCell = Rnd.Next(_neighborCells.Count); // We choose random cell inside neighbour cells we add up.
            Vector nextCell = _neighborCells[randomCell]; // Making the random cell our next cell.

            _neighborCells.Remove(nextCell);

            foreach (Vector cell in _neighborCells)
            {
                _walls.Add(cell);
            }
            
            _maze.Add(nextCell); // Adding the next cell to our maze road.
            currentRoad = nextCell; // And make our current position to next cell for creating the next road if possible.
            
            _neighborCells.Clear(); // Clearing our neighbour cells because our current cell is different now and our neighbour cells going to change with that.

        }
        return _maze;
    }

    public static List<Vector> Generate(int width, int height, int connectingRoads)
    {
        List<Vector> maze = GenerateBaseRoad(width, height);
        for (int i = 0; i < connectingRoads; i++)
            GenerateConnectingRoads(maze);
        return maze;
    }
}