<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGlobalEvents" TagPrefix="dx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to measure loading time on the server and on the client sides</title>
    <script>
        function OnEndCallback(s, e) {
            if (s.cpTime)
                document.getElementById("test").innerHTML = s.cpTime;
        }
        var start = new Date();
        function ge_ControlsInitialized(s, e) {
            if (e.isCallback == false) {
                var original = aspxCallback;
                aspxCallback = function (result, context) {
                    start = new Date(); 
                    original(result, context);
                }
            }
            var end = new Date();
            var output = document.getElementById("output");
            output.innerHTML = "Loading time (in ms): " + (end - start);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        Client Results:  <span id="output"></span>
        <dx:ASPxGridView ID="ASPxGridView1" runat="server" ClientInstanceName="grid"
            OnDataBinding="ASPxGridView1_DataBinding" OnCustomColumnDisplayText="ASPxGridView1_CustomColumnDisplayText" OnCustomJSProperties="ASPxGridView1_CustomJSProperties" KeyFieldName="ProductID" AutoGenerateColumns="False">
            <Columns>
                <dx:GridViewCommandColumn ShowEditButton="true" VisibleIndex="0">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UnitsOnOrder" VisibleIndex="4">
                </dx:GridViewDataTextColumn>
            </Columns>
            <ClientSideEvents EndCallback="OnEndCallback" />
            <Settings ShowFilterRow="true" />
        </dx:ASPxGridView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice], [UnitsOnOrder] FROM [Products]"
            DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = ?"
            InsertCommand="INSERT INTO [Products] ([ProductName], [UnitPrice], [UnitsOnOrder]) VALUES (?, ?, ?)"
            UpdateCommand="UPDATE [Products] SET [ProductName] = ?, [UnitPrice] = ?, [UnitsOnOrder] = ? WHERE [ProductID] = ?">
            <DeleteParameters>
                <asp:Parameter Name="ProductID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="UnitsOnOrder" Type="Int16" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="UnitsOnOrder" Type="Int16" />
                <asp:Parameter Name="ProductID" Type="Int32" />
            </UpdateParameters>
        </asp:AccessDataSource>
        <div>Server Results:</div>
        <dx:ASPxLabel ID="test" Border-BorderStyle="Dashed" Border-BorderColor="Red" EncodeHtml="False" runat="server"></dx:ASPxLabel>
        <dx:ASPxGlobalEvents ID="ge" runat="server">
            <ClientSideEvents EndCallback="OnEndCallback" ControlsInitialized="ge_ControlsInitialized" />
        </dx:ASPxGlobalEvents>

    </form>
</body>
</html>
