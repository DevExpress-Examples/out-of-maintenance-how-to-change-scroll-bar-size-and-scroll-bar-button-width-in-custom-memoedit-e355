Imports Microsoft.VisualBasic
Imports System
Namespace WindowsApplication1
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim superToolTip1 As New DevExpress.Utils.SuperToolTip()
			Dim toolTipTitleItem1 As New DevExpress.Utils.ToolTipTitleItem()
			Dim superToolTip2 As New DevExpress.Utils.SuperToolTip()
			Dim toolTipTitleItem2 As New DevExpress.Utils.ToolTipTitleItem()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.gridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.repositoryItemMyMemoEdit1 = New WindowsApplication1.RepositoryItemMyMemoEdit()
			Me.myMemoEdit1 = New WindowsApplication1.MyMemoEdit()
			Me.trackBarControl1 = New DevExpress.XtraEditors.TrackBarControl()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			Me.trackBarControl2 = New DevExpress.XtraEditors.TrackBarControl()
			Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemMyMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.myMemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.trackBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.trackBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.trackBarControl2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.trackBarControl2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Location = New System.Drawing.Point(12, 12)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemMyMemoEdit1})
			Me.gridControl1.Size = New System.Drawing.Size(414, 271)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.gridColumn1})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			Me.gridView1.RowHeight = 100
			' 
			' gridColumn1
			' 
			Me.gridColumn1.Caption = "Text"
			Me.gridColumn1.ColumnEdit = Me.repositoryItemMyMemoEdit1
			Me.gridColumn1.FieldName = "Text"
			Me.gridColumn1.Name = "gridColumn1"
			Me.gridColumn1.Visible = True
			Me.gridColumn1.VisibleIndex = 0
			' 
			' repositoryItemMyMemoEdit1
			' 
			Me.repositoryItemMyMemoEdit1.Name = "repositoryItemMyMemoEdit1"
			Me.repositoryItemMyMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.repositoryItemMyMemoEdit1.WordWrap = False
			' 
			' myMemoEdit1
			' 
			Me.myMemoEdit1.Location = New System.Drawing.Point(12, 289)
			Me.myMemoEdit1.Name = "myMemoEdit1"
			Me.myMemoEdit1.Size = New System.Drawing.Size(414, 100)
			Me.myMemoEdit1.TabIndex = 1
'			Me.myMemoEdit1.EditValueChanged += New System.EventHandler(Me.myMemoEdit1_EditValueChanged_1);
			' 
			' trackBarControl1
			' 
			Me.trackBarControl1.EditValue = 17
			Me.trackBarControl1.Location = New System.Drawing.Point(12, 414)
			Me.trackBarControl1.Name = "trackBarControl1"
			Me.trackBarControl1.Properties.LargeChange = 16
			Me.trackBarControl1.Properties.Maximum = 40
			Me.trackBarControl1.Properties.Minimum = 10
			Me.trackBarControl1.Properties.ShowValueToolTip = True
			Me.trackBarControl1.Properties.TickFrequency = 10
			Me.trackBarControl1.Size = New System.Drawing.Size(194, 45)
			toolTipTitleItem1.Text = Constants.vbCrLf
			superToolTip1.Items.Add(toolTipTitleItem1)
			Me.trackBarControl1.SuperTip = superToolTip1
			Me.trackBarControl1.TabIndex = 2
			Me.trackBarControl1.Value = 17
'			Me.trackBarControl1.EditValueChanged += New System.EventHandler(Me.trackBarControl1_EditValueChanged);
			' 
			' labelControl1
			' 
			Me.labelControl1.Location = New System.Drawing.Point(40, 395)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(138, 13)
			Me.labelControl1.TabIndex = 3
			Me.labelControl1.Text = "MyMemoEdit ScrollBars width"
			' 
			' trackBarControl2
			' 
			Me.trackBarControl2.EditValue = 17
			Me.trackBarControl2.Location = New System.Drawing.Point(233, 414)
			Me.trackBarControl2.Name = "trackBarControl2"
			Me.trackBarControl2.Properties.LargeChange = 16
			Me.trackBarControl2.Properties.Maximum = 40
			Me.trackBarControl2.Properties.Minimum = 10
			Me.trackBarControl2.Properties.ShowValueToolTip = True
			Me.trackBarControl2.Properties.TickFrequency = 10
			Me.trackBarControl2.Size = New System.Drawing.Size(194, 45)
			toolTipTitleItem2.Text = Constants.vbCrLf
			superToolTip2.Items.Add(toolTipTitleItem2)
			Me.trackBarControl2.SuperTip = superToolTip2
			Me.trackBarControl2.TabIndex = 2
			Me.trackBarControl2.Value = 17
'			Me.trackBarControl2.EditValueChanged += New System.EventHandler(Me.trackBarControl2_EditValueChanged);
			' 
			' labelControl2
			' 
			Me.labelControl2.Location = New System.Drawing.Point(241, 395)
			Me.labelControl2.Name = "labelControl2"
			Me.labelControl2.Size = New System.Drawing.Size(178, 13)
			Me.labelControl2.TabIndex = 3
			Me.labelControl2.Text = "MyMemoEdit ScrollBars Buttons width"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(439, 456)
			Me.Controls.Add(Me.labelControl2)
			Me.Controls.Add(Me.labelControl1)
			Me.Controls.Add(Me.trackBarControl2)
			Me.Controls.Add(Me.trackBarControl1)
			Me.Controls.Add(Me.myMemoEdit1)
			Me.Controls.Add(Me.gridControl1)
			Me.LookAndFeel.SkinName = "Lilian"
			Me.LookAndFeel.UseDefaultLookAndFeel = False
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemMyMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.myMemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.trackBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.trackBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.trackBarControl2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.trackBarControl2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private gridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
		Private repositoryItemMyMemoEdit1 As RepositoryItemMyMemoEdit
		Private WithEvents myMemoEdit1 As MyMemoEdit
		Private WithEvents trackBarControl1 As DevExpress.XtraEditors.TrackBarControl
		Private labelControl1 As DevExpress.XtraEditors.LabelControl
		Private WithEvents trackBarControl2 As DevExpress.XtraEditors.TrackBarControl
		Private labelControl2 As DevExpress.XtraEditors.LabelControl


	End Class
End Namespace

