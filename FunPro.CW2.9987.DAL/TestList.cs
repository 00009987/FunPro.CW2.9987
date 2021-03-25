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
            // getting all the tests from the database
            return new TestManager().GetAllTests();
        }

        public List<Tests> Sort()
        {
            // sorting the tests by names using LINQ                       
            return GetAllTests().OrderBy(test => test.Name).ToList();                           
        }

        public List<Tests> Search(string value, ByAttribute attribute)
        {
            switch (attribute)
            {                
                case ByAttribute.TestName:
                    // searching test by its name
                    return GetAllTests().Where(test => test.Name.ToUpper().Contains(value.ToUpper())).ToList();
                case ByAttribute.Question1:
                    // searching test by first question 1
                    return GetAllTests().Where(test => test.Question1.ToUpper().Contains(value.ToUpper())).ToList();
                case ByAttribute.Question2:
                    // searching test by first question 2
                    return GetAllTests().Where(test => test.Question2.ToUpper().Contains(value.ToUpper())).ToList();
                case ByAttribute.Question3:
                    // searching test by first question 3
                    return GetAllTests().Where(test => test.Question3.ToUpper().Contains(value.ToUpper())).ToList();
            }
            
            return null;
        }
    }
}
