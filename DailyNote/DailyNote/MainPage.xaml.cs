using DailyNote.DataBases;
using SQLite.Net;
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

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace DailyNote
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        // need layout and state management
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (var conn = DatabaseConnection.GetDbConnection())
            {
                conn.CreateTable<User>();
                var addPsd = new User() { Password = "1234"};
                var count = conn.Insert(addPsd);

            }
        }
        
        private async void SIgn_In_Click(object sender, RoutedEventArgs e)
        {

            using (var conn = DatabaseConnection.GetDbConnection())
            {
                var psd = conn.Table<User>().Where(v => v.Id.Equals(1));
                foreach (var item in psd) {

                    if (passwordBox.Password == item.Password)
                    {
                        string msg = "$ successful login ";
                        await new MessageDialog(msg).ShowAsync();
                        this.Frame.Navigate(typeof(Functionpage));
                    }
                    else {
                        string msg = "$ pleas type correct password! ";
                        await new MessageDialog(msg).ShowAsync();
                    }
               
                
            }
              
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(UpdataPage));
        }
        }
    }
