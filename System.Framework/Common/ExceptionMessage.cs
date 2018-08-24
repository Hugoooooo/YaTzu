using System;

namespace System.Framework.Common
{
    /// <summary>
    /// ExceptionMessage ªººK­n´y­z¡C
    /// </summary>
    public class ExceptionMessage : Exception
    {
        private int _dialogWidth = 0;
        private int _dialogHeight = 0;

        #region Properties
        /// <summary>¿ù»~µ¡¼e</summary>
        public int DialogWidth
        {
            get { return _dialogWidth; }
        }
        /// <summary>¿ù»~µ¡°ª</summary>
        public int DialogHeight
        {
            get { return _dialogHeight; }
        }
        #endregion

        public ExceptionMessage(string AMsg, int AWidth, int AHeight) : base(AMsg)
        {
            _dialogWidth = AWidth;
            _dialogHeight = AHeight;
        }

        public ExceptionMessage(string AMsg) : base(AMsg) {}
    }
}
