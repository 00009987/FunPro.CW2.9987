using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunPro.CW2._9987
{
    class MyForms
    {
        public static T GetForm<T>() where T : class, new()
        {
            // returning the forms according to their type
            return Application.OpenForms.OfType<T>().FirstOrDefault() ?? new T();
        }

    }
}
