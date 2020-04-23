using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;

namespace Repositorios
{
    public class RepoProducto : IRepositorio<Producto>
    {
        public bool Alta(Producto obj)
        {

            {
                bool ret = false;

                //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
                string strCon = "Data Source=(local)\\MSSQLSERVER; Initial Catalog=BaseDistribuidora; Integrated Security=SSPI;";
                SqlConnection con = new SqlConnection(strCon);

                string sql = "insert into Clientes(Nombre, Apellido, RazonSocial, Telefono) values(@nom, @ape, @razon, @tel);";
                SqlCommand com = new SqlCommand(sql, con);

                com.Parameters.AddWithValue("@nom", obj.Nombre);
                com.Parameters.AddWithValue("@ape", obj.PesoUnidad);
                com.Parameters.AddWithValue("@tel", obj.Precio);

                try
                {
                    con.Open();
                    int afectadas = com.ExecuteNonQuery();
                    con.Close();

                    ret = afectadas == 1;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }

                return ret;
            }

            
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Producto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Producto obj)
        {
            throw new NotImplementedException();
        }

        public List<Producto> TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}
