using System.Reflection;
using System.Windows.Forms;

namespace System.Windows
{
    /// <summary>
    /// An implementation of `Command` that wraps the internal WinForms implementation. We have to use the built-in implementation as
    /// it is used to dispatch `WM_COMMAND` messages.
    /// 
    /// Credit to Inmobilis (https://github.com/Inmobilis) for this solution.
    /// https://github.com/paintdotnet/System.Windows.Forms.Legacy/issues/3#issuecomment-1463645942
    /// </summary>
    internal class Command : IDisposable
    {
        #region Fields

        #region Private

        private readonly object _cmd;

        #endregion

        #region Private Static

        private static readonly Type CommandType = typeof(Control).Assembly.GetType("System.Windows.Forms.Command")!;
        private static readonly PropertyInfo CommandIdProperty = CommandType.GetProperty(nameof(ID), typeof(int))!;
        private static readonly MethodInfo CommandDisposeMethod = CommandType.GetMethod(nameof(Dispose), Type.EmptyTypes)!;

        #endregion

        #endregion

        #region Construction

        public Command(ICommandExecutor target)
        {
            _cmd = Activator.CreateInstance(CommandType, target) ?? throw new NullReferenceException("'target' parameter cannot be null.");
        }

        #endregion

        #region Properties

        public int ID => (int)CommandIdProperty.GetValue(_cmd)!;

        #endregion

        #region Methods

        public void Dispose()
        {
            CommandDisposeMethod.Invoke(_cmd, null);
        }

        #endregion
    }
}