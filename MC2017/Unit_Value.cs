using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC2017
{
    public class Unit_Value
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
        public bool static_Modifier { get; set; }
        public bool final_Modifier { get; set; }
        public string str_Print { get; set; }

        public Unit_Value(string get_Name = "none", string get_Type = "void", access_Modifier get_Modifier = access_Modifier.PRIVATE, bool get_Static_Modifier = false, bool get_Final_Modifier = false)
        {
            name = get_Name;
            type = get_Type;
            modifier = get_Modifier;
            static_Modifier = get_Static_Modifier;
            final_Modifier = get_Final_Modifier;
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
            str_Print += " :";
            str_Print += type;
        }
    }
}
