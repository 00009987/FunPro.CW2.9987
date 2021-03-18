using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPro.CW2._9987.DAL
{
    public class Tests
    {
        // declaring global variables
        public int Id { get; set; }
        private string _testName;
        private string _testQuestion1;
        private string _testQuestion1Answer;
        private string _testQuestion2;
        private string _testQuestion2Answer;
        private string _testQuestion3;
        private string _testQuestion3Answer;

        public string TestName
        {
            // returning test name value
            get => _testName;
            set
            {
                // validating input value
                if (string.IsNullOrWhiteSpace(value))
                {
                    // showing the error message
                    throw new Exception("Name cannot be empty.");
                }
                // setting value to test name's variable
                _testName = value;
            }
        }
        public string TestQuestion1
        {
            // returning 1st question's value
            get => _testQuestion1;
            set
            {
                // validating input value
                if (string.IsNullOrWhiteSpace(value))
                {
                    // showing the error message
                    throw new Exception("Test value cannot be empty.");
                }

                // setting value to 1st question's variable
                _testQuestion1 = value;
            }
        }
        public string TestQuestion1Answer
        {
            // returning answer of the 1st question's value
            get => _testQuestion1Answer;
            set
            {
                // validating input value   
                if (string.IsNullOrWhiteSpace(value))
                {
                    // showing the error message
                    throw new Exception("Answer value cannot be empty.");
                }

                // setting value to answer of the 1st question's variable
                _testQuestion1Answer = value;
            }
        }
        public string TestQuestion2
        {
            // returning the 2nd question's value
            get => _testQuestion2;
            set
            {
                // validating input value
                if (string.IsNullOrWhiteSpace(value))
                {                    
                    // showing the error message
                    throw new Exception("Test value cannot be empty.");
                }

                // setting value to the 2nd question's variable
                _testQuestion2 = value;
            }
        }
        public string TestQuestion2Answer
        {
            // returning answer of the 2nd question's value
            get => _testQuestion2Answer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Answer value cannot be empty.");
                }

                // setting value to answer value of the 2nd question's variable
                _testQuestion2Answer = value;
            }
        }
        public string TestQuestion3
        {
            // returning the 3rd question's value
            get => _testQuestion3;
            set
            {
                // validating input value
                if (string.IsNullOrWhiteSpace(value))
                {
                    // showing the error message
                    throw new Exception("Test value cannot be empty.");
                }

                // setting value to the 3rd question's variable
                _testQuestion3 = value;
            }
        }

        public string TestQuestion3Answer
        {
            // returning the 3rd question's value
            get => _testQuestion3Answer;
            set
            {
                // validating input value
                if (string.IsNullOrWhiteSpace(value))
                {
                    // showing the error message
                    throw new Exception("Test value cannot be empty.");
                }

                // setting value to answer of the 3rd question's variable
                _testQuestion3Answer = value;
            }
        }

        // declaring empty Tests constructor
        public Tests() { }

        // declaring constructor with only name var
        public Tests(string testName)
        {
            TestName = testName;
        }

        // declaring constructor with 6 parameters
        public Tests(string testQuestion1, string testQuestion1Answer, string testQuestion2, string testQuestion2Answer, string testQuestion3, string testQuestion3Answer)
        {
            // setting received parameters to the variables accordingly            
            TestQuestion1 = testQuestion1;
            TestQuestion1Answer = testQuestion1Answer;
            TestQuestion2 = testQuestion2;
            TestQuestion2Answer = testQuestion2Answer;
            TestQuestion3 = testQuestion3;
            TestQuestion3Answer = testQuestion3Answer;
        }


        // declaring Tests constuctor with required parameters
        public Tests(string testName, string testQuestion1, string testQuestion1Answer, string testQuestion2, string testQuestion2Answer, string testQuestion3, string testQuestion3Answer)
        {
            // setting received parameters to the variables accordingly
            TestName = testName;
            TestQuestion1 = testQuestion1;
            TestQuestion1Answer = testQuestion1Answer;
            TestQuestion2 = testQuestion2;
            TestQuestion2Answer = testQuestion2Answer;
            TestQuestion3 = testQuestion3;
            TestQuestion3Answer = testQuestion3Answer;
        }
        public override string ToString()
        {
            return TestName;
        }
    }
}
