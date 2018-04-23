Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.Skins

Namespace WindowsApplication1
	Public Class MyScrollBarPainter
		Inherits SkinScrollBarPainter
		Public Sub New(ByVal Skin As ISkinProvider)
			MyBase.New(Skin)
		End Sub

		Public Overrides ReadOnly Property ThumbMinWidth() As Integer
			Get
				Return 8
			End Get
		End Property
	End Class
End Namespace
