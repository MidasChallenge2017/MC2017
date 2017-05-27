using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC2017
{
    public class Unit_Line
    {
        public enum line_Type
        {
            GENERALIZATION,
            REALIZATION,
            DEPENDENCY,
            ASSOCIATION
        };

        public ClassUnit_GUI from { get; set; }
        public ClassUnit_GUI to { get; set; }
        public line_Type type { get; set; }

        public Unit_Line(ClassUnit_GUI from = null, ClassUnit_GUI to = null, line_Type type = line_Type.GENERALIZATION)
        {
            this.from = from;
            this.to = to;
            this.type = type;
        }
    }
}
