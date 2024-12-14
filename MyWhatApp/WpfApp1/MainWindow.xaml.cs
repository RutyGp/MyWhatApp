using Model;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MemberList mList = new();
        Member m = new();
        public MainWindow()
        {
            InitializeComponent();


            List<Member> cList = new();
            MemberDb mDB = new();
            mList = mDB.SelectAll();
           
            

            myListV.ItemsSource = mList;



            MemberDb memberDb = new();
            Member member = memberDb.SelectAll().First();
            byte[] imgStr = Convert.FromBase64String(member.Pic);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(imgStr);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            // Set the Source of the Image control
            img.Source = bitmapImage;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private DispatcherTimer timer;
        private int counter = 0;

        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            TextBlock1.Text = $"Counter: {counter}";
        }
        private void ShowContactList(object sender, RoutedEventArgs e)
        {
            List<ContactListMember> contactLists = new();
            MemberDb mDB = new();
            MemberList mList = mDB.SelectAll();
            foreach(Member m in mList)
            {
                contactLists.Add(new ContactListMember(m));
            }
            lv.Visibility = Visibility.Visible;
            lv.ItemsSource = contactLists;

            myListV.ItemsSource = contactLists;

            List<Member> cLists = new();
            mDB = new();
            mList = mDB.SelectAll();
            cLists = (List<Member>) mList;
            lv2.Visibility = Visibility.Visible;
            lv2.ItemsSource = cLists;
        }

        private void NextWind(object sender, RoutedEventArgs e)
        {
            Window ownedWindow = new Window1();
            ownedWindow.Owner = this;
            ownedWindow.Show();
        }

        private void Uc(object sender, RoutedEventArgs e)
        {
            Window w = new Window2();
            w.Show();
        }

        private void EditPerson(object sender, RoutedEventArgs e)
        {
            m =(Member) myListV.SelectedItem;


            this.tbName.Tag = m.NickName;
            this.tbTelNumber.Tag = m.TelNumber;
            this.tbPic.Tag = m.Pic;
            this.editMember.Visibility = Visibility.Visible;
            
            //NavigationService nv = NavigationService.GetNavigationService(this);
            //nv.Navigate(new EditPage(mem,mList));
        }

        private void UpdateMember(object sender, RoutedEventArgs e)
        {
            string newNickName = tbPic.Text, newTelNumber = tbTelNumber.Text;
            int index = mList.FindIndex(x => x.TelNumber == m.TelNumber);
            mList.Remove(mList.Find(x => x.TelNumber == m.TelNumber));
            mList.Insert(index, new Member() { NickName = tbName.Text, Pic = tbPic.Text, TelNumber = tbTelNumber.Text });

            myListV.ItemsSource = null;
            myListV.ItemsSource = mList;

        }

        private void selectDates(object sender, SelectionChangedEventArgs e)
        {
            List<DateTime> dLst = (List<DateTime>)mycal.SelectedDates.ToList();
            foreach(var x in dLst)
            {
                MessageBox.Show(""+x.Day);
            }
        }

        private void goToDatesPage(object sender, RoutedEventArgs e)
        {

            NavigationService nv = NavigationService.GetNavigationService(this);
            nv.Navigate(new DatesPage());
        }

        
    }
}