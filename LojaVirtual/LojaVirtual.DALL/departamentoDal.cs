using Microsoft.VisualBasic;  // biblioteca do Visual Basic, contem clases e funcionalidades.
using System; //contém tipos fundamentais e primitivos, como Object, e fornece acesso a várias funcionalidades básicas do .NET.
using System.Collections.Generic;// fornece coleções genéricas como List<T>
using System.Data.SqlClient; //é usado para interagir com o SQL Server
using System.Diagnostics.Metrics; // é usado para instrumentação de métricas
using System.Linq; //  fornece funcionalidades relacionadas à consulta de dados em coleções
using System.Text; // fornece classes e métodos para manipular caracteres e strings. 
using System.Threading.Tasks; //oferece suporte ao modelo de programação assíncrona e paralela em C#. Ele fornece classes como
                              //Task e Task<TResult>, 



namespace LojaVirtual.DAL // namespace é usado para uma organização logica do codigo. -----
                          // DAL é a camada de relação com o banco de dados "Data Access Layer"
    {

    public class departamentoDal // declaração da Classe
        {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCad { get; set; }

        public departamentoDal ()
            {
            this.DataCad = DateTime.Now;
            }


        /// <summary> fornece informações sobre o metodo
        /// cadastro informações para uma nova categoria
        /// </summary>
        /// <param name="Nome">nome cadastrado</param> informaçoes dos parametros
        /// <param name="Descricao">descrição produto cadastrado</param>
        /// <param name="DataCadastro">data do cadastro do produto</param>
        public static int Cadastro ( departamentoDal departamentos )

            {

            // instanciação da Classe que conecta com o banco de dados
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtualBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            // tem que estar aberto
            conn.Open();// abertura da conexão com o banco de dados

            StringBuilder sql = new StringBuilder();// Criação de uma instância de StringBuilder. Este objeto será usado para construir
                                                    // dinamicamente a instrução SQL.
            sql.Append("set dateformat dmy ");// Adiciona uma instrução SQL para definir o formato da data como "dia/mês/ano". 
            sql.Append("INSERT INTO departamentos ");// Adiciona uma parte da instrução SQL para inserção de dados na tabela
            sql.Append("values('" + departamentos.Nome + "',");
            sql.Append("'" + departamentos.Descricao + "')");
            sql.Append("SELECT @@identity"); // pesquisar Adiciona uma parte da instrução SQL para recuperar o último valor
                                             // de identidade inserido na tabela. 

            SqlCommand cmd = new SqlCommand(sql.ToString(),conn);
            // executa o comando e retorna o numero de linhas afetadas
            //Criação de uma instância da classe SqlCommand. Essa classe representa um comando SQL a ser executado em um banco de dados.
            //O construtor recebe a instrução SQL e a conexão à qual o comando está associado.

            return Convert.ToInt32(cmd.ExecuteScalar());//Executa o comando SQL usando o método ExecuteScalar(). Este método é usado quando
                                                        //se espera que a consulta retorne uma única valor (como é o caso com SELECT @@identity).
                                                        //O resultado é convertido para um inteiro e retornado. Isso geralmente representa o ID
                                                        //do último registro inserido na tabela "Departamentos".


            }

        /// <summary>
        /// atualização de informações cadastradas
        /// </summary>
        /// <param name="id">id  para consultas</param>
        /// <param name="Nome"></param>
        /// <param name="Descricao"></param>
        /// <param name="DataCadastro"></param>
        public static void Atualizar ( departamentoDal departamentos )

            {
            using SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtualBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
                {
                // tem que estar aberto
                conn.Open();
                StringBuilder sql = new StringBuilder();


                sql.Append("UPDATE departamentos SET ");
                sql.Append("nome = '" + departamentos.Nome + "', ");
                sql.Append("descricao = '" + departamentos.Descricao + "' ");

                sql.Append("WHERE Id = '" + departamentos.Id + "'");

                using SqlCommand cmd = new SqlCommand(sql.ToString(),conn);
                    {
                    // executa o comando e retorna o numero de linhas afetadas
                    // classe SqlCommand para executar um comando SQL que não retorna um conjunto de resultados 

                    cmd.ExecuteNonQuery(); // é um método da classe SqlCommand que é usado para executar comandos que não retornam dados, como comandos
                                           // INSERT, UPDATE ou DELETE. Neste caso, o comando SQL contido em cmd 
                                           // será executado, e o método retornará o número de linhas afetadas pela execução do comando.
                    }
                }
            }



        /// <summary>
        /// Remover itens cadastrados
        /// </summary>
        /// <param name="id">id item</param>
        public static void Remover ( int id )

            {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtualBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            // tem que estar aberto
            conn.Open();
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE  FROM departamentos WHERE id =" + id);
            //sql.Append("WHERE id=" + id);

            using SqlCommand cmd = new SqlCommand(sql.ToString(),conn);
                {
                // executa o comando e retorna o numero de linhas afetadas

                cmd.ExecuteScalar();
                }
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public static departamentoDal Buscar ( int id )
            {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtualBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            // tem que estar aberto
            conn.Open();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  FROM Departamento ");
            sql.Append("WHERE id=" + id);

            SqlCommand cmd = new SqlCommand(sql.ToString(),conn);
            // executa o comando e retorna o numero de linhas afetadas

            SqlDataReader reader = cmd.ExecuteReader(); //Execução do comando SQL usando ExecuteReader(),
                                                        //que retorna um SqlDataReader. Este objeto permite a
                                                        //leitura sequencial dos resultados da consulta.

            departamentoDal objDepartamento = new departamentoDal();

            if(reader.Read()) //Verificação se o SqlDataReader possui linhas de resultado (HasRows).
                              //Se houver linhas, os dados do departamento são lidos do leitor (reader)
                              //e atribuídos às propriedades do objeto objDepartamento.
                {
                objDepartamento.Nome = reader["Nome"].ToString();
                objDepartamento.Descricao = reader["Nome"].ToString();
                objDepartamento.DataCad = Convert.ToDateTime(reader["DataCadastro"].ToString());
                //
                }

            return objDepartamento;
            }


        public static List<departamentoDal> BuscarPorNome ( string busca )
            {
            using SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtualBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
                {
                //tem q estar aberto!!!!
                conn.Open();

                //mudar para update
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM Departamentos");
                sql.Append(" WHERE nome LIKE'%" + busca + "%'  ");

                SqlCommand cmd = new SqlCommand(sql.ToString(),conn);
                // executa o comando e retorna o numeros de linhas afetadas!!!

                SqlDataReader reader = cmd.ExecuteReader();

                List<departamentoDal> listaDepartamentos = new List<departamentoDal>();

                while(reader.Read())
                    {
                    departamentoDal objDepartamento = new departamentoDal();
                    objDepartamento.Nome = reader["Nome"].ToString();
                    objDepartamento.Descricao = reader["Descricao"].ToString();
                    // objDepartamento.DataCadastro = Convert.ToDateTime(reader["DataCadastro"].ToString());

                    listaDepartamentos.Add(objDepartamento);
                    }

                return listaDepartamentos;
                }
            }
        }
    }

