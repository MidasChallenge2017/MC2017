using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC2017
{
    class Unit_Line
    {
        public enum line_Type
        {
            GENERALIZATION,
            REALIZATION,
            DEPENDENCY,
            ASSOCIATION
        };

        private Unit_Class from;
        private Unit_Class to;
        private line_Type type;

        public Unit_Line(Unit_Class from = null, Unit_Class to = null, line_Type type = line_Type.GENERALIZATION)
        {
            this.from = from;
            this.to = to;
            this.type = type;
        }

        public void delete_Line()
        {
            from.to.Remove(this);
            to.from.Remove(this);
        }
    }
}
