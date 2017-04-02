using DailyNote.DataBases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace DailyNote
{


    public sealed partial class UpdataPage : Page
    {
        public UpdataPage()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "" || passwordBox1.Password == "")
            {
                string msg = $"the block can not be null!";
                await new MessageDialog(msg).ShowAsync();
            }
            else
            {
                
          
             
                using (var conn = DatabaseConnection.GetDbConnection())
                {
                    var psd = conn.Table<User>().Where(v => v. Id.Equals(1));

                    foreach (var item in psd)
                    {
                        if (passwordBox.Password == item.Password)
                        {
                            conn.Execute("UPDATE User SET Password = ? Where Id = ?", passwordBox1.Password,1);
                            string msg = $"Password changed!";
                            await new MessageDialog(msg).ShowAsync();

                            
                            this.Frame.Navigate(typeof(MainPage));
                        }
                        else
                        {
                            string msg = $"Type correct Password please!";
                            await new MessageDialog(msg).ShowAsync();
                        }
                    }
                }
            }
        }
    }
}
