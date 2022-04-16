using System;
using System.Collections.Generic;
using System.Text;
//Emil Namaan Reuben Murray
//PROG POE TASK 3
//Student Number: 20117913
namespace Monthly_Budget_Planner.Abstract
{
   public abstract class Expense
    {
        //Declaring an abstract method getExpense that can be overridden by Expenses child classes 
        public abstract double getExpense();
        public abstract string toString();
    }
}
