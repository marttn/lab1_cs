using System;

namespace lab1_cs.Models
{
    internal class Program
    {
        private DateTime? _date;
        private string age;
        private string westernSign;
        private string chineseSign;

        public DateTime? Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        public string WesternSign
        {
            get { return westernSign; }
            set { westernSign = value; }
        }

        public string ChineseSign
        {
            get { return chineseSign; }
            set { chineseSign = value; }
        }
    }
}
