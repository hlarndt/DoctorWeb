<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="telapadrao.aspx.cs" Inherits="CrudInterface.telapadrao" %>

<!DOCTYPE html>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["menu"] == "1")
        {
           Page.Header.Title = "Doctor WEB - Cadastro de Pacientes";
        }
        if (Request.QueryString["menu"] == "2")
        {
           Page.Header.Title = "Doctor WEB - Cadastro de Convênios";
        }
        if (Request.QueryString["menu"] == "3")
        {
           Page.Header.Title = "Doctor WEB - Cadastro de Enfermeiros";
        }
        if (Request.QueryString["menu"] == "4")
        {
           Page.Header.Title = "Doctor WEB - Cadastro de Médicos";
        }
        if (Request.QueryString["menu"] == "5")
        {
           Page.Header.Title = "Doctor WEB - Cadastro de Procedimentos";
        }
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=0.8">
    <link href="/Content/bootstrap.css" rel="stylesheet"/>
    <link href="/Content/site.css" rel="stylesheet"/>
    <script type="application/json" id="__browserLink_initializationData">
        {"appName":"Firefox","requestId":"4d3c0c2834044ad18dc5f24ea407818b"}
    </script>
</head>
<body style="background-color: #FFFFCC;">
    <!--#include virtual="/menubar.aspx"-->
    <script src="/Scripts/jquery-1.10.2.js"></script>
    <script src="/Scripts/bootstrap.js"></script>
    <script src="/Scripts/respond.js"></script>
    <form id="form1" runat="server">
    <div style="background-color: #FFFFCC;text-align:center;position:absolute;left:50%;top:50%;-webkit-transform: translate(-50%, -50%);transform: translate(-50%, -50%);">
        <center>
        <div>
            <% if (Request.QueryString["menu"] == "5")  %>
            <% { %>
            <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AllowSorting="True" DataKeyNames="id" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource11" ForeColor="Black" PageSize="6" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Codigo">
                    <ItemTemplate>    <%#Container.DataItemIndex+1 %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descrição">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" Enabled="false" Width="245" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" ButtonType ="Image" SelectImageUrl="aceitar.jpg" ItemStyle-HorizontalAlign="center" HeaderText="Selec.">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <% } %>
            <% if (Request.QueryString["menu"] == "4")  %>
            <% { %>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" DataKeyNames="id" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource4" ForeColor="Black" PageSize="6" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Codigo">
                    <ItemTemplate>    <%#Container.DataItemIndex+1 %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" Enabled="false" Width="245" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" ButtonType ="Image" SelectImageUrl="aceitar.jpg" ItemStyle-HorizontalAlign="center" HeaderText="Selec.">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <% } %>
            <% if (Request.QueryString["menu"] == "3")  %>
            <% { %>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataKeyNames="id" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black" PageSize="6" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Codigo">
                    <ItemTemplate>    <%#Container.DataItemIndex+1 %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" Enabled="false" Width="245" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" ButtonType ="Image" SelectImageUrl="aceitar.jpg" ItemStyle-HorizontalAlign="center" HeaderText="Selec.">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <% } %>
            <% if (Request.QueryString["menu"] == "2")  %>
            <% { %>
            <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True" DataKeyNames="id" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource6" ForeColor="Black" PageSize="6" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Codigo">
                    <ItemTemplate>    <%#Container.DataItemIndex+1 %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" Enabled="false" Width="245" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" ButtonType ="Image" SelectImageUrl="aceitar.jpg" ItemStyle-HorizontalAlign="center" HeaderText="Selec.">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <% } %>
            <% if (Request.QueryString["menu"] == "1")  %>
            <% { %>
            <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AllowSorting="True" DataKeyNames="id" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource8" ForeColor="Black" PageSize="6" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Codigo">
                    <ItemTemplate>    <%#Container.DataItemIndex+1 %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" Enabled="false" Width="245" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" ButtonType ="Image" SelectImageUrl="aceitar.jpg" ItemStyle-HorizontalAlign="center" HeaderText="Selec.">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <% } %>
        </div>
        <div><p>Pesquisa: <asp:TextBox ID="TextBox4" Text="" runat="server" Width="266px"></asp:TextBox></p></div>
        <div>
            <% if (Request.QueryString["menu"] == "5")  %>
            <% { %>
            <asp:DetailsView ID="DetailsView5" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource10" DataKeyNames="id" ForeColor="Black" Height="50px" Width="366px" AutoGenerateRows="False" GridLines="Vertical" OnItemDeleted="DetailsView1_ItemDeleted" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" OnModeChanged="DetailsView1_ModeChanged" OnLoad="DetailsView1_Load" OnDataBinding="DetailsView1_DataBinding" OnItemInserting="DetailsView1_ItemInserting" OnItemUpdating="DetailsView1_ItemUpdating">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <EditRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                <Fields>
                    <asp:TemplateField HeaderText="Descrição">
                        <InsertItemTemplate>
                            <asp:TextBox ID="descricao" Width="245" runat="server" enabled="true" Text='<%# Bind("descricao") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="descricao" Width="245" runat="server" enabled="true" Text='<%# Bind("descricao") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="descricao" Width="245" runat="server" enabled="false" Text='<%# Bind("descricao") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor">
                        <InsertItemTemplate>
                            <asp:TextBox ID="preco" Width="245" runat="server" enabled="true" Text='<%# Bind("preco") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="preco" Width="245" runat="server" enabled="true" Text='<%# Bind("preco") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="preco" Width="245" runat="server" enabled="false" Text='<%# Bind("preco") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Grava" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancela" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Insert" Text="Insere" OnInit="Button1_Init" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancela" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edita" OnInit="Button1_Init1"/>
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="New" Text="Novo" OnInit="Button2_Init" />
                            &nbsp;<asp:Button ID="Button3" runat="server" CausesValidation="False" CommandName="Delete" Text="Apaga" OnClientClick="return confirm('Confirma a exclusão?');" OnInit="Button3_Init"/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Fields>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:DetailsView>
            <% } %>
            <% if (Request.QueryString["menu"] == "4")  %>
            <% { %>
            <asp:DetailsView ID="DetailsView2" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource3" DataKeyNames="id" ForeColor="Black" Height="50px" Width="365px" AutoGenerateRows="False" GridLines="Vertical" OnItemDeleted="DetailsView1_ItemDeleted" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" OnModeChanged="DetailsView1_ModeChanged" OnLoad="DetailsView1_Load" OnDataBinding="DetailsView1_DataBinding" OnItemInserting="DetailsView1_ItemInserting" OnItemUpdating="DetailsView1_ItemUpdating">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <EditRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                <Fields>
                    <asp:TemplateField HeaderText="Nome">
                        <InsertItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="true" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="true" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="false" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Grava" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancela" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Insert" Text="Insere" OnInit="Button1_Init3"/>
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancela" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edita" OnInit="Button1_Init4" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="New" Text="Novo" OnInit="Button2_Init1"/>
                            &nbsp;<asp:Button ID="Button3" runat="server" CausesValidation="False" CommandName="Delete" Text="Apaga" OnClientClick="return confirm('Confirma a exclusão?');" OnInit="Button3_Init1"/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Fields>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:DetailsView>
            <% } %>
            <% if (Request.QueryString["menu"] == "3")  %>
            <% { %>
            <asp:DetailsView ID="DetailsView1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" DataKeyNames="id" ForeColor="Black" Height="50px" Width="365px" AutoGenerateRows="False" GridLines="Vertical" OnItemDeleted="DetailsView1_ItemDeleted" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" OnModeChanged="DetailsView1_ModeChanged" OnLoad="DetailsView1_Load" OnDataBinding="DetailsView1_DataBinding" OnItemInserting="DetailsView1_ItemInserting" OnItemUpdating="DetailsView1_ItemUpdating">
                <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                <EditRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                <Fields>
                    <asp:TemplateField HeaderText="Nome">
                        <InsertItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="true" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="true" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="false" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Grava" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancela" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Insert" Text="Insere" OnInit="Button1_Init2"/>
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancela" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edita" OnInit="Button2_Init2" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="New" Text="Novo" OnInit="Button1_Init2"/>
                            &nbsp;<asp:Button ID="Button3" runat="server" CausesValidation="False" CommandName="Delete" Text="Apaga" OnClientClick="return confirm('Confirma a exclusão?');" OnInit="Button3_Init2" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Fields>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:DetailsView>
            <% } %>
            <% if (Request.QueryString["menu"] == "2")  %>
            <% { %>
            <asp:DetailsView ID="DetailsView3" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource5" DataKeyNames="id" ForeColor="Black" Height="50px" Width="366px" AutoGenerateRows="False" GridLines="Vertical" OnItemDeleted="DetailsView1_ItemDeleted" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" OnModeChanged="DetailsView1_ModeChanged" OnLoad="DetailsView1_Load" OnDataBinding="DetailsView1_DataBinding" OnItemInserting="DetailsView1_ItemInserting" OnItemUpdating="DetailsView1_ItemUpdating">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <EditRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                <Fields>
                    <asp:TemplateField HeaderText="Nome">
                        <InsertItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="true" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="true" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="false" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Grava" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancela" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Insert" Text="Insere" OnInit="Button1_Init5"/>
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancela"/>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edita" OnInit="Button1_Init6"/>
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="New" Text="Novo" OnInit="Button1_Init5"/>
                            &nbsp;<asp:Button ID="Button3" runat="server" CausesValidation="False" CommandName="Delete" Text="Apaga" OnClientClick="return confirm('Confirma a exclusão?');" OnInit="Button3_Init3"/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Fields>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:DetailsView>
            <% } %>
            <% if (Request.QueryString["menu"] == "1")  %>
            <% { %>
            <asp:DetailsView ID="DetailsView4" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource7" DataKeyNames="id" ForeColor="Black" Height="40px" Width="366px" AutoGenerateRows="False" GridLines="Vertical" OnItemDeleted="DetailsView1_ItemDeleted" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" OnModeChanged="DetailsView1_ModeChanged" OnLoad="DetailsView1_Load" OnDataBinding="DetailsView1_DataBinding" OnItemInserting="DetailsView1_ItemInserting" OnItemUpdating="DetailsView1_ItemUpdating">
                <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                <EditRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="Black" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                <Fields>
                    <asp:TemplateField HeaderText="Nome">
                        <InsertItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="true" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="true" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="nome" Width="245" runat="server" enabled="false" Text='<%# Bind("nome") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Enfermeiro">
                        <EditItemTemplate>
                            <asp:DropDownList ID="id_enfermeiro" Width="250" runat="server" enabled="true" DataSourceID="SqlDataSource9" DataTextField="nome" DataValueField="id" AppendDataBoundItems="true" Text='<%# Bind("id_enfermeiro") %>'><asp:ListItem Text="Selecione o enfermeiro" Value="0" /></asp:DropDownList>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:DropDownList ID="id_enfermeiro" Width="250" runat="server" enabled="true" DataSourceID="SqlDataSource9" DataTextField="nome" DataValueField="id" AppendDataBoundItems="true" Text='<%# Bind("id_enfermeiro") %>'><asp:ListItem Text="Selecione o enfermeiro" Value="0" /></asp:DropDownList>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="id_enfermeiro" Width="250" runat="server" enabled="false" DataSourceID="SqlDataSource9" DataTextField="nome" DataValueField="id" AppendDataBoundItems="true" Text='<%# Bind("id_enfermeiro") %>'><asp:ListItem Text="Selecione o enfermeiro" Value="0" /></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Médico">
                        <EditItemTemplate>
                            <asp:DropDownList ID="id_medico" Width="250" runat="server" enabled="true" DataSourceID="SqlDataSource12" DataTextField="nome" DataValueField="id" AppendDataBoundItems="true" Text='<%# Bind("id_medico") %>'><asp:ListItem Text="Selecione o médico" Value="0" /></asp:DropDownList>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:DropDownList ID="id_medico" Width="250" runat="server" enabled="true" DataSourceID="SqlDataSource12" DataTextField="nome" DataValueField="id" AppendDataBoundItems="true" Text='<%# Bind("id_medico") %>'><asp:ListItem Text="Selecione o médico" Value="0" /></asp:DropDownList>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="id_medico" Width="250" runat="server" enabled="false" DataSourceID="SqlDataSource12" DataTextField="nome" DataValueField="id"  AppendDataBoundItems="true" Text='<%# Bind("id_medico") %>'><asp:ListItem Text="Selecione o médico" Value="0" /></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Grava" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancela" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Insert" Text="Insere" OnInit="Button1_Init7"/>
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancela" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edita" OnInit="Button1_Init8"/>
                            &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="New" Text="Novo" OnInit="Button1_Init7"/>
                            &nbsp;<asp:Button ID="Button3" runat="server" CausesValidation="False" CommandName="Delete" Text="Apaga"  OnClientClick="return confirm('Confirma a exclusão?');" OnInit="Button3_Init4"/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Fields>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:DetailsView>
            <% } %>
        </div>
        <% if  (Request.QueryString["menu"] == "5")  %>
        <% { %>
        <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,descricao,preco from dbo.procedimento where id=@id" DeleteCommand="delete from dbo.procedimento where id=@id" InsertCommand="insert into dbo.procedimento(descricao,preco,dt_cadastro) values(@descricao,@preco,getdate())" UpdateCommand="update dbo.procedimento set descricao=@descricao,preco=@preco,dt_alteracao=getdate() where id=@id">
            <SelectParameters><asp:ControlParameter Name="id" ControlId="GridView5" /></SelectParameters>
            <UpdateParameters><asp:ControlParameter Name="descricao" ControlID="DetailsView5" PropertyName="SelectedValue" /><asp:ControlParameter Name="preco" ControlID="DetailsView5" PropertyName="SelectedValue" />
            </UpdateParameters>
            <DeleteParameters><asp:ControlParameter Name="id" ControlId="GridView5" /></DeleteParameters>
            <InsertParameters><asp:ControlParameter Name="descricao" ControlID="DetailsView5$descricao" /><asp:ControlParameter Name="preco" ControlID="DetailsView5$preco" /></InsertParameters></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource11" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,descricao from dbo.procedimento" FilterExpression="descricao LIKE '{0}%'"> <FilterParameters><asp:ControlParameter Name="nome" ControlID="TextBox4" PropertyName="Text" /></FilterParameters></asp:SqlDataSource>
        <% } %>
        <% if  (Request.QueryString["menu"] == "4")  %>
        <% { %>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,nome from dbo.medico where id=@id" DeleteCommand="delete from dbo.medico where id=@id" InsertCommand="insert into dbo.medico(nome,dt_cadastro) values(@nome,getdate())" UpdateCommand="update dbo.medico set nome=@nome,dt_alteracao=getdate() where id=@id">
            <SelectParameters><asp:ControlParameter Name="id" ControlId="GridView2" /></SelectParameters>
            <UpdateParameters><asp:ControlParameter Name="nome" ControlID="DetailsView2" PropertyName="SelectedValue" />
            </UpdateParameters>
            <DeleteParameters><asp:ControlParameter Name="id" ControlId="GridView2" /></DeleteParameters>
            <InsertParameters><asp:ControlParameter Name="nome" ControlID="DetailsView2$nome" /></InsertParameters></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,nome from dbo.medico" FilterExpression="nome LIKE '{0}%'"> <FilterParameters><asp:ControlParameter Name="nome" ControlID="TextBox4" PropertyName="Text" /></FilterParameters></asp:SqlDataSource>
        <% } %>
        <% if  (Request.QueryString["menu"] == "3")  %>
        <% { %>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,nome from dbo.enfermeiro where id=@id" DeleteCommand="delete from dbo.enfermeiro where id=@id" InsertCommand="insert into dbo.enfermeiro(nome,dt_cadastro) values(@nome,getdate())" UpdateCommand="update dbo.enfermeiro set nome=@nome,dt_alteracao=getdate() where id=@id">
            <SelectParameters><asp:ControlParameter Name="id" ControlId="GridView1" /></SelectParameters>
            <UpdateParameters><asp:ControlParameter Name="nome" ControlID="DetailsView1" PropertyName="SelectedValue" />
            </UpdateParameters>
            <DeleteParameters><asp:ControlParameter Name="id" ControlId="GridView1" /></DeleteParameters>
            <InsertParameters><asp:ControlParameter Name="nome" ControlID="DetailsView1$nome" /></InsertParameters></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,nome from dbo.enfermeiro" FilterExpression="nome LIKE '{0}%'"> <FilterParameters><asp:ControlParameter Name="nome" ControlID="TextBox4" PropertyName="Text" /></FilterParameters></asp:SqlDataSource>
        <% } %>
        <% if  (Request.QueryString["menu"] == "2")  %>
        <% { %>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,nome from dbo.convenio where id=@id" DeleteCommand="delete from dbo.convenio where id=@id" InsertCommand="insert into dbo.convenio(nome,dt_cadastro) values(@nome,getdate())" UpdateCommand="update dbo.convenio set nome=@nome,dt_alteracao=getdate() where id=@id">
            <SelectParameters><asp:ControlParameter Name="id" ControlId="GridView3" /></SelectParameters>
            <UpdateParameters><asp:ControlParameter Name="nome" ControlID="DetailsView3" PropertyName="SelectedValue" />
            </UpdateParameters>
            <DeleteParameters><asp:ControlParameter Name="id" ControlId="GridView3" /></DeleteParameters>
            <InsertParameters><asp:ControlParameter Name="nome" ControlID="DetailsView3$nome" /></InsertParameters></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,nome from dbo.convenio" FilterExpression="nome LIKE '{0}%'"> <FilterParameters><asp:ControlParameter Name="nome" ControlID="TextBox4" PropertyName="Text" /></FilterParameters></asp:SqlDataSource>
        <% } %>
        <% if  (Request.QueryString["menu"] == "1")  %>
        <% { %>
        <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,nome,id_enfermeiro,id_medico from dbo.paciente where id=@id" DeleteCommand="delete from dbo.paciente where id=@id" InsertCommand="insert into dbo.paciente(nome,id_enfermeiro,id_medico,dt_cadastro) values(@nome,@id_enfermeiro,@id_medico,getdate())" UpdateCommand="update dbo.paciente set nome=@nome,id_enfermeiro=@id_enfermeiro,id_medico=@id_medico,dt_alteracao=getdate() where id=@id">
            <SelectParameters><asp:ControlParameter Name="id" ControlId="GridView4" /></SelectParameters>
            <UpdateParameters><asp:ControlParameter Name="nome" ControlID="DetailsView4" PropertyName="SelectedValue" /><asp:ControlParameter Name="id_enfermeiro" ControlID="DetailsView4" PropertyName="SelectedValue" /><asp:ControlParameter Name="id_medico" ControlID="DetailsView4" PropertyName="SelectedValue" />
            </UpdateParameters>
            <DeleteParameters><asp:ControlParameter Name="id" ControlId="GridView4" /></DeleteParameters>
            <InsertParameters><asp:ControlParameter Name="nome" ControlID="DetailsView4$nome" /><asp:ControlParameter Name="id_enfermeiro" ControlID="DetailsView4$id_enfermeiro" /><asp:ControlParameter Name="id_medico" ControlID="DetailsView4$id_medico" /></InsertParameters></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,nome,id_enfermeiro,id_medico from dbo.paciente" FilterExpression="nome LIKE '{0}%'"> <FilterParameters><asp:ControlParameter Name="nome" ControlID="TextBox4" PropertyName="Text" /></FilterParameters></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,nome from dbo.enfermeiro"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,nome from dbo.medico"></asp:SqlDataSource>
        <% } %>
    </center>    
    </div>
    </form>
</body>
</html>
