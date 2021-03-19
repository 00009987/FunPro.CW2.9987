using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace FunPro.CW2._9987.DAL
{
    public class ApplicantManager : DbManager // inheriting DbManager class
    {
        // method to create a new applicant in the database
        public void Create(Applicants applicant)
        {
            // insert sql statement to work with database
            var sql = $"INSERT INTO Applicants (ap_name_9987, ap_score_9987, ap_tests_taken_9987) " +
                $"VALUES('{applicant.Name}', '{applicant.Score}', '{applicant.TestTaken}')";

            // calling helper method to execute sql statement
            SqlExecuter(sql);            
        }

        // method to update the information of the applicant
        public void Update(Applicants applicant)
        {
            // update sql statement to work with database
            var sql = $"UPDATE Applicants SET " +
                $"ap_name_9987 = '{applicant.Name}'," +
                $"ap_score_9987 = '{applicant.Score}'," +
                $"ap_tests_taken_9987 = '{applicant.TestTaken}' " +
                $"WHERE ap_id_9987 = {applicant.Id}";

            // calling helper method to execute sql statement
            SqlExecuter(sql);
        }

        // method to update the score of the applicant
        public void UpdateScore(int id, int score)
        {
            // update sql statement to work with database
            var sql = $"UPDATE Applicants SET " +                
                $"ap_score_9987 = {score} " +                
                $"WHERE ap_id_9987 = {id}";

            // calling helper method to execute sql statement
            SqlExecuter(sql);
        }

        // method to update the taken tests of the applicant
        public void UpdateTestTaken(int id, string takenTests)
        {
            // update sql statement to work with database
            var sql = $"UPDATE Applicants SET " +
                $"ap_tests_taken_9987 = '{takenTests}' " +
                $"WHERE ap_id_9987 = {id}";

            // calling helper method to execute sql statement
            SqlExecuter(sql);
        }

        // method to delete an applicant
        public void Delete(int id)
        {
            // delete sql statement to work with database
            var sql = $"DELETE FROM Applicants WHERE ap_id_9987 = {id}";

            // calling helper method to execute sql statement
            SqlExecuter(sql);
        }

        // method to get all the applicants from the database
        public List<Applicants> GetAllApplicants()
        {                        
            var conn = Connection;
            // declearing initializing applicants list
            var applicants = new List<Applicants>();
            try
            {
                // select sql statement to work with database
                var sql = "SELECT ap_id_9987, ap_name_9987, ap_score_9987, ap_tests_taken_9987 FROM Applicants";                
                var command = new SqlCeCommand(sql, conn);
                // opening the sql connection
                conn.Open();
                // declearing and initializing reader
                var rdr = command.ExecuteReader();

                // reading from database
                while (rdr.Read())
                {
                    // declearing and initializing new applicant with proper parameters
                    var applicant = new Applicants
                    {
                        Id = Convert.ToInt32(rdr.GetValue(0)),
                        Name = Convert.ToString(rdr.GetValue(1)),
                        Score = Convert.ToInt32(rdr.GetValue(2)),
                        TestTaken = Convert.ToString(rdr.GetValue(3))
                    };
                    // adding the applicant to the list
                    applicants.Add(applicant);
                }
            }
            catch (Exception ex)
            {
                // if there is an error during the prosses, show the proper error message
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                // closing the connection
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            // returning the list of the applicants
            return applicants;
        } 
        
        // helper method to execute sql statements
        public void SqlExecuter(string sql)
        {
            var conn = Connection;
            try
            {
                // declearing and initializing the sqlCeCommand
                var command = new SqlCeCommand(sql, conn);
                // opening the sql connection
                conn.Open();
                // exectuing the command
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // if there is an error during the prosses, show the proper error message                
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                // closing the connection
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
    }
}
