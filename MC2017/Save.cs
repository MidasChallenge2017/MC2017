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
        public void save(string file_Name)
        {
            FileStream FS = new FileStream(file_Name, FileMode.Append, FileAccess.Write);
            StreamWriter SW = new StreamWriter(FS);
            SW.WriteLine(canvas.Width);
            SW.WriteLine(canvas.Height);
            SW.WriteLine(list_class.Count);
            int cou_of_line = 0;
            foreach(var s in list_class)
            {
                cou_of_line += save_ClassUnit_GUI(SW, s);
            }
            SW.WriteLine(cou_of_line);
            for (int i = 0; i < list_class.Count; i++)
            {
                foreach(var s in list_class[i].from)
                {
                    SW.WriteLine(i);
                    SW.WriteLine(list_class.IndexOf(s.to));
                    save_LineUnit_GUI(SW, s);
                }
            }
        }

        private int save_ClassUnit_GUI(StreamWriter SW, ClassUnit_GUI cur_data)
        {
            SW.WriteLine(Canvas.GetLeft(cur_data));
            SW.WriteLine(Canvas.GetTop(cur_data));
            SW.WriteLine(cur_data.name);
            SW.WriteLine(cur_data.type);
            SW.WriteLine(cur_data.val.Count);
            foreach (var s in cur_data.val)
            {
                save_Unit_Value(SW, s);
            }
            SW.WriteLine(cur_data.method.Count);
            foreach (var s in cur_data.method)
            {
                save_Unit_Method(SW, s);
            }
            return cur_data.from.Count;
        }
        private void save_Unit_Value(StreamWriter SW, Unit_Value cur_data)
        {
            SW.WriteLine(cur_data.name);
            SW.WriteLine(cur_data.type);
            SW.WriteLine(cur_data.modifier);
            SW.WriteLine(cur_data.static_Modifier);
            SW.WriteLine(cur_data.final_Modifier);
        }
        private void save_Unit_Method(StreamWriter SW, Unit_Method cur_data)
        {
            SW.WriteLine(cur_data.name);
            SW.WriteLine(cur_data.type);
            SW.WriteLine(cur_data.modifier);
            SW.WriteLine(cur_data.static_Modifier);
            SW.WriteLine(cur_data.abstract_Modifier);
            SW.WriteLine(cur_data.parameter);
        }
        private void save_LineUnit_GUI(StreamWriter SW, LineUnit_GUI cur_data)
        {
            SW.WriteLine(cur_data.X1);
            SW.WriteLine(cur_data.Y1);
            SW.WriteLine(cur_data.X2);
            SW.WriteLine(cur_data.Y2);
            SW.WriteLine(cur_data.type);
        }
    }
}
