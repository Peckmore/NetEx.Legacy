using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Windows.Forms
{
    /// <summary>
    /// Provides extension methods for the <see cref="NotifyIcon"/> class.
    /// </summary>
    public static class NotifyIconExtensionMethods
    {
        /// <summary>
        /// Shows the context menu for the tray icon.
        /// </summary>
        /// <param name="notifyIcon">The <see cref="NotifyIcon"/> to show a context menu for.</param>
        /// <param name="contextMenu">The context menu to show.</param>
        /// <remarks>
        /// <para>In .Net Framework, and .Net Core 3.0 and earlier, this method was available on the <see cref="NotifyIcon"/> class,
        /// along with a <c>ContextMenu</c> property that could be used to set the context menu for a notification icon. However, when
        /// these controls were removed in .Net Core 3.1, the <c>ContextMenu</c> property was removed, and the <c>ShowContextMenu</c>
        /// method was updated to only support <see cref="ContextMenuStrip"/>.</para>
        /// <para>Rather than implement a "legacy" version of <see cref="NotifyIcon"/> under a new name, most of the old functionality
        /// can be restored through this extension method. Previously the context menu would be shown when the user right-clicks an icon
        /// in the notification area of the taskbar. However this method will need to be manually invoked when the notification icon is
        /// clicked.</para>
        /// </remarks>
        public static void ShowContextMenu(this NotifyIcon notifyIcon, ContextMenu contextMenu)
        {
            var pos = Cursor.Position;

            var window = typeof(NotifyIcon).GetField("_window", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(notifyIcon);
            var windowHandle = (IntPtr)window!.GetType().GetProperty("Handle")!.GetValue(window)!;

            // Summary: the current window must be made the foreground window
            // before calling TrackPopupMenuEx, and a task switch must be
            // forced after the call.
            UnsafeNativeMethods.SetForegroundWindow(new HandleRef(window, windowHandle));

            contextMenu.OnPopup(EventArgs.Empty);

            SafeNativeMethods.TrackPopupMenuEx(new HandleRef(contextMenu, contextMenu.Handle),
                NativeMethods.TPM_VERTICAL | NativeMethods.TPM_RIGHTALIGN,
                pos.X, //pt.x,
                pos.Y, //pt.y,
                new HandleRef(window, windowHandle),
                null);

            // Force task switch (see above)
            UnsafeNativeMethods.PostMessage(new HandleRef(window, windowHandle), Interop.WindowMessages.WM_NULL, IntPtr.Zero, IntPtr.Zero);
        }
    }
}