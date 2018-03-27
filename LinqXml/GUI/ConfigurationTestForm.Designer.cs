namespace LinqXml
{
   partial class ConfigurationTestForm
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
         this.components = new System.ComponentModel.Container();
         this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
         this.bar1 = new DevExpress.XtraBars.Bar();
         this.bar2 = new DevExpress.XtraBars.Bar();
         this.newBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.openBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.saveBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.saveAsBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.closeBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.setWorkingDirectoryBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.addAppCSBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.cloneAppCSBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.delAppCSBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.addDataStoreBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.cloneDSBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.delDataStoreBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.expandAllBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.expandNodeBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.expandChildrenBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.collapseAllBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.collapsedNodeBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
         this.bar3 = new DevExpress.XtraBars.Bar();
         this.labelStatusBarStaticItem = new DevExpress.XtraBars.BarStaticItem();
         this.objnmStatusBarStaticItem = new DevExpress.XtraBars.BarStaticItem();
         this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
         this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
         this.configurationView1 = new LinqXml.Control.ConfigurationView();
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
         this.SuspendLayout();
         // 
         // barManager1
         // 
         this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
         this.barManager1.DockControls.Add(this.barDockControlTop);
         this.barManager1.DockControls.Add(this.barDockControlBottom);
         this.barManager1.DockControls.Add(this.barDockControlLeft);
         this.barManager1.DockControls.Add(this.barDockControlRight);
         this.barManager1.Form = this;
         this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.openBarButtonItem,
            this.saveBarButtonItem,
            this.saveAsBarButtonItem,
            this.closeBarButtonItem,
            this.setWorkingDirectoryBarButtonItem,
            this.labelStatusBarStaticItem,
            this.objnmStatusBarStaticItem,
            this.addDataStoreBarButtonItem,
            this.addAppCSBarButtonItem,
            this.delDataStoreBarButtonItem,
            this.delAppCSBarButtonItem,
            this.newBarButtonItem,
            this.cloneDSBarButtonItem,
            this.cloneAppCSBarButtonItem,
            this.collapseAllBarButtonItem,
            this.expandAllBarButtonItem,
            this.expandNodeBarButtonItem,
            this.expandChildrenBarButtonItem,
            this.collapsedNodeBarButtonItem});
         this.barManager1.MainMenu = this.bar2;
         this.barManager1.MaxItemId = 20;
         this.barManager1.StatusBar = this.bar3;
         // 
         // bar1
         // 
         this.bar1.BarName = "Tools";
         this.bar1.DockCol = 0;
         this.bar1.DockRow = 1;
         this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.bar1.Text = "Tools";
         // 
         // bar2
         // 
         this.bar2.BarName = "Main menu";
         this.bar2.DockCol = 0;
         this.bar2.DockRow = 0;
         this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
         this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.newBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.openBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.saveBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.saveAsBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.closeBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.setWorkingDirectoryBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.addAppCSBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.cloneAppCSBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.delAppCSBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.addDataStoreBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.cloneDSBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.delDataStoreBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.expandAllBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.expandNodeBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.expandChildrenBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.collapseAllBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.collapsedNodeBarButtonItem)});
         this.bar2.OptionsBar.MultiLine = true;
         this.bar2.OptionsBar.UseWholeRow = true;
         this.bar2.Text = "Main menu";
         // 
         // newBarButtonItem
         // 
         this.newBarButtonItem.Caption = "New";
         this.newBarButtonItem.Enabled = false;
         this.newBarButtonItem.Id = 11;
         this.newBarButtonItem.Name = "newBarButtonItem";
         this.newBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.newBarButtonItem_ItemClick);
         // 
         // openBarButtonItem
         // 
         this.openBarButtonItem.Caption = "Open";
         this.openBarButtonItem.Enabled = false;
         this.openBarButtonItem.Id = 0;
         this.openBarButtonItem.Name = "openBarButtonItem";
         this.openBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.openBarButtonItem_ItemClick);
         // 
         // saveBarButtonItem
         // 
         this.saveBarButtonItem.Caption = "Save";
         this.saveBarButtonItem.Enabled = false;
         this.saveBarButtonItem.Id = 1;
         this.saveBarButtonItem.Name = "saveBarButtonItem";
         this.saveBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.saveBarButtonItem_ItemClick);
         // 
         // saveAsBarButtonItem
         // 
         this.saveAsBarButtonItem.Caption = "Save As";
         this.saveAsBarButtonItem.Enabled = false;
         this.saveAsBarButtonItem.Id = 2;
         this.saveAsBarButtonItem.Name = "saveAsBarButtonItem";
         this.saveAsBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.saveAsBarButtonItem_ItemClick);
         // 
         // closeBarButtonItem
         // 
         this.closeBarButtonItem.Caption = "Close";
         this.closeBarButtonItem.Enabled = false;
         this.closeBarButtonItem.Id = 3;
         this.closeBarButtonItem.Name = "closeBarButtonItem";
         this.closeBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.closeBarButtonItem_ItemClick);
         // 
         // setWorkingDirectoryBarButtonItem
         // 
         this.setWorkingDirectoryBarButtonItem.Caption = "Set Working Directory";
         this.setWorkingDirectoryBarButtonItem.Enabled = false;
         this.setWorkingDirectoryBarButtonItem.Id = 4;
         this.setWorkingDirectoryBarButtonItem.Name = "setWorkingDirectoryBarButtonItem";
         this.setWorkingDirectoryBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.setWorkingDirectoryBarButtonItem_ItemClick);
         // 
         // addAppCSBarButtonItem
         // 
         this.addAppCSBarButtonItem.Caption = "Add CS";
         this.addAppCSBarButtonItem.Enabled = false;
         this.addAppCSBarButtonItem.Id = 8;
         this.addAppCSBarButtonItem.Name = "addAppCSBarButtonItem";
         this.addAppCSBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addAppCSBarButtonItem_ItemClick);
         // 
         // cloneAppCSBarButtonItem
         // 
         this.cloneAppCSBarButtonItem.Caption = "Clone CS";
         this.cloneAppCSBarButtonItem.Enabled = false;
         this.cloneAppCSBarButtonItem.Id = 13;
         this.cloneAppCSBarButtonItem.Name = "cloneAppCSBarButtonItem";
         this.cloneAppCSBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cloneAppCSBarButtonItem_ItemClick);
         // 
         // delAppCSBarButtonItem
         // 
         this.delAppCSBarButtonItem.Caption = "Del CS";
         this.delAppCSBarButtonItem.Enabled = false;
         this.delAppCSBarButtonItem.Id = 10;
         this.delAppCSBarButtonItem.Name = "delAppCSBarButtonItem";
         this.delAppCSBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.delAppCsBarButtonItem_ItemClick);
         // 
         // addDataStoreBarButtonItem
         // 
         this.addDataStoreBarButtonItem.Caption = "Add DS";
         this.addDataStoreBarButtonItem.Enabled = false;
         this.addDataStoreBarButtonItem.Id = 7;
         this.addDataStoreBarButtonItem.Name = "addDataStoreBarButtonItem";
         this.addDataStoreBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addDataStoreBarButtonItem_ItemClick);
         // 
         // cloneDSBarButtonItem
         // 
         this.cloneDSBarButtonItem.Caption = "Clone DS";
         this.cloneDSBarButtonItem.Enabled = false;
         this.cloneDSBarButtonItem.Id = 12;
         this.cloneDSBarButtonItem.Name = "cloneDSBarButtonItem";
         this.cloneDSBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cloneDSBarButtonItem_ItemClick);
         // 
         // delDataStoreBarButtonItem
         // 
         this.delDataStoreBarButtonItem.Caption = "Del DS";
         this.delDataStoreBarButtonItem.Enabled = false;
         this.delDataStoreBarButtonItem.Id = 9;
         this.delDataStoreBarButtonItem.Name = "delDataStoreBarButtonItem";
         this.delDataStoreBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.delDataStoreBarButtonItem_ItemClick);
         // 
         // expandAllBarButtonItem
         // 
         this.expandAllBarButtonItem.Caption = "Expand All";
         this.expandAllBarButtonItem.Enabled = false;
         this.expandAllBarButtonItem.Id = 15;
         this.expandAllBarButtonItem.Name = "expandAllBarButtonItem";
         this.expandAllBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.expandAllBarButtonItem_ItemClick);
         // 
         // expandNodeBarButtonItem
         // 
         this.expandNodeBarButtonItem.Caption = "Expand Node";
         this.expandNodeBarButtonItem.Enabled = false;
         this.expandNodeBarButtonItem.Id = 16;
         this.expandNodeBarButtonItem.Name = "expandNodeBarButtonItem";
         this.expandNodeBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.expandNodeBarButtonItem_ItemClick);
         // 
         // expandChildrenBarButtonItem
         // 
         this.expandChildrenBarButtonItem.Caption = "Expand Children";
         this.expandChildrenBarButtonItem.Enabled = false;
         this.expandChildrenBarButtonItem.Id = 17;
         this.expandChildrenBarButtonItem.Name = "expandChildrenBarButtonItem";
         this.expandChildrenBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.expandChildrenBarButtonItem_ItemClick);
         // 
         // collapseAllBarButtonItem
         // 
         this.collapseAllBarButtonItem.Caption = "Collapse All";
         this.collapseAllBarButtonItem.Enabled = false;
         this.collapseAllBarButtonItem.Id = 14;
         this.collapseAllBarButtonItem.Name = "collapseAllBarButtonItem";
         this.collapseAllBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.collapseAllBarButtonItem_ItemClick);
         // 
         // collapsedNodeBarButtonItem
         // 
         this.collapsedNodeBarButtonItem.Caption = "Collapse Node";
         this.collapsedNodeBarButtonItem.Enabled = false;
         this.collapsedNodeBarButtonItem.Id = 18;
         this.collapsedNodeBarButtonItem.Name = "collapsedNodeBarButtonItem";
         this.collapsedNodeBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.collapsedNodeBarButtonItem_ItemClick);
         // 
         // bar3
         // 
         this.bar3.BarName = "Status bar";
         this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
         this.bar3.DockCol = 0;
         this.bar3.DockRow = 0;
         this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
         this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.labelStatusBarStaticItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.objnmStatusBarStaticItem)});
         this.bar3.OptionsBar.AllowQuickCustomization = false;
         this.bar3.OptionsBar.DrawDragBorder = false;
         this.bar3.OptionsBar.UseWholeRow = true;
         this.bar3.Text = "Status bar";
         // 
         // labelStatusBarStaticItem
         // 
         this.labelStatusBarStaticItem.Id = 5;
         this.labelStatusBarStaticItem.Name = "labelStatusBarStaticItem";
         // 
         // objnmStatusBarStaticItem
         // 
         this.objnmStatusBarStaticItem.Id = 6;
         this.objnmStatusBarStaticItem.Name = "objnmStatusBarStaticItem";
         // 
         // barDockControlTop
         // 
         this.barDockControlTop.CausesValidation = false;
         this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
         this.barDockControlTop.Manager = this.barManager1;
         this.barDockControlTop.Size = new System.Drawing.Size(755, 73);
         // 
         // barDockControlBottom
         // 
         this.barDockControlBottom.CausesValidation = false;
         this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.barDockControlBottom.Location = new System.Drawing.Point(0, 683);
         this.barDockControlBottom.Manager = this.barManager1;
         this.barDockControlBottom.Size = new System.Drawing.Size(755, 25);
         // 
         // barDockControlLeft
         // 
         this.barDockControlLeft.CausesValidation = false;
         this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.barDockControlLeft.Location = new System.Drawing.Point(0, 73);
         this.barDockControlLeft.Manager = this.barManager1;
         this.barDockControlLeft.Size = new System.Drawing.Size(0, 610);
         // 
         // barDockControlRight
         // 
         this.barDockControlRight.CausesValidation = false;
         this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.barDockControlRight.Location = new System.Drawing.Point(755, 73);
         this.barDockControlRight.Manager = this.barManager1;
         this.barDockControlRight.Size = new System.Drawing.Size(0, 610);
         // 
         // configurationView1
         // 
         this.configurationView1.DefaultFileName = "cfg.xml";
         this.configurationView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.configurationView1.Location = new System.Drawing.Point(0, 73);
         this.configurationView1.Name = "configurationView1";
         this.configurationView1.Size = new System.Drawing.Size(755, 610);
         this.configurationView1.TabIndex = 4;
         // 
         // ConfigurationTestForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(755, 708);
         this.Controls.Add(this.configurationView1);
         this.Controls.Add(this.barDockControlLeft);
         this.Controls.Add(this.barDockControlRight);
         this.Controls.Add(this.barDockControlBottom);
         this.Controls.Add(this.barDockControlTop);
         this.Name = "ConfigurationTestForm";
         this.Text = "ConfigurationTestForm";
         this.Load += new System.EventHandler(this.ConfigurationTestForm_Load);
         ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraBars.BarManager barManager1;
      private DevExpress.XtraBars.Bar bar1;
      private DevExpress.XtraBars.Bar bar2;
      private DevExpress.XtraBars.BarButtonItem openBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem saveBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem saveAsBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem closeBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem setWorkingDirectoryBarButtonItem;
      private DevExpress.XtraBars.Bar bar3;
      private DevExpress.XtraBars.BarDockControl barDockControlTop;
      private DevExpress.XtraBars.BarDockControl barDockControlBottom;
      private DevExpress.XtraBars.BarDockControl barDockControlLeft;
      private DevExpress.XtraBars.BarDockControl barDockControlRight;
      private DevExpress.XtraBars.BarStaticItem labelStatusBarStaticItem;
      private Control.ConfigurationView configurationView1;
      private DevExpress.XtraBars.BarStaticItem objnmStatusBarStaticItem;
      private DevExpress.XtraBars.BarButtonItem addDataStoreBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem addAppCSBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem delDataStoreBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem delAppCSBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem newBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem cloneAppCSBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem cloneDSBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem collapseAllBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem expandAllBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem expandNodeBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem expandChildrenBarButtonItem;
      private DevExpress.XtraBars.BarButtonItem collapsedNodeBarButtonItem;
   }
}
