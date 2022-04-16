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
    /// Interaction logic for frmVehicleOption.xaml
    /// </summary>
    public partial class frmVehicleOption : Window
    {
        public static bool isVehicle = false;
        public frmVehicleOption()
        {
            //centres the the form when it loads
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        //Method used to confirm if the user would like to exit the app
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
                Mouse.OverrideCursor = Cursors.Wait;
                //---------END---------

                Task.Delay(delay).Wait();
                System.Environment.Exit(1);
            }
        }
        //Displays the vehicle form if selected
        private void rectYes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Hides this form and shows the vehicle form
            isVehicle = true;
            FrmVehicleDetails newVehicle = new FrmVehicleDetails();
            newVehicle.Show();
            this.Hide();
        }
        //moves to the next form
        private void rectNo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isVehicle = false;
            frmSavingOption newSaveOption = new frmSavingOption();
            newSaveOption.Show();
            this.Hide();
        }
        //Method used to determine which form to move to when the user clicks back
        private void rectArrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Checks if the homeloan button was selected to switch to the homeloan form
            if (frmAccomodation.isHomeloan)
            {
                frmHomeLoan newLoan = new frmHomeLoan();
                newLoan.Show();
                Hide();
                // Deletes the last stored object in the list as we are now going back one step
                WorkerLists.expenseList.RemoveAt(WorkerLists.expenseList.Count -1);
            }
            // else if switches to the renting form
            else
            {
                frmRenting newRent = new frmRenting();
                newRent.Show();
                Hide();
                // Deletes the last stored object in the list as we are now going back one step
                WorkerLists.expenseList.RemoveAt(WorkerLists.expenseList.Count - 1);
            }
        }
    }
}
