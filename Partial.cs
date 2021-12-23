using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMONIC
{
    public partial class Users
    {
        public int Age
        {
            get
            {
                if (DateBirth.HasValue)
                {
                    return DateTime.Now.Year - DateBirth.Value.Year;
                }
                return 0;
            }
        }
    }
}
