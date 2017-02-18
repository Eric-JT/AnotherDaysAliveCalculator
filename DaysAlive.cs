using System;
namespace DaysAlive
{
  class DaysAlive
  {


    public static bool isLeapYear(int year)
    {
      /* Check if the year is a Leap Year. Input an integer. Returns True or False */
      if (year % 400 == 0) {
        return true;
      }
      else if (year % 100 == 0){
        return false;
      }
      else if (year % 4 == 0){
        return true;
      }
      else{
        return false;
      }
    }


    public static int daysInMonth(int year, int month)
    {
      /* Input year and month, Returns the amount of days in the given month */

      int days = 0;
      switch (month) {
        case 1:
        case 3:
        case 5:
        case 7:
        case 8:
        case 10:
        case 12:
          days = 31;
          break;
        case 4:
        case 6:
        case 9:
        case 11:
          days = 30;
          break;
        case 2:
          if(isLeapYear(year)){
            days = 29;
          }
          else {
            days = 28;
          }
          break;
      }
      return days;
    }


    public static int[] nextDay(int[] date)
    {
      /* The counter. Moves the date to the next day by one number. returns the new date */
      if (date[2] < daysInMonth(date[0], date[1])){
        date[0] = date[0];
        date[1] = date[1];
        date[2] = ++date[2];
        return date;
      }
      else {
        if (date[1] == 12) {
          date[0] = ++date[0];
          date[1] = 1;
          date[2] = 1;
          return date;
        }
        else {
          date[0] = date[0];
          date[1] = ++date[1];
          date[2] = 1;
          return date;
        }
      }
    }


    public static bool isDateBefore(int[] dateOne, int[] dateTwo)
    {
      /* Checks if dates are valid. Returns True or False */
      if (dateOne[0] < dateTwo[0]){
        return true;
      }
      else if (dateOne[0] ==  dateTwo[0]){
        if (dateOne[1] < dateTwo[1]){
          return true;
        }
        else if (dateOne[1] == dateTwo[1]){
          return dateOne[2] < dateTwo[2];
        }
      }
      return false;
    }


    public static int daysBetweenDates(int[] dateOne, int[] dateTwo)
    {
      /* Counts the days between dates. Returns the number of days */
      int days = 0;
      while (isDateBefore(dateOne, dateTwo)){
        dateOne = nextDay(dateOne);
        days+=1;
      }
      return days;
    }


    public static void Main(string[] args)
    {
      int[] dateOne = new int[3];
      int[] dateTwo = new int[3];

      Console.Write("Enter birth year: ");
      dateOne[0] = Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter birth month: ");
      dateOne[1] = Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter birth day: ");
      dateOne[2] = Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter current year: ");
      dateTwo[0] = Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter current month: ");
      dateTwo[1] = Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter current day: ");
      dateTwo[2] = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine(daysBetweenDates(dateOne, dateTwo));
    }
  }
}
