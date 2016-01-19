using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummerOutreach.ComponentHelper;
using SummerOutreach.Interfaces;

namespace SummerOutreach.ExtensionClass
{
    public static class ScreenShotExtensionClass
    {
        public static void CaptureScreenShot(this IPage pgae,string name = null)
        {
            GenericHelper.TakeSceenShot(name);
        }
    }
}
