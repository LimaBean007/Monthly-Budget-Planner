using Monthly_Budget_Planner.Child_Classes;
using Monthly_Budget_Planner.Workers;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Monthly_Budget_Planner
{
    /// <summary>
    /// Interaction logic for frmGeneralExpense.xaml
    /// </summary>
    public partial class frmGeneralExpense : Window
    {
        public frmGeneralExpense()
        {
            //Centres the form on load
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            txbTax.Focus();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Validation to ensure the user entered the correct details
            try
            {
                lblTaxError.Visibility = Visibility.Hidden;
                lblGroceryError.Visibility = Visibility.Hidden;
                lblWaterError.Visibility = Visibility.Hidden;
                lblTravelError.Visibility = Visibility.Hidden;
                lblOtherError.Visibility = Visibility.Hidden;
                lblCellError.Visibility = Visibility.Hidden;
                //Declaring variables for general expenses;
                double monthly_Tax;
                double grocery_Expense;
                double water_Lights;
                double travel_Cost;
                double cell_Telephone_Price;
                double other_Expenses;

                //Getting values from GUI components
                monthly_Tax = Convert.ToDouble(txbTax.Text);
                grocery_Expense = Convert.ToDouble(txbGroceries.Text);
                water_Lights = Convert.ToDouble(txbWaterxLights.Text);
                travel_Cost = Convert.ToDouble(txbTravelCosts.Text);
                cell_Telephone_Price = Convert.ToDouble(txbCell.Text);
                other_Expenses = Convert.ToDouble(txbOther.Text);

                //Clears everything in the list for a new iteration
                WorkerLists.expenseList.Clear();
                //Validation
                if (monthly_Tax > 0 && monthly_Tax < MainWindow.grossIncomeP)
                {
                    //Creates and saves an object General Expense to the List
                    GeneralExpenses newTax = new GeneralExpenses(monthly_Tax, "Estimated Monthly Tax");
                    GeneralExpenses newGrocery = new GeneralExpenses(grocery_Expense, "Groceries");
                    GeneralExpenses newUtility = new GeneralExpenses(water_Lights, "Water and lights");
                    GeneralExpenses newTravel = new GeneralExpenses(travel_Cost, "Travel Costs (including petrol)");
                    GeneralExpenses newCell = new GeneralExpenses(cell_Telephone_Price, "Cell phone");
                    GeneralExpenses newOther = new GeneralExpenses(other_Expenses, "Other");

                    WorkerLists.expenseList.Add(newTax);
                    WorkerLists.expenseList.Add(newGrocery);
                    WorkerLists.expenseList.Add(newUtility);
                    WorkerLists.expenseList.Add(newTravel);
                    WorkerLists.expenseList.Add(newCell);
                    WorkerLists.expenseList.Add(newOther);
                    //Hides current form and displays the next one
                    frmAccomodation newAcc = new frmAccomodation();
                    newAcc.Show();
                    Hide();
                }
                else
                { 
                    //Displays an error message and determines which component had an invalid value 
                    MessageBox.Show("Please enter the correct General Expense values", "ALERT", MessageBoxButton.OK, MessageBoxImage.Warning);
                    lblTaxError.Visibility = Visibility.Visible;
                    if (grocery_Expense < 0 || string.IsNullOrEmpty(txbGroceries.Text))
                        {
                            lblGroceryError.Visibility = Visibility.Visible;
                        }
                        if (water_Lights < 0 || string.IsNullOrEmpty(txbWaterxLights.Text))
                        {
                            lblWaterError.Visibility = Visibility.Visible;
                        }
                        if (travel_Cost < 0 || string.IsNullOrEmpty(txbTravelCosts.Text))
                        {
                            lblTravelError.Visibility = Visibility.Visible;
                        }
                        if (other_Expenses < 0 || string.IsNullOrEmpty(txbGroceries.Text))
                        {
                            lblOtherError.Visibility = Visibility.Visible;
                        }
                        if (cell_Telephone_Price < 0 || string.IsNullOrEmpty(txbGroceries.Text))
                        {
                            lblCellError.Visibility = Visibility.Visible;
                        }
                }
            }
            catch 
            {
                MessageBox.Show("Please enter the correct General Expense values", "ALERT", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Method used to confirm if the user would like to exit the application  
        private void frmGeneralExpense1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
                Environment.Exit(1);
                }
        }

        private void rectMyArrow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Displays the previous form and clears everything in this form
            Hide();
            MainWindow newIncome = new MainWindow();
            newIncome.Show();
        }

        private void rectArrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Displays the previous form and clears everything in this form
            Hide();
            MainWindow newIncome = new MainWindow();
            newIncome.Show();
        }

        /////////////////////////// Checks and verifies all textboxes using a try catch for each textbox
        ///////////////////// Validation for all GUI input components
        private void txbTax_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double Tax = double.Parse(txbTax.Text);
                lblTaxError.Visibility = Visibility.Hidden;
                if (Tax <= 0 || Tax > MainWindow.grossIncomeP )
                {
                    lblTaxError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblTaxError.Visibility = Visibility.Visible;
            }
        }

        private void txbGroceries_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double value = double.Parse(txbGroceries.Text);
                lblGroceryError.Visibility = Visibility.Hidden;
                if (value < 0)
                {
                    lblGroceryError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblGroceryError.Visibility = Visibility.Visible;
            }
        }

        private void txbWaterxLights_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double value = double.Parse(txbWaterxLights.Text);
                lblWaterError.Visibility = Visibility.Hidden;
                if (value < 0)
                {
                    lblWaterError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblWaterError.Visibility = Visibility.Visible;
            }
        }

        private void txbTravelCosts_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double value = double.Parse(txbTravelCosts.Text);
                lblTravelError.Visibility = Visibility.Hidden;
                if (value < 0)
                {
                    lblTravelError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblTravelError.Visibility = Visibility.Visible;
            }
        }

        private void txbCell_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double value = double.Parse(txbCell.Text);
                lblCellError.Visibility = Visibility.Hidden;
                if (value < 0)
                {
                    lblCellError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblCellError.Visibility = Visibility.Visible;
            }
        }

        private void txbOther_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                double value = double.Parse(txbOther.Text);
                lblOtherError.Visibility = Visibility.Hidden;
                if (value < 0)
                {
                    lblOtherError.Visibility = Visibility.Visible;
                }

            }
            catch (Exception)
            {
                lblOtherError.Visibility = Visibility.Visible;
            }
        }
        ////////////////Focuses the next textbox when enter is clicked

        private void txbGroceries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txbWaterxLights.Focus();
            }
        }

        private void txbWaterxLights_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txbTravelCosts.Focus();
            }
        }

        private void txbTravelCosts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txbCell.Focus();
            }
        }

        private void txbCell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txbOther.Focus();
            }
        }

        private void txbOther_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnNext.Focus();
            }
        }
        //---------CODE ATTRIBUTION---------
        //The following method was from Microsoft Docs
        //Author : adegeo
        //Link:https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/how-to-detect-when-the-enter-key-pressed?view=netframeworkdesktop-4.8
        private void txbTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txbGroceries.Focus();
            }
        }
        //---------END---------
    }
}
