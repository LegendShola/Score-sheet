// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Score_sheet
{
    class Program
    {
        static void Main(string[] args )
        {
            string filePath = @"C:\Student scores.txt";

            List<Pupils> pupil = new List<Pupils>();
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split('-');
                Pupils newpupil = new Pupils();

                newpupil.Names = entries[0];
                newpupil.Marks = int.Parse(entries[1]);

                pupil.Add(newpupil);
            }
            pupil.ForEach(X => Console.WriteLine($"{X.Names}\t{X.Marks}"));

            Console.WriteLine("\t\t\tNew Score sheet after Bonus Mark");
            foreach (var item in pupil)
            {
                if (item.Marks >= 50)
                {
                    item.Marks += 5;
                }
                if (item.Marks < 50)
                {
                    item.Marks += 10;
                }
                Console.WriteLine($"{item.Names}\t\t\t-\t\t\t{item.Marks}");
            }
            Console.ReadKey();
        }

    }
}

