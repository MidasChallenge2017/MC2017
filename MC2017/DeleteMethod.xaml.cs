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
    /// methodDelete.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DeleteMethod : UserControl
    {
        public ClassUnit_GUI unit;

        public DeleteMethod(ClassUnit_GUI unit)
        {
            InitializeComponent();
            this.unit = unit;
            foreach (Unit_Method i in unit.method)
                attributeList.Items.Add(i.str_Print);
            title.Content = unit.name + " class's memeber method";
        }

        private void attributeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int temp = attributeList.SelectedIndex;
                attributeList.Items.Remove(unit.method[temp].str_Print);
                attributeList.Items.Refresh();
                unit.delete_Unit_Method(unit.method[temp]);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}


