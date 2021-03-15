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

        public List<Tests> Search(string value, int id, ByAttribute attribute)
        {
            switch (attribute)
            {
                case ByAttribute.Id:
                    // searching test by id
                    return GetAllTests().Where(test => test.Id.Equals(id)).ToList();
                case ByAttribute.TestName:
                    // searching test by its name
                    return GetAllTests().Where(test => test.TestName.ToUpper().Contains(value.ToUpper())).ToList();
            }
            
            return null;
        }
    }
}
