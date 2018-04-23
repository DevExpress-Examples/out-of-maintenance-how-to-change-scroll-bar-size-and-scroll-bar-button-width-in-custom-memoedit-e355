Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo

Namespace WindowsApplication1
	Public Class MyMemoEditScrollBarViewInfo
		Inherits ScrollBarViewInfo
		Private fWidth As Integer

		Public Sub New(ByVal SB As IScrollBar)
			MyBase.New(SB)
			If ScrollBarType = ScrollBarType.Horizontal Then
				fWidth = SystemInformation.HorizontalScrollBarArrowWidth
			Else
				fWidth = SystemInformation.VerticalScrollBarArrowHeight
			End If
		End Sub

		Public Overrides ReadOnly Property ButtonWidth() As Integer
			Get
				If fWidth > ScrollBarWidth * 2 Then
					Return 0
				End If
				If fWidth > ScrollBarWidth / 2 Then
					fWidth = ScrollBarWidth / 2
				End If
				Return fWidth
			End Get
		End Property
		Public Sub SetButtonWidth(ByVal Width As Integer)
			If Width >= 0 Then
				fWidth = Width
				CalculateCore()
			End If
		End Sub
	End Class

End Namespace
