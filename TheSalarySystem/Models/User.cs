namespace TheSalarySystem.Models
{
    using TheSalarySystem.Interfaces;
    using TheSalarySystem.Menu;
    using System;
    using System.Collections.Generic;


    public class User : IAccount
    {

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string userName { get; set; }

        public string password { get; set; }

        public int salary { get; set; }

        public string role { get; set; }

        public bool isAdmin { get; set; }

        public User()
        {

        }

        
        public User(string firstName, string lastName, string userName, string passWord, int salary, string role, bool IsAdmin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.password = passWord;
            this.salary = salary;
            this.role = role;
            this.isAdmin = isAdmin;
        }

        /// <summary>
        /// Shows the role on the console.
        /// </summary>
        public void ShowRole()
        {
            Console.WriteLine(" \n Your role: {0}", role);
        }

        /// <summary>
        /// Shows the salary on the console
        /// </summary>
        public void ShowSalary()
        {
            Console.WriteLine(" \n Your salary: {0}", salary);
        }

        /// <summary>
        /// Deletes user's account.
        /// Takes the user name and password and sends to Delete method
        /// </summary>
        /// <param name="listOfUsers">The listOfUsers<see cref="List{IAccount}"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool DeleteAccount()
        {
            Console.WriteLine("\n Enter user name and password to delete the account.");
            Console.Write("\n User name: ");
            string username = Console.ReadLine();
            Console.Write("\n Password: ");
            string passWord = Console.ReadLine();
            return (Delete(username, passWord));
        }

        /// <summary>
        /// Deletes user's account.
        /// Checks whether username and password belong to the user then deletes the account if exists in the list of users.
        /// </summary>
        /// <param name="listOfUsers">The listOfUsers<see cref="List{IAccount}"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public virtual bool Delete(string UserName, string Password)
        {
            foreach (var item in StartMenu.listOfUsers)
            {
                if (item.userName == UserName && item.password == Password)
                {
                    if (userName == UserName && password == Password)
                    {
                        StartMenu.listOfUsers.Remove(item);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Shows the user's menu
        /// </summary>
        /// <param name="listOfUsers">The listOfUsers<see cref="List{IAccount}"/>.</param>
        public virtual void Menu()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("\n [1] Delete your account");
            Console.WriteLine("\n [2] Logout");
            Console.Write("\n Select an option: ");
            _ = int.TryParse(Console.ReadLine(), out int choice);
            while (choice != 1 && choice != 2)
            {
                Console.Write("\n Invalid input, try again: ");
                _ = int.TryParse(Console.ReadLine(), out choice);
            }

            ShowSelectedOption(choice);
        }

        /// <summary>
        /// Shows the selected option in the user's menu.
        /// </summary>
        /// <param name="choice">The choice<see cref="int"/>.</param>
        /// <param name="listOfUsers">The listOfUsers<see cref="List{IAccount}"/>.</param>
        private void ShowSelectedOption(int choice)
        {
            switch (choice)
            {
                case 1:
                    if (DeleteAccount())
                    {
                        Console.WriteLine("\n Your account has been deleted successfully.");
                        Console.ReadKey();
                        Console.Clear();
                        StartMenu.LogInMenu();
                    }
                    else
                    {
                        Console.WriteLine("\n Could not deleted. ");
                        Console.Write("\n Try again? (y/n): ");
                        if (Console.ReadLine().Trim().ToLower() == "y")
                        {
                            DeleteAccount();
                        }
                        else
                        {
                            LogOut();
                        }

                    }
                    break;
                case 2:
                    LogOut();
                    break;
            }
        }

        /// <summary>
        /// Logs out the user and shows the login menu again.
        /// </summary>
        public void LogOut()
        {
            Console.Clear();
            StartMenu.LogInMenu();
        }

    }
}
