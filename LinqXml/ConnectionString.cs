namespace LinqXml
{
   using System.Linq;

   public partial class ConnectionString
   {
      public bool isPrivate { get; set; }
      public string Name { get; set; }
      public string ProviderName { get; set; }
      public string String { get; set; }
      //
      public static System.Collections.Generic.List<ConnectionString> LoadConnectionStringCollection()
      {
         System.Collections.Generic.List<ConnectionString> list = new System.Collections.Generic.List<ConnectionString>( );
         System.Configuration.ConnectionStringSettingsCollection css = System.Configuration.ConfigurationManager.ConnectionStrings;
         if( css == null )
         {
            return list;
         }
         foreach( System.Configuration.ConnectionStringSettings cs in css )
         {
            ConnectionString o = new ConnectionString( )
            {
               isPrivate = false,
               Name = cs.Name,
               ProviderName = cs.ProviderName,
               String = cs.ConnectionString
            };
            list.Add( o );
         }
         return list;
      }
      public static System.Collections.Generic.List<ConnectionString> LoadConnectionStringCollection( System.Xml.Linq.XDocument doc )
      {
         System.Collections.Generic.List<ConnectionString> list =
            (
               from e in doc.Root.Element("csColl").Descendants( "cs" )
               select new ConnectionString
               {
                  isPrivate = true,
                  Name = (string) e.Attribute( "nm" ),
                  ProviderName = (string) e.Attribute( "pn" ),
                  String = (string) e.Element( "str" )
               }
            ).ToList( );
         return list;
      }
   }
}
