namespace DayOneWindowsClient.Utilities
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// A utility class for declaring WIN32 API functions
    /// </summary>
    internal class PInvoke
    {
        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        public static extern int CoInternetSetFeatureEnabled(
            int featureEntry,
            [MarshalAs(UnmanagedType.U4)] int flags,
            bool enable);
    }
}
