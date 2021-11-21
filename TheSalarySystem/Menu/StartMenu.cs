using System;
using System.Collections.Generic;
using TheSalarySystem.Models;
using TheSalarySystem.Interfaces;

namespace TheSalarySystem.Menu
{
    /// <summary>
    /// Container of all menus and their methods.
    /// </summary>
    public class StartMenu
    {
        /// <summary>
        /// A list of accounts
        /// </summary>
        public static List<IAccount> listOfUsers = new List<IAccount> { new Admin { firstName = "Sammy", lastName = "Wong", userName = "admin1", password = "admin1234", salary = 23000, role = "adminstrator", isAdmin = true },
                                                                        new User { firstName = "Farzane", lastName = "Zafar", userName = "farzanezafar", password = "password1", salary = 54000, role = "manager", isAdmin = false },
                                                                        new User { firstName = "David", lastName = "Berg", userName = "davidberg", password = "david123", salary = 34000, role = "staff", isAdmin = false }};

        /// <summary>
        /// Method for getting the kind of account.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>Object of IAccount</returns>
        public static IAccount GetUser(string userName)
        {
            IAccount newUser = null;
            foreach (var user in listOfUsers)
            {
                if (user.userName == userName)
                {
                    newUser = user;
                }
            }
            return newUser;
        }

        /// <summary>
        /// log in method 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>The account object if login successed, return null if not.</returns>
        public static string Login(string userName, string password)
        {
            foreach (var user in listOfUsers)
            {
                if (user.userName == userName && user.password == password)
                {
                    return user.userName;
                }
            }
            return null;
        }

        /// <summary>
        /// Shows Log in menu and user enter username and password
        /// if user name and password is valid shows admin menu or user menu
        /// </summary>
        public static void LogInMenu()
        {
            Console.Clear();
            Console.WriteLine("\n Welcome! Please log in for accessing your account.");
            Console.Write("\n UserName: ");
            string userName = Console.ReadLine().Trim().ToLower();
            Console.Write("\n PassWord: ");
            string passWord = Console.ReadLine();
            string newUser = Login(userName, passWord);
            ShowMenu(GetUser(newUser));
        }
        
        /// <summary>
        /// if account is a user account displays user's menu
        /// if account is an admin account displays admin's menu
        /// </summary>
        /// <param name="account">Object of IAccount</param>
        /// <returns></returns>
        public static bool ShowMenu(IAccount account)
        {
            if (account != null)
            {
               Console.Clear();
               account.ShowRole();
               account.ShowSalary();
               account.Menu();
               return true;
            }
            else
            {
                Console.WriteLine("\n Invalid user name and password, try again: ");
                Console.ReadKey();
                LogInMenu();
                return false;
            }
        }
    }
}
