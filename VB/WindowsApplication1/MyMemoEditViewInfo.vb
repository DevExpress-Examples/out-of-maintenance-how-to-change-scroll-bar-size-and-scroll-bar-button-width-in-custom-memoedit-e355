Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo

Namespace WindowsApplication1
	Public Class MyMemoEditViewInfo
		Inherits MemoEditViewInfo
		Private Sub New(ByVal item As RepositoryItem)
			MyBase.New(item)
		End Sub

		Public Shadows ReadOnly Property Item() As RepositoryItemMyMemoEdit
			Get
				Return TryCast(MyBase.Item, RepositoryItemMyMemoEdit)
			End Get
		End Property
		Public Shadows ReadOnly Property OwnerControl() As MyMemoEdit
			Get
				Return TryCast(MyBase.OwnerControl, MyMemoEdit)
			End Get
		End Property

		Protected Overrides Sub CalcContentRect(ByVal bounds As Rectangle)
			MyBase.CalcContentRect(bounds)
			If OwnerControl IsNot Nothing Then
				If OwnerControl.VScrollVisible Then
					fContentRect.Width = ContentRect.Width - Item.ScrollWidth + SystemInformation.VerticalScrollBarWidth + 1
				End If
				If OwnerControl.HScrollVisible Then
					fContentRect.Height = ContentRect.Height - Item.ScrollWidth + SystemInformation.VerticalScrollBarWidth + 1
				End If
				fMaskBoxRect = ContentRect
			End If
		End Sub
	End Class

End Namespace
