using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;



namespace LojaVirtual.DAL
    {

    #region propriedades
    public class ClienteDal

        {
        public int id { get; set; }

        public string nome { get; set; }

        public int cpf { get; set; }

        public string email { get; set; }
        
            

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome">Nome do cliente para cadastro</param>
        /// <param name="cpf">Numero do cpf</param>
        /// <param name="email">Email para contato</param>
        /// <returns></returns>
        public static int Cadastro ( ClienteDal cliente )
            {
            using(SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtualBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
                {

                conn.Open();


                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO Clientes ");
                //sql.Append("OUTPUT INSERTED.ID ");
                sql.Append("VALUES('" + cliente.nome + "',");
                sql.Append("'" + cliente.cpf + "', ");
                sql.Append("'" + cliente.email + "') ");
                sql.Append("SELECT @@identity");

                using(SqlCommand cmd = new SqlCommand(sql.ToString(),conn))
                    {

                   // return cmd.ExecuteNonQuery();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id para buscas</param>
        /// <returns></returns>
        public static ClienteDal Buscar ( int id )
            {
            using(SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtualBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
                {
                conn.Open();
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM Clientes ");
                sql.Append("WHERE id=" + id);

                using(SqlCommand cmd = new SqlCommand(sql.ToString(),conn))
                    {
                    cmd.Parameters.AddWithValue("@Id",id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    ClienteDal objCliente = new ClienteDal();

                    if(reader.Read())
                        {
                        objCliente.nome = reader["Nome"].ToString();
                        objCliente.cpf = Convert.ToInt32(reader["CPF"]);
                        objCliente.email = reader["Email"].ToString();
                        }
                    return objCliente;
                    }


                }
            }



        public  static List<ClienteDal> BuscarPorNome ( string busca )
            {
            using(SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtualBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
                {
                //tem q estar aberto!!!!
                conn.Open();

                //mudar para update
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM Clientes");
                sql.Append(" WHERE nome LIKE '%" + busca + "%'  ");

                using(SqlCommand cmd = new SqlCommand(sql.ToString(),conn))
                    {
                    // executa o comando e retorna o numeros de linhas afetadas!!!

                    using SqlDataReader reader = cmd.ExecuteReader();
                        {

                        List<ClienteDal> listacliente = new List<ClienteDal>();

                        while(reader.Read())
                            {
                            ClienteDal objcliente = new ClienteDal();
                            objcliente.nome = reader["Nome"].ToString();
                            objcliente.cpf = Convert.ToInt32(reader["Cpf"]);
                            objcliente.email = reader["Email"].ToString();

                            listacliente.Add(objcliente);
                            }

                        return listacliente;
                        }
                    }
                }
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id para buscar</param>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="cpf">numero do cpf</param>
        /// <param name="email">email para contato</param>
        public  static void Atualizar ( ClienteDal cliente )
            {

            using(SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtualBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
                {
                conn.Open();

                StringBuilder sql = new StringBuilder();

                sql.Append("UPDATE Clientes SET ");
                sql.Append("nome = '" + cliente.nome + "', ");
                sql.Append("cpf = '" + cliente.cpf + "', ");
                sql.Append("email = '" + cliente.email + "' ");
                sql.Append("WHERE id = '" + cliente.id + "'");


                using(SqlCommand cmd = new SqlCommand(sql.ToString(),conn))
                    {

                    cmd.ExecuteNonQuery();
                    }
                }
            }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id para deletar registro</param>
        public static void Deletar ( int id )
            {
            using(SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtualBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
                {
                conn.Open();

                StringBuilder sql = new StringBuilder();

                sql.Append("DELETE  FROM Clientes WHERE id =" + id);
                //sql.Append("Where id=" + id);

                using(SqlCommand cmd = new SqlCommand(sql.ToString(),conn))
                    {

                    cmd.ExecuteScalar();
                    }
                }
            }
        }
    }







