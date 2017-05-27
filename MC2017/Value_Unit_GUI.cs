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
    public partial class Value_Unit_GUI : UserControl
    {
        public Unit_Class unit;

        public Value_Unit_GUI(Unit_Class unit)
        {
            InitializeComponent();
            this.unit = unit;
        }

        private void create_Click(object sender, EventArgs e)
        {
            string valType = type.Text;
            string valName = name.Text;
            Unit_Value.access_Modifier valAccessModifier = new Unit_Value.access_Modifier();
            bool valStatic = checkStatic.Checked;
            bool valFinal = checkFinal.Checked;

            switch (accessModifier.SelectedIndex)
            {
                case 0:
                    valAccessModifier = Unit_Value.access_Modifier.PRIVATE;
                    break;
                case 1:
                    valAccessModifier = Unit_Value.access_Modifier.PUBLIC;
                    break;
                case 2:
                    valAccessModifier = Unit_Value.access_Modifier.PRIVATE;
                    break;
                case 3:
                    valAccessModifier = Unit_Value.access_Modifier.PROTECTED;
                    break;
            }
            Unit_Value val = new Unit_Value(valName, valType, valAccessModifier, valStatic, valFinal);
            unit.add_Unit_Value(val);
        }
    }
}
