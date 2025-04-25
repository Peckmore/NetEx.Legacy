using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Windows.Forms
{
    /// <summary>
    /// A compatibility shim to provide functionality that is normally available on the built in `Control` class within WinForms.
    /// </summary>
    internal static class ControlShim
    {
        internal static void CheckParentingCycle(Control? bottom, Control? toFind)
        {
            typeof(Control).GetMethod(nameof(CheckParentingCycle), BindingFlags.NonPublic | BindingFlags.Static)!.Invoke(null, new object?[] { bottom, toFind });
        }

        internal static IntPtr SetUpPalette(IntPtr dc, bool force, bool realizePalette)
        {
            return (IntPtr)typeof(Control).GetMethod(nameof(SetUpPalette), BindingFlags.NonPublic | BindingFlags.Static)!.Invoke(null, new object?[] { dc, force, realizePalette })!;
            //IntPtr halftonePalette = Graphics.GetHalftonePalette();
            
            //IntPtr result = SafeNativeMethods.SelectPalette(new HandleRef(null, dc), new HandleRef(null, halftonePalette), (force ? 0 : 1));

            //if (result != IntPtr.Zero && realizePalette)
            //{
            //    SafeNativeMethods.RealizePalette(new HandleRef(null, dc));
            //}

            //return result;
        }
    }
}