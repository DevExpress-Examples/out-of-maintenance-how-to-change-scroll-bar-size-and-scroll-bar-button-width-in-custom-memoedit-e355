Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports DevExpress.XtraEditors

Namespace WindowsApplication1
	Public Class MyMemoEdit
		Inherits MemoEdit
		Shared Sub New()
			RepositoryItemMyMemoEdit.RegisterMyMemoEdit()
		End Sub

		Public Sub New()
			MyBase.New()
			scrollHelper = New MyScrollBarAPIHelper()
			scrollHelper.Init(MaskBox, Me)
			AddHandler scrollHelper.ScrollMouseLeave, AddressOf OnScroll_MouseLeave
			scrollHelper.LookAndFeel = LookAndFeel

			AddHandler Properties.Assigned, AddressOf OnPropertiesAssigned
		End Sub

		Public ReadOnly Property HScrollVisible() As Boolean
			Get
				Return ((Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both) OrElse (Properties.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal)) AndAlso ((Not Properties.WordWrap))
			End Get
		End Property

		Public ReadOnly Property VScrollVisible() As Boolean
			Get
				Return (Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both) OrElse (Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical)
			End Get
		End Property

		Protected Shadows ReadOnly Property ScrollHelperP() As MyScrollBarAPIHelper
			Get
				Return TryCast(scrollHelper, MyScrollBarAPIHelper)
			End Get
		End Property

		Public Overridable Sub UpdateScrollBars()
			If ScrollHelperP IsNot Nothing Then
				ScrollHelperP.SetScrollBarsWidth(Properties.ScrollWidth)
				ScrollHelperP.SetScrollBarsButtonWidth(Properties.ScrollButtonWidth)
				Refresh()
			End If
		End Sub

		Private Sub OnScroll_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
			CheckMouseHere()
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemMyMemoEdit.MyMemoEditName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemMyMemoEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemMyMemoEdit)
			End Get
		End Property

		Protected Overridable Sub OnPropertiesAssigned(ByVal sender As Object, ByVal e As EventArgs)
			UpdateScrollBars()
		End Sub

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				RemoveHandler Properties.Assigned, AddressOf OnPropertiesAssigned
			End If
			MyBase.Dispose(disposing)
		End Sub

	End Class
End Namespace
