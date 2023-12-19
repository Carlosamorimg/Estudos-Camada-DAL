using LojaVirtual.DAL;
using System;

/*
 //instancia da classe departamentoDAL
departamentoDal departamentoDAL = new departamentoDal();

//int idInserido = departamentoDAL.Cadastrar("Bebidas","Bebidas para beber.",DateTime.Now);

departamentoDAL.Nome = "trstes";
departamentoDAL.Descricao = "ffgfgfgfgfgf";
departamentoDAL.DataCadastro = DateTime.Now;

int idInserido = departamentoDal.Cadastro(departamentoDAL);

Console.WriteLine("dados cadastrados!!!");


//buscar um objeto (Detalhes da entidade ou para edição)
departamentoDal objRetornado = departamentoDal.Buscar(1);
Console.WriteLine("Descrição:");
Console.WriteLine(objRetornado.Descricao);

Console.WriteLine("Nome:");
Console.WriteLine(objRetornado.Nome);


//buscar umas lista de objeto
List<departamentoDal> listaDep = departamentoDal.BuscarPorNome("carlos");

//percorre a lista que veio da DAL
foreach (var departamento in listaDep)
{
//exibe o objeto que está passando no momento.
Console.WriteLine("Descrição:");
Console.WriteLine(departamento.Descricao);

Console.WriteLine("Nome:");
Console.WriteLine(departamento.Nome);
}




///update     
departamentoDAL.Nome = "trstes";
departamentoDAL.Descricao = "ffgfgfgfgfgf";
departamentoDAL.Id = 10;
departamentoDAL.DataCadastro = DateTime.Now;

departamentoDAL.Atualizar(departamentoDAL);
Console.WriteLine("dados atualizados!!!");


//delete
departamentoDAL.Remover(10);
Console.WriteLine("dados removidos!!!");





// Se desejar, você pode adicionar mais código aqui.

Console.ReadLine(); // Aguarda o usuário pressionar Enter antes de fechar o console.*/





Console.WriteLine("              Bem vindo ");
Console.ReadKey();
Console.WriteLine("               Escolha sua Opção:\n");
Console.WriteLine("   1 Cadastro de Clientes\n   2 Cadastro de Departamentos\n   3 buscar clientes\n   4 buscar departamentos\n  " +
    " 5 buscar 1 Cliente\n   6 buscar 1 departamento\n   7 Editar clientes\n   8 Editar departamentos\n   9 Excluir cliente\n  " +
    " 10 Excluir Departamento\n   11 Sair\n\n");


int opcao = Convert.ToInt32(Console.ReadLine());
bool execucao = true;



while(execucao == true)
    {
    switch(opcao)
        {
        #region cadastro
        case 1:

            try
                {

                ClienteDal clienteDal = new ClienteDal();
                

               


                Console.WriteLine("             Cadastro de Clientes");

                Console.WriteLine("Digite o Nome: ");

                clienteDal.nome = Console.ReadLine();


                Console.WriteLine("\nDigite o CPF: ");
                clienteDal.cpf = Convert.ToInt16(Console.ReadLine());


                Console.WriteLine("\nDigite o Email: ");
                clienteDal.email = Console.ReadLine();
                Console.Clear();
                int idInserido = ClienteDal.Cadastro(clienteDal);

                Console.WriteLine("\n\nOs dados digitados foram:\nNome:" + clienteDal.nome + "\nCPF: " + clienteDal.cpf + "\nEmail: " + clienteDal.email);
                Console.ReadKey();

                Console.Clear();
                execucao = false;

                Console.WriteLine("Deseja cadastrar outro Cliente?  Sim  ou Nao");
                string escolhacad=Console.ReadLine();
                if (escolhacad == "sim")
                    {
                    execucao = true;
                    }
                else
                    {
                    execucao = false;
                    }
                }
            catch(Exception e)
                {
                Console.WriteLine($"Ocorreu um erro: {e.Message}");
                execucao = false;
                }
            break;



        case 2:

            try
                {
                departamentoDal dep = new departamentoDal();



                Console.WriteLine("             Cadastro de Departamentos");

                Console.WriteLine("Digite o Nome do Departamento: ");
                dep.Nome = Console.ReadLine();


                Console.WriteLine("\nDigite a Descrição do departamento: ");
                dep.Descricao = Console.ReadLine();


               
                Console.Clear();
                int idInseridodep = departamentoDal.Cadastro(dep);
                Console.WriteLine("\n\nOs dados digitados foram:\nNome:" + dep.Nome + "\nDescrição: " + dep.Descricao + "\nData de Cadastro: " + dep.DataCad);
               

                Console.Clear();
                execucao = false;

                Console.WriteLine("Deseja cadastrar outro Departamento?  Sim  ou Nao");
                string escolhacad = Console.ReadLine();
                if(escolhacad == "sim")
                    {
                    execucao = true;
                    }
                else
                    {
                    execucao = false;
                    }
                }
            catch(Exception e)
                {
                Console.WriteLine($"Ocorreu um erro: {e.Message}");
                execucao = false;
                }
            break;

        #endregion
        #region Buscar ID
        case 3:
            try
                {
                ClienteDal Cliente = new ClienteDal();

                Console.WriteLine("Informe o ID do Cliente: ");
                int idBusca = Convert.ToInt16(Console.ReadLine());



                
                ClienteDal objCliente = ClienteDal.Buscar(idBusca);

               
                if(objCliente != null)
                    {
                    
                    Console.WriteLine("Nome: " + objCliente.nome);
                    Console.WriteLine("CPF: " + objCliente.cpf);
                    Console.WriteLine("Email: " + objCliente.email);
                    Console.ReadKey();

                    Console.Clear();
                    execucao = false;

                    Console.WriteLine("Deseja Buscar outro Cliente?  Sim  ou Nao");
                    string escolhaBus= Console.ReadLine();
                    if(escolhaBus == "sim")
                        {
                        execucao = true;
                        }
                    else
                        {
                        execucao = false;
                        }
                    }
                else
                    {
                    Console.WriteLine("Cliente não encontrado.");
                    }
                }
            catch(Exception ex)
                {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                }


            break;

        case 4:
            try
                {
                departamentoDal Departamento = new departamentoDal();

                Console.WriteLine("Informe o ID do Departamento: ");
                int idBusca = Convert.ToInt16(Console.ReadLine());

                departamentoDal objDepartamento = new departamentoDal();

                if(objDepartamento != null)
                    {
                    
                    Console.WriteLine("\nNome: " + objDepartamento.Nome);
                    Console.WriteLine("Descrição: " + objDepartamento.Descricao);
                    Console.WriteLine("Data de Cadastro: " + objDepartamento.DataCad);

                    Console.ReadKey();

                    Console.Clear();
                    execucao = false;

                    Console.WriteLine("Deseja Buscar outro Departamento?  Sim  ou Nao");
                    string escolhaBus = Console.ReadLine();
                    if(escolhaBus == "sim")
                        {
                        execucao = true;
                        }
                    else
                        {
                        execucao = false;
                        }
                    }
                else
                    {
                    Console.WriteLine("Cliente não encontrado.");
                    execucao = false;
                    }
                }
            catch(Exception ex)
                {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                execucao |= false;
                }


            break;
        #endregion
        #region buscar nome
        case 5:
            try
                {
                Console.WriteLine("Digite o nome para buscar: ");
                List<ClienteDal> listaCliente = ClienteDal.BuscarPorNome(Console.ReadLine());





                foreach(var cliente1 in listaCliente)
                    {

                    Console.WriteLine("\nNome :" + cliente1.nome);
                    Console.WriteLine("CPF : " + cliente1.cpf);
                    Console.WriteLine("Email : " + cliente1.email);

                    Console.Clear();
                    execucao = false;

                    Console.WriteLine("Deseja Buscar outro Cliente?  Sim  ou Nao");
                    string escolhabus = Console.ReadLine();
                    if(escolhabus == "sim")
                        {
                        execucao = true;
                        }
                    else
                        {
                        execucao = false;
                        }

                    }
                }
            catch(Exception e)
                {
                Console.WriteLine("Ocorreu um erro: " + e.Message);
                execucao = false;

                }
            break;

        case 6:
            try
                {
                Console.WriteLine("Digite o nome para buscar: ");

                List<departamentoDal> listaDepartamento = departamentoDal.BuscarPorNome(Console.ReadLine());





                foreach(var departamento1 in listaDepartamento)
                    {

                    Console.WriteLine("\nNome :" + departamento1.Nome);
                    Console.WriteLine("Descrição : " + departamento1.Descricao);
                    Console.WriteLine("Data de Cadastro : " + departamento1.DataCad);

                    Console.Clear();
                    execucao = false;

                    Console.WriteLine("Deseja buscar outro Departamento?  Sim  ou Nao");
                    string escolhabus = Console.ReadLine();
                    if(escolhabus == "sim")
                        {
                        execucao = true;
                        }
                    else
                        {
                        execucao = false;
                        }
                    }
                }
            catch(Exception e)
                {
                Console.WriteLine("Ocorreu um erro: " + e.Message);
                execucao = false;

                }
            break;
        #endregion
        #region Edição
        case 7:
            try
                {
                ClienteDal cliente = new ClienteDal();

                cliente.id = Convert.ToInt32(Console.ReadLine());
                cliente.nome = Console.ReadLine();
                cliente.cpf = Convert.ToInt16(Console.ReadLine());
                cliente.email = Console.ReadLine();



                ClienteDal.Atualizar(cliente);
                Console.WriteLine("dados atualizados!!!");
                Console.Clear();
                execucao = false;

                Console.WriteLine("Deseja Alterar outro Cliente?  Sim  ou Nao");
                string escolhaAtu = Console.ReadLine();
                if(escolhaAtu == "sim")
                    {
                    execucao = true;
                    }
                else
                    {
                    execucao = false;
                    }
                }
            catch(Exception e)
                {
                Console.WriteLine("Ocorreu um erro: " + e.Message);
                execucao = false;

                }
            break;

        case 8:
            try
                {
                departamentoDal departamento = new departamentoDal();

                Console.WriteLine("Digite o ID do departamento:");
                departamento.Id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite o novo nome do departamento:");
                departamento.Nome = Console.ReadLine();

                Console.WriteLine("Digite a nova descrição do departamento:");
                departamento.Descricao = Console.ReadLine();

                departamentoDal.Atualizar(departamento);
                Console.WriteLine("Dados atualizados!!!");

                Console.Clear();
                execucao = false;

                Console.WriteLine("Deseja Alterar outro Departamento?  Sim  ou Nao");
                string escolhaAtu = Console.ReadLine();
                if(escolhaAtu == "sim")
                    {
                    execucao = true;
                    }
                else
                    {
                    execucao = false;
                    }
                }
            catch(Exception e)
                {

                Console.WriteLine("Ocorreu um erro: " + e.Message);
                execucao = false;
                }
            break;
        #endregion
        #region Deletar
        case 9:
            try
                {
                Console.WriteLine("Digite o ID para deletar");
                ClienteDal.Deletar(Convert.ToInt16(Console.ReadLine()));
                Console.WriteLine("dados removidos!!!");
                Console.ReadKey();
                Console.Clear();
                execucao = false;

                Console.WriteLine("Deseja Deletar outro Cliente?  Sim  ou Nao");
                string escolhaRemover = Console.ReadLine();
                if(escolhaRemover == "sim")
                    {
                    execucao = true;
                    }
                else
                    {
                    execucao = false;
                    }
                }
            catch(Exception e)
                {
                Console.WriteLine("Ocorreu um erro: " + e.Message);
                execucao = false;

                }

            break;

        case 10:
            
                Console.WriteLine("Digite o Id para Deletar Departamento:");
                departamentoDal.Remover(Convert.ToInt16(Console.ReadLine()));
                Console.WriteLine("dados removidos!!!");
                Console.ReadKey();

                Console.Clear();
                execucao = false;

                Console.WriteLine("Deseja Deletar outro Departamento?  Sim  ou Nao");
                string escolhaRemov = Console.ReadLine();
                if(escolhaRemov == "sim")
                    {
                    execucao = true;
                    }
                else
                    {
                    execucao = false;
                    }
                
            

            break;
        #endregion
        case 11:
            Console.WriteLine("Fim da Execuçção");
            execucao = false;

            break;

        default:
            Console.WriteLine("Opção invalida!!!!");
            execucao = false;
            break;

        }

    }

