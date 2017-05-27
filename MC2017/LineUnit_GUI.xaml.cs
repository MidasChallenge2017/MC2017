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
    /// LineUnit_GUI.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LineUnit_GUI : UserControl
    {

        private Unit_Line unit;

        double X1, Y1;  // from
        double X2, Y2;  // to

        public LineUnit_GUI()
        {
            InitializeComponent();
            unit = new Unit_Line();
            
        }

        public void setFromCoordinate(double X, double Y)
        {
            X1 = X;
            Y1 = Y;
            line.X1 = X1;
            line.Y1 = Y1;
        }

        public void setToCoordinate(double X, double Y)
        {
            X2 = X;
            Y2 = Y;
            line.X2 = X2;
            line.Y2 = Y2;
        }

        public void setFromUnit(Unit_Class from)
        {
            unit.from = from;
        }

        public void setToUnit(Unit_Class to)
        {
            unit.to = to;
        }
    }
}
