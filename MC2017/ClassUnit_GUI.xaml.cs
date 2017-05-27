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
    /// ClassUnit_GUI.xaml에 대한 상호 작용 논리
    /// </summary>
    
    public partial class ClassUnit_GUI : UserControl
    {




        public ClassUnit_GUI()
        {
            InitializeComponent();

            panel.Height = name.Height + type.Height + list_method.Height + list_value.Height;
        }
    }
}
