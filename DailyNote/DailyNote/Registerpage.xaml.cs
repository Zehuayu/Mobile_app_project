using System;
using System.Collections.Generic;
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
using Windows.Storage;

using System.ComponentModel.DataAnnotations.Schema;

namespace DailyNote
{
   
    public sealed partial class Registerpage : Page
    {



      
        public Registerpage()
        {
            this.InitializeComponent();
        }


        [Table("userinfo")]
        public class userinfo
        {
               
            public string username { get; set; }
            public string password { get; set; }
        }



        private void register(String Username, String password) {
           Sq
        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var name = textBox.Text;
            var password = textBox1.Text;
            register(name, password);
        }
    }
}
