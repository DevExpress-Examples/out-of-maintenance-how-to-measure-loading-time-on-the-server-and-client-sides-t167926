using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private string eventOrder;
    private void AddEventLog(string eventLog)
    {
        if (!String.IsNullOrEmpty(eventOrder))
            eventOrder += "<br/>";
        eventOrder += eventLog;
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
        Thread.Sleep(1000);
        if (!IsPostBack)
            ASPxGridView1.DataBind();
        sw.Stop();
        AddEventLog(String.Format("Page_Init, Time: {0}", sw.Elapsed.TotalMilliseconds));
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
        //some operations
        sw.Stop();
        AddEventLog(String.Format("Page_Load, Time: {0}", sw.Elapsed.TotalMilliseconds));
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        test.Text = eventOrder;
    }
    protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
    {
        Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
        ASPxGridView1.DataSource = AccessDataSource1;
        sw.Stop();
        AddEventLog(String.Format("ASPxGridView.DataBinding, Time: {0} ", sw.Elapsed.TotalMilliseconds));
    }
    protected void ASPxGridView1_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
    {
        Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
        //some operations
        sw.Stop();
        AddEventLog(String.Format("CustomColumnDisplayText, FieldName:{0}, VisibleIndex: {1} , Time: " + sw.Elapsed.TotalMilliseconds, e.Column.FieldName, e.VisibleRowIndex));
    }
    protected void ASPxGridView1_CustomJSProperties(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs e)
    {
        e.Properties.Add("cpTime", eventOrder);
    }
}