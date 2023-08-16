using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace FrontDeskApp
{
    internal class Program
    {
        public static List<Customer> customerList = new List<Customer>();
        public static List<Facility> facilityList = new List<Facility>();
        public static bool validInput = false;
        public static bool validInputNumber = false;


        static void Main(string[] args)
        {
            
            inputFacilities(); 
            
            DisplayInterface();
            
        }

        //function to input facilities in a list
        public static void inputFacilities()
        {
            Facility facilityA = new Facility();
            Facility facilityB = new Facility();
            Facility facilityC = new Facility();
            
            facilityA.name = "FACILITY A";
            facilityA.smallSize = 44;
            facilityA.mediumSize = 14;
            facilityA.largeSize = 12;
            facilityList.Add(facilityA);

            facilityB.name = "FACILITY B";
            facilityB.smallSize = 44;
            facilityB.mediumSize = 14;
            facilityB.largeSize = 12;
            facilityList.Add(facilityB);

            facilityC.name = "FACILITY C";
            facilityC.smallSize = 44;
            facilityC.mediumSize = 14;
            facilityC.largeSize = 12;
            facilityList.Add(facilityC);
        }

        //function to display the interface of the application
        public static void DisplayInterface()
        {
            Console.WriteLine("----WELCOME TO FRONT DESK APP---");
            Console.WriteLine("1: Customer Section");
            Console.WriteLine("2. Check Available Facility");
            Console.WriteLine("3. Quit");
            Console.WriteLine("--------------------------------");
            int input;
            do
            {
                Console.Write("Enter 1-3: ");
                if(int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1:
                            Console.Clear();
                            CustomerSection();
                            break;
                        case 2:
                            showAvailableFacility();
                            break;
                        case 3:
                            ExitProgram();
                            Environment.Exit(0);
                            validInput = true;
                            break;
                        default:
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }

            } while(!validInput);

           
        }

        //function for customer section
        public static void CustomerSection() 
        {
            bool continueToloop = true;
            while(continueToloop)
            {
                Console.WriteLine("-------CUSTOMER SECTION---------");
                Console.WriteLine("1. Input Customer Information");
                Console.WriteLine("2. Store Customer Packages");
                Console.WriteLine("3. Show Customer Information");
                Console.WriteLine("4. Release Customer Packages");
                Console.WriteLine("5. Back");
                Console.WriteLine("--------------------------------");

                int input;

                do
                {
                    Console.Write("Enter 1-5: ");
                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        switch (input)
                        {
                            case 1:
                                CreateCustomer();
                                break;
                            case 2:
                                StorePackage();
                                break;
                            case 3:
                                ShowCustomerInformation();
                                break;
                            case 4:
                                ReleasePackages();
                                break;
                            case 5:
                                Console.WriteLine("Going back to Main Menu. Please wait...");
                                Thread.Sleep(2000);
                                Console.Clear();
                                DisplayInterface();
                                
                                continueToloop = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                        
                    }
                } while (continueToloop);

            }
            
        }

        //function for display the customer section again 
        public static void CustomerSectionCallBack()
        {
            Thread.Sleep(2000);
            Console.Clear();
            CustomerSection();
        }

        //function to input customer information and make an account
        public static void CreateCustomer()
        {
            Customer customer = new Customer();
            
            string firstNameInputCC, lastNameInputCC;

            Console.WriteLine();
            Console.WriteLine("---INPUT CUSTOMER INFORMATION---");
            do
            {
                //for name input
                Console.Write("Enter First Name: ");
                firstNameInputCC = Console.ReadLine();
                customer.firstName = firstNameInputCC;

                Console.Write("Enter Last Name: ");
                lastNameInputCC = Console.ReadLine();
                customer.lastName = lastNameInputCC;
                
                if (!IsStringOfLetters(firstNameInputCC) && !IsStringOfLetters(lastNameInputCC))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Please enter a string of letters only.");
                    Console.Write("Please wait...");
                    CustomerSectionCallBack();
                }
                else
                {
                    validInput = true;
                }

            } while (!validInput);

            do
            {
                Console.Write("Enter Phone Number: ");
                var phoneNumberInput = Console.ReadLine();
                customer.phoneNumber = phoneNumberInput;
                if(!IsNumericInput(phoneNumberInput))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid phone number. Please enter a string of numbers only.");
                    Console.Write("Please wait...");
                    CustomerSectionCallBack();
                }
                else
                {
                    validInputNumber = true;
                }

            } while (!validInputNumber);
            

            customerList.Add(customer);
            Console.WriteLine();
            Console.WriteLine("Customer Details Added Successfully!");
            Console.WriteLine("Please Wait...");
            CustomerSectionCallBack();
        }

        //function to show customer information
        public static void ShowCustomerInformation()
        {
            string input;
            foreach(var customer in customerList)
            {
                Console.WriteLine();
                Console.WriteLine($"--PERSONAL INFORMATION--");
                Console.WriteLine($"Name: {customer.firstName} {customer.lastName}");
                Console.WriteLine($"Phone Number: {customer.phoneNumber}");
                Console.WriteLine($"-------PACKAGES---------");
                Console.WriteLine($"Total Small Boxes:  {customer.totalsmallPackage} <= \t | Facility A: {customer.getSFacilityAList()} \t | Facility B: {customer.getSFacilityBList()} \t | Facility C: {customer.getSFacilityCList()}");
                Console.WriteLine($"Total Medium Boxes: {customer.totalmediumPackage} <= \t | Facility A: {customer.getMFacilityAList()} \t | Facility B: {customer.getMFacilityBList()} \t | Facility C: {customer.getMFacilityCList()}");
                Console.WriteLine($"Total Large Boxes:  {customer.totallargePackage} <= \t | Facility A: {customer.getLFacilityAList()} \t | Facility B: {customer.getLFacilityBList()} \t | Facility C: {customer.getLFacilityCList()}");
                Console.WriteLine();
            }

            do
            {
                Console.Write("Press 1 to go back: ");
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Going Back to Customer Section");
                    Console.WriteLine("Please Wait...");
                    CustomerSectionCallBack();
                }
            } while (input != "1");
        }

        //function to show customer information without any loop
        public static void ShowCustomerInformationSample()
        {
            foreach (var customer in customerList)
            {
                Console.WriteLine();
                Console.WriteLine($"--PERSONAL INFORMATION--");
                Console.WriteLine($"Name: {customer.firstName} {customer.lastName}");
                Console.WriteLine($"Phone Number: {customer.phoneNumber}");
                Console.WriteLine($"-------PACKAGES---------");
                Console.WriteLine($"Total Small Boxes:  {customer.totalsmallPackage} <= \t | Facility A: {customer.getSFacilityAList()} \t | Facility B: {customer.getSFacilityBList()} \t | Facility C: {customer.getSFacilityCList()}");
                Console.WriteLine($"Total Medium Boxes: {customer.totalmediumPackage} <= \t | Facility A: {customer.getMFacilityAList()} \t | Facility B: {customer.getMFacilityBList()} \t | Facility C: {customer.getMFacilityCList()}");
                Console.WriteLine($"Total Large Boxes:  {customer.totallargePackage} <= \t | Facility A: {customer.getLFacilityAList()} \t | Facility B: {customer.getLFacilityBList()} \t | Facility C: {customer.getLFacilityCList()}");
                Console.WriteLine();
            }
        }

        //function to store package from each customer
        public static void StorePackage()
        {
            string firstNameInputSP, lastNameInputSP;
            int nameIndex;
            int facilitySize;
            string facilityName, size, lowerSizeInput;

            Console.WriteLine();
            Console.WriteLine("---STORE CUSTOMER PACKAGES---");

            do
            {
                //for name input
                Console.Write("Enter First Name: ");
                firstNameInputSP = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                lastNameInputSP = Console.ReadLine();

                if (!IsStringOfLetters(firstNameInputSP) && !IsStringOfLetters(lastNameInputSP))
                {
                    Console.WriteLine("Invalid input. Please enter a string of letters only.");
                }

            } while (!FindName(firstNameInputSP, lastNameInputSP));

            // getting the index of the customer from the list
            nameIndex = FindNameIndex(firstNameInputSP, lastNameInputSP);

            //interface of the selected customer
            
            do
            {
                Console.Write("What is the Package Size? (Small, Medium, Large): ");
                size = Console.ReadLine();
                lowerSizeInput = size.ToLower();
                if(lowerSizeInput != "small" && lowerSizeInput != "medium" && lowerSizeInput != "large")
                {
                    Console.WriteLine("Invalid Input! Choose from (Small, Medium, Large)");
                    Thread.Sleep(1000);
                }
            } while (lowerSizeInput != "small" && lowerSizeInput != "medium" && lowerSizeInput != "large");


            Console.Write("How many?(Numbers Only): ");
            var packageCount = int.Parse(Console.ReadLine());
                
            Console.WriteLine();

            Console.WriteLine("--CHOOSE FACILITY--");
            Console.WriteLine("1. FACILITY A");
            Console.WriteLine("2. FACILITY B");
            Console.WriteLine("3. FACILITY C");

            //to show storage available in each facility
            showFacility();

            Console.Write("Enter Facility: ");
            var facilityInput = int.Parse(Console.ReadLine());

            var lowerSize = size.ToLower();

            switch (facilityInput)
            {
                case 1:
                    facilityName = facilityList[facilityInput - 1].name;
                    facilitySize = lowerSize == "small" ? facilityList[facilityInput - 1].smallSize :
                                   lowerSize == "medium" ? facilityList[facilityInput - 1].mediumSize :
                                   lowerSize == "large" ? facilityList[facilityInput - 1].largeSize :
                                   0; // Handle the default case
                    customerList[nameIndex].StorePackage(size, packageCount, facilitySize, facilityName);
                    facilityList[0].ReserveBox(size, packageCount);
                    Console.WriteLine("Please wait...");
                    CustomerSectionCallBack();
                    break;
                case 2:
                    facilityName = facilityList[facilityInput - 1].name;
                    facilitySize = lowerSize == "small" ? facilityList[facilityInput - 1].smallSize :
                                   lowerSize == "medium" ? facilityList[facilityInput - 1].mediumSize :
                                   lowerSize == "large" ? facilityList[facilityInput - 1].largeSize :
                                   0; // Handle the default case
                    customerList[nameIndex].StorePackage(size, packageCount, facilitySize, facilityName);
                    facilityList[1].ReserveBox(size, packageCount);
                    Console.WriteLine("Please wait...");
                    CustomerSectionCallBack();
                    break;
                case 3:
                    facilityName = facilityList[facilityInput - 1].name;
                    facilitySize = lowerSize == "small" ? facilityList[facilityInput - 1].smallSize :
                                   lowerSize == "medium" ? facilityList[facilityInput - 1].mediumSize :
                                   lowerSize == "large" ? facilityList[facilityInput - 1].largeSize :
                                   0; // Handle the default case
                    customerList[nameIndex].StorePackage(size, packageCount, facilitySize, facilityName);
                    facilityList[2].ReserveBox(size, packageCount);
                    Console.WriteLine("Please wait...");
                    CustomerSectionCallBack();
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    StorePackage();
                    break;
            }


        }

        //function for releasing packages from the customer
        public static void ReleasePackages()
        {
            string firstNameInputRP, lastNameInputRP;
            string inputPackageSize;
            int releasePackageCount;
            int nameIndex;
            string facilityName, lowerSize, lowerSizeInput;
            int facilitySize;

            Console.WriteLine();
            Console.WriteLine("---RELEASE CUSTOMER PACKAGES---");
            do
            {
                //for name input
                Console.Write("Enter First Name: ");
                firstNameInputRP = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                lastNameInputRP = Console.ReadLine();

                if (!IsStringOfLetters(firstNameInputRP) && !IsStringOfLetters(lastNameInputRP))
                {
                    Console.WriteLine("Invalid input. Please enter a string of letters only.");
                }

            } while (!FindName(firstNameInputRP, lastNameInputRP));

            nameIndex = FindNameIndex(firstNameInputRP, lastNameInputRP);

            ShowCustomerInformationSample();

            do
            {
                Console.Write("What is the Package Size? (Small, Medium, Large): ");
                inputPackageSize = Console.ReadLine();
                lowerSizeInput = inputPackageSize.ToLower();
                if (lowerSizeInput != "small" && lowerSizeInput != "medium" && lowerSizeInput != "large")
                {
                    Console.WriteLine("Invalid Input! Choose from (Small, Medium, Large)");
                    Thread.Sleep(1000);
                }
            } while (lowerSizeInput != "small" && lowerSizeInput != "medium" && lowerSizeInput != "large");

            
            lowerSize = inputPackageSize.ToLower();

            Console.WriteLine();
            Console.WriteLine("--CHOOSE FACILITY--");
            Console.WriteLine("1. FACILITY A");
            Console.WriteLine("2. FACILITY B");
            Console.WriteLine("3. FACILITY C");

            Console.Write("Enter Facility: ");
            var facilityInput = int.Parse(Console.ReadLine());
           
            Console.Write("How many packages? (Numbers Only): ");
            releasePackageCount = int.Parse(Console.ReadLine());

            switch(facilityInput)
            {
                case 1:
                    facilityName = facilityList[facilityInput - 1].name;
                    facilitySize = lowerSize == "small" ? facilityList[facilityInput - 1].smallSize :
                                   lowerSize == "medium" ? facilityList[facilityInput - 1].mediumSize :
                                   lowerSize == "large" ? facilityList[facilityInput - 1].largeSize :
                                   0; // Handle the default case
                    customerList[nameIndex].ReleasePackage(inputPackageSize, releasePackageCount, facilitySize, facilityName);
                    facilityList[0].ReleaseBox(inputPackageSize, releasePackageCount);
                    Console.WriteLine("Please wait...");
                    CustomerSectionCallBack();
                    break;
                case 2:
                    facilityName = facilityList[facilityInput - 1].name;
                    facilitySize = lowerSize == "small" ? facilityList[facilityInput - 1].smallSize :
                                   lowerSize == "medium" ? facilityList[facilityInput - 1].mediumSize :
                                   lowerSize == "large" ? facilityList[facilityInput - 1].largeSize :
                                   0; // Handle the default case
                    customerList[nameIndex].ReleasePackage(inputPackageSize, releasePackageCount, facilitySize, facilityName);
                    facilityList[1].ReleaseBox(inputPackageSize, releasePackageCount);
                    Console.WriteLine("Please wait...");
                    CustomerSectionCallBack();
                    break;
                case 3:
                    facilityName = facilityList[facilityInput - 1].name;
                    facilitySize = lowerSize == "small" ? facilityList[facilityInput - 1].smallSize :
                                   lowerSize == "medium" ? facilityList[facilityInput - 1].mediumSize :
                                   lowerSize == "large" ? facilityList[facilityInput - 1].largeSize :
                                   0; // Handle the default case
                    customerList[nameIndex].ReleasePackage(inputPackageSize, releasePackageCount, facilitySize, facilityName);
                    facilityList[2].ReleaseBox(inputPackageSize, releasePackageCount);
                    Console.WriteLine("Please wait...");
                    CustomerSectionCallBack();
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }

        }

        //function to find the name of the customer in the customer list
        public static bool FindName(string firstNameInput, string lastNameInput)
        {
            var linqFindName = (from n in customerList where n.firstName == firstNameInput && n.lastName == lastNameInput select n).FirstOrDefault();
            if(linqFindName != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Customer: {linqFindName.firstName} {linqFindName.lastName}"); 
                return true;
            }
            Console.WriteLine("Customer not found!");
            CustomerSectionCallBack();
            return false;
            
        }

        //function to find the index of the customer within the customerlist
        public static int FindNameIndex(string firstNameInput, string lastNameInput)
        {
            var linqFindName = (from n in customerList where n.firstName == firstNameInput && n.lastName == lastNameInput select n).FirstOrDefault();
            int index = customerList.IndexOf(linqFindName);
            return index;
        }

        //function to iterate the facility list and show the values
        public static void showFacility()
        {
            foreach (var n in facilityList)
            {
                Console.WriteLine(n.name + ": " + "Small: " + n.smallSize + " " + "Medium: " + n.mediumSize + " " + "Large: " + n.largeSize);
            }
        }

        //function to show available space in each facility
        public static void showAvailableFacility()
        {
            string input;
            foreach (var n in facilityList)
            {
                Console.WriteLine(n.name + ": " + "Small: " + n.smallSize + " " + "Medium: " + n.mediumSize + " " + "Large: " + n.largeSize);
            }
            do
            {
                Console.Write("Press 1 to go back: ");
                input = Console.ReadLine();
                if(input == "1")
                {
                    Console.Clear();
                    DisplayInterface();
                }
            } while (input != "1");
            
            
        }

        //function to exit the program
        public static void ExitProgram()
        {
            Console.WriteLine("Program Exiting...");
        }

        //function to accepts only string of letters as an input
        public static bool IsStringOfLetters(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }

        //function to accepts only number as an input
        public static bool IsNumericInput(string input)
        {
            return Regex.IsMatch(input, @"^[0-9]+$");
        }



    }
}