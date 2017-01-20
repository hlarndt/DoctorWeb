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
            <% if (Session["usuarioLogadoID"] != null) { %>
           <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <% if (Session["acessos"].ToString().Substring(0,3).IndexOf("1") != -1) %>
                    <% { %>
                        <li><a href="/usuarios.aspx">Usuários</a></li>
                    <% } %>
                    <% if (Session["acessos"].ToString().Substring(3,3).IndexOf("1") != -1) %>
                    <% { %>
                        <li><a href="/pacientes.aspx">Pacientes</a></li>
                    <% } %>
                    <% if (Session["acessos"].ToString().Substring(6,3).IndexOf("1") != -1) %>
                    <% { %>
                        <li><a href="/convenios.aspx">Convênios</a></li>
                    <% } %>
                    <% if (Session["acessos"].ToString().Substring(9,3).IndexOf("1") != -1) %>
                    <% { %>
                        <li><a href="/movimentos.aspx">Movimentos</a></li>
                    <% } %>
                    <% if (Session["acessos"].ToString().Substring(12,1).IndexOf("1") != -1) %>
                    <% { %>
                        <li><a href="/relatorios.aspx">Relatórios</a></li>
                    <% } %>
                    <% if (Session["acessos"].ToString().Substring(13,1).IndexOf("1") != -1) %>
                    <% { %>
                        <li><a href="/graficos.aspx">Gráficos</a></li>
                    <% } %>
                    <li><a href="/Logoff.aspx">Logoff</a></li>
               </ul>
            </div>
            <% } %>
        </div>
    </div>
    <div class="container body-content">
        



    </div>
