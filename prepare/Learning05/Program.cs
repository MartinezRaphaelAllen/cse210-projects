using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("red", 5));
        shapes.Add(new Rectangle("purple", 10, 4));
        shapes.Add(new Circle("yellow", 3.5));

        foreach (Shape s in shapes)
        {
            Console.WriteLine(s.GetColor());
            Console.WriteLine(s.GetArea());
        }
    }
}