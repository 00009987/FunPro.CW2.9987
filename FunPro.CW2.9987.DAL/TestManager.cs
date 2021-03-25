using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace FunPro.CW2._9987.DAL
{
    public class TestManager : DbManager
    {
        // method to create a new test in the database
        public void Create(Tests test)
        {
            // insert sql statement to work with database
            var sql = $"INSERT INTO Tests (ts_name_9987, " +
                $"ts_q1_9987, ts_q1_answer_9987, " +
                $"ts_q2_9987, ts_q2_answer_9987, " +
                $"ts_q3_9987, ts_q3_answer_9987) " +
                $"VALUES ('{test.Name}', " +
                $"'{test.Question1}', '{test.Answer1}'," +
                $"'{test.Question2}', '{test.Answer2}'," +
                $" '{test.Question3}', '{test.Answer3}')";

            // calling helper method to execute sql statement
            SqlExecuter(sql);
        }

        // method to update the information of the test
        public void Update(Tests test)
        {
            // update sql statement to work with database
            var sql = $"UPDATE Tests SET " +
                $"ts_name_9987 = '{test.Name}', " +
                $"ts_q1_9987 = '{test.Question1}', " +
                $"ts_q1_answer_9987 = '{test.Answer1}', " +
                $"ts_q2_9987 = '{test.Question2}'," +
                $"ts_q2_answer_9987 = '{test.Answer2}', " +
                $"ts_q3_9987 = '{test.Question3}', " +
                $"ts_q3_answer_9987 = '{test.Answer3}' " +
                $"WHERE ts_id_9987 = {test.Id}";

            // calling helper method to execute sql statement
            SqlExecuter(sql);
        }

        // method to delete a test
        public void Delete(int id)
        {
            // delete sql statement to work with database
            var sql = $"DELETE FROM Tests WHERE ts_id_9987 = {id}";

            // calling helper method to execute sql statement
            SqlExecuter(sql);
        }

        // method to get all the tests from the database
        public List<Tests> GetAllTests()
        {
            var conn = Connection;

            // declearing initializing tests list
            var tests = new List<Tests>();
            try
            {
                // select sql statement to work with database
                var sql = $"SELECT ts_id_9987, ts_name_9987, ts_q1_9987, ts_q1_answer_9987, " +
                    $"ts_q2_9987, ts_q2_answer_9987, " +
                    $"ts_q3_9987, ts_q3_answer_9987 FROM Tests";
                var command = new SqlCeCommand(sql, conn);
                // opening the sql connection
                conn.Open();
                // declearing and initializing reader
                var rdr = command.ExecuteReader();

                // reading from database
                while (rdr.Read())
                {
                    // declearing and initializing new test with proper parameters
                    var t = new Tests
                    {
                        Id = Convert.ToInt32(rdr.GetValue(0)),
                        Name = Convert.ToString(rdr.GetValue(1)),
                        Question1 = Convert.ToString(rdr.GetValue(2)),
                        Answer1 = Convert.ToString(rdr.GetValue(3)),
                        Question2 = Convert.ToString(rdr.GetValue(4)),
                        Answer2 = Convert.ToString(rdr.GetValue(5)),
                        Question3 = Convert.ToString(rdr.GetValue(6)),
                        Answer3 = Convert.ToString(rdr.GetValue(7))
                    };

                    // adding the the to the list
                    tests.Add(t);
                }
            }
            catch (Exception ex)
            {
                // if there is an error during the prosses, show the proper error message
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // closing the connection
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            // returning the list of the tests
            return tests;
        }

        // method to check if the test with the same name is tried to be created
        public Boolean CheckName(string name)
        {
            var conn = Connection;
            // declearing & initializing tests list
            var Names = new List<String>();

            try
            {
                var sql = $"SELECT ap_name_9987 FROM Applicants";             
                var command = new SqlCeCommand(sql, conn);
                // opening the sql connection
                conn.Open();
                // declearing and initializing reader
                var rdr = command.ExecuteReader();

                // reading from database
                while (rdr.Read())
                {
                    var t = Convert.ToString(rdr.GetValue(0));
                    
                    Names.Add(t);
                }                          
            }
            catch (Exception ex)
            {
                // if there is an error during the prosses, show the proper error message
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // closing the connection
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }            

            return !Names.Contains((name));
        }

        // method to get questions & answers according to the test name
        public Tests GetQuestionsAndAnswers(string name)
        {
            var conn = Connection;            

            try
            {
                // select sql statement to work with database
                var sql = $"SELECT ts_q1_9987, ts_q1_answer_9987, " +
                    $"ts_q2_9987, ts_q2_answer_9987, " +
                    $"ts_q3_9987, ts_q3_answer_9987 FROM Tests " +
                    $"WHERE ts_name_9987 = '{name}'";
                var command = new SqlCeCommand(sql, conn);
                // opening the sql connection
                conn.Open();
                // declearing and initializing reader
                var rdr = command.ExecuteReader();

                // reading from database
                if (rdr.Read())
                {
                    // declearing and initializing new test with proper parameters
                    var t = new Tests
                    {                        
                        Question1 = Convert.ToString(rdr.GetValue(0)),
                        Answer1 = Convert.ToString(rdr.GetValue(1)),
                        Question2 = Convert.ToString(rdr.GetValue(2)),
                        Answer2 = Convert.ToString(rdr.GetValue(3)),
                        Question3 = Convert.ToString(rdr.GetValue(4)),
                        Answer3 = Convert.ToString(rdr.GetValue(5))
                    };

                    return t;
                }
            }
            catch (Exception ex)
            {
                // if there is an error during the prosses, show the proper error message
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // closing the connection
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            // if something went wrong, return null
            return null;
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
                MessageBox.Show(ex.Message);
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
