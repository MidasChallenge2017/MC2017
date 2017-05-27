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

        private string name { get; set; }
        private string type { get; set; }
        private access_Modifier modifier { get; set; }
        private bool static_Modifier { get; set; }
        private bool final_Modifier { get; set; }

        public Unit_Value(string get_Name = "none", string get_Type = "none", access_Modifier get_Modifier = access_Modifier.PRIVATE, bool get_Static_Modifier = false, bool get_Final_Modifier = false)
        {
            name = get_Name;
            type = get_Type;
            modifier = get_Modifier;
            static_Modifier = get_Static_Modifier;
            final_Modifier = get_Final_Modifier;
        }
    }
}
