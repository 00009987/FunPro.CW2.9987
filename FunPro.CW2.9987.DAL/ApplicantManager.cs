using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace FunPro.CW2._9987.DAL
{
    public class ApplicantManager : DbManager
    {
        public void Create(Applicants applicant)
        {
            var sql = $"INSERT INTO Applicants (ap_name_9987, ap_score_9987, ap_tests_taken_9987)" +
                $"VALUES('{applicant.Name}', '{applicant.Score}', '{applicant.TestTaken}')";
            SqlExecuter(sql);            
        }
        public void Update(Applicants applicant)
        {
            var sql = $"UPDATE Applicants SET" +
                $"ap_name_9987 = '{applicant.Name}'," +
                $"ap_score_9987 = '{applicant.Score}'," +
                $"ap_tests_taken_9987 = '{applicant.TestTaken}'," +
                $"WHERE ap_id_9987 = '{applicant.Id}'";
            SqlExecuter(sql);
        }
        public void Delete(int id)
        {
            var sql = $"DELETE FORM Applicants WHERE ap_id_9987 = '{id}'";
            SqlExecuter(sql);
        }
        public List<Applicants> GetAllApplicants()
        {            
            var conn = Connection;
            var applicants = new List<Applicants>();
            try
            {
                var sql = "SELECT ap_name_9987, ap_score_9987, ap_tests_taken_9987 FROM Applicants";
                var command = new SqlCeCommand(sql, conn);
                conn.Open();
                var rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    var applicant = new Applicants
                    {
                        Name = Convert.ToString(rdr.GetValue(1)),
                        Score = Convert.ToInt32(rdr.GetValue(2)),
                        TestTaken = Convert.ToString(rdr.GetValue(3))
                    };
                    applicants.Add(applicant);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return applicants;
        }

        // TO-DO: Persist applicants’ information in the database        

        public void SqlExecuter(string sql)
        {
            var conn = Connection;
            try
            {
                var command = new SqlCeCommand(sql, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
    }
}
