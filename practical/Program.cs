using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using System.Linq;

[Serializable]
public class Fruit
{
    public string Name { get; set; }
    public string Color { get; set; }

    public Fruit(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public virtual void Input()
    {
        // Read data from the console
        Console.WriteLine("Enter fruit name:");
        Name = Console.ReadLine();
        Console.WriteLine("Enter fruit color:");
        Color = Console.ReadLine();
    }
    public virtual void Input(StreamReader streamReader)
    {
        Name = streamReader.ReadLine();
        Color = streamReader.ReadLine();
    }

    // Overloaded Print method to write to a stream
    public virtual void Print(StreamWriter streamWriter)
    {
        streamWriter.WriteLine($"Fruit: {Name}, Color: {Color}");
    }
    public virtual void Print()
    {
        // Output data to the console
        Console.WriteLine($"Fruit: {Name}, Color: {Color}");
    }

    public override string ToString()
    {
        return $"Fruit: {Name}, Color: {Color}";
    }
}

[Serializable]
public class Citrus : Fruit
{
    public double VitaminC { get; set; }

    public Citrus(string name, string color, double vitaminC) : base(name, color)
    {
        VitaminC = vitaminC;
    }

    public override void Input()
    {
        base.Input();
        Console.WriteLine("Enter content of Vitamin C in grams:");
        VitaminC = double.Parse(Console.ReadLine());
    }
    public override void Input(StreamReader streamReader)
    {
        base.Input(streamReader);
        if (double.TryParse(streamReader.ReadLine(), out double vitC))
        {
            VitaminC = vitC;
        }
        else
        {
            throw new InvalidDataException("Invalid data for Vitamin C content.");
        }
    }

    // Overload the Print method for Citrus to also write the Vitamin C content to a stream
    public override void Print(StreamWriter streamWriter)
    {
        base.Print(streamWriter);
        streamWriter.WriteLine($", Vitamin C content: {VitaminC} grams");
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($", Vitamin C content: {VitaminC} grams");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var fruits = new List<Fruit>
        {
            new Fruit("Apple", "Green"),
            new Fruit("Banana", "Yellow"),
            new Citrus("Lemon", "Yellow", 53),
            new Citrus("Orange", "Orange", 70),
            new Fruit("Grapes", "Purple")
        };

        // Print data about 'yellow' fruits
        fruits.Where(fruit => fruit.Color == "Yellow").ToList().ForEach(fruit => fruit.Print());

        // Sort the list of fruits by name
        fruits.Sort((fruit1, fruit2) => fruit1.Name.CompareTo(fruit2.Name));

        // Output the sorted list to a file
        try
        {
            using (var writer = new StreamWriter("sorted_fruits.txt"))
            {
                fruits.ForEach(fruit => writer.WriteLine(fruit.ToString()));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // Serialize the list to JSON
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(fruits, options);
        File.WriteAllText("fruits.json", jsonString);

        // Deserialize the list from JSON
        var deserializedFruits = JsonSerializer.Deserialize<List<Fruit>>(jsonString, options);

        // Add unit tests for class methods
        // This would be done in a separate testing framework like xUnit or NUnit

        var fruits1 = new List<Fruit>();

        // Read fruits from a file
        try
        {
            using (var reader = new StreamReader("fruits_input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    // Parse the line and create either a Fruit or Citrus object
                    // For the purpose of this example, let's assume we are creating a Fruit object
                    var parts = line.Split(',');
                    var fruit = new Fruit(parts[0], parts[1]);
                    fruits1.Add(fruit);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading from the file: {ex.Message}");
        }

        // Print fruits to a file
        try
        {
            using (var writer = new StreamWriter("fruits_output.txt"))
            {
                foreach (var fruit in fruits1)
                {
                    fruit.Print(writer);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
        }
    }
}
