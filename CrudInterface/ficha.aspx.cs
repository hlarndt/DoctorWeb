using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace CrudInterface
{
    public partial class ficha : System.Web.UI.Page
    {
        protected void form1_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Server.Transfer("logoff.aspx", true);
            }
        }
    }
}
