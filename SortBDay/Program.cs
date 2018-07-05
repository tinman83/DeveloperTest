using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortBDay
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string[] people = System.IO.File.ReadAllLines("people.txt");

                //Sort the file using bubblesort algorithm
                for (int i = 0; i < people.Length - 1; i++)
                {
                    for (int j = 0; j < people.Length - 1; j++)
                    {
                        string[] person = people[j].Split(char.Parse(","));  // Split person record to get array with Name and Birthdate
                        string[] nextPerson = people[j + 1].Split(char.Parse(","));

                        int compare = String.Compare(nextPerson[0], person[0], true); // Compare the Name part of the person string

                        if (compare < 0)
                        {
                            string temp = people[j];
                            people[j] = people[j + 1];
                            people[j + 1] = temp;

                        }

                    }
                }

                //Display sorted file and calculate Average Age
                int sumAge = 0;
                for (int i = 0; i < people.Length - 1; i++)
                {
                    Console.WriteLine(people[i]);

                    string[] person = people[i].Split(char.Parse(","));
                    DateTime dob;
                    if (DateTime.TryParse(person[1], out dob))
                    {
                        int age = DateTime.Now.Year - dob.Year;
                        sumAge += age;
                    }
                }

                Console.WriteLine("The Average age is {0}", (sumAge / people.Length));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
