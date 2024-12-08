namespace DGD203_BurakBisneli_Midterm;

public class Game 
{
    private bool _isRunning = true;
    private bool _mapGenerated = false;
    private List<Maze.Vector> _map;

    private string _playerName;

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
        
        while (!Maze.itemGiven)
        {
            int directionInput = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Maze.Print(_map);
                Console.WriteLine("Please enter the positions number you want to move:");
                Console.WriteLine("1. Up ");
                Console.WriteLine("2. Down ");
                Console.WriteLine("3. Left ");
                Console.WriteLine("4. Right ");
                string input = Console.ReadLine()!;
                
                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("Please enter a valid input.");
                else
                {
                    try
                    {
                        directionInput = Convert.ToInt32(input);
                        isValidInput = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid input.");
                    }
                }
            }
            Maze.UpdatePlayerPos(directionInput, _playerName);
            
        }
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Game is over. Thank you for playing!");
        Console.WriteLine("---------------------------------");
        Tools.WaitSeconds(4);
        
    }
}