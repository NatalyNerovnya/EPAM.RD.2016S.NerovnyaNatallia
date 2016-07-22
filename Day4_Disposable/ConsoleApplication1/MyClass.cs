using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    // TODO: The code below contains a lot of issues. Please, fix all of them.
    // Use as a guidelines:
    // https://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx
    // https://msdn.microsoft.com/en-us/library/b1yfkh5e%28v=vs.100%29.aspx?f=255&MSPPError=-2147217396
    // https://msdn.microsoft.com/en-us/library/fs2xkftw(v=vs.110).aspx
    public class MyClass : IDisposable
    {
        private IntPtr _buffer;       // unmanaged resource
        private SafeHandle _resource; // managed resource
        private bool _disposed = false;

        public MyClass()
        {
            this._buffer = Helper.AllocateBuffer();
            this._resource = Helper.GetResource();
        }

        ~MyClass()
        {
            Dispose(/*true*/ false);
        }

        public/* virtual*/ void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /*private*/
        protected virtual void Dispose(bool disposing) // There wasn't virtual keyword here
        {
            if (_disposed)
                return;
            if (disposing)
            {
                if (_resource != null)
                    _resource.Dispose();
            }
            Helper.DeallocateBuffer(_buffer);
            _disposed = true;

        }


        public void DoSomething()
        {
            // NOTE: Manupulation with _buffer and _resource in this line.
            if (_disposed)
                throw new ObjectDisposedException("_resources has been cleaned");
            // now call some native methods using the resource 
            var smth = _resource.IsInvalid;
            var a = _resource.IsClosed;
        }
    }
}
