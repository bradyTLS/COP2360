using System;

class Octopus
{
    // Readonly field
    public readonly string Name;

    // Public field with an initial value
    public int Age = 10;

    // Static readonly fields (constants scoped to the class)
    public static readonly int Legs = 8;
    public static readonly int Eyes = 1;

    // Constructor to initialize readonly field
    public Octopus(string name)
    {
        Name = name;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating an instance of Octopus
        var o = new Octopus("Jack");

        // Displaying values of the fields
        Console.WriteLine("Octopus Name: " + o.Name);
        Console.WriteLine("Octopus Age: " + o.Age);
        Console.WriteLine("Octopus Legs: " + Octopus.Legs);
        Console.WriteLine("Octopus Eyes: " + Octopus.Eyes);

        // Modifying the Age field (allowed since it's not readonly)
        o.Age = 12;
        Console.WriteLine("Modified Octopus Age: " + o.Age);

        // Trying to modify readonly fields will result in compile-time error
        // o.Name = "New Name";  // Uncommenting this will cause an error
        // Octopus.Legs = 20;    // Uncommenting this will cause an error
    }
}
