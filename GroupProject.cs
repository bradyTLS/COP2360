using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        // Dictionary Creation
        Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Select an option");
            Console.WriteLine("===========================");
            Console.WriteLine("1. Populate the Dictionary");
            Console.WriteLine("2. Display Dictionary Contents");
            Console.WriteLine("3. Remove a Key");
            Console.WriteLine("4. Add a New Key and Value");
            Console.WriteLine("5. Add a Value to an Existing Key");
            Console.WriteLine("6. Sort the Keys");
            Console.WriteLine("7. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Populate the dictionary with some initial key-value pairs
                    myDictionary.Add("Fruit", new List<string> { "Apple", "Banana" });
                    myDictionary.Add("Vegetable", new List<string> { "Carrot", "Broccoli" });
                    Console.WriteLine("Dictionary populated with default values.");
                    break;

                case "2":
                    // Display dictionary contents
                    Console.WriteLine("Dictionary Contents:");
                    foreach (var kvp in myDictionary)
                    {
                        Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
                    }
                    break;

                case "3":
                    // Remove a key
                    Console.Write("Enter key to remove: ");
                    string keyToRemove = Console.ReadLine();
                    if (myDictionary.ContainsKey(keyToRemove))
                    {
                        myDictionary.Remove(keyToRemove);
                        Console.WriteLine($"Key '{keyToRemove}' removed.");
                    }
                    else
                    {
                        Console.WriteLine("Key not found.");
                    }
                    break;

                case "4":
                    // Add a new key and value
                    Console.Write("Enter a new key: ");
                    string newKey = Console.ReadLine();
                    Console.Write("Enter values (comma separated): ");
                    string valuesInput = Console.ReadLine();
                    List<string> newValues = new List<string>(valuesInput.Split(','));

                    myDictionary.Add(newKey, newValues);
                    Console.WriteLine($"Added '{newKey}' with values: {string.Join(", ", newValues)}");
                    break;

                case "5":
                    // Add a value to an existing key
                    Console.Write("Enter the key to append value to: ");
                    string keyToAdd = Console.ReadLine();
                    if (myDictionary.ContainsKey(keyToAdd))
                    {
                        Console.Write("Enter value to add: ");
                        string valueToAdd = Console.ReadLine();
                        myDictionary[keyToAdd].Add(valueToAdd);
                        Console.WriteLine($"Added '{valueToAdd}' to key '{keyToAdd}'.");
                    }
                    else
                    {
                        Console.WriteLine("Key not found.");
                    }
                    break;

                case "6":
                    // Sort the keys in the dictionary
                    Console.WriteLine("Sorted Keys:");
                    foreach (var key in myDictionary.Keys.OrderBy(k => k))
                    {
                        Console.WriteLine(key);
                    }
                    break;

                case "7":
                    // Exit the program
                    exit = true;
                    Console.WriteLine("Exiting program.");
                    break;

                default:
                    Console.WriteLine("ERROR, Try Again:");
                    break;
            }
        }
    }
}
