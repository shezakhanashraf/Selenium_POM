using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Selenium3.Core
{
    public class TestConfiguration
    {

        //Made a singeleton instance through www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
        public TestConfiguration()
        {
            Initialize();
        }
        private string _userName;
        private string _password;
        private string _fName;
        private string _lName;
        private string _postalCode;

        public string UserName
        {
            get { return _userName; }
        }
        public string Password
        {
            get { return _password; }
        }

        public string FirstName
        {
            get { return _fName; }
        }
        public string LastName
        {
            get { return _lName; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
        }


        //Creating instances of the class to be checked if they are null 
        private static TestConfiguration instance = null;
        public static TestConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestConfiguration();
                }
                return instance;
            }
        }

        public void Initialize()
        {
            //For Calling All of the Details from the AppSettings 
            var AppName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings");
            _userName = AppName["Username"];
            _password = AppName["Password"];
            _fName = AppName["FirstName"];
            _lName = AppName["LastName"];
            _postalCode = AppName["PostalCode"];
        }
    }
}
