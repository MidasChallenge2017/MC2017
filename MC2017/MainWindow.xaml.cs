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
using System.IO;
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

        private enum state
        {
            None,
            Class,
            Generaization,
            Realization,
            Association,
            Dependancy
        }

        state button_state;

        List<ClassUnit_GUI> list_class;
        ClassUnit_GUI current_class;
        

        public MainWindow()
        {
            InitializeComponent();

            list_class = new List<ClassUnit_GUI>();
            button_state = state.None;

            canvas.MouseLeftButtonDown += new MouseButtonEventHandler(canvas_mouse_leftBtnDown);
            canvas.MouseMove += new MouseEventHandler(canvas_mouse_move);
            canvas.MouseLeftButtonUp += new MouseButtonEventHandler(canvas_mouse_leftBtnUp);
        }



        private void canvas_mouse_leftBtnDown(object sender, MouseButtonEventArgs e)
        {
/*
            if (button_state == state.Class)
            {

                canvas.CaptureMouse();
                create_Rectangle();
                prePosition = e.GetPosition(this);
                prePosition.X += scrollX;
                prePosition.Y += scrollY;
            }
*/
        }

        private void canvas_mouse_leftBtnUp(object sender, MouseButtonEventArgs e)
        {
            
            if (button_state == state.Class)
            {
                Point p = e.GetPosition(canvas);

                Unit_Class tmp = new Unit_Class("name", Unit_Class.class_Type.CLASS);
                ClassUnit_GUI unit = new ClassUnit_GUI(tmp);

                current_class = unit;
                list_class.Add(unit);
                
                canvas.Children.Add(unit);

                Canvas.SetLeft(unit, p.X);
                Canvas.SetTop(unit, p.Y);

                label1.Content = "X : " + (p.X + unit.ActualWidth) + "  " + canvas.Width;
                label1.Content += "\nY : " + (p.Y + unit.ActualHeight) + "  " + canvas.Height;
                label1.Content += "\nunit.height = " + unit.Height + "\nactualHeight = " + unit.ActualHeight;

                if (p.X + unit.Width > canvas.Width) {
                    canvas.Width += unit.Width;
                }

                if (p.Y + unit.Height > canvas.Height) {
                    canvas.Height += unit.Height;
                }

                button_state = state.None;

                btn_generalization.IsEnabled = true;
                btn_realization.IsEnabled = true;
                btn_association.IsEnabled = true;
                btn_dependancy.IsEnabled = true;

            }
        }

        private void canvas_mouse_move(object sender, MouseEventArgs e)
        {
            Point currentPosition = e.GetPosition(canvas);
            label.Content = "( "+ currentPosition.X + " , " + currentPosition.Y + " )";

/*

            if (button_state == state.Class)
            {

                

                if (e.MouseDevice.LeftButton == MouseButtonState.Pressed && rect != null)
                {

                    double x = prePosition.X + scrollX;
                    double y = prePosition.Y + scrollY;
                    if (currentPosition.X < x) x = currentPosition.X;
                    if (currentPosition.Y < y) y = currentPosition.Y;

                    rect.Margin = new Thickness(x, y, 0, 0);
                    rect.Width = Math.Abs(prePosition.X - currentPosition.X);
                    rect.Height = Math.Abs(prePosition.Y - currentPosition.Y);
                }
            }
*/
        }
/*
        private void create_Rectangle()
        {
            rect = new Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.DarkGreen);
     
            DoubleCollection dash = new DoubleCollection();
            dash.Add(1);
            rect.StrokeDashArray = dash;
            rect.StrokeDashOffset = 0;
            

            rect.Opacity = 0.5;
            
            canvas.Children.Add(rect);
        }

*/















        private void btn_class_Click(object sender, RoutedEventArgs e)
        {
            if (button_state == state.None)
            {
                
                button_state = state.Class;

                btn_generalization.IsEnabled = false;
                btn_realization.IsEnabled = false;
                btn_association.IsEnabled = false;
                btn_dependancy.IsEnabled = false;

            }
            else {
                button_state = state.None;

                btn_generalization.IsEnabled = true;
                btn_realization.IsEnabled = true;
                btn_association.IsEnabled = true;
                btn_dependancy.IsEnabled = true;
            }

        }

        private void btn_generalization_Click(object sender, RoutedEventArgs e)
        {
            if (button_state == state.None)
            {

                button_state = state.Generaization;

                btn_class.IsEnabled = false;
                btn_realization.IsEnabled = false;
                btn_association.IsEnabled = false;
                btn_dependancy.IsEnabled = false;

            }
            else
            {
                button_state = state.None;

                btn_class.IsEnabled = true;
                btn_realization.IsEnabled = true;
                btn_association.IsEnabled = true;
                btn_dependancy.IsEnabled = true;
            }
        }

        private void btn_realization_Click(object sender, RoutedEventArgs e)
        {
            if (button_state == state.None)
            {

                button_state = state.Realization;

                btn_class.IsEnabled = false;
                btn_generalization.IsEnabled = false;
                btn_association.IsEnabled = false;
                btn_dependancy.IsEnabled = false;

            }
            else
            {
                button_state = state.None;

                btn_class.IsEnabled = true;
                btn_generalization.IsEnabled = true;
                btn_association.IsEnabled = true;
                btn_dependancy.IsEnabled = true;
            }
        }

        private void btn_association_Click(object sender, RoutedEventArgs e)
        {
            if (button_state == state.None)
            {

                button_state = state.Association;

                btn_class.IsEnabled = false;
                btn_generalization.IsEnabled = false;
                btn_realization.IsEnabled = false;
                btn_dependancy.IsEnabled = false;

            }
            else
            {
                button_state = state.None;

                btn_class.IsEnabled = true;
                btn_generalization.IsEnabled = true;
                btn_realization.IsEnabled = true;
                btn_dependancy.IsEnabled = true;
            }
        }

        private void btn_dependancy_Click(object sender, RoutedEventArgs e)
        {
            if (button_state == state.None)
            {

                button_state = state.Dependancy;

                btn_class.IsEnabled = false;
                btn_generalization.IsEnabled = false;
                btn_realization.IsEnabled = false;
                btn_association.IsEnabled = false;

            }
            else
            {
                button_state = state.None;

                btn_class.IsEnabled = true;
                btn_generalization.IsEnabled = true;
                btn_realization.IsEnabled = true;
                btn_association.IsEnabled = true;
            }
        }

        private void saveAsPng_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog pFileDlg = new System.Windows.Forms.OpenFileDialog();
            pFileDlg.Title = "선택하여 주세요.";
            pFileDlg.CheckFileExists = false;
            if (pFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String strFullPathFile = pFileDlg.FileName;
                if (!strFullPathFile.EndsWith(".png"))
                {
                    strFullPathFile += ".png";
                }
                ExportToPng(strFullPathFile, canvas);
            }
        }

        public void ExportToPng(string path, Canvas surface)
        {
            if (path == null) return;
            
            Transform transform = surface.LayoutTransform;
            surface.LayoutTransform = null;
            
            Size size = new Size(surface.ActualWidth + 53, surface.ActualHeight + 10);
            surface.Measure(size);
            surface.Arrange(new Rect(size));
            
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
                (int)size.Width,
                (int)size.Height,
                96d,
                96d,
                PixelFormats.Pbgra32);
            renderBitmap.Render(surface);
            
            using (FileStream outStream = new FileStream(path, FileMode.Create))
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                encoder.Save(outStream);
            }
            
            surface.LayoutTransform = transform;
        }
    }
}
