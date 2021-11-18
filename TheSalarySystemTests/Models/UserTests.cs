using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheSalarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSalarySystem.Models.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        [DataRow("farzanezafar", "password",true)]
        public void DeleteTest(string userName, string passWord, bool expected)
        {
            var user = new User("Farzane", "Zafar", "farzanezafar", "password", 54000, "manager", false);
            var actual = user.Delete(userName, passWord);
            Assert.AreEqual(expected, actual);
        }
    }
}