// See https://aka.ms/new-console-template for more information
//Create a class called shapes

namespace ShapesNamespace{
public abstract class Shape{

    public string Name{get; set;}
    public virtual double CalculateArea(){
        return 0;
    }

}


public class Cirlce : Shape{
    private double Radius;

    public Cirlce(string name, double radius){
        Name = name;
        Radius = radius;
    }

 

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape{
    private double Width;
    private double Height;

    public Rectangle(string name, double Width, double Height){
        Name = name;
        this.Width = Width;
        this.Height = Height;
 
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}
public class Triangle : Shape{
    public double Base;
    public double Height;

    public Triangle(string name, double Base, double Height){
        Name = name;
        this.Base = Base;
        this.Height = Height;
 
    }



    public override double CalculateArea()
    {
        return (Base * Height)/2;
    }
}



}

namespace Application{
using  ShapesNamespace;

    public class Program{

        public static void printShape(Shape shape){
            Console.WriteLine($"name of the shape: { shape.Name} \n The area of the shape is: {shape.CalculateArea()}\n");
            
        }

        public static void Main(String[] args){
            Shape circle = new Cirlce("Circle", 5);
            Shape rectangle = new Rectangle("Rectangle", 5, 6);
            Shape triangle = new Triangle("Triangle", 5, 6);

            printShape(circle);
            printShape(rectangle);
            printShape(triangle);

        }
    }
}
 

