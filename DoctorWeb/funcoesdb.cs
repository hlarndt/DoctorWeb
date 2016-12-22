using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Windows.Forms;

namespace DoctorWeb
{
    class funcoesdb
    {
        internal static OdbcDataReader executasql(string sqlselect)
        {
            string connectionString = DoctorWeb.Properties.Settings.Default.DoctorMed;
            using (OdbcConnection con = new OdbcConnection(connectionString))
            {
                using (OdbcCommand cmdAcesso = new OdbcCommand(sqlselect, con))
                {
                    con.Open();
                    try
                    {
                        cmdAcesso.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro " + ex.Message);
                    }

                    OdbcDataReader drsretorno = cmdAcesso.ExecuteReader();
                    return drsretorno;
                }
            }
            throw new NotImplementedException();
        }

    }
}
