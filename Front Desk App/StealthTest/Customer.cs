using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp
{
    internal class Customer
    {
        public string firstName;
        public string lastName;
        public string phoneNumber;
        

        public int totalsmallPackage = 0;
        public int totalmediumPackage = 0;
        public int totallargePackage = 0;
        static bool isForRelease = false;

        static int remainingAS;
        static int remainingAM;
        static int remainingAL;

        static int remainingBS;
        static int remainingBM;
        static int remainingBL;

        static int remainingCS;
        static int remainingCM;
        static int remainingCL;


        //for small size var
        public int totalSFacilityA = 0;
        public int totalSFacilityB = 0;
        public int totalSFacilityC = 0;

        //for medium size var
        public int totalMFacilityA = 0;
        public int totalMFacilityB = 0;
        public int totalMFacilityC = 0;

        //for large size var
        public int totalLFacilityA = 0;
        public int totalLFacilityB = 0;
        public int totalLFacilityC = 0;


        //function to store packages for each customer taking(size[s,m,l], number[how many packages], size of the chosen
        //facility, name of the chosen facility)
        public void StorePackage(string size, int num, int sizeOfFacility, string nameOfFacility)
        {
            
            string input = size.ToLower();
            string inputFacility = nameOfFacility.ToLower();

            if(input == "small" && sizeOfFacility >= num)
            {
                totalsmallPackage = totalsmallPackage + num;
                packagesInFacility(input, inputFacility, num, sizeOfFacility);

            }else if(input == "medium" && sizeOfFacility >= num)
            {
                totalmediumPackage = totalmediumPackage + num;
                packagesInFacility(input, inputFacility, num, sizeOfFacility);

            }
            else if(input == "large" && sizeOfFacility >= num)
            {
                totallargePackage = totallargePackage + num;
                packagesInFacility(input, inputFacility, num, sizeOfFacility);

            }
            else
            {
                Console.WriteLine("Invalid Size!");
            }

        }
        //function to releasae pachages for each customer taking (size of the package(s,m,l), number[how many packages to
        //release], size of the chosen facility and its name)
        public void ReleasePackage(string packageSize, int num, int sizeOfFacility, string nameOfFacility)
        {
            string input = packageSize.ToLower();
            string inputFacility = nameOfFacility.ToLower();
            
            if(input == "small" && sizeOfFacility >= num)
            {
                totalsmallPackage = totalsmallPackage - num;
                releasePackagesInFacility(input, inputFacility, num, sizeOfFacility);
            }
            else if(input == "medium")
            {
                totalmediumPackage = totalmediumPackage - num;
                releasePackagesInFacility(input, inputFacility, num, sizeOfFacility);
            }
            else if(input == "large")
            {
                totallargePackage = totallargePackage - num;
                releasePackagesInFacility(input, inputFacility, num, sizeOfFacility);
            }
            
        }

        //function to take package for each customer in each facility
        public void releasePackagesInFacility(string input, string nameOfFacility, int num, int sizeOfFacility)
        {
            string lowerNameofFacility = nameOfFacility.ToLower();
            switch(lowerNameofFacility)
            {
                case "facility a":
                    if (input == "small")
                    {
                        remainingAS = totalSFacilityA - num;
                        isForRelease = true;
                        totalSFacilityA = remainingAS;
                    }
                    else if(input == "medium")
                    {
                        remainingAM = totalMFacilityA - num;
                        isForRelease = true;
                        totalMFacilityA = remainingAM;
                    }
                    else if(input == "large")
                    {
                        remainingAL = totalLFacilityA - num;
                        isForRelease = true;
                        totalLFacilityA = remainingAL;
                    }
                    break;
                case "facility b":
                    if (input == "small")
                    {
                        remainingBS = totalSFacilityB - num;
                        isForRelease = true;
                        totalSFacilityB = remainingBS;  
                    }
                    else if (input == "medium")
                    {
                        remainingBM = totalMFacilityB - num;
                        isForRelease = true;
                        totalMFacilityB = remainingBM;
                    }
                    else if (input == "large")
                    {
                        remainingBL = totalLFacilityB - num;
                        isForRelease = true;
                        totalLFacilityB = remainingBL;
                    }
                    break;
                case "facility c":
                    if (input == "small" )
                    {
                        remainingCS = totalSFacilityC - num;
                        isForRelease = true;
                        totalSFacilityC = remainingCS;
                    }
                    else if (input == "medium")
                    {
                        remainingCM = totalMFacilityC - num;
                        isForRelease = true;
                        totalMFacilityC = remainingCM;
                    }
                    else if (input == "large")
                    {
                        remainingCL = totalLFacilityC - num;
                        isForRelease = true;
                        totalLFacilityC = remainingCL;
                    }
                    break;
                default:
                    Console.WriteLine("Facility not found!");
                    break;
            }
        }

        //function to take packages from each customer and specified what facility they want to store it
        public void packagesInFacility(string input, string nameOfFacility, int num, int sizeOfFacility)
        {
            string lowerNameOfFacility = nameOfFacility.ToLower();
            
            switch(lowerNameOfFacility)
            {
                case "facility a":
                    if (sizeOfFacility >= num && input == "small")                    
                        totalSFacilityA += num;
                    else if (sizeOfFacility >= num && input == "medium")
                        totalMFacilityA += num;
                    else if (sizeOfFacility >= num && input == "large")
                        totalLFacilityA += num;
                    break;
                case "facility b":
                    if (sizeOfFacility >= num && input == "small")
                        totalSFacilityB += num;
                    else if(sizeOfFacility >= num && input == "medium")
                        totalMFacilityB += num;
                    else if(sizeOfFacility >= num && input == "large")
                        totalLFacilityB += num;
                    break;
                case "facility c":
                    if (sizeOfFacility >= num && input == "small")
                        totalSFacilityC += num;
                    else if(sizeOfFacility >= num && input == "medium")
                        totalMFacilityC += num;
                    else if(sizeOfFacility >= num && input == "large")
                        totalLFacilityC += num;
                    break;
                default:
                    Console.WriteLine("Facility not found!");
                    break;
            }
           
        }
        // getting total and remaining of the small boxes in each facility per customer
        public int getSFacilityAList()
        {
            int total;
            if(isForRelease == false)
            {
                //total = sFacilityAList.Sum() - releaseCount;
                total = totalSFacilityA;
            }
            else
            {
                total = remainingAS;
            }

            isForRelease = false;
            return total;
        }

        public int getSFacilityBList()
        {
            int total;
            if (isForRelease == false)
            {
                //total = sFacilityAList.Sum() - releaseCount;
                total = totalSFacilityB;
            }
            else
            {
                total = remainingBS;
            }

            isForRelease = false;
            return total;
        }

        public int getSFacilityCList()
        {
            int total;
            if (isForRelease == false)
            {
                //total = sFacilityAList.Sum() - releaseCount;
                total = totalSFacilityC;
            }
            else
            {
                total = remainingCS;
            }

            isForRelease = false;
            return total;
        }

        //getting total and remaining of the medium boxes in each facility per customer
        public int getMFacilityAList()
        {
            int total;
            if (isForRelease == false)
            {
                //total = sFacilityAList.Sum() - releaseCount;
                total = totalMFacilityA;
            }
            else
            {
                total = remainingAM;
            }

            isForRelease = false;
            return total;
        }

        public int getMFacilityBList()
        {
            int total;
            if (isForRelease == false)
            {
                //total = sFacilityAList.Sum() - releaseCount;
                total = totalMFacilityB;
            }
            else
            {
                total = remainingBM;
            }

            isForRelease = false;
            return total;
        }

        public int getMFacilityCList()
        {
            int total;
            if (isForRelease == false)
            {
                //total = sFacilityAList.Sum() - releaseCount;
                total = totalMFacilityC;
            }
            else
            {
                total = remainingCM;
            }

            isForRelease = false;
            return total;
        }

        //getting total and remaining of the large boxes in each facility per customer
        public int getLFacilityAList()
        {
            int total;
            if (isForRelease == false)
            {
                //total = sFacilityAList.Sum() - releaseCount;
                total = totalLFacilityA;
            }
            else
            {
                total = remainingAL;
            }

            isForRelease = false;
            return total;
        }
        public int getLFacilityBList()
        {
            int total;
            if (isForRelease == false)
            {
                //total = sFacilityAList.Sum() - releaseCount;
                total = totalLFacilityB;
            }
            else
            {
                total = remainingBL;
            }

            isForRelease = false;
            return total;
        }
        public int getLFacilityCList()
        {
            int total;
            if (isForRelease == false)
            {
                //total = sFacilityAList.Sum() - releaseCount;
                total = totalLFacilityC;
            }
            else
            {
                total = remainingCL;
            }

            isForRelease = false;
            return total;
        }





    }
}
