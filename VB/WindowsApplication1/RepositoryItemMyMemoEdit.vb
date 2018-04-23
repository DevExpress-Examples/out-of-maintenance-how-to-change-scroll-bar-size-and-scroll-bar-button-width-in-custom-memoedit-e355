Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Accessibility
Imports System.Drawing

Namespace WindowsApplication1
    <UserRepositoryItem("RegisterMyMemoEdit")> _
    Public Class RepositoryItemMyMemoEdit
        Inherits RepositoryItemMemoEdit
        Public Event Assigned As EventHandler

        Shared Sub New()
            RegisterMyMemoEdit()
        End Sub

        Public Sub New()
            fScrollWidth = 17
            fScrollButtonWidth = 17
        End Sub

        Public Const MyMemoEditName As String = "MyMemoEdit"
        Public Overrides ReadOnly Property EditorTypeName() As String
            Get
                Return MyMemoEditName
            End Get
        End Property

        Public Shared Sub RegisterMyMemoEdit()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(MyMemoEditName, GetType(MyMemoEdit), GetType(RepositoryItemMyMemoEdit), GetType(MyMemoEditViewInfo), New MemoEditPainter(), True, New Bitmap(16, 16), GetType(TextEditAccessible)))
        End Sub

        Public Overrides Sub Assign(ByVal item As RepositoryItem)
            BeginUpdate()
            Try
                MyBase.Assign(item)
                Dim source As RepositoryItemMyMemoEdit = TryCast(item, RepositoryItemMyMemoEdit)
                If source Is Nothing Then
                    Return
                End If
                fScrollWidth = source.fScrollWidth
                fScrollButtonWidth = source.fScrollButtonWidth
                RaiseEvent Assigned(Me, New EventArgs())
            Finally
                EndUpdate()
            End Try
        End Sub

        Private fScrollWidth As Integer
        Private fScrollButtonWidth As Integer

        <DefaultValue(17)> _
        Public Property ScrollWidth() As Integer
            Get
                Return fScrollWidth
            End Get
            Set(ByVal value As Integer)
                If fScrollWidth <> value Then
                    fScrollWidth = value
                    OnPropertiesChanged()
                    If OwnerEdit IsNot Nothing Then
                        TryCast(OwnerEdit, MyMemoEdit).UpdateScrollBars()
                    End If
                End If
            End Set
        End Property

        <DefaultValue(17)> _
        Public Property ScrollButtonWidth() As Integer
            Get
                Return fScrollButtonWidth
            End Get
            Set(ByVal value As Integer)
                If fScrollButtonWidth <> value Then
                    fScrollButtonWidth = value
                    OnPropertiesChanged()
                    If OwnerEdit IsNot Nothing Then
                        TryCast(OwnerEdit, MyMemoEdit).UpdateScrollBars()
                    End If
                End If
            End Set
        End Property
    End Class

End Namespace
