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

        public Point p_from;
        public Point p_to;
        
        public double tmp_from_X, tmp_from_Y;
        public double tmp_to_X, tmp_to_Y;

        public LineUnit_GUI(Point p1, Point p2, ClassUnit_GUI from = null, ClassUnit_GUI to = null, line_Type type = line_Type.GENERALIZATION)
        {
            InitializeComponent();

            this.from = from;
            this.to = to;
            this.type = type;

            p_from.X = p1.X;
            p_from.Y = p1.Y;
            p_to.X = p2.X;
            p_to.Y = p2.Y;

            line_setup();

            line.MouseLeftButtonDown += new MouseButtonEventHandler(mouse_down);
            line.MouseMove += new MouseEventHandler(mouse_move);
            line.MouseLeftButtonUp += new MouseButtonEventHandler(mouse_up);

            polygon.MouseLeftButtonDown += new MouseButtonEventHandler(mouse_down_to);
            polyline.MouseLeftButtonDown += new MouseButtonEventHandler(mouse_down_to);

        }

        private void mouse_down_to(object sender, MouseButtonEventArgs e)
        {
            Point p = e.MouseDevice.GetPosition(this);
            int offset = 20;

            if (p.X < p_to.X + offset && p.X > p_to.X - offset && p.Y < p_to.Y + offset && p.Y > p_to.Y - offset)
            {
                MainWindow.program_state = MainWindow.state.LineTo;
                MainWindow.current_line = this;
            }
        }

        private void mouse_down(object sender, MouseButtonEventArgs e)
        {
            Point p = e.MouseDevice.GetPosition(this);
            int offset = 20;

            if (p.X < p_from.X + offset && p.X > p_from.X - offset && p.Y < p_from.Y + offset && p.Y > p_from.Y - offset)
            {
                MainWindow.program_state = MainWindow.state.LineFrom;
                MainWindow.current_line = this;
            }
        }

        private void mouse_up(object sender, MouseButtonEventArgs e)
        {


        }

        private void mouse_move(object sender, MouseEventArgs e)
        {
            /*
                        Point p = e.MouseDevice.GetPosition(this);
                        if (p.X < p_from.X + 5 && p.X > p_from.X - 5 && p.Y < p_from.Y + 5 && p.Y > p_from.Y - 5)
                        {
                            dot_from.Margin = new Thickness(p_from.X, p_from.Y, 0, 0);
                            dot_from.Visibility = Visibility.Visible;
                        }
                        else if (p.X < p_to.X + 5 && p.X > p_to.X - 5 && p.Y < p_to.Y + 5 && p.Y > p_to.Y - 5)
                        {
                            dot_to.Margin = new Thickness(p_to.X, p_to.Y, 0, 0);
                            dot_to.Visibility = Visibility.Visible;
                        }
                        else {

                            dot_from.Visibility = Visibility.Hidden;
                            dot_to.Visibility = Visibility.Hidden;
                        }
            */
        }


        private void line_setup()
        {
            line.X1 = p_from.X;
            line.Y1 = p_from.Y;
            line.X2 = p_to.X;
            line.Y2 = p_to.Y;

            if (type == line_Type.GENERALIZATION)
            {
                polygon.Visibility = Visibility.Visible;
            }
            else if (type == line_Type.REALIZATION)
            {
                line.StrokeDashArray = new DoubleCollection { 5, 3 };
                polygon.Visibility = Visibility.Visible;

            }
            else if (type == line_Type.ASSOCIATION)
            {
                polyline.Visibility = Visibility.Visible;
            }
            else if (type == line_Type.DEPENDENCY)
            {
                line.StrokeDashArray = new DoubleCollection { 5, 3 };
                polyline.Visibility = Visibility.Visible;
            }

            Point left, right;
            cal_tri(p_from, p_to, out left, out right);

            PointCollection pc = new PointCollection();
            pc.Add(left);
            pc.Add(p_to);
            pc.Add(right);
            polygon.Points = pc;
            polyline.Points = pc;

        }

        public void setFromOffset(double x, double y)
        {
            tmp_from_X = x;
            tmp_from_Y = y;
        }

        public void setToOffset(double x, double y)
        {
            tmp_to_X = x;
            tmp_to_Y = y;
        }

        public void setFromCoordinate(double X, double Y)
        {

            double dist = Math.Sqrt(Math.Pow(X - p_to.X, 2) + Math.Pow(Y - p_to.Y, 2));

            if (dist >= 40) {

                line.X1 = p_from.X = X;
                line.Y1 = p_from.Y = Y;

                Point left, right;
                cal_tri(p_from, p_to, out left, out right);

                PointCollection pc = new PointCollection();
                pc.Add(left);
                pc.Add(p_to);
                pc.Add(right);
                polygon.Points = pc;
                polyline.Points = pc;

            }

            this.Width = ((p_from.X>p_to.X) ? p_from.X : p_to.X) + 50;
            this.Height = ((p_from.Y > p_to.Y) ? p_from.Y : p_to.Y) + 50;

        }

        public void setToCoordinate(double X, double Y)
        {
            double dist = Math.Sqrt(Math.Pow(X - p_from.X, 2) + Math.Pow(Y - p_from.Y, 2));

            if (dist >= 40)
            {
                line.X2 = p_to.X = X;
                line.Y2 = p_to.Y = Y;

                Point left, right;
                cal_tri(p_from, p_to, out left, out right);

                PointCollection pc = new PointCollection();
                pc.Add(left);
                pc.Add(p_to);
                pc.Add(right);
                polygon.Points = pc;
                polyline.Points = pc;
            }

            this.Width = ((p_from.X > p_to.X) ? p_from.X : p_to.X) + 50;
            this.Height = ((p_from.Y > p_to.Y) ? p_from.Y : p_to.Y) + 50;
        }

        public void delete_Line()
        {
            delete_From();
            delete_To();
        }


        public void delete_From()
        {
            from.delete_Line_From(this);
        }


        public void delete_To()
        {
            to.delete_Line_To(this);
        }


        public void cal_tri(Point st, Point fi, out Point left, out Point right)
        {
            double arrow_length = 30.0;
            double minus_length = arrow_length / 2.0 * 1.732;
            double minus_length2 = arrow_length / 2.0;

            fi.X -= st.X;
            fi.Y -= st.Y;

            double len = Math.Sqrt(fi.X * fi.X + fi.Y * fi.Y);

            Point tmp = new Point();
            tmp.X = fi.X * (len - minus_length) / len;
            tmp.Y = fi.Y * (len - minus_length) / len;

            //(-fi.Y, fi.X)
            //(fi.Y, -fi.X)
            left = new Point();
            left.X = -fi.Y * minus_length2 / len;
            left.X += tmp.X;
            left.Y = fi.X * minus_length2 / len;
            left.Y += tmp.Y;

            right = new Point();
            right.X = fi.Y * minus_length2 / len;
            right.X += tmp.X;
            right.Y = -fi.X * minus_length2 / len;
            right.Y += tmp.Y;

            left.X += st.X;
            left.Y += st.Y;
            right.X += st.X;
            right.Y += st.Y;
        }

    }
}
