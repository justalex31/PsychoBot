using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Core
{
    public class FileHelper : DBHelper
    {
        public string anew = @"C:\Users\Alex\Source\Repos\Sentiment Analysis\Core\ANEW.txt";

        public FileHelper()
        {
            using (StreamReader sr = new StreamReader(anew, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] str = line.Split(new char[] { ' ' });
                    string sqlExpression = String.Format("INSERT INTO Words (Word, Valence) VALUES ('{0}', {1})", str[0], str[2]);
                    using (SqlConnection connection = new SqlConnection(conn))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Stop()
        {
            string sqlExpression = "DELETE FROM Words";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        /*public Words GetWordsFromAnew(string word)
        {
            using (StreamReader sr = new StreamReader(anew, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] str = line.Split(new char[] { ' ' });
                    if (word == str[0])
                    {
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        double d = double.Parse(str[2]);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        return new Words(str[0], d);
                    }
                }
            }
            return null;
        }

        public Words GetWordsFromTestData(string word)
        {
            using (StreamReader sr = new StreamReader(tdata, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] str = line.Split(new char[] { ' ' });
                    if (word == str[0])
                    {
                        CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        double d = double.Parse(str[1]);
                        Thread.CurrentThread.CurrentCulture = temp_culture;
                        return new Words(str[0], d);
                    }
                }
            }
            return null;
        }

        public void AddWords(string word, string sen)
        {
            using(StreamWriter sw = new StreamWriter(tdata, true, Encoding.Default))
            {
                if (sen == "pos")
                {
                    sw.WriteLine(word + " 1 1 1");
                }
                else
                {
                    sw.WriteLine(word + " 0 0 1");
                }
            }
        }

        public void UpdateWords(string word, string sen)
        {
            using(StreamWriter sw = new StreamWriter(tdata, true, Encoding.Default))
            {

            }
        }*/
    }
}
