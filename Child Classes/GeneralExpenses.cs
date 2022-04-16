using Monthly_Budget_Planner.Abstract;
using System;
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
namespace Monthly_Budget_Planner.Child_Classes
{
    //Class GeneralExpenses inherits from Expense, as GeneralExpenses stores the different types of expenses
    //GeneralExpenses = child class
    public class GeneralExpenses : Expense
    {
        //Declaring variables
        private double generalExpenseValue;
        private string expenseName;
        private string timeIssued;

        //Generating constructor for the GeneralExpenses class
        public GeneralExpenses(double generalExpenseValue, string expenseName)
        {
            this.generalExpenseValue = generalExpenseValue;
            this.expenseName = expenseName;
      
        }
        //Getters and setters for variables
        public double GeneralExpenseValue { get => generalExpenseValue; set => generalExpenseValue = value; }
        public string ExpenseName { get => expenseName; set => expenseName = value; }
        public string TimeIssued { get => timeIssued; set => timeIssued = value; }

        //Overiding the abtract method for the GeneralExpenses Class returning all "GeneralExpenses" expenses
        public override double getExpense()
        {
            return generalExpenseValue;
        }
        //Overiding the abtract method for the GeneralExpenses Class returning all "GeneralExpenses" displays
        public override string toString()
        {
            string display = "";
            display = "\nLess: " + expenseName + "\t\t: R " + generalExpenseValue;
            return display;
        }
    }
}
