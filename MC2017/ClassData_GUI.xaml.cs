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
    /// ClassData_GUI.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClassData_GUI : UserControl
    {
        ClassUnit_GUI unit;

        public ClassData_GUI(ClassUnit_GUI unit)
        {
            InitializeComponent();
            classType.Items.Add("NORMAL");
            classType.Items.Add("INTERFACE");
            classType.Items.Add("ABSTRACT");
            classType.Items.Add("UTILITY");
            classType.Items.Add("ENUMERATION");
            this.unit = unit;
            className.Text = this.unit.name;
            classType.SelectedIndex = (int)this.unit.type;
        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {
            unit.name = className.Text;
            switch (classType.SelectedIndex)
            {
                case 1:
                    unit.type = ClassUnit_GUI.class_Type.NORMAL;
                    break;
                case 2:
                    unit.type = ClassUnit_GUI.class_Type.INTERFACE;
                    break;
                case 3:
                    unit.type = ClassUnit_GUI.class_Type.ABSTRACT;
                    break;
                case 4:
                    unit.type = ClassUnit_GUI.class_Type.UTILITY;
                    break;
                case 5:
                    unit.type = ClassUnit_GUI.class_Type.ENUMERATION;
                    break;
            }
            unit.writeAttribute();
        }
    }
}
