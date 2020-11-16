using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payday_loan
{
    class Program
    {

        public static void Main(string[] args)
        {

            //Variables
            String menu;
            Boolean paydayLoan = false;

            //Main menu
            Console.WriteLine("Welcome to Vankers Bankers payday loan program");
            Console.WriteLine("");
            Console.WriteLine("Would you like to read our FAQ's?");
            menu = Console.ReadLine();

            //menu
            if (menu == "Yes" || menu == "yes")
            {
                Console.Clear();
                Console.WriteLine("Q: How much money can i take out?");
                Console.WriteLine("");
                Console.WriteLine("A: You can borrow from £100 to £500");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Q: How long can my loan last?");
                Console.WriteLine("");
                Console.WriteLine("A: Your loan can last as little as 3 months or as much as 18 months");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Q: Is this secure?");
                Console.WriteLine("");
                Console.WriteLine("A: Our banking software is very secure with encryption, ensuring your details are safe and secure with us");
                Console.WriteLine("");
                Console.ReadLine();
                paydayLoan = true;
                Eligibility(paydayLoan);
            }

            if (menu == "No" || menu == "no")
            {
                paydayLoan = true;
                Eligibility(paydayLoan);

            }


        } // end main

        public static void Eligibility(Boolean paydayLoan)
        {
            //Variables
            Boolean userValid = false;
            String verify;

            //Eligibility
            while (paydayLoan == true)
            {
                Console.Clear();
                Console.WriteLine("To access this program you will need to perform an eligibility check");
                Console.WriteLine("1) You need to be over the age of 18");
                Console.WriteLine("2) You will need to be in full time employment");
                Console.WriteLine("3) You will need to have read the conditions on www.vankersbankers.co.uk");
                Console.WriteLine("");
                Console.WriteLine("Do you meet the requirements for this program?");

                verify = Console.ReadLine().ToUpper();
                verify = verify[0].ToString();

                //verify
                if (verify == "N")
                {
                    Console.Clear();
                    Console.WriteLine("You're uneligable to use this program and cannot be offered a loan");
                    Console.WriteLine("Press ENTER to exit the program");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                if (verify == "Y")
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations, you're eligable to use this program");
                    userValid = true;
                    Borrow(userValid);

                   
                }

                else
                {
                    Console.WriteLine("Invalid answer");
                }
            }
        }

        public static void Borrow(Boolean userValid)
        {
            //Variables
            Boolean costValid = false;
            Int16 loanAmount = 0, period = 12;
            Decimal interestPercentage = 0;

            while (userValid == true)
            {
                while (costValid == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("How much would you like to borrow?");
                    loanAmount = Convert.ToInt16(Console.ReadLine());


                    //loanAmount
                    if (loanAmount >= 300)
                    {
                        costValid = true;
                        interestPercentage = 0.36m;
                        PaydayLoan(loanAmount, interestPercentage, period, costValid, userValid);

                    }

                    if (loanAmount <= 300)
                    {
                        costValid = true;
                        interestPercentage = 0.38m;
                        PaydayLoan(loanAmount, interestPercentage, period, costValid, userValid);
                    }

                    if (loanAmount < 100 || loanAmount > 500)
                    {
                        costValid = false;
                        Console.Clear();
                        Console.WriteLine("Invalid Amount, please enter a value between £100 and £500");

                    }

                }
            }
        }

        public static void PaydayLoan(Int16 loanAmount, decimal interestPercentage, int period, Boolean costValid, Boolean userValid)
        {
            //Variables
            Decimal MonthlyPayment, MonthlyInterest;
            Int16 displayPercentage = 0;

            //Algorithm
            MonthlyPayment = loanAmount;

            Console.WriteLine(string.Format("{0,5} {1,15} {2,15}", "Month", "Monthly", "Monthly"));
            Console.WriteLine(string.Format("{0,5} {1,15} {2,15}", "", "Interest", "Payment"));

            for (var month = 1; month <= period; month++)
            {
                MonthlyInterest = MonthlyPayment * interestPercentage;
                MonthlyPayment = MonthlyPayment + MonthlyInterest;
                Console.WriteLine(string.Format("{0,5} {1,15:C2} {2,15:C2}", month, MonthlyInterest, MonthlyPayment));         
            }
            Console.WriteLine("Interest Percentage:" + displayPercentage + "%");
            Console.WriteLine("");
            Console.WriteLine("If you fail to make this payment compound interest charges apply.");
            Console.WriteLine("Below is a 12 month illustration of interest charges and monthly");
            Console.WriteLine("payments that apply if you fail to make payments.");
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            costValid = true;
            Projection(loanAmount, interestPercentage, period, costValid, userValid);
        }

        public static void Projection(Int16 loanAmount, Decimal interestPercentage, int period, Boolean costValid, Boolean userValid)
        {
            //Variables
            Boolean scopeValid = true, ProjectionValid = false;
            String ProjectionChoice;
            Decimal MonthlyPayment, MonthlyInterest;

            while (costValid == true)
            {
                Console.Clear();
                Console.WriteLine("Would you like to customize your projection?");
                ProjectionChoice = Console.ReadLine();

                if (ProjectionChoice == "yes" || ProjectionChoice == "Yes")
                {
                    ProjectionValid = true;
                }

                else
                {
                    scopeValid = false;
                    Quote(scopeValid, userValid);
                }

                while (ProjectionValid == true)
                {
                    Console.Clear();
                    Console.WriteLine("How long would you like to project?");
                    period = Convert.ToInt16(Console.ReadLine());

                    //loanTime
                    if (period <= 3 || period >= 18)
                    {
                        scopeValid = false;
                        Console.Clear();
                        Console.WriteLine("Invalid projection, please enter a value between 3 and 18 months");
                    }

                    else
                    {
                        scopeValid = true;
                    }


                    //Algorithm
                    while (scopeValid == true)
                    {
                        MonthlyPayment = loanAmount;

                        Console.WriteLine(string.Format("{0,5} {1,15} {2,15}", "Month", "Monthly", "Monthly"));
                        Console.WriteLine(string.Format("{0,5} {1,15} {2,15}", "", "Interest", "Payment"));

                        for (var month = 1; month <= period; month++)
                        {
                            MonthlyInterest = MonthlyPayment * interestPercentage;
                            MonthlyPayment = MonthlyPayment + MonthlyInterest;
                            Console.WriteLine(string.Format("{0,5} {1,15:C2} {2,15:C2}", month, MonthlyInterest, MonthlyPayment));
                        }
                        Console.ReadLine();
                        scopeValid = false;
                        Quote(scopeValid, userValid);
                    }
                }
            }
        }

        public static void Quote(Boolean scopeValid, Boolean userValid)
        {
            //Variables
            String choice;

            while (scopeValid == false)
            {

                //Details

                Console.Clear();
                Console.WriteLine("Do you want to calculate another quote?");
                choice = Console.ReadLine();

                //choice
                if (choice == "yes" || choice == "Yes")
                {
                    Console.Clear();
                    Borrow(userValid);

                }
                if (choice == "no" || choice == "No")
                {
                    Console.Clear();
                    Console.WriteLine("Thank you for using the Payday loan generator");
                    Console.WriteLine("Press ENTER to exit the program");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }

        } // end quote

    }
}