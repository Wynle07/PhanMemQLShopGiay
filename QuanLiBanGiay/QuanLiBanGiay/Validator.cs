using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace QuanLiBanGiay
{
    public static class Validator
    {
        public static bool KiemTraEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string strRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            Regex regex = new Regex(strRegex);
            return regex.IsMatch(email);
        }

        public static bool KiemTraSDT(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt)) return false;
            string strRegex = @"^0\d{9}$";
            Regex regex = new Regex(strRegex);
            return regex.IsMatch(sdt);
        }
    }
}
