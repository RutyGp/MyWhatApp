using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for DatesPage.xaml
    /// </summary>
    public partial class DatesPage : Page
    {
        public DatesPage()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {

        }
        Calendar c = new();
        private void RadioChecked(object sender, RoutedEventArgs e)
        {
            if (rb1.IsChecked == true)
            {
                sp.Visibility = Visibility.Visible;
               
            }
        }

        private void CalcAge(object? sender, SelectionChangedEventArgs e)
        {
            var days=DateTime.Now-c.SelectedDate;
            MessageBox.Show(days.Value.TotalDays+"");
        }

        private void GetYear(object sender, RoutedEventArgs e)
        {
            int year;
            bool success = int.TryParse(tb.Text, out year);
            if (success)
            {
                sp.Children.Add(c);
                string st = "01.01." + year;
                DateTime d = DateTime.Parse("01.01." + year);
                c.DisplayMode = CalendarMode.Month;
                c.DisplayDateStart = d;

                c.SelectedDatesChanged += CalcAge;// C_SelectedDatesChanged;
            }
            else
            {
                tb.Foreground = new SolidColorBrush(Colors.DeepPink);
                tb.Text = "not valid text";

            }
        }
        private void GotoDynamicPage(object sender, RoutedEventArgs e)
        {
            NavigationService nv = NavigationService.GetNavigationService(this);
            nv.Navigate(new DinamicPage());
        }
    }  
    }
