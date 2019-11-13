<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewReport.aspx.cs" Inherits="Easy_Shopping.ViewReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jscharts.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Please Select</asp:ListItem>
            <asp:ListItem>2019</asp:ListItem>
            <asp:ListItem>2018</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generate Chart" />
        <br />
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyDatabaseConnectionString1 %>" SelectCommand="SELECT * FROM [tblPurchase]"></asp:SqlDataSource>

      
    </form>
    <div id="graph">
        Loading...</div>
    
<script type="text/javascript">
var myChart= new JSChart('graph', 'line');
myChart.setDataXML("xml/data.xml");
myChart.draw();
</script>
</body>
</html>
