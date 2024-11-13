using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Student
    {
        
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        
        public Student(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }

        
        public abstract bool IsPassed(double grade);
    }

    public class Undergraduate : Student
    {
        
        public Undergraduate(string name, int studentId, double grade): base(name, studentId, grade)
        {
        }

        
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;  
        }
    }

    public class Graduate : Student
    {

        public Graduate(string name, int studentId, double grade): base(name, studentId, grade)
        {
        }
        

        
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;  
        }
    }

    class Program
    {
        static void Main()
        {
            
            Student undergrad = new Undergraduate("somu", 189, 85.3);
            Console.WriteLine($"Undergraduate Student: {undergrad.Name}");
            Console.WriteLine($"Student ID: {undergrad.StudentId}");
            Console.WriteLine($"Grade: {undergrad.Grade}");
            Console.WriteLine($"Passed: {undergrad.IsPassed(undergrad.Grade)}");
            

            
            Student grad = new Graduate("sekhar", 283, 85);
            Console.WriteLine($"Graduate Student: {grad.Name}");
            Console.WriteLine($"Student ID: {grad.StudentId}");
            Console.WriteLine($"Grade: {grad.Grade}");
            Console.WriteLine($"Passed: {grad.IsPassed(grad.Grade)}");
            Console.Read();
        }
    }
}   
    
        
    

