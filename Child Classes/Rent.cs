using Monthly_Budget_Planner.Abstract;
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
namespace Monthly_Budget_Planner.Child_Classes

{   //Class Rent inherits from Expense
    //Rent = child class
    class Rent : Expense
    {
        //Declaring variables
        private double rentAMT;

        //Constructor for the Rent Class
        public Rent(double rentAMT)
        {
            this.rentAMT = rentAMT;

        }

        //Overiding the abtract method for the Rent Class returning all "RENT" expenses
        public override double getExpense()
        {
            return rentAMT;
        }

        public override string toString()
        {
            string display = "";
            display = "\nLess: Rental\t\t\t\t: R " + getExpense().ToString("### ### ###.00");
            return display;
        }

        //Getters and Setters
        public double RentAMT { get => rentAMT; set => rentAMT = value; }
    }
}
