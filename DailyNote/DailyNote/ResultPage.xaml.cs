using DailyNote.DataBases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace DailyNote
{
    
    public sealed partial class ResultPage : Page
    {
        public ObservableCollection<Infomation> UsefulInfomation = new ObservableCollection<Infomation>();
     
        public ResultPage()
        {
            this.InitializeComponent();

            using (var conn = DataBases.DatabaseConnection.GetDbConnection())
            {
                note note = new note();
                Infomation info = new Infomation();
                var query = conn.Table<note>();

                foreach (var iteam in query)
                {

                    UsefulInfomation.Add(new Infomation(info.note = iteam.Info, info.Location = iteam.Location, info.CurrentTime= iteam.Time));

                }
                
            }

           listBox1.DataContext = UsefulInfomation;
          
           
        }




            public class Infomation { 
                public string note { get; set; }
                public string Location { get; set; }
                public DateTime CurrentTime { get; set; }
                public Infomation() { }
                public Infomation(string info, string location, DateTime currentTime)
                {
                    note = info;
                    Location =location;
                    CurrentTime = currentTime;
                }
                public override string ToString()
                {
                    return "details: " + note + "\n" + "noted Time: " + CurrentTime + "\n" + "your location: " + Location;
                }

            }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Functionpage));
        }
    }
}
