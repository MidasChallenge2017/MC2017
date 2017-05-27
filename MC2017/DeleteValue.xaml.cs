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
    /// dataDelete.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DeleteValue : UserControl
    {
        public ClassUnit_GUI unit;

        public DeleteValue(ClassUnit_GUI unit)
        {
            InitializeComponent();
            this.unit = unit;
            foreach (Unit_Value i in unit.val)
                AttributeList.Items.Add(i.str_Print);
            title.Content = unit.name + " class's memeber valuable";
        }
        
        private void AttributeList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int temp = AttributeList.SelectedIndex;
                AttributeList.Items.Remove(unit.val[temp].str_Print);
                AttributeList.Items.Refresh();
                unit.delete_Unit_Value(unit.val[temp]);
            }catch(Exception)
            {
                return;
            }

            return;

        }
    }
}
