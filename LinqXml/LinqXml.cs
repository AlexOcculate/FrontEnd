namespace LinqXml
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Xml.Linq;

   internal partial class LinqXmlTest
   {
      public static void EntryPoint()
      {
         XDocument doc = GetDsCfgDoc( );
         Configuration poco = Configuration.GetPoco( doc.Root );
         XElement xElement1 = poco.GetXElement( );
         //
         Configuration cfg = new Configuration( );
         cfg.StageDirPath = @"C:\temp";
         {
            DataStore ds = new DataStore( );
            {
               ds.Name = "ds001";
               ds.ConnectionStringName = "xpto";
               ds.WithFields = true;
               ds.LoadDefaultDatabaseOnly = true;
               ds.StagePathDir = "./../../..";
            }
            cfg.AddDataStore( ds );
            //
            ConnectionString cs = new ConnectionString( )
            {
               Name = "   Alex Mello          ",
               ProviderName = "   System.Data.SqlClient          ",
               String = " 1234567890   "
            };
            cfg.AddConnectionString( cs );
         }
         XElement xElement = cfg.GetXElement( );
         //{
         //   DataStore ds = new DataStore( );
         //   {
         //      ds.Name = "ds001";
         //      ds.ConnectionStringName = "xpto";
         //      ds.WithFields = true;
         //      ds.LoadDefaultDatabaseOnly = true;
         //      ds.StagePathDir = "./../../..";
         //   }
         //   XElement e = ds.GetXElement( );
         //   DataStore poco = DataStore.GetPoco( e );
         //   XElement element = GetDsCfgDoc( ).Root.Element( "dsCfg" );
         //   List<DataStore> pocoList = DataStore.GetPocoList( element );
         //}
         //{
         //   XDocument doc = GetDsCfgDoc( );
         //   IEnumerable<XElement> csList = doc.Root.Element( "csColl" ).Descendants( "cs" );
         //   XElement csColl = doc.Root.Element( "csColl" );
         //   using( ConnectionStringHandler x = new ConnectionStringHandler( ) )
         //   {
         //      x.Load( csColl );
         //   }
         //   System.Threading.Thread.Sleep( 50000 );
         //}
         //{
         //   ConnectionString o = new ConnectionString( )
         //   {
         //      Name = "   Alex Mello          ",
         //      ProviderName = "   System.Data.SqlClient          ",
         //      String = " 1234567890   "
         //   };
         //   o.PropertyChanged += O_PropertyChanged;
         //   XElement xElement = o.GetXElement( );
         //   ConnectionString parser = ConnectionString.GetPoco( xElement );
         //   o.Name = "Alex M Occulate";

         //}
         //{
         //   XDocument doc = SaveDsCfgDocDataToAnXmlFile( @"DsCfgData.xml" );
         //   List<ConnectionString> csPrvList = ConnectionString.LoadConnectionStringCollection( doc );
         //   List<ConnectionString> csList = ConnectionString.LoadConnectionStringCollection( );
         //   List<DataStore> dsColl = DataStore.LoadDataStoreCollection( doc );
         //   //
         //   List<DataStore> loadDsCfgDoc = LoadDsCollDoc( doc );
         //   //List<ConnectionString> privCsList = LoadCsCollDoc( doc );
         //}
         ////
         ////         OtherTests( );
      }

      private static void O_PropertyChanged( object sender, System.ComponentModel.PropertyChangedEventArgs e )
      {
      }

      private static void OtherTests()
      {
         {
            XDocument doc = SaveEmployeesDocDataToAnXmlFile( @"EmployeesData.xml" );
            List<Employee> loadEmployeesDoc = LoadEmployeesDoc( doc );
         }

         { // https://msdn.microsoft.com/en-us/library/bb308960.aspx
            SaveContacsDocDataToAnXmlFile( @"contacsdata.xml" );
         }

         { // http://broadcast.oreilly.com/2010/10/understanding-c-simple-linq-to.html

            // Save the Starbuzz data
            SaveStarbuzzDataToAnXmlFile( @"starbuzzdata.xml" );

            // Read the XML data from starbuzzdata.xml
            XDocument starbuzzData = XDocument.Load( "starbuzzdata.xml" );

            // Query the data that was loaded
            QueryTheData( starbuzzData );
         }

         {
            // Load the blog posts and print the title of the blog
            XDocument ourBlog = XDocument.Load( "http://www.stellman-greene.com/feed" );
            Console.WriteLine( ourBlog
                .Element( "rss" )
                .Element( "channel" )
                .Element( "title" )
                .Value );

            // Query the <item>s in the XML RSS data and select each one into a new Post()
            IEnumerable<Post> posts = from post in ourBlog.Descendants( "item" )
                                      select new Post( post );

            // Print each post to the console
            foreach( Post post in posts )
            {
               Console.WriteLine( post.ToString( ) );
            }
         }
      }

      /////////////////////////////////////////////////////////////////////////

      private static XDocument SaveDsCfgDocDataToAnXmlFile( string filename )
      {
         XDocument doc = GetDsCfgDoc( );
         doc.Save( filename );
         return doc;
      }

      public static System.Collections.Generic.List<ConnectionString> LoadCsCollDoc( XDocument doc )
      {
         System.Collections.Generic.List<ConnectionString> list =
            (
               from e in doc.Descendants( "cs" )
               select new ConnectionString
               {
                  Name = (string) e.Attribute( "nm" ),
                  ProviderName = (string) e.Attribute( "pn" ),
                  //                  isPrivate = (bool) e.Attribute( "pvt" ),
                  String = (string) e.Element( "str" )
               }
            ).ToList( );
         return list;
      }
      public static System.Collections.Generic.List<DataStore> LoadDsCollDoc( XDocument doc )
      {
         System.Collections.Generic.List<DataStore> list =
            (
               from e in doc.Descendants( "ds" )
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

      public static XDocument GetDsCfgDoc()
      {
         XDocument doc =
            new XDocument(
               new XDeclaration( "1.0", "utf-8", "yes" ),
               new XComment( "LINQ to XML Contacts XML Example" ),
               new XProcessingInstruction( "MyApp", "123-44-4444" ),
               new XElement( "cfg",
                  new XElement( "dsCfg",
                     new XElement( "stgDir", "./../.." ), // StagePathDir
                     new XElement( "dsColl",
                        new XElement( "ds",
                           new XAttribute( "nm", "Patrick Hines" ),
                           new XAttribute( "csNm", "144" ),
                           new XAttribute( "lddo", true ), // LoadDefaultDatabaseOnly
                           new XAttribute( "lso", true ), // LoadSystemObjects
                           new XAttribute( "wf", true ), // WithFields
                           new XElement( "stgDir", "./../.." ) // stage path dir
                        ),
                        new XElement( "ds",
                           new XAttribute( "nm", "Alex" ),
                           new XAttribute( "csNm", "x144" ),
                           new XAttribute( "lddo", true ), // LoadDefaultDatabaseOnly
                           new XAttribute( "lso", true ), // LoadSystemObjects
                           new XAttribute( "wf", true ), // WithFields
                           new XElement( "stgDir", "./../.." )  // StagePathDir
                        )
                     )
                  ),
                  new XElement( "csColl",
                     new XElement( "cs",
                        new XAttribute( "pvt", true ), // isPrivate
                        new XAttribute( "nm", "144" ),
                        new XAttribute( "pn", "System.Data.SqlClient" ), // ProviderName
                        new XElement( "str", "zzzasda:xcxxxc.xcxc.xcxc" ) // ConnectionString
                     ),
                     new XElement( "cs",
                        new XAttribute( "pvt", true ), // isPrivate
                        new XAttribute( "nm", "144" ),
                        new XAttribute( "pn", "System.Data.SqlClient" ), // ProviderName
                        new XElement( "str", "zzzasda:xcxxxc.xcxc.xcxc" ) // ConnectionString
                     ),
                     new XElement( "cs",
                        new XAttribute( "pvt", true ), // isPrivate
                        new XAttribute( "nm", "x144" ),
                        new XAttribute( "pn", "System.Data.SqlClient" ), // ProviderName
                        new XElement( "str", "sql:url.qwerty" ) // ConnectionString
                     )
                  )
               )
            );
         return doc;
      }

      public partial class DataStoreConfig
      {
         public string StagePathDir { get; set; }
         public System.Collections.Generic.List<DataStore> DataStores { get; set; }
         public System.Collections.Generic.List<ConnectionString> ConnectionStrings { get; set; }
      }

      /////////////////////////////////////////////////////////////////////////

      public class Employee
      {
         public int ID { get; set; }
         public string Nm { get; set; }
         public int Pos { get; set; }
         public string Xyz { get; set; }
         public List<Proj> Projs { get; set; }
      }
      public class Proj
      {
         public string Nm { get; set; }
         public int Age { get; set; }
      }

      public static List<Employee> LoadEmployeesDoc( XDocument doc )
      {
         List<Employee> eList = (
            from e in doc.Root.Elements( "employee" )
            select new Employee
            {
               ID = (int) e.Element( "id" ),
               Nm = (string) e.Element( "nm" ),
               Pos = (int) e.Element( "pos" ),
               Xyz = (string) e.Element( "xyz" ),
               Projs =
               (
                  from p in e.Elements( "projs" ).Elements( "proj" )
                  select new Proj
                  {
                     Nm = (string) p.Element( "nm" ),
                     Age = (int) p.Element( "age" )
                  }
               ).ToList( )
            }
         ).ToList( );
         return eList;
      }

      private static XDocument SaveEmployeesDocDataToAnXmlFile( string filename )
      {
         XDocument doc = GetEmployeesDoc( );
         doc.Save( filename );
         return doc;
      }

      public static XDocument GetEmployeesDoc()
      {
         XDocument doc =
            new XDocument(
               new XDeclaration( "1.0", "utf-8", "yes" ),
               new XComment( "LINQ to XML Contacts XML Example" ),
               new XProcessingInstruction( "MyApp", "123-44-4444" ),
               new XElement( "employees",
                  new XElement( "employee",
                     new XElement( "id", "10" ),
                     new XElement( "nm", "Patrick Hines" ),
                     new XElement( "pos", "144" ),
                     new XElement( "xyz", "206-555-0144",
                        new XAttribute( "type", "home" ) ),
                     new XElement( "projs",
                        new XElement( "proj",
                           new XElement( "nm", "qwerty" ),
                           new XElement( "age", "188" ) ),
                        new XElement( "proj",
                           new XElement( "nm", "qwerty" ),
                           new XElement( "age", "188" ) ),
                        new XElement( "proj",
                           new XElement( "nm", "qwerty" ),
                           new XElement( "age", "188" ) ),
                        new XElement( "proj",
                           new XElement( "nm", "qwerty" ),
                           new XElement( "age", "188" ) )
                     )
                  )
               )
            );
         return doc;
      }

      /////////////////////////////////////////////////////////////////////////

      private static void SaveContacsDocDataToAnXmlFile( string filename )
      {
         XDocument doc = GetContacsDoc( );
         doc.Save( filename );
      }

      private static XDocument GetContacsDoc()
      {
         XNamespace ns = "http://mycompany.com";
         XNamespace ns2 = "URI";
         XDocument doc =
            new XDocument(
               new XDeclaration( "1.0", "utf-8", "yes" ),
               new XComment( "LINQ to XML Contacts XML Example" ),
               new XProcessingInstruction( "MyApp", "123-44-4444" ),
               new XElement( "contacts",
                  new XElement( ns + "contact",
                     new XElement( ns + "name", "Patrick Hines" ),
                     new XElement( ns + "phone", "206-555-0144",
                        new XAttribute( "type", "home" ) ),
                     new XElement( ns + "phone", "206-555-3144",
                        new XAttribute( "type", "work" ) ),
                     new XElement( "address",
                        new XElement( "street1", "123 Main St" ),
                        new XElement( "city", "Mercer Island" ),
                        new XElement( "state", "WA" ),
                        new XElement( "postal", "68042" ) ),
                     new XElement( ns + "e",
                        new XAttribute( XNamespace.Xmlns + nameof( Proj ), ns ) )
                  )
               )
            );
         return doc;
      }

      private static XElement f()
      {
         XElement ee = XElement.Load( @"c:\myContactList.xml" );
         XElement e = XElement.Parse(
            @"<contacts>
               <contact>
                  <name>Patrick Hines</name>
                  <phone type=""home"">206-555-0144</phone>
                  <phone type=""work"">425-555-0145</phone>
                  <address>
                     <street1>123 Main St</street1>
                     <city>Mercer Island</city>         
                     <state>WA</state>
                     <postal>68042</postal>
                  </address>
                  <netWorth>10</netWorth>
               </contact>
               <contact>
                  <name>Gretchen Rivas</name>
                  <phone type=""mobile"">206-555-0163</phone>
                  <address>
                     <street1>123 Main St</street1>
                     <city>Mercer Island</city>
                     <state>WA</state>
                     <postal>68042</postal>
                  </address>
                  <netWorth>11</netWorth>
               </contact>
               <contact>
                  <name>Scott MacDonald</name>
                  <phone type=""home"">925-555-0134</phone>
                  < phone type = ""mobile"" > 425 - 555 - 0177 </ phone >
                  <address>
                     <street1>345 Stewart St</street1>
                     <city>Chatsworth</city>
                     <state>CA</state>
                     <postal>91746</postal>
                  </address>
                  <netWorth>500000</netWorth>
               </contact>
              </ contacts > " );
         return e;
      }

      /// <summary>
      /// Save the Starbuzz data to an XML file and load it again.
      /// </summary>
      /// <param name="filename">Filename to write the data to</param>
      private static void SaveStarbuzzDataToAnXmlFile( string filename )
      {
         XDocument doc = GetStarbuzzData( );
         doc.Save( filename );
      }

      /// <summary>
      /// Get the Starbuzz customer data as an XDocument
      /// </summary>
      /// <returns>XDocument with the Starbuzz data</returns>
      private static XDocument GetStarbuzzData()
      {
         /*
             * You can use an XDocument to create an XML file, and that includes XML
             * files you can read and write using DataContractSerializer.
             *
             * An XMLDocument object represents an XML document. It's part of the
             * System.Xml.Linq namespace.
             *
             * Use XElement objects to create elements under the XML tree.
             */
         XDocument doc = new XDocument(
             new XDeclaration( "1.0", "utf-8", "yes" ),
             new XComment( "Starbuzz Customer Loyalty Data" ),
             new XElement( "starbuzzData",
                 new XAttribute( "storeName", "Park Slope" ),
                 new XAttribute( "location", "Brooklyn, NY" ),
                 new XElement( "person",
                     new XElement( "personalInfo",
                         new XElement( "name", "Janet Venutian" ),
                         new XElement( "zip", 11215 ) ),
                     new XElement( "favoriteDrink", "Choco Macchiato" ),
                     new XElement( "moneySpent", 255 ),
                     new XElement( "visits", 50 ) ),
                 new XElement( "person",
                     new XElement( "personalInfo",
                         new XElement( "name", "Liz Nelson" ),
                         new XElement( "zip", 11238 ) ),
                     new XElement( "favoriteDrink", "Double Cappuccino" ),
                     new XElement( "moneySpent", 150 ),
                     new XElement( "visits", 35 ) ),
                 new XElement( "person",
                     new XElement( "personalInfo",
                         new XElement( "name", "Matt Franks" ),
                         new XElement( "zip", 11217 ) ),
                     new XElement( "favoriteDrink", "Zesty Lemon Chai" ),
                     new XElement( "moneySpent", 75 ),
                     new XElement( "visits", 15 ) ),
                 new XElement( "person",
                     new XElement( "personalInfo",
                         new XElement( "name", "Joe Ng" ),
                         new XElement( "zip", 11217 ) ),
                     new XElement( "favoriteDrink", "Banana Split in a Cup" ),
                     new XElement( "moneySpent", 60 ),
                     new XElement( "visits", 10 ) ),
                 new XElement( "person",
                     new XElement( "personalInfo",
                         new XElement( "name", "Sarah Kalter" ),
                         new XElement( "zip", 11215 ) ),
                     new XElement( "favoriteDrink", "Boring Coffee" ),
                     new XElement( "moneySpent", 110 ),
                     new XElement( "visits", 15 ) ) ) );
         return doc;
      }

      /// <summary>
      /// Query the data and print the results to the console
      /// <param name="doc">XDocument with Starbuzz customer loyalty data loaded</param>
      /// </summary>
      private static void QueryTheData( XDocument doc )
      {
         // Do a simple query and print the results to the console
         var data = from item in doc.Descendants( "person" )
                    select new
                    {
                       drink = item.Element( "favoriteDrink" ).Value,
                       moneySpent = item.Element( "moneySpent" ).Value,
                       zipCode = item.Element( "personalInfo" ).Element( "zip" ).Value
                    };
         foreach( var p in data )
         {
            Console.WriteLine( p.ToString( ) );
         }

         // Do a more complex query and print the results to the console
         IEnumerable<IGrouping<string, string>> zipcodeGroups = from item in doc.Descendants( "person" )
                                                                group item.Element( "favoriteDrink" ).Value
                                                                by item.Element( "personalInfo" ).Element( "zip" ).Value
                                                                into zipcodeGroup
                                                                select zipcodeGroup;
         foreach( IGrouping<string, string> group in zipcodeGroups )
         {
            Console.WriteLine( $"{group.Distinct( ).Count( )} favorite drinks in {group.Key}" );
         }
      }

      /// <summary>
      /// A Post object represents a single RSS post read from XML data
      /// </summary>
      private class Post
      {
         public string Title { get; private set; }
         public DateTime? Date { get; private set; }
         public string Url { get; private set; }
         public string Description { get; private set; }
         public string Creator { get; private set; }
         public string Content { get; private set; }

         private static string GetElementValue( XContainer element, string name )
         {
            if( (element == null) || (element.Element( name ) == null) )
            {
               return string.Empty;
            }

            return element.Element( name ).Value;
         }

         public Post( XContainer post )
         {
            // Get the string properties from the post's element values
            this.Title = GetElementValue( post, "title" );
            this.Url = GetElementValue( post, "guid" );
            this.Description = GetElementValue( post, "description" );
            this.Creator = GetElementValue( post, "{http://purl.org/dc/elements/1.1/}creator" );
            this.Content = GetElementValue( post, "{http://purl.org/dc/elements/1.0/modules/content}encoded" );

            // The Date property is a nullable DateTime? -- if the pubDate element
            // can't be parsed into a valid date, the Date property is set to null
            DateTime result;
            if( DateTime.TryParse( GetElementValue( post, "pubDate" ), out result ) )
            {
               this.Date = (DateTime?) result;
            }
         }

         public override string ToString()
         {
            return $"{this.Title ?? "no title"} by {this.Creator ?? "Unknown"}";
         }
      }
   }
}
