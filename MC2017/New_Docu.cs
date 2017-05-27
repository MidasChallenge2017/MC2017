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

namespace MC2017
{
    public partial class MainWindow : Window
    {
        public void init()
        {
            canvas.Children.RemoveRange(0, canvas.Children.Count);
            list_class.Clear();
            current_class = null;
            program_state = state.None;
            btn_class.IsEnabled = true;
            btn_generalization.IsEnabled = true;
            btn_realization.IsEnabled = true;
            btn_association.IsEnabled = true;
            btn_dependancy.IsEnabled = true;
            canvas.Width = 700;
            canvas.Height = 500;
        }
    }
}