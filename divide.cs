using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the first number: ");
        string input1 = Console.ReadLine();
        Console.Write("Enter the second number: ");
        string input2 = Console.ReadLine();

        try
        {
            int number1 = Convert.ToInt32(input1);
            int number2 = Convert.ToInt32(input2);
            int result = Divide(number1, number2);
            Console.WriteLine($"The result of {number1} / {number2} is: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid integers.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: The number entered is too large or too small for an int.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static int Divide(int x, int y)
    {
        return x / y;
    }
}
