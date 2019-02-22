using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using lab1_cs.Tools;
using lab1_cs.Tools.Managers;

namespace lab1_cs.ViewModels
{
    internal class SelectingDate:BaseViewModel
    {
        #region Fields
        private DateTime? _date;
        private string age;
        private string westernSign;
        private string chineseSign;

        #region Commands
        private RelayCommand<object> _selectDate;
        #endregion
        #endregion

        #region Properties
        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged();
                

            }
        }
        public string Age
        {
            get
            {
                return "Your age: " + age;
            }
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }
        public string WesternSign
        {
            get
            {
                return "Western horoscope: " + westernSign;
            }

            set
            {
                westernSign = value;
                OnPropertyChanged();
            }
        }

        public string ChineseSign
        {
            get
            {
                return "Chinese horoscope: " + chineseSign;
            }
            set
            {
                chineseSign = value;
                OnPropertyChanged();

            }
        }

        #region Commands

        public RelayCommand<object> SelectDate
        {
            get
            {
                return _selectDate ?? (_selectDate= new RelayCommand<object>(
                           SelectDateImplementation, o => CanExecuteCommand()));
            }
        }

        

        #endregion
        #endregion

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_date.ToString()) ;
        }

        private async void SelectDateImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Thread.Sleep(1300));
            LoaderManager.Instance.HideLoader();
            if (IsDateCorrect(_date))
            {
                DateTime birth = Convert.ToDateTime(_date);
                int res = DateTime.Today.Year - birth.Year;

                if (DateTime.Today.Month < birth.Month ||
                   ((DateTime.Today.Month == birth.Month) && (DateTime.Today.Day < birth.Day)))
                {
                    res--;
                }
                //HappyBirthday();
                Age = res.ToString();
                WesternSign = WesternSigns(_date);
                ChineseSign = ChineseSigns(_date);
                if (IsBirthday(_date))
                {
                    MessageBox.Show("Happy birthday, dear!!!");
                }
            }
            else
            {
                MessageBox.Show("Error!!!\nInput is incorrect!");
            }
           
        }

        private bool IsDateCorrect(DateTime? dt)
        {
            return ((DateTime.Now.Year - dt.Value.Year) > 135 || dt.Value > DateTime.Now) ? false : true;
        }

        private bool IsBirthday(DateTime? dt)
        {
            return (dt.Value.Day == DateTime.Now.Day && dt.Value.Month == DateTime.Now.Month) ? true : false;
        }

        private string WesternSigns(DateTime? dt)
        {
            string res = "";
            int month = dt.Value.Month;
            int day = dt.Value.Day;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
            {
                res = "Aries";
            }
            else if ((month == 4 && day >= 21) || (month == 5 && day <= 20))
            {
                res = "Taurus";
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 21))
            {
                res = "Gemini";
            }
            else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
            {
                res = "Cancer";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 23))
            {
                res = "Leo";
            }
            else if ((month == 8 && day >= 24) || (month == 9 && day <= 23))
            {
                res = "Virgo";
            }
            else if ((month == 9 && day >= 24) || (month == 10 && day <= 23))
            {
                res = "Libra";
            }
            else if ((month == 10 && day >= 24) || (month == 11 && day <= 22))
            {
                res = "Scorpio";
            }
            else if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
            {
                res = "Saggitarius";
            }
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 20))
            {
                res = "Capricorn";
            }
            else if ((month == 1 && day >= 21) || (month == 2 && day <= 20))
            {
                res = "Aquarius";
            }
            else if ((month == 2 && day >= 21) || (month == 3 && day <= 20))
            {
                res = "Pisces";
            }

            return res;

        }


        private string ChineseSigns(DateTime? dt)
        {
            int year = dt.Value.Year;
            if (year % 12 == 0) { return "Monkey"; }
            else if (year % 12 == 1) { return "Rooster"; }
            else if (year % 12 == 2) { return "Dog"; }
            else if (year % 12 == 3) { return "Pig"; }
            else if (year % 12 == 4) { return "Rat"; }
            else if (year % 12 == 5) { return "Ox"; }
            else if (year % 12 == 6) { return "Tiger"; }
            else if (year % 12 == 7) { return "Rabbit"; }
            else if (year % 12 == 8) { return "Dragon"; }
            else if (year % 12 == 9) { return "Snake"; }
            else if (year % 12 == 10) { return "Horse"; }
            else { return "Goat"; }
        }
    }
}
