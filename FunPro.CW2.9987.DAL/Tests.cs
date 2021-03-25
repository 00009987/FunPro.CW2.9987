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
        private string _name;
        private string _question1;
        private string _answer1;
        private string _question2;
        private string _answer2;
        private string _question3;
        private string _answer3;

        public string Name
        {
            // returning test name value
            get => _name;
            set
            {
                // validating input value
                if (string.IsNullOrWhiteSpace(value))
                {
                    // showing the error message
                    throw new Exception("Name cannot be empty.");
                }
                // setting value to test name's variable
                _name = value;
            }
        }
        public string Question1
        {
            // returning 1st question's value
            get => _question1;
            set
            {
                // validating input value
                if (string.IsNullOrWhiteSpace(value))
                {
                    // showing the error message
                    throw new Exception("Test value cannot be empty.");
                }

                // setting value to 1st question's variable
                _question1 = value;
            }
        }
        public string Answer1
        {
            // returning answer of the 1st question's value
            get => _answer1;
            set
            {
                // validating input value   
                if (string.IsNullOrWhiteSpace(value))
                {
                    // showing the error message
                    throw new Exception("Answer value cannot be empty.");
                }

                // setting value to answer of the 1st question's variable
                _answer1 = value;
            }
        }
        public string Question2
        {
            // returning the 2nd question's value
            get => _question2;
            set
            {
                // validating input value
                if (string.IsNullOrWhiteSpace(value))
                {                    
                    // showing the error message
                    throw new Exception("Test value cannot be empty.");
                }

                // setting value to the 2nd question's variable
                _question2 = value;
            }
        }
        public string Answer2
        {
            // returning answer of the 2nd question's value
            get => _answer2;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Answer value cannot be empty.");
                }

                // setting value to answer value of the 2nd question's variable
                _answer2 = value;
            }
        }
        public string Question3
        {
            // returning the 3rd question's value
            get => _question3;
            set
            {
                // validating input value
                if (string.IsNullOrWhiteSpace(value))
                {
                    // showing the error message
                    throw new Exception("Test value cannot be empty.");
                }

                // setting value to the 3rd question's variable
                _question3 = value;
            }
        }

        public string Answer3
        {
            // returning the 3rd question's value
            get => _answer3;
            set
            {
                // validating input value
                if (string.IsNullOrWhiteSpace(value))
                {
                    // showing the error message
                    throw new Exception("Test value cannot be empty.");
                }

                // setting value to answer of the 3rd question's variable
                _answer3 = value;
            }
        }

        // declaring empty Tests constructor
        public Tests() { }

        // declaring constructor with only name var
        public Tests(string name)
        {
            Name = name;
        }

        // declaring constructor with 6 parameters
        public Tests(string question1, string answer1, string question2, string answer2, string question3, string answer3)
        {
            // setting received parameters to the variables accordingly            
            Question1 = question1;
            Answer1 = answer1;
            Question2 = question2;
            Answer2 = answer2;
            Question3 = question3;
            Answer3 = answer3;
        }


        // declaring Tests constuctor with required parameters
        public Tests(string testName, string question1, string answer1, string question2, string answer2, string question3, string answer3)
        {
            // setting received parameters to the variables accordingly
            Name = testName;
            Question1 = question1;
            Answer1 = answer1;
            Question2 = question2;
            Answer2 = answer2;
            Question3 = question3;
            Answer3 = answer3;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
