using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Specify the path to the text file
            string filePath = "C:\\Users\\soums\\OneDrive\\Desktop\\Simplilear\\Student.txt";

            // Read all lines from the text file
            string[] lines = File.ReadAllLines(filePath);

            // Parse the lines into Student objects
            List<Student> students = ParseStudentData(lines);

            // Display header
            Console.WriteLine("Student Data:");

            // Display each student's information
            DisplayStudents(students);

            // Sort by name
            students = students.OrderBy(s => s.Name).ToList();

            // Display sorted data
            Console.WriteLine("\nStudent Data (Sorted by Name):");
            DisplayStudents(students);

            // Search for a student by name
            Console.Write("\nEnter a name to search: ");
            string searchName = Console.ReadLine();
            SearchAndDisplayStudent(students, searchName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // Wait for user input before closing the console window
        Console.ReadLine();
    }

    // Function to parse lines into Student objects
    static List<Student> ParseStudentData(string[] lines)
    {
        List<Student> students = new List<Student>();

        foreach (var line in lines)
        {
            string[] parts = line.Split(','); // Assuming the data is in the format "Name, Class"
            if (parts.Length == 2)
            {
                string name = parts[0].Trim();
                string className = parts[1].Trim();

                students.Add(new Student { Name = name, ClassName = className });
            }
        }

        return students;
    }

    // Function to display a list of students
    static void DisplayStudents(List<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}, {student.ClassName}");
        }
    }

    // Function to search for a student by name and display the result
    static void SearchAndDisplayStudent(List<Student> students, string searchName)
    {
        var result = students.FindAll(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

        if (result.Any())
        {
            Console.WriteLine("\nSearch Results:");
            DisplayStudents(result);
        }
        else
        {
            Console.WriteLine($"\nStudent with name '{searchName}' not found.");
        }
    }
}

// Student class to represent each student's data
class Student
{
    public string Name { get; set; }
    public string ClassName { get; set; }
}