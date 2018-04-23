Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits XtraForm
		Private DT As DataTable

		Public Sub New()
			InitializeComponent()

			DT = New DataTable()
			DT.Columns.Add("Text", GetType(String))
			DT.Rows.Add("Text")
			DT.Rows.Add("Text")

			gridControl1.DataSource = DT

			myMemoEdit1.DataBindings.Add("EditValue",DT, "Text", True, DataSourceUpdateMode.OnPropertyChanged)

		End Sub

		Private Sub trackBarControl1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles trackBarControl1.EditValueChanged
			myMemoEdit1.Properties.ScrollWidth = trackBarControl1.Value
			repositoryItemMyMemoEdit1.ScrollWidth = trackBarControl1.Value
		End Sub

		Private Sub trackBarControl2_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles trackBarControl2.EditValueChanged
			myMemoEdit1.Properties.ScrollButtonWidth = trackBarControl2.Value
			repositoryItemMyMemoEdit1.ScrollButtonWidth = trackBarControl2.Value
		End Sub

		Private Sub myMemoEdit1_EditValueChanged_1(ByVal sender As Object, ByVal e As EventArgs) Handles myMemoEdit1.EditValueChanged
			Dim Manager As BindingManagerBase = BindingContext(DT)
			Manager.EndCurrentEdit()
		End Sub
	End Class
End Namespace
