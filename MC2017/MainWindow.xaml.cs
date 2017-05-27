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
            ClassMove
        }

        public static state program_state;

        public List<ClassUnit_GUI> list_class;
        public static ClassUnit_GUI current_class;

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
            
        }

        private void canvas_mouse_leftBtnUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(canvas);
            classData.Children.Clear();
            if (program_state == state.ClassMove)
            {
                if (p.X + current_class.Width > canvas.Width)
                    canvas.Width += current_class.Width;

                if (p.Y + current_class.Height > canvas.Height)
                    canvas.Height += current_class.Height;

                program_state = state.None;
                getClass();
            }
            else if (program_state == state.None) {
                current_class = null;
                classData.Children.Clear();
            }
            else if (program_state == state.Class)
            {
                ClassUnit_GUI unit = new ClassUnit_GUI();

                current_class = unit;
                list_class.Add(unit);

                draw_Unit_Class(unit, p);

                label1.Content = "X : " + (p.X + unit.ActualWidth) + "  " + canvas.Width;
                label1.Content += "\nY : " + (p.Y + unit.ActualHeight) + "  " + canvas.Height;
                label1.Content += "\nunit.height = " + unit.Height + "\nactualHeight = " + unit.ActualHeight;
                getClass();
            }
        }
        
        public void getClass()
        {
            int i = 0;
            MethodUnit_GUI methodUnit = new MethodUnit_GUI(current_class.unit);
            UserControl1 valUnit = new UserControl1(current_class.unit);

            Label className = new Label(); 
            Label classType = new Label();
            Label emptyLable = new Label();

            className.Content = current_class.unit.name;
            classType.Content = current_class.unit.type;
            emptyLable.Content = " ";

            classData.Children.Insert(i++, classType);
            classData.Children.Insert(i++, className);
            classData.Children.Insert(i++, valUnit);
            foreach (Unit_Value t in valUnit.unit.val)
            {
                Label temp = new Label();
                temp.Content = t.str_Print;
                classData.Children.Insert(i++, temp);
            }
            classData.Children.Insert(i++, emptyLable);
            classData.Children.Insert(i++, methodUnit);
            foreach (Unit_Method t in methodUnit.unit.method)
            {
                Label temp = new Label();
                temp.Content = t.str_Print;
                classData.Children.Insert(i++, temp);
            }
        }

        private void canvas_mouse_move(object sender, MouseEventArgs e)
        {
            Point currentPosition = e.GetPosition(canvas);
            label.Content = "( "+ currentPosition.X + " , " + currentPosition.Y + " )";
            label1.Content = (current_class == null) ? "null" : "clicked";


            if (program_state == state.ClassMove) {

                if (e.MouseDevice.LeftButton == MouseButtonState.Pressed && current_class != null) {

                    Canvas.SetLeft(current_class, currentPosition.X);
                    Canvas.SetTop(current_class, currentPosition.Y);
                }
            }

            
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
            btn_generalization.IsEnabled = true;
            btn_realization.IsEnabled = true;
            btn_association.IsEnabled = true;
            btn_dependancy.IsEnabled = true;
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
            else {
                program_state = state.None;

                btn_generalization.IsEnabled = true;
                btn_realization.IsEnabled = true;
                btn_association.IsEnabled = true;
                btn_dependancy.IsEnabled = true;
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
                program_state = state.None;

                btn_class.IsEnabled = true;
                btn_realization.IsEnabled = true;
                btn_association.IsEnabled = true;
                btn_dependancy.IsEnabled = true;
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
                program_state = state.None;

                btn_class.IsEnabled = true;
                btn_generalization.IsEnabled = true;
                btn_association.IsEnabled = true;
                btn_dependancy.IsEnabled = true;
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
                program_state = state.None;

                btn_class.IsEnabled = true;
                btn_generalization.IsEnabled = true;
                btn_realization.IsEnabled = true;
                btn_dependancy.IsEnabled = true;
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
                program_state = state.None;

                btn_class.IsEnabled = true;
                btn_generalization.IsEnabled = true;
                btn_realization.IsEnabled = true;
                btn_association.IsEnabled = true;
            }
        }

        private void classData_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            classData.Children.Clear();
            getClass();
        }
    }
}
