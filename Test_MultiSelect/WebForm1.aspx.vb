Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Code", GetType(String)))
        dt.Columns.Add(New DataColumn("Name", GetType(String)))

        Dim row As DataRow = dt.NewRow
        row("Code") = "C01"
        row("Name") = "Code Name 1"
        dt.Rows.Add(row)
        Dim row1 As DataRow = dt.NewRow
        row1("Code") = "C02"
        row1("Name") = "Code Name 2"
        dt.Rows.Add(row1)
        Dim row2 As DataRow = dt.NewRow
        row2("Code") = "C03"
        row2("Name") = "Code Name 3"
        dt.Rows.Add(row2)

        If (Not IsPostBack) Then
            WebUserControl1.TextField = "Name"
            WebUserControl1.ValueField = "Code"
            WebUserControl1.BindData(dt)

            WebUserControl11.TextField = "Code"
            WebUserControl11.ValueField = "Name"
            WebUserControl11.BindData(dt)
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As List(Of String)
        result = WebUserControl1.GetSelectedValues()
        If WebUserControl1.IsEmpty Then
            'ok
        Else
            result.Clear()
        End If
    End Sub
End Class