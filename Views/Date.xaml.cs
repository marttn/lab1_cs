using System.Windows.Controls;
using lab1_cs.ViewModels;

namespace lab1_cs.Views
{
    public partial class Date : UserControl
    {
        public Date()
        {
            InitializeComponent();
            DataContext = new SelectingDate();
        }
    }
}
