using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 13, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine("--------------------Sum--------------------");
            double sum = numbers.Sum();
            Console.WriteLine(sum);

            //TODO: Print the Average of numbers
            Console.WriteLine("--------------------Average--------------------");
            double average = sum / numbers.Length;
            Console.WriteLine(average);
            //OR
            Console.WriteLine("OR (Another way to do it, output same)");
            Console.WriteLine(numbers.Average());

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("--------------------Ascending Order--------------------");
            numbers.OrderBy(x => x)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in decsending order adn print to the console
            Console.WriteLine("--------------------Decsending Order--------------------");
            numbers.OrderByDescending(x => x)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("--------------------Greater than 6--------------------");
            numbers.Where(x => x > 6)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            
            var randomNumber1 = new Random();

            var number1 = Enumerable.Range(randomNumber1.Next(0, 10), 4);

            foreach (var num1 in number1)
            {
                Console.WriteLine(num1);
            }
            //OR

            //foreach (var number in numbers.OrderByDescending(x => x).Take(4))
            //{
            //    Console.WriteLine(number);
            //}

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("--------------------Printing number desc order--------------------");
            var randomNumber2 = new Random();

            var number2 = Enumerable.Range(randomNumber2.Next(0, 10), 4);

            foreach (var num2 in number2)
            {
                Console.WriteLine(num2);
            }
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();



            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            Console.WriteLine("--------------------FirstNames with c or s--------------------");
            var filter = employees.Where(person => person.FirstName.ToLower().StartsWith("c") || person.FirstName.ToLower().StartsWith("s"))
                .OrderBy(person => person.FirstName);
            foreach (var name in filter)
            {
                Console.WriteLine(name.FullName);
            }

            //(Note for self)Instead of foreach you can do:
            // .ToList
            // .ForEach(x => Console.WriteLine(person.FirstName)


            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            Console.WriteLine("--------------------Employee ages over 26--------------------");
            var over26 = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age)
                .ThenBy(person => person.FirstName);
            foreach (var age in over26)
            {
                Console.Write(age.FullName + " ");
                Console.WriteLine(age.Age);
            }

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("--------------------Average of: age > 35 and exp < 10yrs--------------------");
            var yrsOfExp = employees.Where(person => person.Age > 35 && person.YearsOfExperience <= 10);
            var theAverage = employees.Average(person => person.YearsOfExperience);
            var theSum = employees.Sum(person => person.YearsOfExperience);
            Console.WriteLine("Sum: " + theSum);
            Console.WriteLine("Average: " + theAverage);

            //TODO: Add an employee to the end of the list without using employees.Add()

            Console.WriteLine("----------Adding name to list(not using Add())----------");
            employees = employees.Append(new Employee("Andre", "Renaud", 32, 6))
                .ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FullName);
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
