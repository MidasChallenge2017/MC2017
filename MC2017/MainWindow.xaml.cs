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
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// commit test
    public partial class MainWindow : Window
    {

        public enum state
        {
            None,
            Class,
            Generaization,
            Realization,
            Association,
            Dependancy,
            ClassMove,
            LineFrom,
            LineTo
        }

        public static state program_state;

        public List<ClassUnit_GUI> list_class;
        public static ClassUnit_GUI current_class;
        public static LineUnit_GUI current_line;
        

        public MainWindow()
        {
            InitializeComponent();

            list_class = new List<ClassUnit_GUI>();
            program_state = state.None;

            canvas.MouseLeftButtonDown += new MouseButtonEventHandler(canvas_mouse_leftBtnDown);
            canvas.MouseMove += new MouseEventHandler(canvas_mouse_move);
            canvas.MouseLeftButtonUp += new MouseButtonEventHandler(canvas_mouse_leftBtnUp);
            
        }



        private void canvas_mouse_leftBtnDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(canvas);




        }

        private void canvas_mouse_leftBtnUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(canvas);


            if (program_state == state.ClassMove)
            {

                if (p.X + current_class.Width > canvas.Width)
                    canvas.Width += current_class.Width;

                if (p.Y + current_class.Height > canvas.Height)
                    canvas.Height += current_class.Height;

                program_state = state.None;
            }
            else if (program_state == state.LineFrom)
            {

                if (current_class != null)
                {

                    if (current_line.from != null) current_line.from.delete_Line_From(current_line);

                    current_line.from = current_class;
                    current_class.add_Line_From(current_line);

                    lineFromBoundCheck();
                    lineToBoundCheck();
                }
                else
                {
                    if (current_line.from != null) current_line.from.delete_Line_From(current_line);
                    current_line.from = null;
                }

                current_line = null;
                current_class = null;

                program_state = state.None;
            }
            else if (program_state == state.LineTo)
            {
                if (current_class != null)
                {

                    if (current_line.to != null) current_line.to.delete_Line_From(current_line);

                    current_line.to = current_class;
                    current_class.add_Line_To(current_line);

                    lineFromBoundCheck();
                    lineToBoundCheck();
                }
                else
                {
                    if (current_line.to != null) current_line.to.delete_Line_From(current_line);
                    current_line.to = null;
                }

                current_line = null;
                current_class = null;

                program_state = state.None;
            }
            else if (program_state == state.None)
            {
                current_line = null;
                current_class = null;
            }
            else if (program_state == state.Class)
            {

                ClassUnit_GUI unit = new ClassUnit_GUI();

                current_class = unit;
                list_class.Add(unit);

                draw_Unit_Class(unit, p);

            }
            if (program_state == state.Generaization)
            {

                current_line = new LineUnit_GUI(p, new Point(p.X+100, p.Y), type: LineUnit_GUI.line_Type.GENERALIZATION);
                canvas.Children.Add(current_line);
                reset_btn();

            }
            else if (program_state == state.Realization)
            {

                current_line = new LineUnit_GUI(p, new Point(p.X + 100, p.Y), type: LineUnit_GUI.line_Type.REALIZATION);
                canvas.Children.Add(current_line);
                reset_btn();

            }
            else if (program_state == state.Association)
            {

                current_line = new LineUnit_GUI(p, new Point(p.X + 100, p.Y), type: LineUnit_GUI.line_Type.ASSOCIATION);
                canvas.Children.Add(current_line);
                reset_btn();

            }
            else if (program_state == state.Dependancy)
            {

                current_line = new LineUnit_GUI(p, new Point(p.X + 100, p.Y), type: LineUnit_GUI.line_Type.DEPENDENCY);
                canvas.Children.Add(current_line);
                reset_btn();

            }

        }

        private void canvas_mouse_move(object sender, MouseEventArgs e)
        {
            Point currentPosition = e.GetPosition(canvas);
            label.Content = "( " + currentPosition.X + " , " + currentPosition.Y + " )";
            label1.Content = "cur_class : " + ((current_class == null) ? "null" : "focused");
            label1.Content += "\ncur_list : " + ((current_line == null) ? "null" : "focused");


            if (program_state == state.ClassMove)
            {

                if (e.MouseDevice.LeftButton == MouseButtonState.Pressed && current_class != null)
                {

                    Canvas.SetLeft(current_class, currentPosition.X);
                    Canvas.SetTop(current_class, currentPosition.Y);

                    current_class.moveAll(currentPosition);

                }
            }
            else if (program_state == state.LineFrom)
            {
                if (e.MouseDevice.LeftButton == MouseButtonState.Pressed && current_line != null)
                {
                    current_line.setFromCoordinate(currentPosition.X, currentPosition.Y);

                }
            }
            else if (program_state == state.LineTo)
            {
                if (e.MouseDevice.LeftButton == MouseButtonState.Pressed && current_line != null)
                {
                    current_line.setToCoordinate(currentPosition.X, currentPosition.Y);
                }
            }


        }




        public void reset_btn()
        {
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

            reset_btn();
        }

        public void draw_Unit_Line(LineUnit_GUI unit)
        {
            canvas.Children.Add(unit);

            reset_btn();

        }


        public void lineToBoundCheck() {

            double x = Canvas.GetLeft(current_class);
            double y = Canvas.GetTop(current_class);

            if (current_line.p_from.X < x && current_line.p_to.X > x)
            {
                current_line.setToCoordinate(x - 5, current_line.p_to.Y);
                current_line.setToOffset(current_line.p_to.X - x, current_line.p_to.Y - y);
            }
            else if (current_line.p_from.X > x + current_class.Width && current_line.p_to.X < x + current_class.Width)
            {
                current_line.setToCoordinate(x + current_class.Width + 5, current_line.p_to.Y);
                current_line.setToOffset(current_line.p_to.X - x, current_line.p_to.Y - y);
            }
            else if (current_line.p_from.Y < y && current_line.p_to.Y > y)
            {
                current_line.setToCoordinate(current_line.p_to.X, y - 5);
                current_line.setToOffset(current_line.p_to.X - x, current_line.p_to.Y - y);
            }
            else if (current_line.p_from.Y > y + current_class.Height && current_line.p_to.Y < y + current_class.Height)
            {
                current_line.setToCoordinate(current_line.p_to.X, y + current_class.Height + 5);
                current_line.setToOffset(current_line.p_to.X - x, current_line.p_to.Y - y);
            }

        }

        public void lineFromBoundCheck()
        {

            double x = Canvas.GetLeft(current_class);
            double y = Canvas.GetTop(current_class);

            if (current_line.p_to.X < x && current_line.p_from.X > x)
            {
                current_line.setFromCoordinate(x - 5, current_line.p_from.Y);
                current_line.setFromOffset(current_line.p_from.X - x, current_line.p_from.Y - y);
            }
            else if (current_line.p_to.X > x + current_class.Width && current_line.p_from.X < x + current_class.Width)
            {
                current_line.setFromCoordinate(x + current_class.Width + 5, current_line.p_from.Y);
                current_line.setFromOffset(current_line.p_from.X - x, current_line.p_from.Y - y);
            }
            else if (current_line.p_to.Y < y && current_line.p_from.Y > y)
            {
                current_line.setFromCoordinate(current_line.p_from.X, y - 5);
                current_line.setFromOffset(current_line.p_from.X - x, current_line.p_from.Y - y);
            }
            else if (current_line.p_to.Y > y + current_class.Height && current_line.p_from.Y < y + current_class.Height)
            {
                current_line.setFromCoordinate(current_line.p_from.X, y + current_class.Height + 5);
                current_line.setFromOffset(current_line.p_from.X - x, current_line.p_from.Y - y);
            }

        }







        private void btn_class_Click(object sender, RoutedEventArgs e)
        {
            if (program_state == state.None)
            {
                
                program_state = state.Class;

                btn_generalization.IsEnabled = false;
                btn_realization.IsEnabled = false;
                btn_association.IsEnabled = false;
                btn_dependancy.IsEnabled = false;

            }
            else
            {
                reset_btn();
                current_line = null;
                current_class = null;
            }

        }

        private void btn_generalization_Click(object sender, RoutedEventArgs e)
        {
            if (program_state == state.None)
            {

                program_state = state.Generaization;

                btn_class.IsEnabled = false;
                btn_realization.IsEnabled = false;
                btn_association.IsEnabled = false;
                btn_dependancy.IsEnabled = false;

            }
            else
            {
                reset_btn();
                current_line = null;
                current_class = null;
            }
        }

        private void btn_realization_Click(object sender, RoutedEventArgs e)
        {
            if (program_state == state.None)
            {

                program_state = state.Realization;

                btn_class.IsEnabled = false;
                btn_generalization.IsEnabled = false;
                btn_association.IsEnabled = false;
                btn_dependancy.IsEnabled = false;

            }
            else
            {
                reset_btn();
                current_line = null;
                current_class = null;
            }
        }

        private void btn_association_Click(object sender, RoutedEventArgs e)
        {
            if (program_state == state.None)
            {

                program_state = state.Association;

                btn_class.IsEnabled = false;
                btn_generalization.IsEnabled = false;
                btn_realization.IsEnabled = false;
                btn_dependancy.IsEnabled = false;

            }
            else
            {
                reset_btn();
                current_line = null;
                current_class = null;
            }
        }

        private void btn_dependancy_Click(object sender, RoutedEventArgs e)
        {
            if (program_state == state.None)
            {

                program_state = state.Dependancy;

                btn_class.IsEnabled = false;
                btn_generalization.IsEnabled = false;
                btn_realization.IsEnabled = false;
                btn_association.IsEnabled = false;

            }
            else
            {
                reset_btn();
                current_line = null;
                current_class = null;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            canvas_dialog dialog = new canvas_dialog((int)canvas.Width, (int)canvas.Height);
            if (dialog.ShowDialog() == true) {
                String[] strs = dialog.Answer.Split(' ');
                canvas.Width = int.Parse(strs[0]);
                canvas.Height = int.Parse(strs[1]);
            }

        }
    }
}
