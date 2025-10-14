using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fr = new Fraction();
        Fraction fr2 = new Fraction(5);
        Fraction fr3 = new Fraction(3, 4);

        Console.WriteLine(fr.GetFractionString());
        Console.WriteLine(fr.GetDecimalValue());
        Console.WriteLine(fr2.GetFractionString());
        Console.WriteLine(fr2.GetDecimalValue());
        Console.WriteLine(fr3.GetFractionString());
        Console.WriteLine(fr3.GetDecimalValue());
    }
}