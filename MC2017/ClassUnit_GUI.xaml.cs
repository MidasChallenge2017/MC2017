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
    /// <summary>
    /// ClassUnit_GUI.xaml에 대한 상호 작용 논리
    /// </summary>
    
    public partial class ClassUnit_GUI : UserControl
    {
        public enum class_Type
        {
            NORMAL,
            INTERFACE,
            ABSTRACT,
            UTILITY,
            ENUMERATION
        }

        public string name { get; set; }
        public class_Type type { get; set; }

        public List<Unit_Value> val;
        public List<Unit_Method> method;
        public List<LineUnit_GUI> from; // i'm from!
        public List<LineUnit_GUI> to; // i'm to!

        public ClassUnit_GUI(String _name = "none", class_Type _type = class_Type.NORMAL)
        {
            InitializeComponent();

            name = _name;
            type = _type;
            val = new List<Unit_Value>();
            method = new List<Unit_Method>();
            from = new List<LineUnit_GUI>();
            to = new List<LineUnit_GUI>();

            list_val.ItemsSource = val;
            list_method.ItemsSource = method;

            label_type.Content = "<<" + _type + ">>";
            label_name.Content = _name;

            MouseLeftButtonDown += new MouseButtonEventHandler(mouse_click);
        }

        private void mouse_click(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.program_state == MainWindow.state.None) {
                MainWindow.current_class = this;
                MainWindow.program_state = MainWindow.state.ClassMove;
            }
        }

        

        public void delete_Class()
        {
            foreach (var s in from)
            {
                s.delete_To();
            }
            foreach (var s in to)
            {
                s.delete_From();
            }
        }
        public void add_Line_From(LineUnit_GUI line_From)
        {
            from.Add(line_From);
        }
        public void add_Line_To(LineUnit_GUI line_To)
        {
            to.Add(line_To);
        }
        public void delete_Line_From(LineUnit_GUI line_From)
        {
            from.Remove(line_From);
        }
        public void delete_Line_To(LineUnit_GUI line_To)
        {
            to.Remove(line_To);
        }
        public void add_Unit_Value(Unit_Value val)
        {
            this.val.Add(val);
        }
        public void add_Unit_Method(Unit_Method method)
        {
            this.method.Add(method);
        }
        public void delete_Unit_Value(Unit_Value val)
        {
            this.val.Remove(val);
        }
        public void delete_Unit_Method(Unit_Method method)
        {
            this.method.Remove(method);
        }
    }
}
