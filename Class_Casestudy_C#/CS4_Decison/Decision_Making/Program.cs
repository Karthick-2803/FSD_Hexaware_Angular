using System;
using System.Net.Http.Headers;

namespace Decision_Making
{
    //decision making:3
    internal class Program
    {
        static void Main(string[] args)
        {
            string Password = "CSharp@123";
            int attempts = 3;

        Retry:
            Console.WriteLine("Enter the Password:");
            string ps = Console.ReadLine();

            if (Password == ps)
            {
                Console.WriteLine("Acess granted");
            }
            else
            {
                attempts--;
                if (attempts > 0)
                {
                    Console.WriteLine($"Incorrect Password! {attempts} attempts left.");
                    goto Retry;
                }
                else
                {
                    Console.WriteLine("Account Locked!");
                }
            }

        }
    }

    //decision making:4
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the bill Amount:");
            double amount = Convert.ToDouble(Console.ReadLine());

            double ans = (amount > 5000) ? amount * 0.80 : amount;

            Console.WriteLine(ans);
        }
    }

    //looping: 1
    internal class Program
    {
        static void Main(string[] args)
        {
            double salary = Convert.ToDouble(Console.ReadLine());
            double incrPer = Convert.ToDouble(Console.ReadLine());

            for (int yr = 1; yr <= 5; yr++)
            {
                salary = salary + (salary * incrPer / 100);
                Console.WriteLine($"Salary increemented for the next 5 years:{yr}:{salary}");
            }

        }
    }

    //looping: 2
    internal class Program
    {
        static void Main(string[] args)
        {
            double stockprice = Convert.ToDouble(Console.ReadLine());
            double targetprice = Convert.ToDouble(Console.ReadLine());
            int Day = 1;

            while (stockprice < targetprice)
            {
                stockprice = stockprice + 5;
                Console.WriteLine($"{Day}:Stock Price = Rs.{stockprice}");
                Day++;

            }
            Console.WriteLine($"\nStock price exceeded ₹{targetprice} on Day {Day - 1}");

        }
    }

    //looping: 3
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] products = { "Laptop", "Smartphone", "Headphones", "Tablet", "Smartwatch" };
            string[] outOfStock = { "Smartphone", "Tablet" };

            Console.WriteLine("Checking product availability:\n");

            foreach (string product in products)
            {
                bool isOutOfStock = false;

                foreach (string item in outOfStock)
                {
                    if (product == item)
                    {
                        isOutOfStock = true;
                        break;
                    }
                }

                if (isOutOfStock)
                    Console.WriteLine($"{product}: Out of Stock");
                else
                    Console.WriteLine($"{product}: In Stock");
            }
        }
    }
    //Arrays:1
    internal class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            string[] products = new string[size];

            string search = Console.ReadLine();

            for (int i = 0; i < size; i++)
            {
                products[i] = Console.ReadLine();
            }
            bool found = false;

            for (int i = 0; i < size; i++)
            {
                if (products[i] == search)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                Console.WriteLine("Product Available");
            }
            else
            {
                Console.WriteLine("Out of Stock");
            }
        }

    }

    //Arrays:2

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] students = { "Alice", "Bob", "Charlie" };
            int[,] marks = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter marks for {students[i]} (Math English Science):");
                for (int j = 0; j < 3; j++)
                {
                    marks[i, j] = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Student: {students[i]}");
                Console.Write("Marks: ");
                int total = 0;

                for (int j = 0; j < 3; j++)
                {
                    Console.Write(marks[i, j] + " ");
                    total += marks[i, j];
                }

                double average = total / 3.0;

                Console.WriteLine($"\nTotal: {total}");
                Console.WriteLine($"Average: {average:F2}\n");
            }

        }
    }

    //Arrays :3
    internal class Program
    {
        static void Main()
        {
            string[] subjects = { "Math", "Science", "English" };

            int[][] scores = new int[3][];
            scores[0] = new int[] { 80, 85, 90 };          
            scores[1] = new int[] { 75, 78 };              
            scores[2] = new int[] { 88, 84, 79, 91 };     

            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine($"Subject: {subjects[i]}");
                Console.Write("Scores: ");

                int total = 0;

                foreach (int score in scores[i])
                {
                    Console.Write(score + " ");
                    total += score;
                }

                double average = (double)total / scores[i].Length;
                Console.WriteLine($"\nAverage: {average:F2}\n");
            }
        }
    }
}
