using System;
using System.Data.SqlClient;

namespace Core
{
    public class DBHelper
    {
        protected string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ANEW;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string connStrSen = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=SenWordsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Words GetWordsFromAnew(string word)
        {
            string sqlExpression = "SELECT * FROM Words WHERE Word = '" + word + "'";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Words w = new Words(reader.GetValue(1).ToString().Trim(new char[] { '\"' }), double.Parse(reader.GetValue(2).ToString()));
                    return w;
                }
            }
            return null;
        }

        public Words GetWordsFromSenDb(string word)
        {
            string sqlExpression = "SELECT * FROM Words WHERE Word = '" + word + "'";
            using (SqlConnection connection = new SqlConnection(connStrSen))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Words w = new Words(
                        reader.GetValue(1).ToString().Trim(new char[] { '\"'}), 
                        double.Parse(reader.GetValue(2).ToString()), 
                        int.Parse(reader.GetValue(3).ToString()),
                        int.Parse(reader.GetValue(4).ToString()));
                    return w;
                }
            }
            return null;
        }

        public void AddWord(string word, string sen)
        {
            string sqlExpression = string.Empty;
            if (sen == "pos")
            {
                sqlExpression = String.Format("INSERT INTO Words (Word, Valence, Count, Figure) VALUES ('{0}', 1, 1, 1)", word);
            } else if (sen == "neg")
            {
                sqlExpression = String.Format("INSERT INTO Words (Word, Valence, Count, Figure) VALUES ('{0}', 0, 0, 1)", word);
            } else { throw new Exception("Error add word"); }

            using(SqlConnection connection = new SqlConnection(connStrSen))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateWord(string word, string sen)
        {
            Words w = GetWordsFromSenDb(word);

            if (w != null)
            {
                double valence = w.Valence;
                int count = w.Count;
                int figure = w.Figure;

                if (sen == "pos")
                {
                    count++;
                    figure++;

                    valence = count / figure;
                }
                else
                {
                    figure++;

                    valence = count / figure;
                }

                string sqlExpression = "UPDATE Words SET Valence=" + valence.ToString() + ",Count=" + count.ToString() + ",Figure=" + figure.ToString() + " WHERE Word='" + word + "'";
                using (SqlConnection conn = new SqlConnection(connStrSen))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, conn);
                    command.ExecuteNonQuery();
                }
            } else
            {
                AddWord(word, sen);
            }
        }
    }
}
