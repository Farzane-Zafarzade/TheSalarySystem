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

        public bool Delete(string userName, string password);

        /// <summary>
        /// Deletes an account
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool DeleteAccount();

        /// <summary>
        /// Shows the account menu.
        /// </summary>
        public void Menu();

        /// <summary>
        /// Shows the role
        /// </summary>
        public void ShowRole();

        /// <summary>
        /// Shows the salary
        /// </summary>
        public void ShowSalary();
    }
}
