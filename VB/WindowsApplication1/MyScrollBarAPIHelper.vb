Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ScrollHelpers

Namespace WindowsApplication1
	<StructLayout(LayoutKind.Sequential)> _
	Friend Structure SCROLLBARINFO
		Public Const STATE_SYSTEM_INVISIBLE As UInteger = &H00008000, STATE_SYSTEM_OFFSCREEN As UInteger = &H00010000, STATE_SYSTEM_UNAVAILABLE As UInteger = &H00000001, OBJID_VSCROLL As UInteger = &HFFFFFFFBL, OBJID_HSCROLL As UInteger = &HFFFFFFFAL
		Private Const CCHILDREN_SCROLLBAR As Integer = 5
		Public cbSize As Int32
		Public rcScrollBar As GDIRect
		Public dxyLineButton As Int32
		Public xyThumbTop As Int32
		Public xyThumbBottom As Int32
		Public reserved As Int32
		Public rgstate0, rgstate1, rgstate2, rgstate3, rgstate4, rgstate5 As Int32
		Public Sub Init()
			Me.rcScrollBar = New GDIRect()
			Me.cbSize = Marshal.SizeOf(Me)
			Me.reserved = 0
			Me.xyThumbBottom = Me.reserved
			Me.xyThumbTop = Me.xyThumbBottom
			Me.dxyLineButton = Me.xyThumbTop
			Me.rgstate5 = 0
			Me.rgstate4 = Me.rgstate5
			Me.rgstate3 = Me.rgstate4
			Me.rgstate2 = Me.rgstate3
			Me.rgstate1 = Me.rgstate2
			Me.rgstate0 = Me.rgstate1
		End Sub
		<System.Runtime.InteropServices.DllImport("USER32.dll")> _
		Friend Shared Function GetScrollBarInfo(ByVal hwnd As IntPtr, ByVal idObject As UInteger, ByRef psbi As SCROLLBARINFO) As Boolean
		End Function
	End Structure
	<StructLayout(LayoutKind.Sequential)> _
	Friend Structure SCROLLINFO
		Public Const SIF_RANGE As Integer = &H0001, SIF_PAGE As Integer = &H0002, SIF_POS As Integer = &H0004, SIF_DISABLENOSCROLL As Integer = &H0008, SIF_TRACKPOS As Integer = &H0010, SIF_ALL As Integer = (SIF_RANGE Or SIF_PAGE Or SIF_POS Or SIF_TRACKPOS)
		Public Const SB_HORZ As Integer = 0, SB_VERT As Integer = 1
		Public cbSize, fMask, nMin, nMax, nPage, nPos, nTrackPos As Int32
		Public Sub Init()
			Me.cbSize = Marshal.SizeOf(Me)
			Me.nTrackPos = 0
			Me.nPos = Me.nTrackPos
			Me.nPage = Me.nPos
			Me.nMax = Me.nPage
			Me.nMin = Me.nMax
			Me.fMask = SIF_ALL
		End Sub
		<System.Runtime.InteropServices.DllImport("USER32.dll")> _
		Friend Shared Function SetScrollInfo(ByVal handle As IntPtr, ByVal fnBar As Integer, ByRef scrollInfo As SCROLLINFO, ByVal redraw As Boolean) As Integer
		End Function
		<System.Runtime.InteropServices.DllImport("USER32.dll")> _
		Friend Shared Function GetScrollInfo(ByVal handle As IntPtr, ByVal fnBar As Integer, ByRef scrollInfo As SCROLLINFO) As Boolean
		End Function
	End Structure
	<StructLayout(LayoutKind.Sequential)> _
	Friend Structure GDIRect
		Public left, top, right, bottom As Integer
		Public Sub New(ByVal l As Integer, ByVal t As Integer, ByVal r As Integer, ByVal b As Integer)
			left = l
			top = t
			right = r
			bottom = b
		End Sub
		Public Sub New(ByVal r As Rectangle)
			left = r.Left
			top = r.Top
			right = r.Right
			bottom = r.Bottom
		End Sub
		Public Function ToRectangle() As Rectangle
			Return New Rectangle(left, top, right - left, bottom - top)
		End Function
	End Structure

	Public Class MyScrollBarAPIHelper
		Inherits ScrollBarEditorsAPIHelper
		Private fWidth As Integer

		Public Sub New()
			Dim SHelperType As Type = GetType(DevExpress.XtraEditors.ScrollHelpers.ScrollBarAPIHelper)

			Dim fHScroll As FieldInfo = SHelperType.GetField("hscroll", BindingFlags.Instance Or BindingFlags.NonPublic)
			Dim fVScroll As FieldInfo = SHelperType.GetField("vscroll", BindingFlags.Instance Or BindingFlags.NonPublic)

			Dim hscroll As ScrollBarBase
			Dim vscroll As ScrollBarBase

			hscroll = New MyMemoEditHScrollBar()
			vscroll = New MyMemoEditVScrollBar()
			AddHandler hscroll.Scroll, AddressOf OnHScroll_Scroll
			AddHandler vscroll.Scroll, AddressOf OnVScroll_Scroll
			AddHandler hscroll.MouseLeave, AddressOf OnScroll_Leave
			AddHandler vscroll.MouseLeave, AddressOf OnScroll_Leave

			vscroll.Visible = True
			hscroll.Visible = True

			fHScroll.SetValue(Me, hscroll)
			fVScroll.SetValue(Me, vscroll)

			fWidth = 17
		End Sub

		Public Overrides Sub Init(ByVal control As Control, ByVal parent As Control)
			MyBase.Init(control, parent)
		End Sub

		Public Sub SetScrollBarsWidth(ByVal Width As Integer)
			If Width >= 0 Then
				fWidth = Width
				UpdateScrollBars()
			End If
		End Sub

		Public Sub SetScrollBarsButtonWidth(ByVal Width As Integer)
			If Width >= 0 Then
				TryCast(VScroll, MyMemoEditVScrollBar).ViewInfo.SetButtonWidth(Width)
				TryCast(HScroll, MyMemoEditHScrollBar).ViewInfo.SetButtonWidth(Width)
			End If
		End Sub

		Protected Overrides Sub UpdateDXScrollBar(ByVal isHorz As Boolean)
			If IsLockUpdate Then
				Return
			End If
			Dim dxScroll As ScrollBarBase = If(isHorz, CType(HScroll, ScrollBarBase), CType(VScroll, ScrollBarBase))
			If SourceControl Is Nothing Then
				Return
			End If
			If (Not SourceControl.IsHandleCreated) OrElse (Not dxScroll.Parent.IsHandleCreated) Then
				dxScroll.Visible = False
				Return
			End If
			BeginUpdate()
			Try
				Dim sbInfo As New SCROLLBARINFO()
				sbInfo.Init()
				SCROLLBARINFO.GetScrollBarInfo(SourceControl.Handle,If(isHorz, SCROLLBARINFO.OBJID_HSCROLL, SCROLLBARINFO.OBJID_VSCROLL), sbInfo)
				Dim scrollBounds As Rectangle = sbInfo.rcScrollBar.ToRectangle()
				If (SourceControl IsNot Nothing AndAlso (Not SourceControl.Visible)) OrElse scrollBounds.IsEmpty OrElse sbInfo.rgstate0 = SCROLLBARINFO.STATE_SYSTEM_INVISIBLE OrElse sbInfo.rgstate0 = SCROLLBARINFO.STATE_SYSTEM_OFFSCREEN Then
					dxScroll.Visible = False
					Return
				End If
				scrollBounds = dxScroll.Parent.RectangleToClient(scrollBounds)

				If isHorz Then

					scrollBounds.Height = fWidth
				Else
					scrollBounds.Width = fWidth
				End If
				dxScroll.Bounds = scrollBounds
				Dim currentArgs As New ScrollArgs(dxScroll), args As New ScrollArgs()
				If sbInfo.rgstate0 = SCROLLBARINFO.STATE_SYSTEM_UNAVAILABLE Then
					args.Minimum = 0
					args.Maximum = args.Minimum
					args.Value = 0
					args.Enabled = False
				Else
					Dim sInfo As New SCROLLINFO()
					sInfo.Init()
					SCROLLINFO.GetScrollInfo(SourceControl.Handle,If(isHorz, SCROLLINFO.SB_HORZ, SCROLLINFO.SB_VERT), sInfo)
					args.Enabled = True
					args.Maximum = sInfo.nMax
					args.Minimum = sInfo.nMin
					args.LargeChange = sInfo.nPage
					args.SmallChange = If(isHorz, 8, 1)
					args.Value = sInfo.nTrackPos
				End If
				dxScroll.Visible = True
				If currentArgs.IsEquals(args) Then
					Return
				End If
				args.AssignTo(dxScroll)
			Finally
				EndUpdate()
			End Try
		End Sub
	End Class
End Namespace
