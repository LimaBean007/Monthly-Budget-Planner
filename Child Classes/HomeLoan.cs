using Monthly_Budget_Planner.Abstract;
using System;
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
namespace Monthly_Budget_Planner.Child_Classes
{
    class HomeLoan : Expense
    {
        //Declaring variables
        private double property_Price;
        private double tot_Deposit;
        private double int_Rate;
        private double num_Of_Months;

        //Overiding the abtract method for the HomeLoan Class returning all "HomeLoan" expenses which will be the monthly Repayment
        public override double getExpense()
        {
            //Declaring variables
            double monthlyRepayment = 0;
            double interest = Int_Rate / 100;
            double difference = 0;
            //Constants
            const int MONTHLY = 12;
            const int one = 1;

            difference = property_Price - tot_Deposit;
            //Calculates the monthly repayment
            monthlyRepayment = (difference * (one + (interest * num_Of_Months / MONTHLY)) / num_Of_Months);
            //Rounds off to 2 decimal places
            Math.Round(monthlyRepayment, 2);
            return monthlyRepayment;
        }
        //Constructor for the HomeLoan Class
        public HomeLoan(double property_Price, double tot_Deposit, double int_Rate, double num_Of_Months)

        {
            this.property_Price = property_Price;
            this.tot_Deposit = tot_Deposit;
            this.int_Rate = int_Rate;
            this.num_Of_Months = num_Of_Months;

        }

        //Getters and Setters
        public double Property_Price { get => property_Price; set => property_Price = value; }
        public double Tot_Deposit { get => tot_Deposit; set => tot_Deposit = value; }
        public double Int_Rate { get => int_Rate; set => int_Rate = value; }
        public double Num_Of_Months { get => num_Of_Months; set => num_Of_Months = value; }

        public bool checkifQualifies(double grossIncome, double monthlyRepayment, double netSal)
        {

            //Constant
            const double percentage = 0.3333;
            //Declaring variables
            bool qualified;
            //Performs check to see if user qualifies based on 1/3 of gross income
            if ((percentage * grossIncome) > monthlyRepayment || netSal >= 0)
            {
                qualified = true;
            }
            else
            {
                qualified = false;
            }
            return qualified;
        }
        //Overirding the toString method
        public override string toString()
        {
            string display = "";
            display = "\nLess: Property Repayment\t\t: R " + getExpense().ToString("### ### ###.00");
            return display;
        }
    }
}
