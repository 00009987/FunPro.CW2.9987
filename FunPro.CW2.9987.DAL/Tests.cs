using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPro.CW2._9987.DAL
{
    public class Tests
    {
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
            get => _testName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty.");
                }
                _testName = value;
            }
        }
        public string TestQuestion1
        {
            get => _testQuestion1;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Test value cannot be empty.");
                }
                _testQuestion1 = value;
            }
        }
        public string TestQuestion1Answer
        {
            get => _testQuestion1Answer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Answer value cannot be empty.");
                }
                _testQuestion1Answer = value;
            }
        }
        public string TestQuestion2
        {
            get => _testQuestion2;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Test value cannot be empty.");
                }
                _testQuestion2 = value;
            }
        }
        public string TestQuestion2Answer
        {
            get => _testQuestion2Answer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Answer value cannot be empty.");
                }
                _testQuestion2Answer = value;
            }
        }
        public string TestQuestion3
        {
            get => _testQuestion3;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Test value cannot be empty.");
                }
                _testQuestion3 = value;
            }
        }
        public string TestQuestion3Answer
        {
            get => _testQuestion3Answer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Test value cannot be empty.");
                }
                _testQuestion3Answer = value;
            }
        }

        public Tests() { }
        public Tests(string testName, string testQuestion1, string testQuestion1Answer, string testQuestion2, string testQuestion2Answer, string testQuestion3, string testQuestion3Answer)
        {
            TestName = testName;
            TestQuestion1 = testQuestion1;
            TestQuestion1Answer = testQuestion1Answer;
            TestQuestion2 = testQuestion2;
            TestQuestion2Answer = testQuestion2Answer;
            TestQuestion3 = testQuestion3;
            TestQuestion3Answer = testQuestion3Answer;
        }
    }
}
