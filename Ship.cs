using System.Drawing;

namespace Field
{
    public class Ship 
    {
        static Point start ;
        public int length;

        public Ship(){}
        public Ship(int x, int y , int l)
        {
            setStart(x , y);
            this.length = l;
        }

        public Point GetPoint()
        {
            return start;
        }

        public void setStart(int x, int  y)
        {
            start.X = x;
            start.Y = y;

        }
    }
}