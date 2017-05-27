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
    /// MethodUnit_GUI.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MethodUnit_GUI : UserControl
    {

        public Unit_Class unit;
        public MethodUnit_GUI(Unit_Class unit)
        {
            InitializeComponent();
            this.unit = unit;
            accessModifier.Items.Add("PUBLIC");
            accessModifier.Items.Add("PRIVATE");
            accessModifier.Items.Add("PROTECTED");
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            string methodType = type.Text;
            string methodName = name.Text;
            Unit_Method.access_Modifier methodAccessModifier = new Unit_Method.access_Modifier();
            string methodParam = param.Text;
            bool methodStatic = (bool)checkStatic.IsChecked;
            bool methodFinal = (bool)checkAbstract.IsChecked;

            switch (accessModifier.SelectedIndex)
            {
                case 0:
                    methodAccessModifier = Unit_Method.access_Modifier.PUBLIC;
                    break;
                case 1:
                    methodAccessModifier = Unit_Method.access_Modifier.PRIVATE;
                    break;
                case 2:
                    methodAccessModifier = Unit_Method.access_Modifier.PROTECTED;
                    break;
                default:
                    methodAccessModifier = Unit_Method.access_Modifier.PRIVATE;
                    break;
            }
            Unit_Method method = new Unit_Method(methodName, methodType,methodParam, methodAccessModifier, methodStatic, methodFinal);
            unit.add_Unit_Method(method);
        }
    }
}
