Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private eventOrder As String
    Private Sub AddEventLog(ByVal eventLog As String)
        If (Not String.IsNullOrEmpty(eventOrder)) Then
            eventOrder &= "<br/>"
        End If
        eventOrder &= eventLog
    End Sub
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim sw As Stopwatch = System.Diagnostics.Stopwatch.StartNew()
        Thread.Sleep(1000)
        If (Not IsPostBack) Then
            ASPxGridView1.DataBind()
        End If
        sw.Stop()
        AddEventLog(String.Format("Page_Init, Time: {0}", sw.Elapsed.TotalMilliseconds))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim sw As Stopwatch = System.Diagnostics.Stopwatch.StartNew()
        'some operations
        sw.Stop()
        AddEventLog(String.Format("Page_Load, Time: {0}", sw.Elapsed.TotalMilliseconds))
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
        test.Text = eventOrder
    End Sub
    Protected Sub ASPxGridView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)

        Dim sw As Stopwatch = System.Diagnostics.Stopwatch.StartNew()
        ASPxGridView1.DataSource = AccessDataSource1
        sw.Stop()
        AddEventLog(String.Format("ASPxGridView.DataBinding, Time: {0} ", sw.Elapsed.TotalMilliseconds))
    End Sub
    Protected Sub ASPxGridView1_CustomColumnDisplayText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs)
        Dim sw As Stopwatch = System.Diagnostics.Stopwatch.StartNew()
        'some operations
        sw.Stop()
        AddEventLog(String.Format("CustomColumnDisplayText, FieldName:{0}, VisibleIndex: {1} , Time: " & sw.Elapsed.TotalMilliseconds, e.Column.FieldName, e.VisibleRowIndex))
    End Sub
    Protected Sub ASPxGridView1_CustomJSProperties(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewClientJSPropertiesEventArgs)
        e.Properties.Add("cpTime", eventOrder)
    End Sub
End Class