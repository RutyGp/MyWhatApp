using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string[] allPic = {
                            @"c:\\users\\nativ\\source\\repos\\hishtalmutmaui\\mywhatapp\\wpfapp1\\myimages\\flower1.jfif",
                            @"c:\\users\\nativ\\source\\repos\\hishtalmutmaui\\mywhatapp\\wpfapp1\\myimages\\6248505501595234555-128.png",
                            @"c:\\users\\nativ\\source\\repos\\hishtalmutmaui\\mywhatapp\\wpfapp1\\myimages\\flower2.jfif",
                            @"c:\\users\\nativ\\source\\repos\\hishtalmutmaui\\mywhatapp\\wpfapp1\\myimages\\flower3.jfif",
                          };
        int pos = 0;
        public Window1()
        {
            InitializeComponent();
            List<int> lst = new();
            for(int i = 1; i <= 30; i++) { lst.Add(i); }
            lb.ItemsSource = lst;
            List<Image> sList = new();
            Image img;
            foreach (string st in allPic)
            {
                img = new();
                img.Source = new BitmapImage(new Uri(st));
                sList.Add(img);
            }
            lv.Visibility = Visibility.Visible;
            lv.ItemsSource = sList;

            StackPanel sp; 
            List<StackPanel> sList2 = new();
            Image img2;
            foreach (string st in allPic)
            {
                sp = new();

                img2 = new();
                img2.Source = new BitmapImage(new Uri(st));
                sp.Children.Add(img2);
                TextBlock tb = new TextBlock();
                tb.Text = st;
                sp.Children.Add(tb);
                sList2.Add(sp);
            }
            lv.Visibility = Visibility.Visible;
            lv.ItemsSource = sList2;

        }

        private void ClickMeLeft(object sender, RoutedEventArgs e)
        {
            //byte[] imgStr = Convert.FromBase64String(allPic[pos]);
            //BitmapImage bitmapImage = new BitmapImage();
            //bitmapImage.BeginInit();
            //bitmapImage.StreamSource = new MemoryStream(imgStr);
            //bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            //bitmapImage.EndInit();

            // Set the Source of the Image control

            // Create a new Image
           // Image newImage = new Image();



            msg.Visibility = Visibility.Collapsed;
            if (pos == allPic.Length - 1)
            {
                msg.Visibility = Visibility.Visible;
            }
            else
            {               
                this.flowerImg.Source = new BitmapImage(new Uri(allPic[pos]));
                pos++;
            }
        }

        private void ClickMeRight(object sender, RoutedEventArgs e)
        {
            msg.Visibility = Visibility.Collapsed;
            if (pos == 0)
            {
                msg.Visibility = Visibility.Visible;
            }
            else
            {
                this.flowerImg.Source = new BitmapImage(new Uri(allPic[pos]));
                pos--;
            }
        }

        private void Change(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("hi");
        }
    }
}
