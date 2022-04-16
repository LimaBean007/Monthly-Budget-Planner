using System.Windows;
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
namespace Monthly_Budget_Planner.Delegate_Classes
{
    class ExpenseWarningService
    {
        public void Alert()
        {
            //Used to display to the user when the users monthly expenses exceed 75%
            MessageBox.Show("Your total expenses exceed 75 % of your monthly income", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
