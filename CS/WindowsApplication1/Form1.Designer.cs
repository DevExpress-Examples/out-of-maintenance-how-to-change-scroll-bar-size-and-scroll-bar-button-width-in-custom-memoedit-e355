namespace WindowsApplication1
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMyMemoEdit1 = new WindowsApplication1.RepositoryItemMyMemoEdit();
            this.myMemoEdit1 = new WindowsApplication1.MyMemoEdit();
            this.trackBarControl1 = new DevExpress.XtraEditors.TrackBarControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.trackBarControl2 = new DevExpress.XtraEditors.TrackBarControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMyMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMyMemoEdit1});
            this.gridControl1.Size = new System.Drawing.Size(414, 271);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowHeight = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Text";
            this.gridColumn1.ColumnEdit = this.repositoryItemMyMemoEdit1;
            this.gridColumn1.FieldName = "Text";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // repositoryItemMyMemoEdit1
            // 
            this.repositoryItemMyMemoEdit1.Name = "repositoryItemMyMemoEdit1";
            this.repositoryItemMyMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.repositoryItemMyMemoEdit1.WordWrap = false;
            // 
            // myMemoEdit1
            // 
            this.myMemoEdit1.Location = new System.Drawing.Point(12, 289);
            this.myMemoEdit1.Name = "myMemoEdit1";
            this.myMemoEdit1.Size = new System.Drawing.Size(414, 100);
            this.myMemoEdit1.TabIndex = 1;
            this.myMemoEdit1.EditValueChanged += new System.EventHandler(this.myMemoEdit1_EditValueChanged_1);
            // 
            // trackBarControl1
            // 
            this.trackBarControl1.EditValue = 17;
            this.trackBarControl1.Location = new System.Drawing.Point(12, 414);
            this.trackBarControl1.Name = "trackBarControl1";
            this.trackBarControl1.Properties.LargeChange = 16;
            this.trackBarControl1.Properties.Maximum = 40;
            this.trackBarControl1.Properties.Minimum = 10;
            this.trackBarControl1.Properties.ShowValueToolTip = true;
            this.trackBarControl1.Properties.TickFrequency = 10;
            this.trackBarControl1.Size = new System.Drawing.Size(194, 45);
            toolTipTitleItem1.Text = "\r\n";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.trackBarControl1.SuperTip = superToolTip1;
            this.trackBarControl1.TabIndex = 2;
            this.trackBarControl1.Value = 17;
            this.trackBarControl1.EditValueChanged += new System.EventHandler(this.trackBarControl1_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(40, 395);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(138, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "MyMemoEdit ScrollBars width";
            // 
            // trackBarControl2
            // 
            this.trackBarControl2.EditValue = 17;
            this.trackBarControl2.Location = new System.Drawing.Point(233, 414);
            this.trackBarControl2.Name = "trackBarControl2";
            this.trackBarControl2.Properties.LargeChange = 16;
            this.trackBarControl2.Properties.Maximum = 40;
            this.trackBarControl2.Properties.Minimum = 10;
            this.trackBarControl2.Properties.ShowValueToolTip = true;
            this.trackBarControl2.Properties.TickFrequency = 10;
            this.trackBarControl2.Size = new System.Drawing.Size(194, 45);
            toolTipTitleItem2.Text = "\r\n";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.trackBarControl2.SuperTip = superToolTip2;
            this.trackBarControl2.TabIndex = 2;
            this.trackBarControl2.Value = 17;
            this.trackBarControl2.EditValueChanged += new System.EventHandler(this.trackBarControl2_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(241, 395);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(178, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "MyMemoEdit ScrollBars Buttons width";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 456);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.trackBarControl2);
            this.Controls.Add(this.trackBarControl1);
            this.Controls.Add(this.myMemoEdit1);
            this.Controls.Add(this.gridControl1);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMyMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private RepositoryItemMyMemoEdit repositoryItemMyMemoEdit1;
        private MyMemoEdit myMemoEdit1;
        private DevExpress.XtraEditors.TrackBarControl trackBarControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TrackBarControl trackBarControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;


    }
}

