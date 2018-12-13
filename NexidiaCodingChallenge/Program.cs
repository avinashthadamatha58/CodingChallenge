using System;
using System.Collections.Generic;
using System.IO;

namespace NexidiaCodingChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            HandlingExceptions(args); //ToDO make argument readonly
        }

        public static void HandlingExceptions(string[] args)
        {
            try
            {
                Console.WriteLine("Assumptions: \n1. Only one argument(File path) is given \n2. The path to a file is a text file \n3) Numbers of size greater than 64 bits are considered as string\n");

                if (!File.Exists(args[0]))
                {
                    throw new FileNotFoundException("File is not found, please enter a valid path");
                }
                if (!Path.GetExtension(args[0]).Equals(".txt"))
                {
                    Console.WriteLine("Please enter a file name with .txt extension");
                    return;
                }
                if (new FileInfo(args[0]).Length == 0)
                {
                    Console.WriteLine("File does not contain any data, please enter a different file path");
                    return;
                }
                PrimeFactorsInaFile(args);
            }

            catch (FileNotFoundException fileNotFound)
            {
                Console.WriteLine(fileNotFound.FileName + " " + fileNotFound.Message);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Please provide command line arguments first");
            }
            catch (Exception)
            {
                Console.WriteLine("File error, please try entering a different file");
            }
        }

        public static void PrimeFactorsInaFile(string[] args)
        {
            string[] textArray = System.IO.File.ReadAllLines(args[0]); //Automatically opens, reads, and closes the file
            foreach (string Line in textArray)
            {
                {                                                    //fileExists, fileformat, FileOpeningorNotToDo, FileContentNull, - check read permission
                    if (Int64.TryParse(Line, out Int64 parsedVar) && parsedVar > 1)
                    {
                        Console.Write(Line + "  -  ");
                        WritePrimeFactors(CalculatePrimeFactors(parsedNum: parsedVar));
                    }
                    else
                    {
                        //if (parsedVar <= 0 && parsedVar>= -Int64.MaxValue)
                        //{
                        //    Console.WriteLine(Line + "  -  is neither prime nor composite");
                        //}
                        //else if (CheckStringForBigNum(Line))
                        //{
                        //    Console.WriteLine(Line + "  -  Please enter a smaller number");
                        //}
                        //else
                        Console.WriteLine(Line + "  -  " + "No prime factors");
                    }
                }
            }
        }
        //private static bool CheckStringForBigNum(string eachLine)
        //{
        //    foreach (char c in eachLine)
        //    {
        //        if (c < '0' || c > '9')
        //            return false;
        //    }
        //    return true;
        //}
       public static List<long> CalculatePrimeFactors(long parsedNum)
        {
            List<long> primeFactorsList = new List<long>();

            parsedNum = AddTwosToList(parsedNum, primeFactorsList);
            parsedNum = AddOtherFactors(parsedNum, primeFactorsList);

            if (parsedNum > 1) primeFactorsList.Add(parsedNum);       // If num is not 1, then whatever is left is prime.

            return primeFactorsList;
        }

        public static long AddTwosToList(long parsedNum, List<long> primeFactorsList)
        {
            try
            {
                while (parsedNum % 2 == 0 && parsedNum > 0)        // Checking if number is divided by 2 and adding 2 to List
                {
                    primeFactorsList.Add(2);
                    parsedNum /= 2;
                }
                return parsedNum;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Arguments");
                return parsedNum;
            }
            }

        public static long AddOtherFactors(long parsedNum, List<long> primeFactorsList)
        {
            long factor = 3;         // Take out other primes.
            while (factor * factor <= parsedNum)
            {
                if (parsedNum % factor == 0)
                {
                    primeFactorsList.Add(factor);         // This is a factor
                    parsedNum /= factor;
                }
                else
                {
                    factor += 2;        // Go to next odd number
                }
            }
            return parsedNum;
        }


        public static void WritePrimeFactors(List<long> result)
        {
            int count = result.Count;
            for (int i = 0; i < result.Count; i++)
            {
                if (i == result.Count - 1)
                {
                    Console.Write(result[i]);
                }
                else
                {
                    Console.Write(result[i] + ", ");
                }
            }
            Console.WriteLine("");
        }
    }
}