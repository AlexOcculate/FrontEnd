namespace LinqXml.Control
{
   partial class ConfigurationView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationView));
         this.treeView = new DevExpress.XtraTreeList.TreeList();
         this.selectSvgImageCollection = new DevExpress.Utils.SvgImageCollection(this.components);
         this.stateSvgImageCollection = new DevExpress.Utils.SvgImageCollection(this.components);
         this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.treeView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.selectSvgImageCollection)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.stateSvgImageCollection)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
         this.SuspendLayout();
         // 
         // treeView
         // 
         this.treeView.DataSource = null;
         this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treeView.Location = new System.Drawing.Point(0, 0);
         this.treeView.Name = "treeView";
         this.treeView.SelectImageList = this.selectSvgImageCollection;
         this.treeView.Size = new System.Drawing.Size(511, 851);
         this.treeView.StateImageList = this.stateSvgImageCollection;
         this.treeView.TabIndex = 0;
         this.treeView.CustomDrawEmptyArea += new DevExpress.XtraTreeList.CustomDrawEmptyAreaEventHandler(this.treeView_CustomDrawEmptyArea);
         // 
         // selectSvgImageCollection
         // 
         this.selectSvgImageCollection.Add("fld_gray", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("selectSvgImageCollection.fld_gray"))));
         // 
         // stateSvgImageCollection
         // 
         this.stateSvgImageCollection.Add("db_red", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("stateSvgImageCollection.db_red"))));
         // 
         // ConfigurationView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.treeView);
         this.Name = "ConfigurationView";
         this.Size = new System.Drawing.Size(511, 851);
         ((System.ComponentModel.ISupportInitialize)(this.treeView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.selectSvgImageCollection)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.stateSvgImageCollection)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraTreeList.TreeList treeView;
      private DevExpress.Utils.SvgImageCollection stateSvgImageCollection;
      private DevExpress.Utils.SvgImageCollection selectSvgImageCollection;
      private DevExpress.Utils.SvgImageCollection svgImageCollection1;
   }
}
