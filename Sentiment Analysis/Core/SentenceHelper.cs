using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class SentenceHelper
    {
        static FileHelper file = new FileHelper();
        static DBHelper dBHelper = new DBHelper();

        public static void UpdateData(string sentence, string pos)
        {
            string[] str = sentence.Trim().Split(new char[] { ' ' });
            foreach (string s in str)
            {
                dBHelper.UpdateWord(s, pos);
            }
        }

        public static double UseANEW(string text)
        {
            if (text != null)
            {
                string[] str = text.Trim().Split(new char[] { ' ' });

                double count = 0;
                int figure = 0;

                foreach (string s in str)
                {
                    Words w = dBHelper.GetWordsFromAnew(s);

                    if (w != null)
                    {
                        count += w.Valence;
                        figure++;
                    }
                }

                return count / figure;
            }
            else return -1;
        }

        public static double UseSenDb(string text)
        {
            if (text != null)
            {
                string[] str = text.Trim().Split(new char[] { ' ' });

                double count = 0;
                int figure = 0;

                foreach (string s in str)
                {
                    Words w = dBHelper.GetWordsFromSenDb(s);

                    if (w != null)
                    {
                        count += w.Valence;
                        figure++;
                    }
                }

                return count / figure;
            }
            else return -1;
        }
    }
}
