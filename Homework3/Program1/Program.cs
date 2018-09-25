using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1

{
    public abstract class Shape
    {
        private string myId;
        public Shape(string s)
        {
            Id = s;
        }
    public string Id
    {
        get
        {
            return myId;
        }
        set
        {
            myId = value;
        }
    }
    public abstract double Area
    {
        get;
    }
    public virtual void Draw()
    {
        Console.WriteLine("Draw Shape Icon");
    }
    public override string ToString()
    {
        return Id + "Area=" + String.Format("{0:F2}", Area);
    }
}

    //正方形类
    public class Square:Shape
    {
        private int mySide;
        public Square(int side,string id):base(id)
        {
            mySide = side;
        }
        public override double Area
        {
            get
            {
                return mySide * mySide;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw 4 Side:" + mySide);
        }
    }

 
    //圆类
    public class Circle : Shape
    {
        private int myRadius;
        public Circle(int radius, string id) : base(id)
        {
            myRadius=radius;
        }
        public override double Area
        {
            get
            {
                return myRadius * myRadius * System.Math.PI;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw Circle:" + myRadius);
        }
    }


    //长方形类
    public class Rectangle : Shape
    {
        private int myWidth;
        private int myHeight;
        public Rectangle(int width,int height, string id) : base(id)
        {
            myWidth = width;
            myHeight = height;
        }
        public override double Area
        {
            get
            {
                return myHeight * myWidth;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw Rectangle");
        }
    }


    //三角形类
    public class Triangle : Shape
    {
        private int myEdge_a;
        private int myEdge_b;
        private int myEdge_c;
        public Triangle(int edge_a, int edge_b, int edge_c, string id) : base(id)
        {
            myEdge_a = edge_a;
            myEdge_b = edge_b;
            myEdge_c = edge_c;
        }
        public override double Area
        {
            get
            {
                int p = (myEdge_a + myEdge_b + myEdge_c) / 2;
                int i = p * (p - myEdge_a) * (p - myEdge_b) * (p - myEdge_c);
                return Math.Sqrt(i);
            }
        }
        public override void Draw()
        {
            Console.WriteLine("Draw Triangle");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes =
            {
                new Square(5,"Square"),
                new Circle(3,"Circle"),
                new Rectangle(4,5,"Rectangle"),
                new Triangle(3,4,5,"Triangle")
            };
            foreach(Shape s in shapes)
            {
                System.Console.WriteLine(s);
            }
        }
    }
}
