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
    public partial class UserActivity
    {
        public TimeSpan? TimeSpent
        {
            get
            {
                if (LogutTime.HasValue)
                {
                    return (LogutTime.Value.TimeOfDay - LoginTime.TimeOfDay);
                }
                return null;
            }
        }
        public bool IsNotReason
        {
            get
            {
                return Reason == null;
            }
        }
    }
}
