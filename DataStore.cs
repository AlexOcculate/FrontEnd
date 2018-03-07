namespace FrontEnd
{
   public partial class DataStoreConfig
   {
      public string PathDir { get; set; }
      public System.Collections.Generic.List<DataStore> DataStores { get; set; }
      public System.Collections.Generic.List<ConnectionString> ConnectionStrings { get; set; }
   }

   public partial class DataStore
   {
      public string Name { get; set; }
      public string ConnectionName { get; set; }
      public bool LoadDefaultDatabaseOnly { get; set; }
      public bool LoadSystemObjects { get; set; }
      public bool WithFields { get; set; }
      public string PathDir { get; set; }
   }

   public partial class ConnectionString
   {
      public string Name { get; set; }
      public string String { get; set; }
      public string ProviderName { get; set; }
      public bool fromConfigurationManager { get; set; }
   }
}
