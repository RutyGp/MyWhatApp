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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for DinamicPage.xaml
    /// </summary>
    public partial class DinamicPage : Page
    {
        private ListBox yearsListBox;
        private ScrollViewer scrollViewer;

        public DinamicPage()
        {
            InitializeComponent();
            
            // Create the window properties
            Title = "Years ListBox";
            Width = 200;
            Height = 300;

            // Create ScrollViewer
            scrollViewer = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                Margin = new Thickness(10)
            };

            // Create ListBox
            yearsListBox = new ListBox();
            yearsListBox.SelectionChanged += YearsListBox_SelectionChanged;
            // Add ListBox to ScrollViewer
            scrollViewer.Content = yearsListBox;

            // Add ScrollViewer to the Window
            this.Content = scrollViewer;

            // Populate the ListBox
            PopulateYearsList();
        }

        private void YearsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(""+yearsListBox.SelectedItem.ToString());
        }

        private void PopulateYearsList()
        {
            for (int year = 1900; year <= 2000; year++)
            {
                yearsListBox.Items.Add(year);
            }
        }       



    }
}
