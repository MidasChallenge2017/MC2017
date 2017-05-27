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
        public enum line_Type
        {
            GENERALIZATION,
            REALIZATION,
            DEPENDENCY,
            ASSOCIATION
        };

        public ClassUnit_GUI from { get; set; }
        public ClassUnit_GUI to { get; set; }
        public line_Type type { get; set; }

        public double X1, Y1;  // from
        public double X2, Y2;  // to
        

        public LineUnit_GUI(Point p1, Point p2, ClassUnit_GUI from = null, ClassUnit_GUI to = null, line_Type type = line_Type.GENERALIZATION)
        {
            InitializeComponent();

            this.from = from;
            this.to = to;
            this.type = type;

            X1 = p1.X;
            Y1 = p1.Y;
            X2 = p2.X;
            Y2 = p2.Y;

            line_setup();

            line.MouseMove += new MouseEventHandler(mouse_move);
        }

        private void mouse_move(object sender, MouseEventArgs e)
        {


        }


        private void line_setup()
        {
            line.X1 = X1;
            line.X2 = X2;
            line.Y1 = Y1;
            line.Y2 = Y2;
            
        }

        public void setFromCoordinate(double X, double Y)
        {

            double dist = Math.Sqrt(Math.Pow(X - X2, 2) + Math.Pow(Y - Y2, 2));

            if (dist >= 40) {

                X1 = X;
                Y1 = Y;
                line.X1 = X1;
                line.Y1 = Y1;

            }

            this.Width = Math.Abs(X1 - X2);
            this.Height = Math.Abs(Y1 - Y2);

        }

        public void setToCoordinate(double X, double Y)
        {
            double dist = Math.Sqrt(Math.Pow(X - X1, 2) + Math.Pow(Y - Y1, 2));

            if (dist >= 40)
            {
                X2 = X;
                Y2 = Y;
                line.X2 = X2;
                line.Y2 = Y2;
            }

            this.Width = Math.Abs(X1 - X2);
            this.Height = Math.Abs(Y1 - Y2);
        }

        public void delete_Line()
        {
            delete_From();
            delete_To();
        }
        public void delete_From()
        {
            from.delete_Line_From(this);
            from = null;
        }
        public void delete_To()
        {
            to.delete_Line_To(this);
            to = null;
        }
        public void add_Line(ClassUnit_GUI from, ClassUnit_GUI to)
        {
            add_From(from);
            add_To(to);
        }
        public void add_From(ClassUnit_GUI from)
        {
            from.add_Line_From(this);
            this.from = from;
        }
        public void add_To(ClassUnit_GUI to)
        {
            to.add_Line_To(this);
            this.to = to;
        }
    }
}
