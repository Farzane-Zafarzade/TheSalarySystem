namespace TheSalarySystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IAccount" />.
    /// </summary>
    public interface IAccount
    {

        public string userName { get; set; }

        public string password { get; set; }

        /// <summary>
        /// Shows the salary
        /// </summary>
        public void ShowSalary();

        /// <summary>
        /// Shows the role
        /// </summary>
        public void ShowRole();

        /// <summary>
        /// Deletes an account
        /// </summary>
        /// <param name="listOfUsers">The listOfUsers<see cref="List{IAccount}"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool DeleteAccount(List<IAccount> listOfUsers);

        /// <summary>
        /// Shows the account menu.
        /// </summary>
        /// <param name="listOfUsers">The listOfUsers<see cref="List{IAccount}"/>.</param>
        public void Menu();
    }
}