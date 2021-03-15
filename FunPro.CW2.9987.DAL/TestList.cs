using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPro.CW2._9987.DAL
{
    public class TestList
    {
        public List<Tests> GetAllTests()
        {
            return new TestManager().GetAllTests();
        }

        public List<Tests> Sort(ByAttribute attribute)
        {
            // sorting the tests by names using LINQ                       
            return GetAllTests().OrderBy(test => test.TestName).ToList();                           
        }

        public List<Tests> Search(string value, ByAttribute attribute)
        {
            switch (attribute)
            {                
                case ByAttribute.TestName:
                    // searching test by its name
                    return GetAllTests().Where(test => test.TestName.ToUpper().Contains(value.ToUpper())).ToList();
                case ByAttribute.Question1:
                    // searching test by first question 1
                    return GetAllTests().Where(test => test.TestQuestion1.ToUpper().Contains(value.ToUpper())).ToList();
                case ByAttribute.Question2:
                    // searching test by first question 2
                    return GetAllTests().Where(test => test.TestQuestion2.ToUpper().Contains(value.ToUpper())).ToList();
                case ByAttribute.Question3:
                    // searching test by first question 3
                    return GetAllTests().Where(test => test.TestQuestion3.ToUpper().Contains(value.ToUpper())).ToList();
            }
            
            return null;
        }
    }
}
