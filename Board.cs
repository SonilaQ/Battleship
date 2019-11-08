using System;

namespace Field
{
    public class Board
    {
        public static int col_nr = 10;
        public static int row_nr = 10;
        public  string[,] field = new string[col_nr,row_nr];
 

        public Board(){
            
            setField();
        }

        public string[,] getField()
        {
            return field;
        }

        public void setField() // mbushja e field me simbolin '-'
        {
            field = new string[row_nr,col_nr];
            
            for(int i = 0; i<row_nr; i++)
            {
                for(int j = 0; j<col_nr; j++)
                {
                    field[i,j] = "-";
                }
            }
        }


        public void printBoard() //printimi i board
        {
            for(int i = 0; i<row_nr; i++)
            {
                Console.Write("|");
                for(int j = 0; j<col_nr; j++)
                {
                    // field[i,j] = "0";
                    Console.Write(""+field[i,j]+" | ");
                }
                Console.WriteLine("");
            }
        }

        //per anijen shenohen 1-sha ne board per sa njesi ka anija duke u nisur nga pozicioni fillestar 
        public bool addShip( Ship sh ) 
        {
            bool ok = true;
            int x = sh.GetPoint().X;
            int y = sh.GetPoint().Y;
            int l = sh.length;
            if( (y+l) < row_nr )  // nese anija mund te pozicionohet ne te djathte te pikes p
            {
                for(int j = y; j < y+l; j++)
                {
                    if(field[x,j] != "-")
                    {    
                        ok = false;
                        break;
                    }
                }
                
                if(ok)
                {
                    for(int j=y; j < y+l; j++)
                        field[x,j] = "1";

                    return true;

                }

                else ok= true;
            }

            else if( (y-l) >= 0 ) // ose nese anija mund te pozicionohet majtas pikes se fillimit p
            {
                for(int j = y; j > y-l; j--)
                {
                    if(field[x,j] == "1")
                    {    
                        ok = false;
                        break;
                    }

                }
                
                if(ok)
                {
                    
                    for(int j = y; j > y-l ; j--)
                    {
                        field[x,j] = "1";
                    }

                    return true;

                }

                else ok = true;


            }

            else if( (x+l) < col_nr ) // ose nese anija mund te pozicionohet larte pikes p 
            {
                for(int j = x; j < x+l ; j++)
                {
                    if(field[j,y] == "1")
                    {    
                        ok = false;
                        break;
                    }
                }
                
                if(ok)
                {
                    
                    for(int j = x; j < x+l ; j++)
                    {
                        field[j,y] = "1";
                    }

                    return true;

                }

                else ok = true;

            }

            else if( (x-l) > 0 ) // ose nese anija mund te pozicionohet poshte pikes p
            {
                for(int j = x; j > x-l; j--)
                {
                    if(field[j,y] =="1")
                    {    
                        ok = false;
                        break;
                    }
                }
                
                if(ok)
                {
                    for(int j = x; j > x-l; j--)
                        field[j,y] = "1";
                   
                    return true;

                }

                else ok = true;

            }
            
            return false;

        }

        //kontorlli nese ka akoma njesi anije (1) ne board
        public bool hasMore() 
        {
            for(int i = 0; i<row_nr; i++)
            {
                for(int j = 0; j<col_nr; j++)
                {
                    if(field[i,j] == "1")
                    {
                        return true;
                    }
                }
                
            }   

            return false;         
        }
    }
}