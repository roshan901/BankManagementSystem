using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Bank_Managment_System
{
    /// <summary>
    /// Class validation
    /// </summary>
    class Validation
    {
       
        /// <summary>
        /// Password check
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        //public bool PasswordValid(string password)
        //{
        //    try
        //    {
        //        Regex regex = new Regex(@"^([a-zA-Z0-9@*#]{8,15})$");
        //        Match match = regex.Match(password);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        return false;
        //    }


        //}
        /// <summary>
        /// Email validation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool EmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch (Exception e)
            {

                return false;

            }
        }
    }
}