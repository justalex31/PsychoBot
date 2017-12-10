using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Words
    {
        private string _word { get; set; }
        private double _valence { get; set; }
        private int _count { get; set; }
        private int _figure { get; set; }

        public Words(string Word, double Valence)
        {
            _word = Word;
            _valence = Valence;
        }

        public Words(string Word, double Valence, int Count, int Figure)
        {
            _word = Word;
            _valence = Valence;
            _count = Count;
            _figure = Figure;
        }

        public string Word
        {
            get { return _word; }
            set { _word = value; }
        }

        public double Valence {
            get { return _valence; }
            set { _valence = value; }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public int Figure
        {
            get { return _figure; }
            set { _figure = value; }
        }
    }
}
