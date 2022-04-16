using System;
using System.Collections.Generic;
using System.Text;

namespace Monthly_Budget_Planner
{
    //Class income to store all things income related
    class Income
    {
        //Declaring Variables
        private double grossIncome;

        //Constructor for the Income Class
        public Income(double grossIncome)
        {
            this.grossIncome = grossIncome;
        }

        //Getters and Setters
        public double GrossIncome { get => grossIncome; set => grossIncome = value; }
    }
}
