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
        public void load(string file_Name)
        {
            init();

            FileStream FS = new FileStream(file_Name, FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(FS);
            canvas.Width = Double.Parse(SR.ReadLine());
            canvas.Height = Double.Parse(SR.ReadLine());
            int cou_of_class = int.Parse(SR.ReadLine());
            for(int i = 0; i < cou_of_class; i++)
            {
                load_ClassUnit_GUI(SR);
            }
            int cou_of_line = int.Parse(SR.ReadLine());
            for(int i = 0; i < cou_of_line; i++)
            {
                load_LineUnit_GUI(SR);
            }
        }

        private void load_ClassUnit_GUI(StreamReader SR)
        {
            ClassUnit_GUI tmp = new ClassUnit_GUI();
            double left = double.Parse(SR.ReadLine());
            double top = double.Parse(SR.ReadLine());
            tmp.name = SR.ReadLine();
            tmp.type = (MC2017.ClassUnit_GUI.class_Type)int.Parse(SR.ReadLine());
            int cou = int.Parse(SR.ReadLine());
            for(int i = 0; i < cou; i++)
            {
                load_Unit_Value(SR, tmp.val);
            }
            cou = int.Parse(SR.ReadLine());
            for(int i = 0; i < cou; i++)
            {
                load_Unit_Method(SR, tmp.method);
            }
            list_class.Add(tmp);
            draw_Unit_Class(tmp, new Point(left, top));
        }
        private void load_Unit_Value(StreamReader SR, List<Unit_Value> list)
        {
            Unit_Value tmp = new Unit_Value();
            tmp.name = SR.ReadLine();
            tmp.type = SR.ReadLine();
            tmp.modifier = (MC2017.Unit_Value.access_Modifier)(int.Parse(SR.ReadLine()));
            tmp.static_Modifier = bool.Parse(SR.ReadLine());
            tmp.final_Modifier = bool.Parse(SR.ReadLine());
            list.Add(tmp);
        }
        private void load_Unit_Method(StreamReader SR, List<Unit_Method> list)
        {
            Unit_Method tmp = new Unit_Method();
            tmp.name = SR.ReadLine();
            tmp.type = SR.ReadLine();
            tmp.modifier = (MC2017.Unit_Method.access_Modifier)(int.Parse(SR.ReadLine()));
            tmp.static_Modifier = bool.Parse(SR.ReadLine());
            tmp.abstract_Modifier = bool.Parse(SR.ReadLine());
            tmp.parameter = SR.ReadLine();
            list.Add(tmp);
        }
        private void load_LineUnit_GUI(StreamReader SR)
        {
            int index_from = int.Parse(SR.ReadLine());
            int index_to = int.Parse(SR.ReadLine());
            double X1 = double.Parse(SR.ReadLine());
            double Y1 = double.Parse(SR.ReadLine());
            double X2 = double.Parse(SR.ReadLine());
            double Y2 = double.Parse(SR.ReadLine());
            LineUnit_GUI tmp = new LineUnit_GUI(new Point(X1, Y1), new Point(X2, Y2));
            tmp.type = (LineUnit_GUI.line_Type)int.Parse(SR.ReadLine());
            list_class[index_from].add_Line_From(tmp);
            list_class[index_to].add_Line_To(tmp);
            draw_Unit_Line(tmp);
        }
    }
}