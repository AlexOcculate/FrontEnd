using System;
using System.Linq;

namespace DataPhilosophiae.Exceptions.DS
{
   [System.Serializable]
   public class FocusedDataStoreChangedException : System.Exception
   {
      public FocusedDataStoreChangedException() : base( )
      {
      }

      public FocusedDataStoreChangedException( string message ) : base( message )
      {
      }

      public FocusedDataStoreChangedException( string format, params object[ ] args )
         : base( string.Format( format, args ) )
      {
      }

      public FocusedDataStoreChangedException( string message, System.Exception innerException )
         : base( message, innerException )
      {
      }

      public FocusedDataStoreChangedException( string format, System.Exception innerException, params object[ ] args )
         : base( string.Format( format, args ), innerException )
      {
      }

      protected FocusedDataStoreChangedException( System.Runtime.Serialization.SerializationInfo info,
                                                 System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }
}
