<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="CrudInterface.usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctor WEB - Cadastro de Usuários</title>
    <link href="/Content/bootstrap.css" rel="stylesheet"/>
    <link href="/Content/site.css" rel="stylesheet"/>
    <script src="/Scripts/modernizr-2.6.2.js"></script>
    <script src="/Scripts/jquery-1.10.2.js"></script>
    <script src="/Scripts/bootstrap.js"></script>
    <script src="/Scripts/respond.js"></script>
    <script type="application/json" id="__browserLink_initializationData">
        {"appName":"Firefox","requestId":"4d3c0c2834044ad18dc5f24ea407818b"}
    </script>
</head>
<body style="background-color: #FFFFCC;">
    <!--#include virtual="/menubar.aspx"-->
    <form id="form1" runat="server">
    <div style="background-color: #FFFFCC;text-align:center;position:absolute;left:50%;top:50%;-webkit-transform: translate(-50%, -50%);transform: translate(-50%, -50%);">
        <center>
        <div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataKeyNames="id" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black" PageSize="4" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Codigo">
                    <ItemTemplate>    <%#Container.DataItemIndex+1 %>    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Usuário">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" Enabled="false" Width="100" runat="server" Text='<%# Bind("usuario") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Senha">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox2" Width="100" Enabled="false" runat="server" TextMode="Password" Text='<%# Bind("senha") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox3" Width="20" Enabled="false" runat="server" MaxLength="1" Text='<%# Bind("tipo") %>'></asp:TextBox>
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
        </div>
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" BackColor="#FFFFCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource2" DataKeyNames="id" ForeColor="Black" Height="50px" Width="355px" AutoGenerateRows="False" GridLines="Vertical" OnItemDeleted="DetailsView1_ItemDeleted" OnItemInserted="DetailsView1_ItemInserted" OnItemUpdated="DetailsView1_ItemUpdated" OnModeChanged="DetailsView1_ModeChanged" OnLoad="DetailsView1_Load" OnDataBinding="DetailsView1_DataBinding">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <Fields>
                    <asp:TemplateField HeaderText="Usuário">
                        <InsertItemTemplate>
                            <asp:TextBox ID="usuario" Width="100" runat="server" enabled="true" Text='<%# Bind("usuario") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="usuario" Width="100" runat="server" enabled="true" Text='<%# Bind("usuario") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="usuario" Width="100" runat="server" enabled="false" Text='<%# Bind("usuario") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Senha">
                        <InsertItemTemplate>
                            <asp:TextBox ID="senha" Width="100" enabled="true" runat="server" TextMode="Password" Text='<%# Bind("senha") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="senha" Width="100" enabled="true" runat="server" TextMode="Password" Text='<%# Bind("senha") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="senha" Width="100" enabled="false" runat="server" TextMode="Password" Text='<%# Bind("senha") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo">
                        <InsertItemTemplate>
                            <asp:TextBox ID="tipo" Width="20" enabled="true" runat="server" MaxLength="1" Text='<%# Bind("tipo") %>'></asp:TextBox>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tipo" Width="20" enabled="true" runat="server" MaxLength="1" Text='<%# Bind("tipo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="tipo" Width="20" enabled="false" runat="server" MaxLength="1" Text='<%# Bind("tipo") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" CancelText="Cancela" DeleteText="Apaga" EditText="Edita" InsertText="Insere" NewText="Novo" SelectText="Seleciona" ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" UpdateText="Grava" ItemStyle-HorizontalAlign="center" />
                </Fields>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:DetailsView>
        </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,usuario,senha,tipo from usuario where id=:id" DeleteCommand="delete from usuario where id=:id" InsertCommand="insert into usuario(usuario,senha,tipo) values(:usuario,:senha,:tipo)" UpdateCommand="update usuario set usuario=:usuario,senha=:senha,tipo=:tipo where id=:id">
            <SelectParameters><asp:ControlParameter Name="id" ControlId="GridView1" /></SelectParameters>
            <UpdateParameters><asp:ControlParameter Name="usuario" ControlID="DetailsView1" PropertyName="SelectedValue" />
                <asp:FormParameter FormField="DetailsView1$senha" Name="senha" />
                <asp:ControlParameter Name="tipo" ControlId="DetailsView1" PropertyName="SelectedValue" /><asp:ControlParameter Name="id" ControlId="GridView1" /></UpdateParameters>
            <DeleteParameters><asp:ControlParameter Name="id" ControlId="GridView1" /></DeleteParameters>
            <InsertParameters><asp:ControlParameter Name="usuario" ControlID="DetailsView1$usuario" /><asp:ControlParameter Name="senha" ControlId="DetailsView1$senha" /><asp:ControlParameter Name="tipo" ControlId="DetailsView1$tipo" /></InsertParameters></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="select id,usuario,senha,tipo from usuario"></asp:SqlDataSource>
        <div>
            <p>&nbsp;</p>
        </div>
        <div>
            <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource3" Width="68px" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView2_RowDataBound" OnDataBinding="GridView2_DataBinding" Font-Size="Smaller">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" CancelImageUrl="~/erro.jpg" EditImageUrl="~/editar.jpg" ShowEditButton="True" UpdateImageUrl="~/aceitar.jpg" />
                <asp:CheckBoxField DataField="usuarioinc" HeaderText="01" SortExpression="usuarioinc" />
                <asp:CheckBoxField DataField="usuarioman" HeaderText="02" SortExpression="usuarioman" />
                <asp:CheckBoxField DataField="usuariodel" HeaderText="03" SortExpression="usuariodel" />
                <asp:CheckBoxField DataField="pacienteinc" HeaderText="04" SortExpression="pacienteinc" />
                <asp:CheckBoxField DataField="pacienteman" HeaderText="05" SortExpression="pacienteman" />
                <asp:CheckBoxField DataField="pacientedel" HeaderText="06" SortExpression="pacientedel" />
                <asp:CheckBoxField DataField="convenioinc" HeaderText="07" SortExpression="convenioinc" />
                <asp:CheckBoxField DataField="convenioman" HeaderText="08" SortExpression="convenioman" />
                <asp:CheckBoxField DataField="conveniodel" HeaderText="09" SortExpression="conveniodel" />
                <asp:CheckBoxField DataField="movimentoinc" HeaderText="10" SortExpression="movimentoinc" />
                <asp:CheckBoxField DataField="movimentoman" HeaderText="11" SortExpression="movimentoman" />
                <asp:CheckBoxField DataField="movimentodel" HeaderText="12" SortExpression="movimentodel" />
                <asp:CheckBoxField DataField="fichainc" HeaderText="12" SortExpression="fichainc" />
                <asp:CheckBoxField DataField="fichaman" HeaderText="13" SortExpression="fichaman" />
                <asp:CheckBoxField DataField="fichadel" HeaderText="14" SortExpression="fichadel" />
                <asp:CheckBoxField DataField="medicoinc" HeaderText="15" SortExpression="medicoinc" />
                <asp:CheckBoxField DataField="medicoman" HeaderText="16" SortExpression="medicoman" />
                <asp:CheckBoxField DataField="medicodel" HeaderText="17" SortExpression="medicodel" />
                <asp:CheckBoxField DataField="enfermeiroinc" HeaderText="18" SortExpression="enfermeiroinc" />
                <asp:CheckBoxField DataField="enfermeiroman" HeaderText="19" SortExpression="enfermeiroman" />
                <asp:CheckBoxField DataField="enfermeirodel" HeaderText="20" SortExpression="enfermeirodel" />
                <asp:CheckBoxField DataField="procedimentoinc" HeaderText="21" SortExpression="procedimentoinc" />
                <asp:CheckBoxField DataField="procedimentoman" HeaderText="22" SortExpression="procedimentoman" />
                <asp:CheckBoxField DataField="procedimentodel" HeaderText="23" SortExpression="procedimentodel" />
                <asp:CheckBoxField DataField="relatorio" HeaderText="24" SortExpression="relatorio" />
                <asp:CheckBoxField DataField="grafico" HeaderText="25" SortExpression="grafico" />
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DoctorWebConnectionString %>" ProviderName="<%$ ConnectionStrings:DoctorWebConnectionString.ProviderName %>" SelectCommand="SELECT usuarioinc, usuarioman, usuariodel, pacienteinc, pacienteman, pacientedel, convenioinc, convenioman, conveniodel, movimentoinc, movimentoman, movimentodel, relatorio, grafico,medicoinc,medicoman,medicodel,procedimentoinc,procedimentoman,procedimentodel,enfermeiroinc,enfermeiroman,enfermeirodel,fichainc,fichaman,fichadel FROM usuario WHERE (id = :id)" UpdateCommand="update usuario set usuarioinc=:usuarioinc, usuarioman=:usuarioman, usuariodel=:usuariodel, pacienteinc=:pacienteinc, pacienteman=:pacienteman, pacientedel=:pacientedel, convenioinc=:convenioinc, convenioman=:convenioman, conveniodel=:conveniodel, movimentoinc=:movimentoinc, movimentoman=:movimentoman, movimentodel=:movimentodel, relatorio=:relatorio, grafico=:grafico,medicoinc=:medicoinc,medicoman=:medicoman,medicodel=:medicodel,procedimentoinc=:procedimentoinc,procedimentoman=:procedimentoman,procedimentodel=:procedimentodel,enfermeiroinc=:enfermeiroinc,enfermeiroman=:enfermeiroman,enfermeirodel=:enfermeirodel,fichainc=:fichainc,fichaman=:fichaman,fichadel=:fichadel  where id=:id">
            <SelectParameters><asp:ControlParameter Name="id" ControlId="GridView1" /></SelectParameters>
            <UpdateParameters><asp:ControlParameter Name="id" ControlId="GridView1" /></UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <div>
            <p>&nbsp;</p>
        </div>
    </center>    
    </div>
    </form>
</body>
</html>
