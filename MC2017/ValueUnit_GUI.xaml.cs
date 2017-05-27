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
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class UserControl1 : UserControl
    {
        public Unit_Class unit;

        public UserControl1(Unit_Class unit)
        {
            InitializeComponent();
            this.unit = unit;
            accessModifier.Items.Add("PUBLIC");
            accessModifier.Items.Add("PRIVATE");
            accessModifier.Items.Add("PROTECTED");

        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            string valType = type.Text;
            string valName = name.Text;
            Unit_Value.access_Modifier valAccessModifier = new Unit_Value.access_Modifier();
            bool valStatic = (bool)checkStatic.IsChecked;
            bool valFinal = (bool)checkFinal.IsChecked;

            switch (accessModifier.SelectedIndex)
            {
                case 0:
                    valAccessModifier = Unit_Value.access_Modifier.PUBLIC;
                    break;
                case 1:
                    valAccessModifier = Unit_Value.access_Modifier.PRIVATE;
                    break;
                case 2:
                    valAccessModifier = Unit_Value.access_Modifier.PROTECTED;
                    break;
                default:
                    valAccessModifier = Unit_Value.access_Modifier.PRIVATE;
                    break;
            }
            Unit_Value val = new Unit_Value(valName, valType, valAccessModifier, valStatic, valFinal);
            unit.add_Unit_Value(val);
        }
    }
}
