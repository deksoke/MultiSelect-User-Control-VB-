Public Class WebUserControl1
    Inherits System.Web.UI.UserControl

    'Require Items
    'Jqeury / Bootstrap CSS

#Region "Property"
    <System.ComponentModel.DefaultValue(False)> _
    Public Property enableFiltering As Boolean
        Get
            Return IIf(hEnableFiltering.Value = "", False, hEnableFiltering.Value = "T")
        End Get
        Set(value As Boolean)
            hEnableFiltering.Value = IIf(value, "T", "F")
        End Set
    End Property

    <System.ComponentModel.DefaultValue(True)> _
    Public Property includeSelectAllOption As Boolean
        Get
            Return IIf(hIncludeSelectAllOption.Value = "", True, hIncludeSelectAllOption.Value = "T")
        End Get
        Set(value As Boolean)
            hIncludeSelectAllOption.Value = IIf(value, "T", "F")
        End Set
    End Property

    Public Property TextField As String
        Get
            Return hTextField.Value
        End Get
        Set(value As String)
            hTextField.Value = value
        End Set
    End Property
    Public Property ValueField As String
        Get
            Return hValueField.Value
        End Get
        Set(value As String)
            hValueField.Value = value
        End Set
    End Property
#End Region

#Region "Method"
    Protected Function InitialListBoxOptions() As String
        Dim command As String = ""
        If includeSelectAllOption Then
            command &= "includeSelectAllOption: true"
        End If
        If command <> "" Then command &= ","
        If enableFiltering Then
            command &= "enableFiltering: true"
        End If
        Return command
    End Function

    Public Function GetSelectedValues() As List(Of String)
        Dim l As New List(Of String)
        For Each item As ListItem In ListBox1.Items
            If item.Selected Then
                l.Add(item.Value)
            End If
        Next
        Return l
    End Function

    Public Function GetSelectedCount() As Integer
        Return GetSelectedValues.Count
    End Function

    Public Function IsEmpty() As Boolean
        Return ListBox1.GetSelectedIndices.Count = 0
    End Function

    Public Sub BindData(dt As DataTable)
        ListBox1.Items.Clear()

        If TextField <> "" And ValueField <> "" Then
            For Each row As DataRow In dt.Rows
                ListBox1.Items.Add(New ListItem(row(TextField), row(ValueField)))
            Next
        End If

    End Sub
#End Region

End Class