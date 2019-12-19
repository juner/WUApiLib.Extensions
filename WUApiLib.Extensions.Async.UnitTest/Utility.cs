using System;
using System.Security.Principal;

namespace WUApiLib.Extensions.Async.UnitTest
{
    public static class Utility
    {
        public static bool IsInRoleAdministrator()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            return (System.Threading.Thread.CurrentPrincipal as WindowsPrincipal).IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
