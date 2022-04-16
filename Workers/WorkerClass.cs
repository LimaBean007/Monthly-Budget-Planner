using Monthly_Budget_Planner.Abstract;
using Monthly_Budget_Planner.Child_Classes;
using Monthly_Budget_Planner.Delegate_Classes;
using System;
using System.Linq;
using System.Windows;

//Folder . etc
namespace Monthly_Budget_Planner.Workers
{
    class WorkerClass
    {
        //Constant varaibles 
        const double LIMIT = 0.75;
        const int DELAY = 1400;
        private const string Format = "R ### ### ###.00";


        //Variable for the nett salary
        private double nettSal;


        //Method used to check if the user qualifies for a home loan, 
        public bool checkifQualifies(double grossIncome, double monthlyRepayment, double netSal)
        {

            //Constant
            const double THIRD_PERCENT = 0.33333333333;
            //Declaring variables
            bool qualified;
            //Performs check to see if user qualifies based on 1/3 of gross income
            if ((THIRD_PERCENT * grossIncome) > monthlyRepayment)
            {
                qualified = true;
            }
            else
            {
                qualified = false;
            }
            return qualified;
        }
        //Method to display the report afater all deductions have been made
        private string displayQualifiedReport(double income, HomeLoan newhomeLoan, double netSal)
        {
            string display = "";
            if (checkifQualifies(income, newhomeLoan.getExpense(), netSal) == true && netSal >= 0)
            {
                display = display + "\n\nYour request for the home loan application is approved.";
                MessageBox.Show("Your request for the home loan application is approved.", "Home Loan Application Notice", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {

                display = display + "\n\nYour request for the home loan application is declined.";
                MessageBox.Show("Your request for the home loan application is declined.", "Home Loan Application Notice", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            return display;
        }
        //Method used to display the final or left money at the end. Using surplus or deficit
        private string netSalDeductions(double netSal)
        {
            string finalDisplay;
            if (netSal >= 0)
            {
                finalDisplay = "\nSurplus of Cash:\t\t\t\t" + nettSal.ToString(Format);
            }
            else
            {
                finalDisplay = "\nDeficit of Cash:\t\t\t\t" + (1 * nettSal).ToString(Format);
            }
            return finalDisplay;
        }

        //Report used to create the report using the list and the objects.
        public void generateReport(bool isHome, bool isVehicle, bool isSavings, Income newIncome)
        {

            string display = "";
            double totExpenses = 0;

            //For loop to create to first part of the display report
            System.Collections.IList list = WorkerLists.expenseList;
            display = display + "\t\tIncome & Expenditure Report\n-------------------------------------------------------------------";
            display = display + "\nGross Income :\t\t\t\t" + newIncome.GrossIncome.ToString(Format) + "\n";

            //Sorts the list storing objects
            WorkerLists.expenseList = WorkerLists.expenseList.OrderByDescending(o => o.getExpense()).ToList();

            //Loops through the list to look for each type of Expense child ovject and displays the appropriate result.
            System.Collections.IList list2 = WorkerLists.expenseList;
            for (int i = 0; i < list2.Count; i++)
            {
                Expense item = (Expense)list2[i];
                //If the object stored in the list is homeloan it will display the total for home loan
                if (item.GetType() == typeof(HomeLoan))
                {
                    //Adds the homeloan expenses to the total expenses
                    totExpenses += item.getExpense();
                    display = display + "\n\nHome Loan";
                    display = display + "\nPurchase Price :\t\t" + ((HomeLoan)item).Property_Price.ToString(Format);
                    display = display + "\nTotal deposit :\t\t" + ((HomeLoan)item).Tot_Deposit.ToString(Format);
                    display = display + "\nInterest :\t\t\t" + ((HomeLoan)item).Int_Rate.ToString() + "%";
                    display = display + "\nPeriod :\t\t\t" + ((HomeLoan)item).Num_Of_Months.ToString() + " Months";
                    display = display + "\nLess: Property Repayment:\t\t\t" + item.getExpense().ToString(Format);

                }
                //If the object stored in the list is general expense it will display the total for general expense
                else if (item.GetType() == typeof(GeneralExpenses))
                {
                    //adds the general expenses to the total expenses
                    totExpenses += item.getExpense();
                    if (((GeneralExpenses)item).ExpenseName.Equals("Estimated Monthly Tax", StringComparison.OrdinalIgnoreCase))
                    {
                        display = display + "\nLess : " + ((GeneralExpenses)item).ExpenseName + " :\t\t" + item.getExpense().ToString(Format);
                    }
                    if (((GeneralExpenses)item).ExpenseName.Equals("Groceries", StringComparison.OrdinalIgnoreCase))
                    {
                        display = display + "\nLess : " + ((GeneralExpenses)item).ExpenseName + " :\t\t\t\t" + item.getExpense().ToString(Format);
                    }
                    if (((GeneralExpenses)item).ExpenseName.Equals("Water and lights", StringComparison.OrdinalIgnoreCase))
                    {
                        display = display + "\nLess : " + ((GeneralExpenses)item).ExpenseName + " :\t\t\t" + item.getExpense().ToString(Format);
                    }
                    if (((GeneralExpenses)item).ExpenseName.Equals("Travel Costs (including petrol)", StringComparison.OrdinalIgnoreCase))
                    {
                        display = display + "\nLess : " + ((GeneralExpenses)item).ExpenseName + " :\t" + item.getExpense().ToString(Format);
                    }
                    if (((GeneralExpenses)item).ExpenseName.Equals("Cell phone", StringComparison.OrdinalIgnoreCase))
                    {
                        display = display + "\nLess : " + ((GeneralExpenses)item).ExpenseName + " :\t\t\t\t" + item.getExpense().ToString(Format);
                    }
                    if (((GeneralExpenses)item).ExpenseName.Equals("Other", StringComparison.OrdinalIgnoreCase))
                    {
                        display = display + "\nLess : " + ((GeneralExpenses)item).ExpenseName + " :\t\t\t\t" + item.getExpense().ToString(Format);
                    }

                }
                //If the object is stored in the list is rent it will display the total expenses for rent
                else if (item.GetType() == typeof(Rent))
                {
                    //adds rent to the total expenses
                    totExpenses += item.getExpense();
                    display = display + "\nLess: Rental :\t\t\t\t" + item.getExpense().ToString(Format);

                }
                else if (item.GetType() == typeof(Savings))
                {
                    totExpenses += item.getExpense();
                    display = display + "\n\nSavings";
                    display = display + "\nAccount Name :\t\t" + ((Savings)item).SavingName;
                    display = display + "\nSaving Amount :\t\t" + ((Savings)item).SavingAMT.ToString(Format);
                    display = display + "\nPeriod :\t\t\t" + ((Savings)item).NumYears + " Years";
                    display = display + "\nInterest :\t\t\t" + ((Savings)item).IntRate.ToString() + "%";
                    display = display + "\nLess: Savings Account :\t\t\t" + item.getExpense().ToString(Format);
                }
                //If the object is stored in the list is neither types of the others, it has to be of type of vehicle, so it displays vehicle expenses
                else
                {
                    //Adds vehicle  to the total expense
                    totExpenses += item.getExpense();
                    display += "\n\nVehicle";
                    display = display + "\nVehicle Make and Model :\t" + ((Vehicles)item).ModelMake;
                    display = display + "\nVehicle Price :\t\t" + ((Vehicles)item).Veh_PurchasePrice.ToString(Format);
                    display = display + "\nDeposit :\t\t\t" + ((Vehicles)item).Veh_Total_Deposit.ToString(Format);
                    display = display + "\nInterest :\t\t\t" + ((Vehicles)item).Veh_Int_Rate.ToString() + "%";
                    display = display + "\nInsurance Premium :\t" + ((Vehicles)item).InsurancePrem.ToString(Format);
                    display = display + "\nLess: Vehicle repayment :\t\t\t" + item.getExpense().ToString(Format);
                }
            }
            //Calcs the netsal
            display += "\n";
            nettSal = newIncome.GrossIncome - totExpenses;

            double expense75 = newIncome.GrossIncome * LIMIT;
            //Checks if the expenses are more than 75% of their income, proceeds to display delegate
            if (totExpenses >= expense75)
            {
                //Creates an instance of the delegate class which will call the delegate method.
                ProcessWarning newWarning = new ProcessWarning();
                newWarning.processWarning();
            }
            //Loop to check if they quailify for home loan, and displays the end which is surplus or deficit
            System.Collections.IList list1 = WorkerLists.expenseList;
            for (int i = 0; i < list1.Count; i++)
            {
                Expense item = (Expense)list1[i];
                if (item.GetType() == typeof(HomeLoan))
                {
                    if (isHome)
                    {
                        display += netSalDeductions(nettSal);

                        display += displayQualifiedReport(newIncome.GrossIncome, (HomeLoan)item, nettSal);
                    }
                }
                if (item.GetType() == typeof(Rent))
                {
                    if (isHome == false)
                    {

                        display += netSalDeductions(nettSal);
                    }
                }


            }
            //Displays the same thing as athe delegate at the end for extra info to the user
            if (totExpenses >= expense75)
            {
                display += "\nYour total expenses exceed 75 % of your monthly income.";
            }

            //Construcor for the viewReport Form
            frmViewReport newReport = new frmViewReport();

            //Calling getReport to display the generated display in the rich edit
            newReport.getReport(display);

            //---------CODE ATTRIBUTION---------
            //The following method was  tafrom StackOverFlow
            //Author : Carlos Loth
            //Link: https://stackoverflow.com/questions/2902327/c-sharp-winforms-change-cursor-icon-of-mouse
            //---------END---------

            //Shows the report Form
            newReport.Show();
        }
    }
}
