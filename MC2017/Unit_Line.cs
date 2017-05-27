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

        private Unit_Class from { get; set; }
        private Unit_Class to { get; set; }
        private line_Type type { get; set; }

        public Unit_Line(Unit_Class from = null, Unit_Class to = null, line_Type type = line_Type.GENERALIZATION)
        {
            this.from = from;
            this.to = to;
            this.type = type;
        }

        public void delete_Line()
        {
            delete_From();
            delete_To();
        }
        public void delete_From()
        {
            from.delete_Line_From(this);
        }
        public void delete_To()
        {
            from.delete_Line_To(this);
        }
    }
}
