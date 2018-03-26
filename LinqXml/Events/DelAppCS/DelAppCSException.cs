using System;
using System.Linq;

namespace LinqXml.Control
{
   [System.Serializable]
   public class DelAppCSException : System.Exception
   {
      public DelAppCSException() : base( )
      {
      }

      public DelAppCSException( string message ) : base( message )
      {
      }

      public DelAppCSException( string format, params object[ ] args ) : base( string.Format( format, args ) )
      {
      }

      public DelAppCSException( string message, System.Exception innerException ) : base( message,
                                                                                                  innerException )
      {
      }

      public DelAppCSException( string format, System.Exception innerException, params object[ ] args ) : base( string.Format( format,
                                                                                                                                      args ),
                                                                                                                        innerException )
      {
      }

      protected DelAppCSException( System.Runtime.Serialization.SerializationInfo info,
                                             System.Runtime.Serialization.StreamingContext context ) : base( info,
                                                                                                           context )
      {
      }
   }
}
