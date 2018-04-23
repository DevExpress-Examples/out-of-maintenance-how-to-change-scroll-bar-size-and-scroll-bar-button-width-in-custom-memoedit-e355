Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors.ViewInfo

Namespace WindowsApplication1
	Public Class MyMemoEditHScrollBar
		Inherits DevExpress.XtraEditors.HScrollBar
		Public Sub New()
			MyBase.New()
		End Sub

		Protected Overrides Function CreateScrollBarPainter() As ScrollBarPainterBase
			If LookAndFeel.ActiveStyle = ActiveLookAndFeelStyle.Skin Then
				Return New MyScrollBarPainter(LookAndFeel.ActiveLookAndFeel)
			Else
				Return MyBase.CreateScrollBarPainter()
			End If
		End Function

		Protected Overrides Function CreateScrollBarViewInfo() As ScrollBarViewInfo
			Return New MyMemoEditScrollBarViewInfo(Me)
		End Function

		Public Shadows ReadOnly Property ViewInfo() As MyMemoEditScrollBarViewInfo
			Get
				Return TryCast(MyBase.ViewInfo, MyMemoEditScrollBarViewInfo)
			End Get
		End Property
	End Class
End Namespace
