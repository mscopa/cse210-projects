using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("red", 5);
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("blue", 12, 5);
        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());
        shapes.Add(rectangle);

        Circle circle = new Circle("green", 3);
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());
        shapes.Add(circle);
        
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}