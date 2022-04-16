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
    /// Interaction logic for frmHomeLoan.xaml
    /// </summary>
    public partial class frmHomeLoan : Window
    {
        public frmHomeLoan()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            txbPurchasePrice.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblDepError.Visibility = Visibility.Hidden;
                lblIntError.Visibility = Visibility.Hidden;
                lblMonthsError.Visibility = Visibility.Hidden;
                lblPriceError.Visibility = Visibility.Hidden;
                //declaring variables for property info
                double property_Price;
                double tot_Deposit;
                double int_Rate;
                int num_Of_Months;

                //Gets the users data from GUI components
                property_Price = Convert.ToDouble(txbPurchasePrice.Text);
                tot_Deposit = Convert.ToDouble(txbTotDep.Text);
                int_Rate = Convert.ToDouble(txbIntRate.Text);
                num_Of_Months = Convert.ToInt32(txbNumMonths.Text);

                if (tot_Deposit < property_Price && property_Price > 0 && tot_Deposit > 0 && num_Of_Months >= 240 && num_Of_Months <= 360 && int_Rate > 0 && int_Rate <= 100)
                {
                    HomeLoan newHome = new HomeLoan(property_Price, tot_Deposit, int_Rate, num_Of_Months);
                    WorkerLists.expenseList.Add(newHome);
                    this.Hide();
                    frmVehicleOption newOption = new frmVehicleOption();
                    newOption.Show();
                }
                else
                {
                    //Error message and determines which component is invalid
                    MessageBox.Show("Please enter the correct values for this property", "ALERT", MessageBoxButton.OK, MessageBoxImage.Warning);
                    if (tot_Deposit > property_Price || tot_Deposit < 0 || txbTotDep.Text == "")
                    { 
                        lblDepError.Visibility = Visibility.Visible; 
                    }
                    if (property_Price <= 0 || txbPurchasePrice.Text =="")
                    {
                        lblPriceError.Visibility = Visibility.Visible;
                    }
                    if (num_Of_Months < 240 || num_Of_Months > 360 || txbNumMonths.Text == "")
                    {
                        lblMonthsError.Visibility = Visibility.Visible;
                    }
                    if (int_Rate < 0 || int_Rate > 100 || txbNumMonths.Text == "")
                    {
                        lblIntError.Visibility = Visibility.Visible;
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Please enter the correct values for this property", "ALERT", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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
                //Creates a delay of 1.4 seconds
                int delay = 1400;

                //---------CODE ATTRIBUTION---------
                //The following method was tafrom StackOverFlow
                //Author : Carlos Loth
                //Link: https://stackoverflow.com/questions/2902327/c-sharp-winforms-change-cursor-icon-of-mouse
                //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                //---------END---------

                Task.Delay(delay).Wait();
                System.Environment.Exit(1);
            }
        }
        //Method that displays the nex form
        private void rectArrow_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frmAccomodation newAcc = new frmAccomodation();
            this.Hide();
            newAcc.Show();
        }
        ////////VALIDATION FOR GUI INPUT COMPONENTS
        private void txbPurchasePrice_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double Value = double.Parse(txbPurchasePrice.Text);
                lblPriceError.Visibility = Visibility.Hidden;
                if (Value <= 0 || txbPurchasePrice.Equals(""))
                {
                    lblPriceError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblPriceError.Visibility = Visibility.Visible;
            }
        }

        private void txbTotDep_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double Value = double.Parse(txbTotDep.Text);
                double Price = double.Parse(txbTotDep.Text);
                lblDepError.Visibility = Visibility.Hidden;
                if (Value <= 0 || txbTotDep.Equals("") || Value > Price)
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
                double Value = double.Parse(txbIntRate.Text);
                lblIntError.Visibility = Visibility.Hidden;
                if (Value <= 0 || txbIntRate.Equals("") || Value > 100)
                {
                    lblIntError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblIntError.Visibility = Visibility.Visible;
            }
        }

        private void txbNumMonths_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double Value = double.Parse(txbNumMonths.Text);
                lblMonthsError.Visibility = Visibility.Hidden;
                if (Value < 240 || txbNumMonths.Equals("") || Value > 360)
                {
                    lblMonthsError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblMonthsError.Visibility = Visibility.Visible;
            }

        }

        private void txbPurchasePrice_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txbTotDep.Focus();
            }
        }

        private void txbTotDep_KeyDown(object sender, KeyEventArgs e)
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
                txbNumMonths.Focus();
            }
        }

        private void txbNumMonths_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnNext.Focus();
            }
        }
    }
}
