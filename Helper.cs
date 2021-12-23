using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMONIC
{
    class Helper
    {
        public static UserOficeEntities userOficeEntities;
        public static UserOficeEntities GetEntities()
        {
            if (userOficeEntities == null)
            {
                userOficeEntities = new UserOficeEntities();
            }
            return userOficeEntities;
        }
    }
}
