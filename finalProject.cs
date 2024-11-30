using System;
using System.Collections.Generic;

class Contractor
{
    private string contractorName;
    private int contractorNumber;
    private DateTime contractorStartDate;

    public Contractor(string name, int number, DateTime startDate)
    {
        contractorName = name;
        contractorNumber = number;
        contractorStartDate = startDate;
    }

    public string ContractorName
    {
        get { return contractorName; }
        set { contractorName = value; }
    }

    public int ContractorNumber
    {
        get { return contractorNumber; }
        set { contractorNumber = value; }
    }

    public DateTime ContractorStartDate
    {
        get { return contractorStartDate; }
        set { contractorStartDate = value; }
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Contractor Name: {contractorName}");
        Console.WriteLine($"Contractor Number: {contractorNumber}");
        Console.WriteLine($"Start Date: {contractorStartDate.ToShortDateString()}");
    }
}

class Subcontractor : Contractor
{
    private int shift;
    private double hourlyPayRate;

    public Subcontractor(string name, int number, DateTime startDate, int shift, double hourlyPayRate)
        : base(name, number, startDate)
    {
        this.shift = shift;
        this.hourlyPayRate = hourlyPayRate;
    }

    public int Shift
    {
        get { return shift; }
        set
        {
            if (value == 1 || value == 2)
                shift = value;
            else
                throw new ArgumentException("Shift must be 1 (day) or 2 (night).");
        }
    }

    public double HourlyPayRate
    {
        get { return hourlyPayRate; }
        set
        {
            if (value >= 0)
                hourlyPayRate = value;
            else
                throw new ArgumentException("Hourly pay rate must be non-negative.");
        }
    }

    public float ComputePay(float hoursWorked)
    {
        float pay = (float)(hoursWorked * hourlyPayRate);
        if (shift == 2)
        {
            pay += pay * 0.03f;
        }
        return pay;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Shift: {(shift == 1 ? "Day" : "Night")}");
        Console.WriteLine($"Hourly Pay Rate: {hourlyPayRate:C}");
    }
}

class Program
{
    static void Main()
    {
        List<Subcontractor> subcontractors = new List<Subcontractor>();

        Console.WriteLine("Subcontractor Management Program\n");

        char choice;
        do
        {
            Console.Write("Enter Contractor Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Contractor Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter Contractor Start Date (YYYY-MM-DD): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Shift (1 for Day, 2 for Night): ");
            int shift = int.Parse(Console.ReadLine());

            Console.Write("Enter Hourly Pay Rate: ");
            double hourlyRate = double.Parse(Console.ReadLine());

            subcontractors.Add(new Subcontractor(name, number, startDate, shift, hourlyRate));

            Console.Write("Do you want to add another subcontractor? (y/n): ");
            choice = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine("\n");
        } while (choice == 'y');

        foreach (var subcontractor in subcontractors)
        {
            Console.WriteLine("\nSubcontractor Details:");
            subcontractor.DisplayDetails();

            Console.Write("Enter hours worked: ");
            float hoursWorked = float.Parse(Console.ReadLine());

            Console.WriteLine($"Total Pay: {subcontractor.ComputePay(hoursWorked):C}");
        }

        Console.WriteLine("\nProgram finished.");
    }
}
