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
    /// Interaction logic for UserControlIData.xaml
    /// </summary>
    public partial class UserControlIData : UserControl
    {
        public UserControlIData()
        {
            InitializeComponent();
        }

        private void AAA(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.tb.Text + "");
        }
    }
}
