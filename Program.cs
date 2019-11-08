using System;

namespace Field
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();

            while(true)
            {
                game.initilizeGame();

                game.playGame();
            
                Console.WriteLine("If you want to play again clik 1 or any other key to exit the game");
                string input = Console.ReadLine();

                if(input != "1")
                    break;
            }


            Console.ReadKey();
        }



        
    }
}
