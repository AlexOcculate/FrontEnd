namespace LinqXml
{
   using System.Linq;

   public partial class DataStore
   {
      public string Name { get; set; }
      public string ConnectionStringName { get; set; }
      public bool LoadDefaultDatabaseOnly { get; set; }
      public bool LoadSystemObjects { get; set; }
      public bool WithFields { get; set; }
      public string StagePathDir { get; set; }

      public static System.Collections.Generic.List<DataStore> LoadDataStoreCollection( System.Xml.Linq.XDocument doc )
      {
         System.Collections.Generic.List<DataStore> list =
            (
               from e in doc.Root.Element("dsCfg").Element( "dsColl" ).Descendants( "ds" )
               select new DataStore
               {
                  Name = (string) e.Attribute( "nm" ).Value, // ?? "Invalid Name",
                  ConnectionStringName = (string) e.Attribute( "csNm" ), // ?? "Invalid Name",
                  LoadDefaultDatabaseOnly = (bool) e.Attribute( "lddo" ), // ?? false,
                  LoadSystemObjects = (bool) e.Attribute( "lso" ), //?? ,
                  WithFields = (bool) e.Attribute( "wf" ),
                  StagePathDir = (string) e.Element( "stgDir" )
               }
            ).ToList( );
         return list;
      }
   }
}
