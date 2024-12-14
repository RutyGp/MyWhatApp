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
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public EditPage(Member m,MemberList mList)
        {
            InitializeComponent();
            this.tbName.Tag = m.NickName;
            this.tbTelNumber.Tag = m.TelNumber;
            this.tbPic.Tag = m.Pic;
            string newNickName = tbPic.Text, newTelNumber = tbTelNumber.Text;
            int index = mList.FindIndex(x => x.TelNumber == m.TelNumber); 
            mList.Remove(mList.Find(x => x.TelNumber == m.TelNumber));
            mList.Insert(index, new Member() { NickName = tbName.Text, Pic = tbPic.Text, TelNumber = tbTelNumber.Text });

        }
    }
}
