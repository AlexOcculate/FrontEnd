using System;
using System.Linq;

namespace DataPhilosophiae.Exceptions.SysCS
{
   [System.Serializable]
   public class FocusedSysCSChangedException : System.Exception
   {
      public FocusedSysCSChangedException() : base()
      {
      }

      public FocusedSysCSChangedException(string message) : base(message)
      {
      }

      public FocusedSysCSChangedException(string format, params object[ ] args)
          : base(string.Format(format, args))
      {
      }

      public FocusedSysCSChangedException(string message, System.Exception innerException)
          : base(message, innerException)
      {
      }

      public FocusedSysCSChangedException(string format, System.Exception innerException, params object[ ] args)
          : base(string.Format(format, args), innerException)
      {
      }

      protected FocusedSysCSChangedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
          : base(info, context)
      {
      }
   }
}
