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
    /// Interaction logic for frmSavingOption.xaml
    /// </summary>
    public partial class frmSavingOption : Window
    {
        //Creates a delay of 1.4 seconds
        int DELAY = 1400;
        public static bool isSavings = false;
        public frmSavingOption()
        {
            //Centres the form when it loads
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        //Determines which form to return to if the user selects back, also deleting the last object stored in the List
        private void rectArrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (frmVehicleOption.isVehicle)
            {
                FrmVehicleDetails newVehicle = new FrmVehicleDetails();
                newVehicle.Show();
                Hide();
                WorkerLists.expenseList.RemoveAt(WorkerLists.expenseList.Count - 1);
            }
            else
            {
                frmVehicleOption newVehicleOption = new frmVehicleOption();
                newVehicleOption.Show();
                Hide();
            }
        }
        //Displays the savings form if selected
        private void rectYes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isSavings = true;
            frmSavings newSave = new frmSavings();
            newSave.Show();
            Hide();
        }
        //Creates an object of the worker class calling the generate report method
        private void rectNo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isSavings = false;
            WorkerClass newWorker = new WorkerClass();
            Income newIncome = new Income(MainWindow.grossIncomeP);
            newWorker.generateReport(frmAccomodation.isHomeloan, frmVehicleOption.isVehicle, isSavings, newIncome);
            Hide();
        }
        //Confirms that the user would like to exit the application
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to exit?", "Close App Notice",
              MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            {
                e.Cancel = true;

            }
            else
            {
                //---------CODE ATTRIBUTION---------
                //The following method was tafrom StackOverFlow
                //Author : Carlos Loth
                //Link: https://stackoverflow.com/questions/2902327/c-sharp-winforms-change-cursor-icon-of-mouse
                //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                //---------END---------

                Task.Delay(DELAY).Wait();
                System.Environment.Exit(1);
            }
        }
    }
}
