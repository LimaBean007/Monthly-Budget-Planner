using Monthly_Budget_Planner.Workers;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
namespace Monthly_Budget_Planner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Const variable used for a delay
        const int DELAY = 1400;
        //Global variable that can be called by other forms
        public static double grossIncomeP;
        public MainWindow()
        {
            //Centres the form on load
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            txbGrossIncome.Focus();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Validation to ensure the user enters the correct information
            try
            {
                lblIncomeError.Visibility = Visibility.Hidden;
                //Declaring variables for income
                double grossIncome;
                //Getting Users data from components in the GUI

                grossIncome = Convert.ToDouble(txbGrossIncome.Text);
                WorkerLists.expenseList.Clear();
                if (grossIncome > 0)
                {
                    //Once valid it shows the next step of the budget process
                    grossIncomeP = grossIncome;
                    frmGeneralExpense newExpense = new frmGeneralExpense();
                    newExpense.Show();
                    Hide();
                }
                else
                {
                    //Displays an error message if the users details are incorrect or invalid
                    MessageBox.Show("Please enter a correct Gross Income Value", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                    lblIncomeError.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                //Displays an error message if the users details are incorrect or invalid
                MessageBox.Show("Please enter a correct Gross Income Value", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                lblIncomeError.Visibility = Visibility.Visible;
            }
        }
        //Method used to confirm if the user would like to exit
        private void Window_Closing_1(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Close App Notice",

            MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            {
                e.Cancel = true;

            }
            else
            {
                //Creates a delay of 1.4 seconds


                //---------CODE ATTRIBUTION---------
                //The following method was tafrom StackOverFlow
                //Author : Carlos Loth
                //Link: https://stackoverflow.com/questions/2902327/c-sharp-winforms-change-cursor-icon-of-mouse
                Mouse.OverrideCursor = Cursors.Wait;
                //---------END---------

                Task.Delay(DELAY).Wait();
                Environment.Exit(1);
            }
        }
        ///////////////////// Validation for all GUI input components
        private void txbGrossIncome_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double income = double.Parse(txbGrossIncome.Text);
                lblIncomeError.Visibility = Visibility.Hidden;
                if (income <= 0)
                {
                    lblIncomeError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblIncomeError.Visibility = Visibility.Visible;
            }
        }

        private void txbGrossIncome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnNext.Focus();
            }
        }
    }
}
