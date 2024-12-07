namespace DGD203_BurakBisneli_Midterm;

public class Game 
{
    private bool _isRunning = true;
    private bool _mapGenerated = false;
    private List<Maze.Vector> _map;

    public void GameTest()
    {
        while (!_mapGenerated) // I use ChatGPT for this my code giving error sometimes and I want to avoid that and try again.
        {
            try
            {
                _map = Maze.Generate(20, 20, 5);
                
                _mapGenerated = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        Maze.Print(_map);
        
        
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