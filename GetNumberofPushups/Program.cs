using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNumberofPushups
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assuming Start Date as day on which started pushups
            DateTime startDate = Convert.ToDateTime("01/01/2019"); 
            //Assuming End Date as last day of year for calculating pushups for entire year     
            DateTime endDate = Convert.ToDateTime("12/31/2019");
            //Assuming Missed Date as the day pushups are missed
            DateTime missedDate = Convert.ToDateTime("02/05/2019");

            //Declarations of Variables
            string SpinnerValue = string.Empty;

            Console.WriteLine("Enter Start Date: ");
            string inputValue = Console.ReadLine();
            startDate = Convert.ToDateTime(inputValue);

            Console.WriteLine("Enter End Date: ");
            inputValue = Console.ReadLine();
            endDate = Convert.ToDateTime(inputValue);

            Console.WriteLine("Enter Missed Date: ");
            inputValue = Console.ReadLine();
            missedDate = Convert.ToDateTime(inputValue);

            //Console.WriteLine("Enter SpinnerValue ");
            //inputValue = Console.ReadLine();
            //SpinnerValue = (inputValue).ToString();

            // Function to calculate Total Pushups for a day based on the starting day of pushups and end date.  
            int TotalPushUpsForaDay = GetBusinessDays(startDate, endDate);

            /*For using Spinner for calculating Missed day Pushups. 
            Random Number will give a value everytime we spin it and based on the random number we are taking Spinner Value and based on Spinner value we are calculating the Pushups for missed days.*/
            Random number = new Random();
            int id = number.Next(1, 3);
            SpinnerValue = GetSpinner(id);
           int NoofPushupsonmissedday = calculate(startDate, missedDate, SpinnerValue);
            Console.WriteLine("Total pushUps for a day:" + NoofPushupsonmissedday); 
        }

        public static Int32 GetBusinessDays(DateTime startD, DateTime endD)
        {
            //logic for calculating Working days by excluding weekends
            double calcBusinessDays =
                1 + ((endD - startD).TotalDays * 5 -
                (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

            if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;
            int TotalWorkingDays = Convert.ToInt16(calcBusinessDays);
  
            int TotalPushUpsForaDay = (TotalWorkingDays * (TotalWorkingDays + 1)) / 2;
            return TotalPushUpsForaDay;
        }

   // Assuming the Spinner values as 2x, forgiven, Coworkerdoeshalf
        public static string GetSpinner(int Id)
        {
            string SpinnerValue = string.Empty;
            switch (Id)
            {
                case 1:
                    SpinnerValue = "2x"; 
                    break;
                case 2:
                    SpinnerValue = "forgiven";
                    break;
                case 3:
                    SpinnerValue = "CoWorkerdoeeshalf";
                    break;
            }
            return SpinnerValue;
        }

        public static int calculate(DateTime startdate, DateTime misseddate, string spinvalue)
        {
            int NoofPushupsonmissedday = 0;
            // x is number of pushups per day 
            int x = GetBusinessDays(startdate, misseddate.AddDays(-1));
            // Assuming if it is 2x, person has to do pushups double the actual on the missed day.
            if (spinvalue == "2x")
                       
                NoofPushupsonmissedday = 2 * x;
            
            // Assuming if forgiven, number of pushups to be done that day as 0
           else if (spinvalue == "forgiven")
            
                NoofPushupsonmissedday = 0;
            
            // Assuming if CoWorkerdoeshalf, number of pushups to be shared by co worker hence calculating as half the total pushups for a day.
             else if(spinvalue == "CoWorkerdoeeshalf")
            
                NoofPushupsonmissedday = x / 2;


            return NoofPushupsonmissedday;
        }

    }

}
