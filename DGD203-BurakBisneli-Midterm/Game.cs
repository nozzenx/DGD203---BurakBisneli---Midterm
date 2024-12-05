namespace DGD203_BurakBisneli_Midterm;

public class Game 
{
    private bool _isRunning = true;

    public void GameTest()
    {
       Maze.Generate(6, 6);
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