using System;

namespace LockCursorInMonitor.Interop.Exceptions
{
    class GetCursorPosFailedException : Exception
    {
        public GetCursorPosFailedException() : base("GetCursorPos has failed.")
        {
        }
    }
}
