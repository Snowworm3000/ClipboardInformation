using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ClipboardPaste
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

        private void ButtonPaste_Click(object sender, RoutedEventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject(); //Gets all clipboard data
            string[] formats = data.GetFormats(); //Gets all available clipboard formats

            //lstContentType.Items.Clear(); //Clears the content type list before populating it 

            List<object> clipboardContents = new List<object>();
            for (int i = 0; i < formats.Length; i++) 
            {
                var content = data.GetData(formats[i]);
                clipboardContents.Add(content);
                //lstContentType.Items.Add(formats[i]);
                
            }

            
            lstClipboard.Items.Clear();
            //lstContent.Items.Clear(); //Clears the content list before populating it 
            //foreach (var content in clipboardContents) //Adds clipboard content to the list
            for (int i = 0; i < formats.Length; i++)
            {
                lstClipboard.Items.Add(new Item { content = clipboardContents[i], type = formats[i]});
            }
            
            printList(clipboardContents); // Also prints the clipboard's contents for debugging purposes

            
        }

        public class Item
        {
            public object content { get; set; }

            public String type { get; set; }
        }

        private void printList(List<object> list)
        {
            if(list != null) { 
                foreach (var i in list)
                {
                    Debug.WriteLine(i);
                }
            }
        }
    }
}
