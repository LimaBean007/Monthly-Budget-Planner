using Monthly_Budget_Planner.Abstract;
using System;
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
namespace Monthly_Budget_Planner.Child_Classes
{
    class Vehicles : Expense
    {
        //Declaring variables
        private double veh_PurchasePrice;
        private double veh_Total_Deposit;
        private double veh_Int_Rate;
        private double insurancePrem;
        private string modelMake;

        //Constructor
        public Vehicles(double veh_PurchasePrice, double veh_Total_Deposit, double veh_Int_Rate, double insurancePrem, string modelMake)
        {
            this.veh_PurchasePrice = veh_PurchasePrice;
            this.veh_Total_Deposit = veh_Total_Deposit;
            this.veh_Int_Rate = veh_Int_Rate;
            this.insurancePrem = insurancePrem;
            this.modelMake = modelMake;

        }
        //Getters and Setters for variables
        public double Veh_PurchasePrice { get => veh_PurchasePrice; set => veh_PurchasePrice = value; }
        public double Veh_Total_Deposit { get => veh_Total_Deposit; set => veh_Total_Deposit = value; }
        public double Veh_Int_Rate { get => veh_Int_Rate; set => veh_Int_Rate = value; }
        public double InsurancePrem { get => insurancePrem; set => insurancePrem = value; }
        public string ModelMake { get => modelMake; set => modelMake = value; }
        //Override method used to calculate the expenses for the vehicle class
        public override double getExpense()
        {
            //Declaring variables
            double monthlyVehRepayment = 0;
            double interest = veh_Int_Rate / 100;
            double difference = 0;
            //Constants
            const int MONTHLY = 12;
            const int Years = 5;
            const int one = 1;

            difference = veh_PurchasePrice - veh_Total_Deposit;
            //Calculates the monthly repayment
            monthlyVehRepayment = (difference * (one + (interest * (Years * MONTHLY) / MONTHLY)) / (Years * MONTHLY));
            //Rounds off to 2 decimal places
            Math.Round(monthlyVehRepayment, 2);

            return monthlyVehRepayment + insurancePrem;

        }
        //Override tostring for the vehicle class
        public override string toString()
        {
            string display = "";
            display = "\nLess: Property Repayment\t\t: R " + getExpense().ToString("### ### ###.00");
            return display;
        }
    }
}
