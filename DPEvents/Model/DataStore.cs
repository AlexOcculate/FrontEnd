using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace DataPhilosophiae.Model
{
   public partial class DataStore
   {
      #region --- OnPropertyChanged EVENTS + HANDLERS + EXCEPTIONS --- 
      public event PropertyChangedEventHandler PropertyChanged;

      protected void OnPropertyChanged(PropertyChangedEventArgs e)
      {
         this.PropertyChanged?.Invoke(this, e);
      }

      protected void OnPropertyChanged(string propertyName)
      {
         this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
      }
      #endregion

      #region --- PROPERTIES + BACKFIELDS ---
      private string _nm;

      public string Name
      {
         get
         {
            if(this._nm == null || string.IsNullOrWhiteSpace(this._nm))
            {
               return null;
            }
            return this._nm.Trim();
         }
         set
         {
            string val = null;
            if(!(value == null || string.IsNullOrWhiteSpace(value)))
            {
               val = value.Trim();
            }
            if(this._nm != val)
            {
               this._nm = val;
               this.OnPropertyChanged(nameof(this.Name));
            }
         }
      }

      private string _csn;

      public string ConnectionStringName
      {
         get
         {
            if(this._csn == null || string.IsNullOrWhiteSpace(this._csn))
            {
               return null;
            }
            return this._csn.Trim();
         }
         set
         {
            string val = null;
            if(!(value == null || string.IsNullOrWhiteSpace(value)))
            {
               val = value.Trim();
            }
            if(this._csn != val)
            {
               this._csn = val;
               this.OnPropertyChanged(nameof(this.ConnectionStringName));
            }
         }
      }

      private bool _lddo;

      public bool LoadDefaultDatabaseOnly
      {
         get
         {
            return this._lddo;
         }
         set
         {
            if(this._lddo != value)
            {
               this._lddo = value;
               this.OnPropertyChanged(nameof(this.LoadDefaultDatabaseOnly));
            }
         }
      }

      private bool _lso;

      public bool LoadSystemObjects
      {
         get
         {
            return this._lso;
         }
         set
         {
            if(this._lso != value)
            {
               this._lso = value;
               this.OnPropertyChanged(nameof(this.LoadSystemObjects));
            }
         }
      }

      private bool _wf;

      public bool WithFields
      {
         get
         {
            return this._wf;
         }
         set
         {
            if(this._wf != value)
            {
               this._wf = value;
               this.OnPropertyChanged(nameof(this.WithFields));
            }
         }
      }

      private string _stgDir;

      public string StagePathDir
      {
         get
         {
            if(this._stgDir == null || string.IsNullOrWhiteSpace(this._stgDir))
            {
               return null;
            }
            return this._stgDir.Trim();
         }
         set
         {
            string val = null;
            if(!(value == null || string.IsNullOrWhiteSpace(value)))
            {
               val = value.Trim();
            }
            if(this._stgDir != val)
            {
               this._stgDir = val;
               this.OnPropertyChanged(nameof(this.StagePathDir));
            }
         }
      }
      #endregion

      #region --- Ctors... ---
      public DataStore()
      {
      }

      public DataStore(string name) : this()
      {
         this.Name = name;
      }
      #endregion
      //
      public System.Xml.Linq.XElement GetXElement()
      {
         //new XElement( "ds",
         //    new XAttribute( "nm", "Patrick Hines" ),
         //    new XAttribute( "csNm", "144" ),
         //    new XAttribute( "lddo", true ), // LoadDefaultDatabaseOnly
         //    new XAttribute( "lso", true ),  // LoadSystemObjects
         //    new XAttribute( "wf", true ),   // WithFields
         //    new XElement( "stgDir",         // stage path dir
         //        new XCData( "./../.." ) )
         //);
         if(this.Name == null)
         {
            return null;
         }
         System.Xml.Linq.XElement e =
            new System.Xml.Linq.XElement("ds",
                new System.Xml.Linq.XAttribute("nm", this.Name)
            );
         if(this.ConnectionStringName != null)
         {
            e.Add(new System.Xml.Linq.XAttribute("csNm", this.ConnectionStringName));
         }
         e.Add(new System.Xml.Linq.XAttribute("lddo", this.LoadDefaultDatabaseOnly));
         e.Add(new System.Xml.Linq.XAttribute("lso", this.LoadSystemObjects));
         e.Add(new System.Xml.Linq.XAttribute("wf", this.WithFields));
         if(this.StagePathDir != null)
         {
            e.Add(new System.Xml.Linq.XElement("stgDir",
                       new System.Xml.Linq.XCData(this.StagePathDir))
            );
         }
         return e;
      }

      //
      public static DataStore GetPoco(System.Xml.Linq.XElement e)
      {
         if(e == null || e.Attribute("nm") == null)
         {
            return null;
         }
         string nm = (string) e.Attribute("nm");
         string csNm = (string) e.Attribute("csNm") ?? null;

         bool lddo = false;
         if(e.Attribute("lddo") != null)
         {
            bool.TryParse(e.Attribute("lddo").Value, out lddo);
         }

         bool lso = false;
         if(e.Attribute("lso") != null)
         {
            bool.TryParse(e.Attribute("lso").Value, out lso);
         }

         bool wf = false;
         if(e.Attribute("wf") != null)
         {
            bool.TryParse(e.Attribute("wf").Value, out wf);
         }

         string stgDir = e.Element("stgDir") != null ? e.Element("stgDir").Value : null;
         //
         DataStore ds = new DataStore()
         {
            Name = nm,
            ConnectionStringName = csNm,
            LoadDefaultDatabaseOnly = lddo,
            LoadSystemObjects = lso,
            WithFields = wf,
            StagePathDir = stgDir
         };
         return ds;
      }

      //
      public static List<DataStore> GetPocoList(XElement e)
      {
         List<DataStore> list =
            (
               from cs in e.Descendants("ds")
            select new DataStore
            {
               Name = (string) cs.Attribute("nm"),
               ConnectionStringName = (string) cs.Attribute("csNm"),
               LoadDefaultDatabaseOnly = (bool) cs.Attribute("lddo"),
               LoadSystemObjects = (bool) cs.Attribute("lso"),
               WithFields = (bool) cs.Attribute("wf"),
               StagePathDir = (string) cs.Element("stgDir")
            }
            ).ToList();
         return list;
      }

      //
      public static List<DataStore> LoadDataStoreCollection(System.Xml.Linq.XDocument doc)
      {
         List<DataStore> list =
            (
               from e in doc.Root.Element("dsCfg").Element("dsColl").Descendants("ds")
            select new DataStore
            {
               Name = e.Attribute("nm").Value, // ?? "Invalid Name",
               ConnectionStringName = (string) e.Attribute("csNm"), // ?? "Invalid Name",
               LoadDefaultDatabaseOnly = (bool) e.Attribute("lddo"), // ?? false,
               LoadSystemObjects = (bool) e.Attribute("lso"), //?? ,
               WithFields = (bool) e.Attribute("wf"),
               StagePathDir = (string) e.Element("stgDir")
            }
            ).ToList();
         return list;
      }

      public DataStore Clone()
      {
         DataStore o = new DataStore(this.Name + "_COPY");
         o.ConnectionStringName = this.ConnectionStringName;
         o.LoadDefaultDatabaseOnly = this.LoadDefaultDatabaseOnly;
         o.LoadSystemObjects = this.LoadSystemObjects;
         o.WithFields = this.WithFields;
         o.StagePathDir = this.StagePathDir;
         return o;
      }
   }
}
