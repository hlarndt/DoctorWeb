<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="movimentos.aspx.cs" Inherits="CrudInterface.movimentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=0.8">
    <title>Doctor WEB - Movimentos</title>
    <link href="/Content/bootstrap.css" rel="stylesheet"/>
    <link href="/Content/site.css" rel="stylesheet"/>
    <script type="application/json" id="__browserLink_initializationData">
        {"appName":"Firefox","requestId":"4d3c0c2834044ad18dc5f24ea407818b"}
    </script>
</head>
<body style="background-color: #FFFFCC;">
    <!--#include virtual="/menubar.aspx"-->
    <script src="/bundles/jquery?v=FVs3ACwOLIVInrAl5sdzR2jrCDmVOWFbZMY6g6Q0ulE1"></script>
    <script src="/bundles/jqueryval?v=hEGG8cMxk9p0ncdRUOJ-CnKN7NezhnPnWIvn6REucZo1"></script>
    <script src="/bundles/bootstrap?v=2Fz3B0iizV2NnnamQFrx-NbYJNTFeBJ2GM05SilbtQU1"></script>
    <form id="form1" runat="server" onload="form1_Load">
    <center>
        <div style="background-color: #FFFFCC;text-align:center;position:absolute;left:50%;top:50%;-webkit-transform: translate(-50%, -50%);transform: translate(-50%, -50%);">
            <div runat="server" id="divtbl" style="width:166vh;height:65vh;overflow:scroll;">
                <center><asp:FileUpload ID="FileUpload1" runat="server" accept=".xls" ForeColor="White"/>
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Download" OnClick="Button1_Click"/>
                <asp:Button ID="Button2" runat="server" Text="Validar" OnClick="Button2_Click"/>
                <asp:Button ID="Button3" runat="server" Text="Gravar" OnClick="Button3_Click"/>
                </center>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" PageSize="6">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
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
    </center>
    </form>
</body>
</html>
