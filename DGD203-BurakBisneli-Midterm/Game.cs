namespace DGD203_BurakBisneli_Midterm;

public class Game 
{
    private bool _isRunning = true;

    public void GameTest()
    {
       List<Maze.Vector> map = Maze.GenerateFirst(20, 20);
       Maze.GenerateSecond(map);
       if (map != null)
       {
            Maze.Print(map);
       }
       else
       {
           map = Maze.GenerateFirst(20, 20);
           Maze.GenerateSecond(map);
       }
    }

    public void GameLoop()
    {
        while (_isRunning)
        {
            Console.WriteLine("Burak");
            Tools.WaitSeconds(1);
            Console.WriteLine("Bisneli");
            _isRunning = false;
        }
    }
}