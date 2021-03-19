using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPro.CW2._9987.DAL
{
    public class Applicants
    {
        // declaring global variables
        public int Id { get; set; }
        private string _name;
        private int _score;
        private string _testTaken;

        public string Name
        {
            // returning name value
            get => _name;
            set
            {
                // validating input value
                if (string.IsNullOrWhiteSpace(value))
                {
                    // showing the error message
                    throw new Exception("Name cannot be empty.");
                }

                // setting value to name variable
                _name = value;
            }
        }
        public int Score
        {
            // returning score value
            get => _score;
            set
            {
                // validating input value
                if (value < 0)
                {
                    // showing the error message
                    throw new Exception("The score cannot be less than 0");                    
                }
                // setting value to score variable
                _score = value;
            }            
        }
        public string TestTaken
        {
            // returning taken test value
            get => _testTaken;
            set
            {
                // validating input value
                //if (string.IsNullOrWhiteSpace(value))
                //{
                    // showing the error message
                 //   throw new Exception("Empty test name cannot be added.");
                //}

                // setting value to the variable
                _testTaken = value;
            }
        }

        // declaring empty Applicants constructor
        public Applicants() { }

        // declaring Applicants constuctor with required parameters
        public Applicants(string name, int score, string testTaken)
        {
            // setting received parameters to the variables accordingly
            Name = name;
            Score = score;
            TestTaken = testTaken;
        }
    }
}
