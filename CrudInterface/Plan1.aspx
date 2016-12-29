<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Plan1.aspx.cs" Inherits="CrudInterface.Plan1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctor WEB - Plan1</title>
    <link href="/Content/bootstrap.css" rel="stylesheet"/>
    <link href="/Content/site.css" rel="stylesheet"/>
    <script src="/Scripts/modernizr-2.6.2.js"></script>
    <style type="text/css">
        #form1 {
            height: 322px;
        }
    </style>
</head>
<body style="background-color: #FFFFCC;">
    <form id="form1" runat="server">
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="/">Doctor WEB</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a href="/Plan1.aspx">Plan1</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
    <div class="position: relative" style="width: 524px; height: 240px;">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select * from plan1"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="F1" HeaderText="F1" SortExpression="F1" />
                <asp:BoundField DataField="F2" HeaderText="F2" SortExpression="F2" />
                <asp:BoundField DataField="F3" HeaderText="F3" SortExpression="F3" />
                <asp:BoundField DataField="May-16" HeaderText="May-16" SortExpression="May-16" />
                <asp:BoundField DataField="F5" HeaderText="F5" SortExpression="F5" />
                <asp:BoundField DataField="Jun-16" HeaderText="Jun-16" SortExpression="Jun-16" />
                <asp:BoundField DataField="F7" HeaderText="F7" SortExpression="F7" />
                <asp:BoundField DataField="Jul-16" HeaderText="Jul-16" SortExpression="Jul-16" />
                <asp:BoundField DataField="F9" HeaderText="F9" SortExpression="F9" />
                <asp:BoundField DataField="Ago-2016" HeaderText="Ago-2016" SortExpression="Ago-2016" />
                <asp:BoundField DataField="F11" HeaderText="F11" SortExpression="F11" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
    </div>
        


    <script src="/Scripts/jquery-1.10.2.js"></script>

    <script src="/Scripts/bootstrap.js"></script>
<script src="/Scripts/respond.js"></script>

    

<script type="application/json" id="__browserLink_initializationData">
    {"appName":"Firefox","requestId":"e7efb6709b8541a59449076b5674a7a3"}
</script>
<script type="text/javascript" src="http://localhost:50452/46a7327714a947c2baaed059682417e9/browserLink" async="async"></script>
    </form>
</body>
</html>
