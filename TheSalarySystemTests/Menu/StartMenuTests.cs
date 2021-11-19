using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheSalarySystem.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSalarySystem.Interfaces;
using TheSalarySystem.Models;

namespace TheSalarySystem.Menu.Tests
{
    [TestClass()]
    public class StartMenuTests
    {

        [TestMethod()]
        [DataRow("admin1", "admin1234", "admin1")]
        [DataRow("emmLind", "123abc", null)]
        [DataRow(null, "123abc", null)]
        [DataRow("samwon", null, null)]

        public static void LoginTest(string userName, string passWord, string expected)
        {
            var actual = StartMenu.Login(userName, passWord);
            Assert.AreEqual(expected, actual);

        }
   
    }

}