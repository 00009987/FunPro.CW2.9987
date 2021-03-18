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
                $"VALUES ('{test.TestName}', " +
                $"'{test.TestQuestion1}', '{test.TestQuestion1Answer}'," +
                $"'{test.TestQuestion2}', '{test.TestQuestion2Answer}'," +
                $" '{test.TestQuestion3}', '{test.TestQuestion3Answer}')";

            // calling helper method to execute sql statement
            SqlExecuter(sql);
        }

        // method to update the information of the test
        public void Update(Tests test)
        {
            // update sql statement to work with database
            var sql = $"UPDATE Tests SET " +
                $"ts_name_9987 = '{test.TestName}', " +
                $"ts_q1_9987 = '{test.TestQuestion1}', " +
                $"ts_q1_answer_9987 = '{test.TestQuestion1Answer}', " +
                $"ts_q2_9987 = '{test.TestQuestion2}'," +
                $"ts_q2_answer_9987 = '{test.TestQuestion2Answer}', " +
                $"ts_q3_9987 = '{test.TestQuestion3}', " +
                $"ts_q3_answer_9987 = '{test.TestQuestion3Answer}' " +
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
                        TestName = Convert.ToString(rdr.GetValue(1)),
                        TestQuestion1 = Convert.ToString(rdr.GetValue(2)),
                        TestQuestion1Answer = Convert.ToString(rdr.GetValue(3)),
                        TestQuestion2 = Convert.ToString(rdr.GetValue(4)),
                        TestQuestion2Answer = Convert.ToString(rdr.GetValue(5)),
                        TestQuestion3 = Convert.ToString(rdr.GetValue(6)),
                        TestQuestion3Answer = Convert.ToString(rdr.GetValue(7))
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
        public Boolean CheckTestName(string name)
        {
            var conn = Connection;
            // declearing & initializing tests list
            var testNames = new List<String>();

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
                    
                    testNames.Add(t);
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

            return !testNames.Contains((name));
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
                        TestQuestion1 = Convert.ToString(rdr.GetValue(0)),
                        TestQuestion1Answer = Convert.ToString(rdr.GetValue(1)),
                        TestQuestion2 = Convert.ToString(rdr.GetValue(2)),
                        TestQuestion2Answer = Convert.ToString(rdr.GetValue(3)),
                        TestQuestion3 = Convert.ToString(rdr.GetValue(4)),
                        TestQuestion3Answer = Convert.ToString(rdr.GetValue(5))
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
