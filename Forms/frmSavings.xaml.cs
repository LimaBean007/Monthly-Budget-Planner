using Monthly_Budget_Planner.Child_Classes;
using Monthly_Budget_Planner.Workers;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
namespace Monthly_Budget_Planner
{
    /// <summary>
    /// Interaction logic for frmSavings.xaml
    /// </summary>
    public partial class frmSavings : Window
    {
        const int DELAY = 1400;
        public frmSavings()
        {
            //Centres the form when it loads
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            txbSavingsAMT.Focus();
            //Gets current year 
            int currentYear = Convert.ToInt32(DateTime.Now.Year.ToString());
            //Adds years to the combobox
            for (int i = 0; i < 50; i++)
            {
                currentYear++;
                cmbxYears.Items.Add(currentYear);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Getting data from GUI components
                string savingDate = cmbxYears.Text;
                double savingAMT;
                double intRate;
                savingAMT = Convert.ToDouble(txbSavingsAMT.Text);
                intRate = Convert.ToDouble(txbIntRate.Text);
                string savingName = txbSaveName.Text;
                //Validation
                if (checkStringInput(savingName) && savingAMT > 0 && intRate > 0 && intRate <= 100 && checkStringInput(savingDate)==true)
                {
                    //Calcs the number of years for the savings account
                    double Year = Convert.ToDouble(savingDate) - Convert.ToDouble(DateTime.Now.Year.ToString());
                    //Creates an object of savings and adds it to the list
                    //Creates an income and worker object calling the generate report method, displaying a new form, hiding this one
                    Savings newSave = new Savings(Year, savingAMT, intRate, savingName);
                    WorkerLists.expenseList.Add(newSave);
                    Income newIncome = new Income(MainWindow.grossIncomeP);
                    WorkerClass newWorker = new WorkerClass();
                    newWorker.generateReport(frmAccomodation.isHomeloan, frmVehicleOption.isVehicle, frmSavingOption.isSavings, newIncome);
                    Hide();
                }
                else
                {
                    //Error message
                    MessageBox.Show("Please enter the correct values for your Savings account", "ALERT", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Please enter the correct values for your Savings account", "ALERT", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        //Confirms that the user would like exit the application
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
        ///////////////Validation for all GUI input components
        private void txbSavingsAMT_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double Value = double.Parse(txbSavingsAMT.Text);
                lblSavingAMTError.Visibility = Visibility.Hidden;
                if (Value <= 0)
                {
                    lblSavingAMTError.Visibility = Visibility.Visible;
                }
                
            }
            catch (Exception)
            {
                lblSavingAMTError.Visibility = Visibility.Visible;
            }
        }
        public bool checkStringInput(string example)
        {
            bool isString = example.Length > 0;
            return isString;
        }

        private void txbSaveName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                string Model = txbSaveName.Text;
                lblSaveNameError.Visibility = Visibility.Hidden;
                if (checkStringInput(Model) == false)
                {
                    lblSaveNameError.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                lblSaveNameError.Visibility = Visibility.Visible;
            }
        }

        private void txbIntRate_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double Value = double.Parse(txbIntRate.Text);
                lblIntRateError.Visibility = Visibility.Hidden;
                if (Value <= 0 || Value > 100)
                {
                    lblIntRateError.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                lblIntRateError.Visibility = Visibility.Visible;
            }

        }

        private void CmbxYears_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                int savingDate = Convert.ToInt32(cmbxYears.Text);

                if (cmbxYears.SelectedIndex > -1)
                {
                    lblMonthsError.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblMonthsError.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                lblMonthsError.Visibility = Visibility.Visible;
            }

        }

        private void rectArrow_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Displays the previous form and hides this one
            Hide();
            frmSavingOption newOption = new frmSavingOption();
            newOption.Show();
        }

        private void cmbxYears_DropDownClosed(object sender, EventArgs e)
        {    
            if (cmbxYears.SelectedIndex > 0)
            {
                lblMonthsError.Visibility = Visibility.Hidden;
            }
     

        }

        private void txbSavingsAMT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txbSaveName.Focus();
            }
        }

        private void txbSaveName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txbIntRate.Focus();
            }
        }

        private void txbIntRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                cmbxYears.Focus();
            }
        }

        private void cmbxYears_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnNext.Focus();
            }
        }
    }
}
