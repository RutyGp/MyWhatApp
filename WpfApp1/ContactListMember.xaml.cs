using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
    /// Interaction logic for ContactListMember.xaml
    /// </summary>
    public partial class ContactListMember : UserControl
    {    
    

    
    Member currentMember = new();


    public ContactListMember()
    {
            InitializeComponent();
            this.DataContext = this;
    }
        public ContactListMember(Member member)
        {
            InitializeComponent();
    
            myBorder.BorderThickness = new Thickness(2);
            myBorder.Background = new SolidColorBrush(Color.FromRgb(192,192,92));
            myBorder.Margin = new Thickness(0, 2, 0, 0);
            // Create a new Label
            Label newLabel = new Label();

            // Set Label properties
            newLabel.Content = member.NickName;
            newLabel.Width = 100;
            newLabel.Height = 30;

            // Add the Label to the grid
            myGrid.Children.Add(newLabel);

            // Set the button's position in the grid
            Grid.SetRow(newLabel, 0); // Set the row (zero-based index)
            Grid.SetColumn(newLabel,0); // Set the column (zero-based index)

            // Create a new Label
            Label newLabel2 = new Label();

            // Set Label properties
            newLabel2.Content = member.TelNumber;
            newLabel2.Width = 100;
            newLabel2.Height = 30;

            // Add the Label to the grid
            myGrid.Children.Add(newLabel2);

            // Set the button's position in the grid
            Grid.SetRow(newLabel2, 0); // Set the row (zero-based index)
            Grid.SetColumn(newLabel2, 1); // Set the column (zero-based index)



            ///====
            byte[] imgStr = Convert.FromBase64String(member.Pic);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(imgStr);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            // Set the Source of the Image control

            // Create a new Image
            Image newImage = new Image();

            // Set Image properties
            newImage.Source = bitmapImage; ;
            newImage.Width = 100;
            newImage.Height = 30;

            // Add the Image to the grid
            myGrid.Children.Add(newImage);

            // Set the button's position in the grid
            Grid.SetRow(newImage, 0); // Set the row (zero-based index)
            Grid.SetColumn(newImage, 2); // Set the column (zero-based index)

            // Create a new Button
            Button newButton = new Button();

            // Set Button properties
          
            newButton.Width = 120;
            newButton.Height = 30;

            currentMember = member;

            newButton.Click += SaveWhichMember;
            
            // Add the Button to the grid
            myGrid.Children.Add(newButton);

            // Set the button's position in the grid
            Grid.SetRow(newButton, 1); // Set the row (zero-based index)
            Grid.SetColumn(newButton, 2); // Set the column (zero-based index)



            myBorder.Child = myGrid;

        }

        private void SaveWhichMember(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(currentMember.TelNumber);
        }

      
    }
    
}
