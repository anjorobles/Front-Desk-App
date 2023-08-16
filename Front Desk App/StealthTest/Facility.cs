using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp
{

    internal class Facility
    {
        public string name;
        public int smallSize;
        public int mediumSize;
        public int largeSize;

      /*  public void CheckAvailablity(string size)
        {
            string input = size.ToLower();
            if (input == "small")
            {
                Console.WriteLine(smallSize);
            }
            else if (input == "medium")
            {
                Console.WriteLine(mediumSize);
            }
            else if (input == "large")
            {
                Console.WriteLine(largeSize);
            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }
        }*/

        //functon to decrement the number of each box size in each facility taking (size of the box, and how many box)
        public void ReserveBox(string size, int num)
        {
           string input = size.ToLower();
            if(input == "small" && smallSize >= num)
            {
                for (int i = 1; i <= num; i++)
                {
                   smallSize--;
                }
                Console.WriteLine();
                Console.WriteLine("Customer Package Stored Successfully!");
            }
            else if (input == "medium" && mediumSize >= num)
            {
                for (int i = 1; i <= num; i++)
                {
                    mediumSize--;
                }
                Console.WriteLine();
                Console.WriteLine("Customer Package Stored Successfully!");
            }
            else if (input == "large" && largeSize >= num)
            {
                for (int i = 1; i <= num; i++)
                {
                    largeSize--;
                }
                Console.WriteLine();
                Console.WriteLine("Customer Package Stored Successfully!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid Input! Not enough space in the selected facility");
            }



        }

        //function to increment the number of each  box size in each facility
        public void ReleaseBox(string size, int num)
        {
            string input = size.ToLower();
            if (input == "small" && smallSize >= num)
            {
                for (int i = 1; i <= num; i++)
                {
                    smallSize++;
                }
                Console.WriteLine();
                Console.WriteLine("Customer Package Released Successfully!");
            }
            else if (input == "medium" && smallSize >= num)
            {
                for (int i = 1; i <= num; i++)
                {
                    mediumSize++;
                }
                Console.WriteLine();
                Console.WriteLine("Customer Package Released Successfully!");
            }
            else if (input == "large" && smallSize >= num)
            {
                for (int i = 1; i <= num; i++)
                {
                    largeSize++;
                }
                Console.WriteLine();
                Console.WriteLine("Customer Package Released Successfully!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid Input!");
            }
        }

    }
}
