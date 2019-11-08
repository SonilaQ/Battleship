using System;

namespace Field
{
    public class Game
    {
        Player player1;
        Player player2;

        public Game()
        {
            player1 = new Player("First");

            player2 = new Player("Second");
        }

        public Game (Player p1 , Player p2)
        {
            player1 = p1;

            player2 = p2;

        }

        public void initilizeGame() //inicializimi i lojes
        {
            player1.GetBoard().setField();
            player2.GetBoard().setField();

        }

        public void playGame()
        {
            completeBoard(player1);

            completeBoard(player2);

            bool play = true;

            // deri sa nje prej lojtareve te kete gjtur te gjitha njesite e anijeve se kundershtarit
            while(true) 
            {


                if(!player1.canPlay(player2)) // kur jane gjetur te gjitha anijet e kundershtarit
                {
                    Console.WriteLine("\nFirst player is the winner. ");
                    break;
                }

                else if(!player2.canPlay(player1))
                {
                    Console.WriteLine("\nSecond player is the winner.");
                    break;    
                }

                // Console.WriteLine("\nFirst Player Turn: ");
                play = player1.play(player2);

                if(!play)  // vendoset rradha e lojes cdo lojtar luan deri sa te kete bere nje goditje te gabuar
                {
                    // Console.WriteLine("\nSecond Player Turn ");
                    play = player2.play(player1);
                
                }

            }
            Console.WriteLine("\nGame finished!");

        }

        //plotesimi dhe printimi i board
        public void completeBoard(Player p) 
        {
            p.setShips();
            Console.WriteLine("\nThe ships of the "+p.name+" Player:");
            p.GetBoard().printBoard();
        }
    }
}