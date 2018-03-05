namespace ChartControlTest
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if( disposing && (components != null) )
         {
            components.Dispose( );
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
         DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
         DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("Alex", new object[] {
            ((object)(10D))});
         DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("Mello", new object[] {
            ((object)(30D))});
         DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("Occulate", new object[] {
            ((object)(20D))});
         this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
         ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
         this.SuspendLayout();
         // 
         // chartControl1
         // 
         xyDiagram1.AxisX.GridLines.MinorVisible = true;
         xyDiagram1.AxisX.GridLines.Visible = true;
         xyDiagram1.AxisX.MinorCount = 1;
         xyDiagram1.AxisX.ScaleBreakOptions.Style = DevExpress.XtraCharts.ScaleBreakStyle.Straight;
         xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
         xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
         xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
         xyDiagram1.Rotated = true;
         this.chartControl1.Diagram = xyDiagram1;
         this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
         this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
         this.chartControl1.Legend.Name = "Default Legend";
         this.chartControl1.Location = new System.Drawing.Point(0, 0);
         this.chartControl1.Name = "chartControl1";
         series1.Name = "Series 1";
         series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2,
            seriesPoint3});
         this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
         this.chartControl1.Size = new System.Drawing.Size(853, 659);
         this.chartControl1.TabIndex = 0;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(853, 659);
         this.Controls.Add(this.chartControl1);
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraCharts.ChartControl chartControl1;
   }
}

