using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace HotListReports.Windows.Util{
    /// <summary>
    /// Helper class for times
    /// </summary>
    public class TimeHelper
    {
        /// <summary>
        /// Validates an input time to its proper format which hh:mm:ss
        /// </summary>
        /// <param name="time">Time to be validated</param>
        /// <returns>Returns True if the time is matched, else throws Exception</returns>
        public static bool ValidateInputTimeString(string time)
        {
            Regex timePattern = new Regex("([0-9]|[2][0-3])(:)([0-9]|[1-5][0-9])(:)([0-9]|[1-5][0-9])");

            if (!timePattern.IsMatch(time)){
                MessageBox.Show("Invalid input time format");
                return false;//throw new ArgumentException(ExceptionStrings.INVALID_INPUT_TIME_FORMAT, "CurrentlySelectedTime");
            }else
                return true;
        }
    }
}
