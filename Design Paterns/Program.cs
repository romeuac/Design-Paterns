using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Design_Paterns
{
    // Sem o VIRTUAL E OVERRIDE  o novo set na classe herdada (Square) nao funciona ao realizar uma operacao de Upcasting (necessário trocar o NEW pelo OVERRIDE e adicionar o VITURAL na classe mae
    public class Rectangle
    {
        public virtual int Width { get; set; }
        //public int Width { get; set; }
        public virtual int Height { get; set; }
        //public int  Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            this.Height = height;
            this.Width = width;
        }

        public override string ToString() => $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
    }

    public class Square : Rectangle
    {
        //public new int Width
        public override int Width
        {
            set => base.Width = base.Height = value;
        }

        //public new int Height
        public override int Height
        {
            set => base.Height = base.Width = value;
        }
    }

    class Program
    {
        static public int area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine($"{rc} has area {area(rc)}");

            Square sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {area(sq)}");    
        }

    }
}
