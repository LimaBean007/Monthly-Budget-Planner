using Monthly_Budget_Planner.Workers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
namespace Monthly_Budget_Planner
{
    /// <summary>
    /// Interaction logic for frmAccomodation.xaml
    /// </summary>
    public partial class frmAccomodation : Window
    {
        //Static bool to check if home loan was clicked or not (Used in the end of the budget input process)
        public static bool isHomeloan = false;
        public frmAccomodation()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void RentingClick_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Creates and displays the renting class, closing this form
            this.Hide();
            frmRenting newRent = new frmRenting();
            newRent.Show();
            isHomeloan = false;
        }

        private void rectArrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Removes the last object in the arraylist as the user clicked back, which will allow them to create a new object of rent or homeloan
            WorkerLists.expenseList.RemoveAt(WorkerLists.expenseList.Count - 1);
            frmGeneralExpense newGeneral = new frmGeneralExpense();
            //Displays previous form and closes this one
            this.Hide();
            newGeneral.Show();
        }
        //Method used to confirm if the user wants to exit the form
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Close App Notice",
             MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            {
                e.Cancel = true;

            }
            else
            {
                //Creates a delay of 1.4 seconds
                int delay = 1400;

                //---------CODE ATTRIBUTION---------
                //The following method was tafrom StackOverFlow
                //Author : Carlos Loth
                //Link: https://stackoverflow.com/questions/2902327/c-sharp-winforms-change-cursor-icon-of-mouse
                //Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                //---------END---------

                Task.Delay(delay).Wait();
                System.Environment.Exit(1);
            }
        }
        //Method used to open the homeloan form if home loan was selected
        private void RentingClick_Copy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Dispalys the home loan form and closes this one
            this.Hide();
            frmHomeLoan newLoan = new frmHomeLoan();
            isHomeloan = true;
            newLoan.Show();
        }
    }
}
