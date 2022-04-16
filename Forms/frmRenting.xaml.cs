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
    /// Interaction logic for frmRenting.xaml
    /// </summary>
    public partial class frmRenting : Window
    {
        public frmRenting()
        {
            //Centres the form on load
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            txbRent.Focus();
        }

        private void rectMyArrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //When the user clicks back it will go to the prev form, creating the option form for Property and renting
            frmAccomodation newAcc = new frmAccomodation();
            //Displays new form and closes this one
            this.Hide();
            newAcc.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblRentError.Visibility = Visibility.Hidden;
                //Declaring variable for rent
                double rentAMT = 0;
                //Gets rent value from GUI component
                rentAMT = Convert.ToDouble(txbRent.Text);
                if (rentAMT > 0)
                {
           
                    //Creating an instance of the rent class to store the object and pass and save it to the list
                    Rent newRent = new Rent(rentAMT);
                    //Hides current form
                    this.Hide();
                    //Adds rent object to list
                    WorkerLists.expenseList.Add(newRent);
                    //Displays the next part of the budget input proess
                    frmVehicleOption newOption = new frmVehicleOption();
                    newOption.Show();
                }
                else
                {
                    //Error message
                    MessageBox.Show("Please enter the correct values for Rental details", "ALERT", MessageBoxButton.OK, MessageBoxImage.Warning);
                    if (rentAMT < 0 || txbRent.Text == "")
                    {
                        txbRent.Text = "0";
                        lblRentError.Visibility = Visibility.Visible;
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Please enter the correct values for Rental details", "ALERT", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void rectArrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //When the user clicks back it will go to the prev form, creating the option form for Property and renting
            frmAccomodation newAcc = new frmAccomodation();
            //Displays new form and closes this one
            this.Hide();
            newAcc.Show();
        }
        //Validation for GUI input component
        private void txbRent_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double income = double.Parse(txbRent.Text);
                lblRentError.Visibility = Visibility.Hidden;
                if (income <= 0)
                {
                    lblRentError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblRentError.Visibility = Visibility.Visible;
            }
        }
        //Confirms that user would like to exit
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

        private void txbRent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnNext.Focus();
            }
        }
    }
}
