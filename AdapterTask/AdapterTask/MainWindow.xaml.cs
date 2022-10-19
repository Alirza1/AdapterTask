using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace AdapterTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        User user = new User(); 

        private void commit_btn_Click(object sender, RoutedEventArgs e)
        {
            user.Surname = surname_txtb.Text;
            user.Name= name_txtb.Text;
            if ((bool)json_rb.IsChecked)
            {
                JsonSerialize();
            }
            else if ((bool)xml_rb.IsChecked)
            {
                XmlSerialize();
            }
        }

        private void XmlSerialize()
        {
            var xml = new XmlSerializer(typeof(User));
            using (var fs = new FileStream("TranslatorArmy.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, user);
            }
        }

        private void JsonSerialize()
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("user.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, user);
                }
            }
        }
    }
}
