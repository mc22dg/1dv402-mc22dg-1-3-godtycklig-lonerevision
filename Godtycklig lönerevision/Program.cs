﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godtycklig_lönerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSalaries;

            //Do-while-loop som kontrollerar så att användaren inte skriver in färre än 2 löner.
            do
            {
                //Skickar anrop till metoden ReadInt tillsammans med argument.
                numberOfSalaries = ReadInt("Ange antal löner att mata in: ");

                //Här får användaren felmeddelande om han/hon angett färre än två löner.
                if (numberOfSalaries < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning!");
                    Console.ResetColor();
                }
                else
                {
                    //Skickar anrop till metoden ProcessSalaries tillsammans med argument.
                    ProcessSalaries(numberOfSalaries);

                    Console.WriteLine();
                }

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tryck tangent för ny beräkning - Escape avslutar.");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }


        static void ProcessSalaries(int count)
        {
            int countSalaries = 0;
            int medianSalary = 0;
            int maxSalary = 0;
            int minSalary = 0;
            int salarySpred = 0;

            int[] salaries = new int[count];
            int[] salariesSorted = new int[count];

            //Här loopas arrayen och metoden ReadInt körs.
            for (int i = 0; i < count; i++)
            {
                salaries[i] = ReadInt(String.Format("Ange lön nummer {0}: ", i + 1));

                salariesSorted[i] = salaries[i];
            }

            //Här sorteras arrayen. 
            Array.Sort(salariesSorted);

            maxSalary = salariesSorted.Max();
            minSalary = salariesSorted.Min();
            salarySpred = maxSalary - minSalary;

            countSalaries = salariesSorted.Count();

            //Här räknas medianen ut.
            int l = salariesSorted.Count() / 2;

            if (countSalaries % 2 == 0)
            {
                medianSalary = (salariesSorted[l - 1] + salariesSorted[l]) / 2;
            }
            else
            {
                medianSalary = salariesSorted[l];
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Medianlön:               {0:c0}", medianSalary);
            Console.WriteLine("Medellön:                {0:c0}", salaries.Average());
            Console.WriteLine("Lönespridning:           {0:c0}", salarySpred);
            Console.WriteLine("----------------------------------");
            Console.WriteLine();

            //Här listas lönerna med tre löner i varje lista.
            for (int i = 1; i <= count; i++)
            {
                //Här ljusteras utskriften av lönerna så att de hamnar snyggt.
                Console.Write("{0,5}   ", salaries[i - 1]);

                if (i % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        static int ReadInt(string prompt)
        {
            int readInt;
            string input = null;

            while (true)
            {
                try
                {
                    //Översätter inmatat värde till en int-variabel.
                    Console.Write(prompt);
                    input = Console.ReadLine();
                    readInt = int.Parse(input);

                    //If-satsen kontrollerar att summan som matas in är högre än noll.
                    if (readInt < 1)
                    {
                        Console.WriteLine("Du måste ange ett höre tal än 0.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    //Ifall det inte fungerade så kommer detta att köras istället.
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! {0} Det du angivet är felaktigt.", input);
                    Console.ResetColor();
                }
            }

            return readInt;
        }
    }
}




