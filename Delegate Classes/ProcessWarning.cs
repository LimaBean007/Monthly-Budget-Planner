namespace Monthly_Budget_Planner.Delegate_Classes
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
{
    //Delegate used to display to display the 75% warning to the user (Did not include the home loan warning as a delegate)
    class ProcessWarning
    {

        //Delegate 
        public delegate void processWarningDelegate();
        public event processWarningDelegate warningSubmitted;

        //Method used to call the delegate
        public void processWarning()
        {
            //Calls the warning service
            ExpenseWarningService newService = new ExpenseWarningService();
            warningSubmitted += newService.Alert;
            onWarningSubmitted();
        }
        //Method called when the process is issued
        protected virtual void onWarningSubmitted()
        {
            if (warningSubmitted != null)
            {
                warningSubmitted();
            }
        }
    }
}
