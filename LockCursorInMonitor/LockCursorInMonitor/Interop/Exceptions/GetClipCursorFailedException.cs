using System;

namespace LockCursorInMonitor.Interop.Exceptions
{
    class GetClipCursorFailedException : Exception
    {
        public GetClipCursorFailedException() : base("GetClipCursor has failed.")
        {
        }
    }
}
