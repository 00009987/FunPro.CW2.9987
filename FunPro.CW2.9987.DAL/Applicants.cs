using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPro.CW2._9987.DAL
{
    public class Applicants
    {
        public int Id { get; set; }
        private string _name;
        private int _score;
        private string _testTaken;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty.");
                }
                _name = Name;
            }
        }
        public int Score
        {
            get => _score;
            set
            {
                if (value < 0)
                {
                    throw new Exception("The score cannot be less than 0");                    
                }
                _score = value;
            }            
        }
        public string TestTaken
        {
            get => _testTaken;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Empty test name cannot be added.");
                }
                _testTaken = value;
            }
        }

        public Applicants() { }
        public Applicants(string name, int score, string testTaken)
        {
            Name = name;
            Score = score;
            TestTaken = TestTaken;
        }
    }
}
