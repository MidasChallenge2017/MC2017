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

namespace MC2017
{
    public partial class MainWindow : Window
    {
        private void keyboard_push_event(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (current_class != null)
                {
                    foreach(var s in current_class.from)
                    {
                        canvas.Children.Remove(s);
                    }
                    foreach (var s in current_class.to)
                    {
                        canvas.Children.Remove(s);
                    }
                    current_class.delete_Class();
                    list_class.Remove(current_class);
                    canvas.Children.Remove(current_class);
                    current_class = null;
                }
                if (current_line != null)
                {
                    current_line.delete_Line();
                    canvas.Children.Remove(current_line);
                    current_line = null;
                }
            }
            if (e.Key == Key.LeftCtrl)
            {
                make_continue = true;
            }
        }

        private void keyboard_up_event(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.LeftCtrl)
            {
                make_continue = false;
            }
        }
    }
}