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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

            List<Member> members = new();
            members.Add(new Member() { NickName = "happy day", Pic = "C:\\Users\\nativ\\source\\repos\\HishtalmutMaui\\MyWhatApp\\WpfApp1\\MyImages\\6248505501595234555-128.png" });
            members.Add(new Member() { NickName = "happy day", Pic = "C:\\Users\\nativ\\source\\repos\\HishtalmutMaui\\MyWhatApp\\WpfApp1\\MyImages\\flower1.jfif" });

            List<UserControl1> userControls = new();
            foreach (Member m in members)
            {
                userControls.Add( new UserControl1(m) );
            }
            lv.ItemsSource = userControls;

        }
    }
}
