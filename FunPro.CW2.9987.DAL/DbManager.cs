using System.Data.SqlServerCe;

namespace FunPro.CW2._9987.DAL
{
    public class DbManager
    {
        protected SqlCeConnection Connection
        {
            get
            {
                // returning new sql connection with the defined property
                return new SqlCeConnection(Properties.Settings.Default.ConnectionString);
            }
        }
    }
}
