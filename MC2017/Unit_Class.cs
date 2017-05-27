using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC2017
{
    class Unit_Class
    {
        public enum class_Type
        {
            CLASS,
            INTERFACE,
            ABSTRACT,
            UTILITY,
            ENUMERATION
        }

        private string name { get; set; }
        private class_Type type { get; set; }

        private List<Unit_Value> val;
        private List<Unit_Method> method;
        public List<Unit_Line> from;
        public List<Unit_Line> to;

        public Unit_Class(String name = "none", class_Type type = class_Type.CLASS)
        {
            this.name = name;
            this.type = type;
            val = new List<Unit_Value>();
            method = new List<Unit_Method>();
            from = new List<Unit_Line>();
            to = new List<Unit_Line>();
        }

        public void delete_Class()
        {

        }
        public void add_Line_From(Unit_Line line_From)
        {
            from.Add(line_From);
        }
        public void add_Line_To(Unit_Line line_To)
        {
            to.Add(line_To);
        }
        public void add_Unit_Value(Unit_Value val)
        {
            this.val.Add(val);
        }
        public void add_Unit_Method(Unit_Method method)
        {
            
        }
    }
}
