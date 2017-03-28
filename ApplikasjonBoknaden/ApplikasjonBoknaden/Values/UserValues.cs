using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplikasjonBoknaden
{
    public static class UserValues
    {
        private static bool UserIsLogedInn = false;

        public static bool GetUserIsLogedInn()
        {
            return UserIsLogedInn;
        }

        public static void SetUserIsLogedInn(bool state)
        {
            UserIsLogedInn = state;
        }

    }
}
