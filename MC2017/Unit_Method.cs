using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC2017
{
    public class Unit_Method
    {
        public enum access_Modifier
        {
            PRIVATE,
            PUBLIC,
            PROTECTED
        }

        public string name { get; set; }
        public string type { get; set; }
        public access_Modifier modifier { get; set; }
        public string parameter;
        public bool static_Modifier { get; set; }
        public bool abstract_Modifier { get; set; }
        public string str_Print { get; set; }

        public Unit_Method(string get_Name = "none", string get_Type = "void", string get_Parameter = "", access_Modifier get_Modifier = access_Modifier.PRIVATE, bool get_Static_Modifier = false, bool get_Abstract_Modifier = false)
        {
            name = get_Name;
            type = get_Type;
            modifier = get_Modifier;
            static_Modifier = get_Static_Modifier;
            abstract_Modifier = get_Abstract_Modifier;
            parameter = get_Parameter;
            make_Str_Print();
        }

        public void make_Str_Print()
        {
            str_Print = string.Empty;
            switch (modifier)
            {
                case access_Modifier.PUBLIC:
                    str_Print += "+";
                    break;
                case access_Modifier.PRIVATE:
                    str_Print += "-";
                    break;
                case access_Modifier.PROTECTED:
                    str_Print += "#";
                    break;
            }

            str_Print += "   ";
            str_Print += name;
            str_Print += "(";
            str_Print += parameter;
            str_Print += ") :";
            str_Print += type;
        }
    }
}
