using Microsoft.Win32;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
namespace Monthly_Budget_Planner
{
    /// <summary>
    /// Interaction logic for frmViewReport.xaml
    /// </summary>
    public partial class frmViewReport : Window
    {
        //Constant variable used for a delay
        const int DELAY = 1400;
        public frmViewReport()
        {
            //Clears the textbox and centres the form when the form loads
            InitializeComponent();
            txbOutput.Clear();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }
        //Method to display the report into the textbox
        public void getReport(string display)
        {
            txbOutput.Text = display;
        }
        //Method which allows the user to print the report
        public void PrintReport() {
            try
            {
                //---------CODE ATTRIBUTION---------
                //The following method was from Someblokeontheinternet.blogspot.com
                //Authors : Unknown
                //Link: http://someblokeontheinternet.blogspot.com/2009/11/printing-contents-of-text-box-or-just.html (Not a secure website)
                
                //Creates a print dialog which allows the user to print
                PrintDialog printDialog = new PrintDialog();
                //displays the printing option
                if (printDialog.ShowDialog().GetValueOrDefault())
                {
                    //flowdocument used to state each line of the textbox
                    FlowDocument flowDocument = new FlowDocument();
                    //Loop going throigh the textfile, adding margins, paragrapghs and spaces to mimic the report
                    foreach (string line in txbOutput.Text.Split('\n'))
                    {
                        Paragraph newPara = new Paragraph();
                        newPara.Margin = new Thickness(1);
                        newPara.Inlines.Add(new Run(line));
                        flowDocument.Blocks.Add(newPara);
                    }
                    //---------END---------
                    //Prints the report caling documentpaginator  sending the flowducument to print
                    DocumentPaginator newDocPag = ((IDocumentPaginatorSource)flowDocument).DocumentPaginator;
                    //sends object to print
                    printDialog.PrintDocument(newDocPag, "Income & Expenditure Report");
                }
            }
            catch 
            {
                MessageBox.Show("An unexpected error occurred", "Monthly Budget Planner", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Method that writes the report to a textfile
        public void writeToFile()
        {
            //---------CODE ATTRIBUTION---------
            //The following method was from Microsoft Docs
            //Authors : BillWagner, IEvangelist, nschonni, jdmartinez36, mairaw, Youssef1313, nemrism,yishengjin1413, nxtn, pkulikov, mjhoffman65, mikeblome, guardrex
            //Link: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
            //---------END---------
            //Takes the text from the output
            string context1 = txbOutput.Text;
            //creates a new saveFileDialog
            SaveFileDialog newsaveFileDialog = new SaveFileDialog();

            //Allows the user to select textfile
            newsaveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (newsaveFileDialog.ShowDialog() == true)
            {
                //Checks if the user selects the textfile option
                if (newsaveFileDialog.FilterIndex == 1)
                {
                    try
                    {
                        //Write to text file 
                        using (StreamWriter writer = new StreamWriter(newsaveFileDialog.FileName, false))
                        {
                            writer.WriteLine(context1);
                            MessageBox.Show("File Successfully saved", "Monthly Budget Planner", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                    }catch
                    {
                        //Shows error message if any occur
                        MessageBox.Show("File not Saved", "Monthly Budget Planner", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            }
        //Method if the user does not qualify for a home loan application
        public void incapableNotice()
        {
            MessageBox.Show("The approval of the home loan is declined.", "ALERT", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //Method if the user qualifies for a home laon
        public void isableNotice()
        {
            MessageBox.Show("The approval of the home loan is accepted.", "ALERT", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void lblSubmitNew_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            txbOutput.Clear();
            //---------CODE ATTRIBUTION---------
            //The following method was tafrom StackOverFlow
            //Author : Carlos Loth
            //Link: https://stackoverflow.com/questions/2902327/c-sharp-winforms-change-cursor-icon-of-mouse
            //---------END---------
            //Has a 1.4 second delay and loads the Income form (restarting the project)
            Task.Delay(DELAY).Wait();
            MainWindow newIncome = new MainWindow();
            newIncome.Show();
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
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }
        //method calling the write to file method
        private void rectArrow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            writeToFile();
        }

        //Method calling the print report method
        private void rectPrint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PrintReport();
        }
    }
}
