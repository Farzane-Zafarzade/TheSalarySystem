namespace TheSalarySystem.Models
{
    using TheSalarySystem.Interfaces;
    using TheSalarySystem.Menu;
    using System;
    using System.Collections.Generic;

    public class Admin : User, IAccount
    {
        public Admin(string firstName, string lastName, string userName, string passWord, int salary, string role, bool IsAdmin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.password = passWord;
            this.salary = salary;
            this.role = role;
            this.isAdmin = isAdmin;
        }

        public Admin()
        {

        }

        /// <summary>
        /// Lists all user that exit in list of users (data base)
        /// </summary>
        /// <param name="lisOfUsers">The lisOfUsers<see cref="List{IAccount}"/>.</param>
        public bool ListUsers()
        {
            if (StartMenu.listOfUsers != null)
            {
                foreach (var user in StartMenu.listOfUsers)
                {
                    Console.WriteLine("User name: {0}, Password: {1}", user.userName, user.password);
                }
                return true;
            }
            return false;

        }

        /// <summary>
        /// Creates a new user and adds to list of users.
        /// If new user added successfully it returns index of new user in the list, else returns -1.
        /// </summary>
        /// <param name="users">The users<see cref="List{IAccount}"/>.</param>
        public int CreateUser(string fname,string lname, string uname, string pass, string role, int salary, bool isAdmin)
        {
            User newUser = new();
            newUser.firstName = fname;
            newUser.lastName = lname;
            newUser.userName = uname;
            newUser.password = pass;
            newUser.role = role;
            newUser.salary = salary;
            newUser.isAdmin = isAdmin;

            StartMenu.listOfUsers.Add(newUser);
            int index = StartMenu.listOfUsers.IndexOf(newUser);
            return index;
        }

        /// <summary>
        /// Takes data from user and create a new user.
        /// </summary>
        /// <returns>The <see cref="User"/>.</returns>
        public int SetUser()
        {
            Console.Write("\n Enter first name:");
            string fname = Console.ReadLine();
            Console.Write("\n Enter last name: ");
            string lname = Console.ReadLine();
            Console.Write("\n Enter username:");
            string uname = Console.ReadLine();
            foreach (var user in StartMenu.listOfUsers)
            {
                while (user.userName==uname)
                {
                    Console.WriteLine("\n Username is taken, choose another username");
                    uname = Console.ReadLine();
                }
            }
            Console.Write("\n Enter password: ");
            string pass = Console.ReadLine();
            Console.Write("\n Enter role:");
            string Role = Console.ReadLine();
            Console.Write("\n Enter salary: ");
            var _int = int.TryParse(Console.ReadLine(), out int Salary);
            while (_int == false)
            {
                Console.Write("\n Invalid data, Enter a number: ");
                _int = int.TryParse(Console.ReadLine(), out Salary);
            }
            int salary = Salary;

            return CreateUser(fname, lname, uname, pass, Role, salary, false);
            
        }

        /// <summary>
        /// Deletes user's account.
        /// Checks whether username and password belong to the user then deletes the account if exists in the list of users.
        /// </summary>
        /// <param name="listOfUsers">The listOfUsers<see cref="List{IAccount}"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool Delete(string UserName, string Password)
        {
            foreach (var item in StartMenu.listOfUsers)
            {
                if (item.userName == UserName && item.password == Password)
                {
                    if (userName != UserName && password != Password)
                    {
                        StartMenu.listOfUsers.Remove(item);
                        return true;
                    }

                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Shows the admin's menu
        /// </summary>
        /// <param name="listOfUsers">The listOfUsers<see cref="List{IAccount}"/>.</param>
        public override void Menu()
        {
            Console.WriteLine("------------");
            Console.WriteLine("[1] List all users");
            Console.WriteLine("[2] Create new user account");
            Console.WriteLine("[3] Delete user account");
            Console.WriteLine("[4] Logout");
            Console.Write("Select an option: ");
            _ = int.TryParse(Console.ReadLine(), out int choice);
            while (choice != 1 && choice != 2 && choice != 3 && choice != 4)
            {
                Console.Write("\n Invalid input, try again: ");
                _ = int.TryParse(Console.ReadLine(), out choice);
            }

            ShowSelectedOption(choice);
        }

        /// <summary>
        /// Shows the selected option in admin's menu
        /// </summary>
        /// <param name="choice">The choice<see cref="int"/>.</param>
        /// <param name="listOfUsers">The listOfUsers<see cref="List{IAccount}"/>.</param>
        private void ShowSelectedOption(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    ListUsers();
                    BackToMenu();
                    break;

                case 2:
                    Console.Clear();
                    if (SetUser() != -1)
                    {
                        Console.WriteLine("\n The User added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("\n Could not added. ");
                    }

                    BackToMenu();
                    break;

                case 3:
                    Console.Clear();
                    if (DeleteAccount(StartMenu.listOfUsers))
                    {
                        Console.WriteLine("\n The account has been deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("\n Could not deleted. ");
                    }
                    BackToMenu();
                    break;

                case 4:
                    Console.Clear();
                    LogOut();
                    break;
            }
        }

        /// <summary>
        /// Returns to main menu or exits the program.
        /// </summary>
        /// <param name="listOfUsers">The listOfUsers<see cref="List{IAccount}"/>.</param>
        private void BackToMenu()
        {
            Console.Write("\n Do you want to back to menu: (y/n)  ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "y")
            {
                Menu();
            }
            else if (input == "n")
            {
                System.Environment.Exit(1);
            }
            else
            {
                Console.Write("\n Invalid input, enter 'y' or 'n': ");
                input = Console.ReadLine().ToLower().Trim();
            }
        }
    }
}
