using System;
using System.Drawing;

namespace Field
{
    public class Player
    {
        static int[] shipsLengths = {1,2,3,3,4,5};
        // static int shipNo = 6;
        public string name;
        Board board;

         int score;

        public Player(string n)
        {
            name = n;
            board = new Board();
        }

        public Board GetBoard()
        {
            return board;
        }

        public int getScore()
        {

            return score;

        }

        //vendosja e anijeve te lojtarit ne board 
        public void setShips() 
        {
            Ship ship;
            int x =0;
            int y =0;
            int i=0;
               
            Random rand = new Random();

            while(i < shipsLengths.Length) //per te gjitha anijet 
            {

                x = rand.Next(0,9);

                y = rand.Next(0,9);

                ship = new Ship(x,y,shipsLengths[i]);
                bool add = board.addShip(ship);

                if(!add)
                {
                    i--;
                }
                    i++;

            }

        }

        //loja e lojtarit qe gjen random nje pike per te sulmuar
        public bool play(Player p2)
        {
            Random rand = new Random();

            int x;
            int y;

            while(true)
            {
                x = rand.Next(0,9);

                y = rand.Next(0,9);

                if (p2.GetBoard().getField()[x, y] == "1") // nese lojtari gjen nje nejsi te anijes se kundershtarit
                {
                    Console.WriteLine(" "+name+" Player guessed: ");

                    p2.GetBoard().getField()[x,y] = "X";   //ajo njesi markohet me X
                    p2.GetBoard().printBoard();
                    Console.WriteLine("\n");
                    score++;

                }

                else //lojtari e humb rradhen
                {
                    // Console.WriteLine(name+" Player missed");
                    p2.GetBoard().getField()[x,y] = "M"; //nese gjen te gabuar markohet me M
                    break;
                }


            }
            
            return false;

        }

        //nese lojtari e ka mbaruar ose jo lojen 
        public bool canPlay(Player p2)
        {
            
            if(p2.GetBoard().hasMore())
                return true;

            return false;

        }


    }
}