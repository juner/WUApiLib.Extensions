namespace WUApiLib.Utility.Extensions
{
    public static class COMExceptionExtension
    {
        public static HResult GetWindowsUpdateHResult(this System.Runtime.InteropServices.COMException e)
        {
            return (HResult)(uint)e.HResult;
        }
    }
}
