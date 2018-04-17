namespace DataPhilosophiae.Control
{
   partial class SysCSXtraUserControl
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysCSXtraUserControl));
         this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
         this.bar1 = new DevExpress.XtraBars.Bar();
         this.refreshBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.showAllFieldsBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.showPreviewBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.showFindPanelBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.showAutoFilterRowBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.showFilterPanelModeBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.useEmbeddedNavigatorBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.testConnectionBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.gridControl1 = new DevExpress.XtraGrid.GridControl();
         this.sysConnectionStringBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colIsSys = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colProviderName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colConnectionString = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.sysConnectionStringBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
         this.SuspendLayout();
         // 
         // barManager1
         // 
         this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
         this.barManager1.DockControls.Add(this.barDockControlTop);
         this.barManager1.DockControls.Add(this.barDockControlBottom);
         this.barManager1.DockControls.Add(this.barDockControlLeft);
         this.barManager1.DockControls.Add(this.barDockControlRight);
         this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
         this.barManager1.Form = this;
         this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.refreshBarButtonItem,
            this.showAllFieldsBarButtonItem,
            this.showPreviewBarButtonItem,
            this.showFindPanelBarButtonItem,
            this.showAutoFilterRowBarButtonItem,
            this.showFilterPanelModeBarButtonItem,
            this.useEmbeddedNavigatorBarButtonItem,
            this.testConnectionBarButtonItem});
         this.barManager1.MaxItemId = 8;
         // 
         // bar1
         // 
         this.bar1.BarName = "Tools";
         this.bar1.DockCol = 0;
         this.bar1.DockRow = 0;
         this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
         this.bar1.FloatLocation = new System.Drawing.Point(602, 234);
         this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.refreshBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.showAllFieldsBarButtonItem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.showPreviewBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.showFindPanelBarButtonItem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.showAutoFilterRowBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.showFilterPanelModeBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.useEmbeddedNavigatorBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.testConnectionBarButtonItem, true)});
         this.bar1.OptionsBar.DisableClose = true;
         this.bar1.OptionsBar.DrawBorder = false;
         this.bar1.OptionsBar.DrawDragBorder = false;
         this.bar1.OptionsBar.UseWholeRow = true;
         this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
         this.bar1.Text = "Tools";
         // 
         // refreshBarButtonItem
         // 
         this.refreshBarButtonItem.Caption = "Refresh";
         this.refreshBarButtonItem.Id = 0;
         this.refreshBarButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("refreshBarButtonItem.ImageOptions.SvgImage")));
         this.refreshBarButtonItem.Name = "refreshBarButtonItem";
         this.refreshBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.refreshBarButtonItem_ItemClick);
         // 
         // showAllFieldsBarButtonItem
         // 
         this.showAllFieldsBarButtonItem.Caption = "Show All Fields";
         this.showAllFieldsBarButtonItem.Id = 1;
         this.showAllFieldsBarButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("showAllFieldsBarButtonItem.ImageOptions.SvgImage")));
         this.showAllFieldsBarButtonItem.Name = "showAllFieldsBarButtonItem";
         this.showAllFieldsBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showAllFieldsBarButtonItem_ItemClick);
         // 
         // showPreviewBarButtonItem
         // 
         this.showPreviewBarButtonItem.Caption = "Show Preview";
         this.showPreviewBarButtonItem.Id = 2;
         this.showPreviewBarButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("showPreviewBarButtonItem.ImageOptions.SvgImage")));
         this.showPreviewBarButtonItem.Name = "showPreviewBarButtonItem";
         this.showPreviewBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showPreviewBarButtonItem_ItemClick);
         // 
         // showFindPanelBarButtonItem
         // 
         this.showFindPanelBarButtonItem.Caption = "Show Find Panel";
         this.showFindPanelBarButtonItem.Id = 3;
         this.showFindPanelBarButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("showFindPanelBarButtonItem.ImageOptions.SvgImage")));
         this.showFindPanelBarButtonItem.Name = "showFindPanelBarButtonItem";
         this.showFindPanelBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.findPanelBarButtonItem_ItemClick);
         // 
         // showAutoFilterRowBarButtonItem
         // 
         this.showAutoFilterRowBarButtonItem.Caption = "Show Auto Filter Row";
         this.showAutoFilterRowBarButtonItem.Id = 4;
         this.showAutoFilterRowBarButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("showAutoFilterRowBarButtonItem.ImageOptions.SvgImage")));
         this.showAutoFilterRowBarButtonItem.Name = "showAutoFilterRowBarButtonItem";
         this.showAutoFilterRowBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showAutoFilterRowBarButtonItem_ItemClick);
         // 
         // showFilterPanelModeBarButtonItem
         // 
         this.showFilterPanelModeBarButtonItem.Caption = "Show Filter Panel";
         this.showFilterPanelModeBarButtonItem.Id = 5;
         this.showFilterPanelModeBarButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("showFilterPanelModeBarButtonItem.ImageOptions.SvgImage")));
         this.showFilterPanelModeBarButtonItem.Name = "showFilterPanelModeBarButtonItem";
         this.showFilterPanelModeBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showFilterPanelModeBarButtonItem_ItemClick);
         // 
         // useEmbeddedNavigatorBarButtonItem
         // 
         this.useEmbeddedNavigatorBarButtonItem.Caption = "Show Embedded Navigator";
         this.useEmbeddedNavigatorBarButtonItem.Id = 6;
         this.useEmbeddedNavigatorBarButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("useEmbeddedNavigatorBarButtonItem.ImageOptions.SvgImage")));
         this.useEmbeddedNavigatorBarButtonItem.Name = "useEmbeddedNavigatorBarButtonItem";
         this.useEmbeddedNavigatorBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.useEmbeddedNavigatorBarButtonItem_ItemClick);
         // 
         // testConnectionBarButtonItem
         // 
         this.testConnectionBarButtonItem.Caption = "Test Connection";
         this.testConnectionBarButtonItem.Id = 7;
         this.testConnectionBarButtonItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("testConnectionBarButtonItem.ImageOptions.SvgImage")));
         this.testConnectionBarButtonItem.Name = "testConnectionBarButtonItem";
         this.testConnectionBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.testConnectionBarButtonItem_ItemClick);
         // 
         // standaloneBarDockControl1
         // 
         this.standaloneBarDockControl1.CausesValidation = false;
         this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
         this.standaloneBarDockControl1.Manager = this.barManager1;
         this.standaloneBarDockControl1.Margin = new System.Windows.Forms.Padding(2);
         this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
         this.standaloneBarDockControl1.Size = new System.Drawing.Size(537, 29);
         this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Manager = this.barManager1;
         this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
         this.barDockControlTop.Size = new System.Drawing.Size(537, 0);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 483);
         this.barDockControlBottom.Manager = this.barManager1;
         this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
         this.barDockControlBottom.Size = new System.Drawing.Size(537, 0);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
         this.barDockControlLeft.Manager = this.barManager1;
         this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 483);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(537, 0);
         this.barDockControlRight.Manager = this.barManager1;
         this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
         this.barDockControlRight.Size = new System.Drawing.Size(0, 483);
         // 
         // gridControl1
         // 
         this.gridControl1.DataSource = this.sysConnectionStringBindingSource;
         this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
         this.gridControl1.Location = new System.Drawing.Point(0, 29);
         this.gridControl1.MainView = this.gridView1;
         this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
         this.gridControl1.MenuManager = this.barManager1;
         this.gridControl1.Name = "gridControl1";
         this.gridControl1.Size = new System.Drawing.Size(537, 454);
         this.gridControl1.TabIndex = 5;
         this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
         // 
         // sysConnectionStringBindingSource
         // 
         this.sysConnectionStringBindingSource.DataSource = typeof(DataPhilosophiae.Model.SysConnectionString);
         // 
         // gridView1
         // 
         this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colIsSys,
            this.colProviderName,
            this.colConnectionString});
         this.gridView1.GridControl = this.gridControl1;
         this.gridView1.Name = "gridView1";
         this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
         this.gridView1.OptionsBehavior.ReadOnly = true;
         this.gridView1.OptionsCustomization.AllowRowSizing = true;
         this.gridView1.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
         this.gridView1.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gridView1_FocusedRowObjectChanged);
         // 
         // colName
         // 
         this.colName.FieldName = "Name";
         this.colName.Name = "colName";
         this.colName.Visible = true;
         this.colName.VisibleIndex = 0;
         // 
         // colIsSys
         // 
         this.colIsSys.FieldName = "IsSys";
         this.colIsSys.Name = "colIsSys";
         // 
         // colProviderName
         // 
         this.colProviderName.FieldName = "ProviderName";
         this.colProviderName.Name = "colProviderName";
         // 
         // colConnectionString
         // 
         this.colConnectionString.FieldName = "ConnectionString";
         this.colConnectionString.Name = "colConnectionString";
         // 
         // gridView2
         // 
         this.gridView2.GridControl = this.gridControl1;
         this.gridView2.Name = "gridView2";
         // 
         // SysCSXtraUserControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.gridControl1);
         this.Controls.Add(this.standaloneBarDockControl1);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Margin = new System.Windows.Forms.Padding(2);
         this.Name = "SysCSXtraUserControl";
         this.Size = new System.Drawing.Size(537, 483);
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.sysConnectionStringBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.BarManager barManager1;
      private DevExpress.XtraBars.Bar bar1;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
      private DevExpress.XtraBars.BarButtonItem refreshBarButtonItem;
      private DevExpress.XtraGrid.GridControl gridControl1;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
      private System.Windows.Forms.BindingSource sysConnectionStringBindingSource;
      private DevExpress.XtraGrid.Columns.GridColumn colIsSys;
      private DevExpress.XtraGrid.Columns.GridColumn colName;
      private DevExpress.XtraGrid.Columns.GridColumn colProviderName;
      private DevExpress.XtraGrid.Columns.GridColumn colConnectionString;
      private DevExpress.XtraBars.BarButtonItem showAllFieldsBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem showPreviewBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem showFindPanelBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem showAutoFilterRowBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem showFilterPanelModeBarButtonItem;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
      private DevExpress.XtraBars.BarButtonItem useEmbeddedNavigatorBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem testConnectionBarButtonItem;
   }
}
