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
        public void draw_Unit_Line(LineUnit_GUI unit)
        {
            canvas.Children.Add(unit);

            program_state = state.None;
            btn_class.IsEnabled = true;
            btn_generalization.IsEnabled = true;
            btn_realization.IsEnabled = true;
            btn_association.IsEnabled = true;
            btn_dependancy.IsEnabled = true;
        }
        public void draw_Unit_Class(ClassUnit_GUI unit, Point p)
        {
            canvas.Children.Add(unit);

            Canvas.SetLeft(unit, p.X);
            Canvas.SetTop(unit, p.Y);

            if (p.X + unit.Width > canvas.Width)
            {
                canvas.Width += unit.Width;
            }

            if (p.Y + unit.Height > canvas.Height)
            {
                canvas.Height += unit.Height;
            }

            program_state = state.None;
            btn_class.IsEnabled = true;
            btn_generalization.IsEnabled = true;
            btn_realization.IsEnabled = true;
            btn_association.IsEnabled = true;
            btn_dependancy.IsEnabled = true;
        }
    }
}
