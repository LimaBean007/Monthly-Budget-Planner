using Monthly_Budget_Planner.Abstract;
using System;
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
namespace Monthly_Budget_Planner.Child_Classes
{
    class Savings : Expense
    {
        //Declaring variables
        private double numYears;
        private double savingAMT;
        private double intRate;
        private string savingName;

        //Constructor for the Savings class
        public Savings(double numYears, double savingAMT, double intRate, string savingName)
        {
            this.numYears = numYears;
            this.savingAMT = savingAMT;
            this.intRate = intRate;
            this.savingName = savingName;
        }

        //Getters and Setters for the Savings class
        public double SavingAMT { get => savingAMT; set => savingAMT = value; }
        public double IntRate { get => intRate; set => intRate = value; }
        public string SavingName { get => savingName; set => savingName = value; }
        public double NumYears { get => numYears; set => numYears = value; }
        //Override method to calc the monthly repay amount for the amount to save
        public override double getExpense()
        {
            //Declaring variables
            double monthRepay = 0;
            //Constants
            const int MONTHLY = 12;
            const int ONE = 1;
            //Calculation for the Savings expenses
            double numMonths = numYears * MONTHLY;
            double interest = intRate / 100;
            interest /= 12;

            double brackets = Math.Pow(ONE + interest, numMonths);
            monthRepay = savingAMT * interest / (brackets - ONE);
            return monthRepay;
        }
        //Override toString to display all expenses of type Savings
        public override string toString()
        {
            return "\nLess: Savings Account\t\t R " +getExpense().ToString("### ### ###.00");
        }
    }
}
