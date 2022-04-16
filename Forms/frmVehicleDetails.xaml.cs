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
    /// Interaction logic for frmVehicleDetails.xaml
    /// </summary>
    public partial class FrmVehicleDetails : Window
    {
        //Creates a delay of 1.4 seconds
        const int DELAY = 1400;

        public FrmVehicleDetails()
        {
            //Centres the form on load
            InitializeComponent();
            txbMakeModel.Focus();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        //Method used to validate a string 
        public bool checkStringInput(string example)
        {
            bool isString = example.Length > 0;
            return isString;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //declaring variables for vehicles
                double veh_PurchasePrice;
                double veh_Tot_Deposit;
                double veh_Int_Rate;
                double insurPrem;
                string makeModel;

                //Getting data from GUI components
                veh_PurchasePrice = Convert.ToDouble(txbPurchasePrice.Text);
                veh_Tot_Deposit = Convert.ToDouble(txbVehDep.Text);
                veh_Int_Rate = Convert.ToDouble(txbIntRate.Text);
                insurPrem = Convert.ToDouble(txbInsurance.Text);
                makeModel = txbMakeModel.Text;
                //Validation 
                if (checkStringInput(makeModel) && veh_PurchasePrice > 0 && veh_Tot_Deposit <= veh_PurchasePrice && veh_Int_Rate > 0 && veh_Int_Rate <= 100 && insurPrem > 0)
                {
                    //Creates and save a vehicle object to a list
                    Vehicles newVehicle = new Vehicles(veh_PurchasePrice, veh_Tot_Deposit, veh_Int_Rate, insurPrem, makeModel);
                    WorkerLists.expenseList.Add(newVehicle);

                    Hide();
                    //Dispalys new form and hides this one
                    frmSavingOption newSaveOption = new frmSavingOption();
                    newSaveOption.Show();
                }
                else
                {
                    //Shows an error message and determines where the error is 
                    MessageBox.Show("Please enter the correct values for Vehicle details", "ALERT", MessageBoxButton.OK, MessageBoxImage.Warning);
                    if (veh_PurchasePrice < 0 || string.IsNullOrEmpty(txbPurchasePrice.Text))
                    {
                        lblPriceError.Visibility = Visibility.Visible;
                    }
                    if (veh_PurchasePrice < 0 || string.IsNullOrEmpty(txbMakeModel.Text))
                    {
                        lblPriceError.Visibility = Visibility.Visible;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter the correct values for Vehicle details", "ALERT", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RectArrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Displays the previous form and hides this one
            Hide();
            frmVehicleOption newOption = new frmVehicleOption();
            newOption.Show();
        }
        //Method used to confirm if the user would like to exit
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
                Mouse.OverrideCursor = Cursors.Wait;
                //---------END---------

                Task.Delay(DELAY).Wait();
                Environment.Exit(1);
            }
        }
        ///////////Validation for the GUI input components
        // Uses try catches to determine if the inputs are valid or not
        private void txbMakeModel_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                string Model = txbMakeModel.Text;
                lblMakeError.Visibility = Visibility.Hidden;
                if (checkStringInput(Model) == false)
                {
                    lblMakeError.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                lblMakeError.Visibility = Visibility.Visible;
            }
        }

        private void txbPurchasePrice_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double Value = double.Parse(txbPurchasePrice.Text);
                lblPriceError.Visibility = Visibility.Hidden;
                if (Value < 0)
                {
                    lblPriceError.Visibility = Visibility.Visible;
                }
            }
            catch (Exception )
            {
                lblPriceError.Visibility = Visibility.Visible;
            }

        }

        private void txbVehDep_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double value = double.Parse(txbVehDep.Text);
                lblDepError.Visibility = Visibility.Hidden;
                if (value < 0 || value > double.Parse(txbPurchasePrice.Text))
                {
                    lblDepError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblDepError.Visibility = Visibility.Visible;
            }

        }

        private void txbIntRate_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double value = double.Parse(txbIntRate.Text);
                lblIntError.Visibility = Visibility.Hidden;
                if (value < 0 || value > 100)
                {
                    lblIntError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblIntError.Visibility = Visibility.Visible;
            }
        }

        private void txbInsurace_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double value = double.Parse(txbInsurance.Text);
                lblInsurError.Visibility = Visibility.Hidden;
                if (value < 0)
                {
                    lblInsurError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblInsurError.Visibility = Visibility.Visible;
            }
        }

        private void txbMakeModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txbPurchasePrice.Focus();
            }
        }

        private void txbPurchasePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txbVehDep.Focus();
            }
        }

        private void txbVehDep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txbIntRate.Focus();
            }
        }

        private void txbInsurance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnNext.Focus();
            }
        }
    }
}
