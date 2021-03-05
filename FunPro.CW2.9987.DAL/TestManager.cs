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
        public void Create(Tests test)
        {
            var sql = $"INSERT INTO Tests (ts_name_9987, " +
                $"ts_q1_9987, ts_q1_answer_9987, " +
                $"ts_q2_9987, ts_q2_answer_9987, " +
                $"ts_q3_9987, ts_q3_answer_9987) " +
                $"VALUES ('{test.TestName}', " +
                $"'{test.TestQuestion1}', '{test.TestQuestion1Answer}'," +
                $"'{test.TestQuestion2}', '{test.TestQuestion2Answer}'," +
                $" '{test.TestQuestion3}', '{test.TestQuestion3Answer}')";
            SqlExecuteHelper(sql);
        }
        public void Update(Tests test)
        {
            var sql = $"UPDATE Tests SET " +
                $"ts_name_9987 = '{test.TestName}', " +
                $"ts_q1_9987 = '{test.TestQuestion1}', " +
                $"ts_q1_answer_9987 = '{test.TestQuestion1Answer}', " +
                $"ts_q2_9987 = '{test.TestQuestion2}'," +
                $"ts_q2_answer_9987 = '{test.TestQuestion2Answer}', " +
                $"ts_q3_9987 = '{test.TestQuestion3}', " +
                $"ts_q3_answer_9987 = '{test.TestQuestion3Answer}' " +
                $"WHERE ts_id_9987 = '{test.Id}'";
            SqlExecuteHelper(sql);
        }
        public void Delete(int id)
        {
            var sql = $"DELETE FROM Tests WHERE ts_id_9987 = '{id}'";
            SqlExecuteHelper(sql);
        }
        public List<Tests> GetAllTests(Tests test)
        {
            var conn = Connection;
            var tests = new List<Tests>();
            try
            {
                var sql = $"SELECT ts_name_9987, ts_q1_9987, ts_q1_answer_9987, " +
                    $"ts_q2_9987, ts_q2_answer_9987, " +
                    $"ts_q3_9987, ts_q3_answer_9987 FROM Tests";
                var command = new SqlCeCommand(sql, conn);
                conn.Open();
                var rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    var t = new Tests
                    {
                        TestName = Convert.ToString(rdr.GetValue(1)),
                        TestQuestion1 = Convert.ToString(rdr.GetValue(2)),
                        TestQuestion1Answer = Convert.ToString(rdr.GetValue(3)),
                        TestQuestion2 = Convert.ToString(rdr.GetValue(4)),
                        TestQuestion2Answer = Convert.ToString(rdr.GetValue(5)),
                        TestQuestion3 = Convert.ToString(rdr.GetValue(6)),
                        TestQuestion3Answer = Convert.ToString(rdr.GetValue(7))
                    };
                    tests.Add(t);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return tests;
        }

        //TO-DO: Persist tests’ information in the database

        public void SqlExecuteHelper(string sql)
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
                MessageBox.Show(ex.Message);
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
