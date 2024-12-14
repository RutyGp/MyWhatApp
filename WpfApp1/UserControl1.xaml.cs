using Model;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public UserControl1(Member member)
        {
            InitializeComponent();
            
            Border myBorder = new();
            myBorder.BorderThickness = new Thickness(2);
            myBorder.Background = new SolidColorBrush(Color.FromRgb(192, 192, 92));
            myBorder.Margin = new Thickness(0, 2, 0, 0);

            StackPanel sp = new();
            //Create a new Label
            Label newLabel = new Label();
           
            //Set Label properties
            newLabel.Content = member.NickName;
            newLabel.Width = 100;
            newLabel.Height = 30;

            newLabel.MouseDoubleClick += NewLabel_MouseDoubleClick;
            sp.Children.Add(newLabel);
            
            Image img = new();
            img.Source = new BitmapImage(new Uri(member.Pic));
            sp.Children.Add(img);
            myBorder.Child = sp;
            myGrid.Children.Add(myBorder);
        }

        private void NewLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("you pressed me!");
        }

       

       
    }
}
