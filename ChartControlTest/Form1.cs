using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartControlTest
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent( );
         {
            // Create an empty Bar series and add it to the chart. 
            DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series( "Series1", DevExpress.XtraCharts.ViewType.Bar );
            this.chartControl1.Series.Add( series );

            // Generate a data table and bind the chart to it. 
            //this.chartControl1.DataSource = this.CreateChartData( );
            // Specify data members to bind the chart's series template. 
            //this.chartControl1.SeriesDataMember = "Type";
            //this.chartControl1.SeriesTemplate.ArgumentDataMember = "Section";
            //this.chartControl1.SeriesTemplate.ValueDataMembers.AddRange( new string[ ] { "Counter" } );

            // Generate a data table and bind the series to it. 
            series.DataSource = this.CreateChartData( );
            // Specify data members to bind the series. 
            series.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            series.ArgumentDataMember = "Type";
            series.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series.ValueDataMembers.AddRange( new string[ ] { "Counter" } );

            // Set some properties to get a nice-looking chart. 
            ((DevExpress.XtraCharts.SideBySideBarSeriesView) series.View).ColorEach = true;
            //((DevExpress.XtraCharts.XYDiagram) chart.Diagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False;
            //chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Specify the template's series view. 
            //            this.chartControl1.SeriesTemplate.View = new DevExpress.XtraCharts.Bar( );

            // Specify the template's name prefix. 
            //this.chartControl1.SeriesNameTemplate.BeginText = "Month: ";

            // Dock the chart into its parent, and add it to the current form. 
            //this.chartControl1.Dock = DockStyle.Fill;
         }
      }
      private DataTable CreateChartData()
      {
         DataTable table = new DataTable( "MetadataItem" );
         // Add three columns to the table. 
         table.Columns.Add( "Type", typeof( String ) );
         table.Columns.Add( "Counter", typeof( Int32 ) );
         // Add data rows to the table. 
         table.Rows.Add( new object[ ] { "Database", 10 } );
         table.Rows.Add( new object[ ] { "Schema", 10 } );
         table.Rows.Add( new object[ ] { "Table", 10 } );
         table.Rows.Add( new object[ ] { "View", 10 } );
         table.Rows.Add( new object[ ] { "Procedure", 10 } );
         table.Rows.Add( new object[ ] { "Synonym", 10 } );
         table.Rows.Add( new object[ ] { "Field", 10 } );
         table.Rows.Add( new object[ ] { "ForeignKey", 10 } );
         table.Rows.Add( new object[ ] { "Root", 10 } );
         table.Rows.Add( new object[ ] { "Server", 10 } );
         table.Rows.Add( new object[ ] { "Package", 10 } );
         table.Rows.Add( new object[ ] { "Namespaces", 10 } );
         table.Rows.Add( new object[ ] { "ObjectMetadata", 10 } );
         table.Rows.Add( new object[ ] { "Objects", 10 } );
         table.Rows.Add( new object[ ] { "Aggregate", 10 } );
         table.Rows.Add( new object[ ] { "Parameter", 10 } );
         table.Rows.Add( new object[ ] { "UserQuery", 10 } );
         table.Rows.Add( new object[ ] { "UserField", 10 } );
         table.Rows.Add( new object[ ] { "All", 10 } );
         table.Rows.Add( new object[ ] { "Others", 10 } );
         //
         return table;
      }
   }
}
