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
using System.Windows.Shapes;

namespace MC2017
{
    /// <summary>
    /// canvas_dialog.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class canvas_dialog : Window
    {
        public canvas_dialog(int width, int height)
        {
            InitializeComponent();

            text_width.Text = "" + width;
            text_height.Text = "" + height;
        }
        

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            text_width.Focus();
        }

        public string Answer
        {
            get { return text_width.Text+" "+text_height.Text; }
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (int.Parse(text_width.Text) <= 0 || int.Parse(text_height.Text) <= 0)
                    MessageBox.Show("input integer ( x > 0 )");
                else
                    this.DialogResult = true;

            }
            catch (FormatException d) {
                MessageBox.Show("input integer ( x > 0 )");
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = false;
        }
    }
}
