using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC2017
{
    public partial class MethodUnit_GUI : UserControl
    {
        Unit_Class unit;

        public MethodUnit_GUI(Unit_Class unit)
        {
            InitializeComponent();
            this.unit = unit;
        }

        private void create_Click(object sender, EventArgs e)
        {
            string methodType = type.Text;
            string methodName = name.Text;
            Unit_Method.access_Modifier methodAccessModifier = new Unit_Method.access_Modifier();
            bool valStatic = checkStatic.Checked;
            bool methodAbstract = checkAbstract.Checked;
            string methodParam = param.Text;

            switch (accessModifier.SelectedIndex)
            {
                case 0:
                    methodAccessModifier = Unit_Method.access_Modifier.PRIVATE;
                    break;
                case 1:
                    methodAccessModifier = Unit_Method.access_Modifier.PUBLIC;
                    break;
                case 2:
                    methodAccessModifier = Unit_Method.access_Modifier.PRIVATE;
                    break;
                case 3:
                    methodAccessModifier = Unit_Method.access_Modifier.PROTECTED;
                    break;
            }
            Unit_Method method = new Unit_Method(methodName, methodType, methodParam, methodAccessModifier, valStatic, methodAbstract);
            unit.add_Unit_Method(method);
        }
    }
    }
}
