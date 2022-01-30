using System;

namespace SpaLNT.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        /// <summary>
        /// Use C# finalizer syntax for finalization code.This finalizer will run only if the Dispose method
        /// does not get called.It gives your base class the opportunity to finalize.
        /// Do not provide finalizer in types derived from this class.
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }

        //Ovveride this to dispose custom objects
        protected virtual void DisposeCore() { }
    }
}