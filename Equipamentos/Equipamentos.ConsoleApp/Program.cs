using System;
using System.Linq;
using System.Data;

namespace Equipamentos.ConsoleApp
{
    class Program
    {
        #region VALIDAÇÃO 1 [OK]
        //nome menor que 6;
        #endregion

        static void Main(string[] args)
        {

            string[] nome = new string[99];
            bool nomeInvalido = false;
            string[] precoAquisicao = new string[99];
            string[] nSerie = new string[99];
            string[] data = new string[99];
            string[] fabricante = new string[99];
            int[] id = new int[99];
            string[] tituloChamado = new string[99];
            string[] descricao = new string[99];
            int[] id2 = new int[99];
            DateTime dataAberturaChamado = DateTime.Now;
            DateTime dataAberturaChamadoEditado;

            int cont = 0;
            int idEquipamento = 1;

            while (true)
            {
                MostraMenuPrincipal();

                Console.WriteLine("------Digite a opção escolhida------");
                string opcaoMenuPrincipal = Console.ReadLine();

                Console.Clear();

                if (opcaoMenuPrincipal.Equals("s", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                switch (opcaoMenuPrincipal)
                {

                    case "1":
                        //MENU EQUIPAMENTO
                        MostraMenuEquipamentos();

                        Console.WriteLine("Digite a opção escolhida: ");
                        string opcaoMenuEquipamentos = Console.ReadLine();

                        Console.Clear();

                        switch (opcaoMenuEquipamentos)
                        {
                            case "1":
                                RegistraEquipamentos(nome, ref nomeInvalido, precoAquisicao, nSerie, data, fabricante, id, ref cont, ref idEquipamento);
                                break;

                            case "2":
                                //visualisar equipamentos
                                VisualizaEquipamentos(nome, precoAquisicao, nSerie, data, fabricante, id, cont);

                                Console.ReadLine();
                                Console.Clear();
                                break;
                            //editar equipamneto
                            case "3":
                                VisualizaEquipamentos(nome, precoAquisicao, nSerie, data, fabricante, id, cont);

                                Console.WriteLine("Digite o id do equipamento que deseja editar: ");
                                int idEditar = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                Console.WriteLine("EDITAR EQUIPAMENTOS: ");
                                Console.WriteLine("Insira o nome do equipamento: ");
                                string nomeEditado = Console.ReadLine();
                                Console.WriteLine("Insira o preço de aquisição: ");
                                string precoAquisicaoEditado = Console.ReadLine();
                                Console.WriteLine("Insira o número de série: ");
                                string nSerieEditado = Console.ReadLine();
                                //data
                                Console.WriteLine("Insira a data: ");
                                string dataEditado = Console.ReadLine();
                                Console.WriteLine("Insira o fabricante: ");
                                string fabricanteEditado = Console.ReadLine();

                                for (int i = 0; i < cont; i++)
                                {
                                    if (nome[i] != null && precoAquisicao[i] != null && nSerie[i] != null && data[i] != null && fabricante[i] != null)
                                    {
                                        if (id[i] == idEditar)
                                        {
                                            nome.SetValue(nomeEditado, i);
                                            precoAquisicao.SetValue(precoAquisicaoEditado, i);
                                            nSerie.SetValue(nSerieEditado, i);
                                            data.SetValue(dataEditado, i);
                                            fabricante.SetValue(fabricanteEditado, i);
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Equipamento editado com sucesso.");
                                Console.ResetColor();

                                Console.ReadLine();
                                Console.Clear();
                                break;

                            //excluir
                            case "4":
                                VisualizaEquipamentos(nome, precoAquisicao, nSerie, data, fabricante, id, cont);

                                Console.WriteLine("Digite o id do equipamento que deseja excluir: ");
                                int idExcluir = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                for (int i = 0; i < cont; i++)
                                {
                                    if (nome[i] != null && precoAquisicao[i] != null && nSerie[i] != null && data[i] != null && fabricante[i] != null)
                                    {
                                        if (id[i] == idExcluir)
                                        {
                                            nome = nome.Where(val => val != nome[i]).ToArray();
                                            precoAquisicao = precoAquisicao.Where(val => val != precoAquisicao[i]).ToArray();
                                            nSerie = nSerie.Where(val => val != nSerie[i]).ToArray();
                                            data = data.Where(val => val != data[i]).ToArray();
                                            fabricante = fabricante.Where(val => val != fabricante[i]).ToArray();
                                            id = id.Where(val => val != id[i]).ToArray();
                                            cont--;
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Equipamento excluído com sucesso.");
                                Console.ResetColor();

                                Console.ReadLine();
                                Console.Clear();
                                break;

                            default: break;
                        }

                        break;
                    //MENU MANUTENÇÃO
                    case "2":
                        MostraMenuManutencao();

                        Console.WriteLine("Digite a opção escolhida: ");
                        string opcaoMenuChamados = Console.ReadLine();

                        Console.Clear();

                        switch (opcaoMenuChamados)
                        {
                            case "1":
                                Console.WriteLine("REALIZAR CHAMADO: ");

                                VisualizaEquipamentos(nome, precoAquisicao, nSerie, data, fabricante, id, cont);

                                Console.WriteLine("Insira o id do equipamento desejado: ");
                                int idChamado = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                Console.WriteLine("Insira o título do chamado: ");
                                tituloChamado[cont] = Console.ReadLine();
                                Console.WriteLine("Insira a descrição do chamado: ");
                                descricao[cont] = Console.ReadLine();
                                Console.WriteLine("Insira a data de abertura do chamado: ");
                                dataAberturaChamado = Convert.ToDateTime(Console.ReadLine());
                                id2[cont] = idChamado;
                                cont++;
                                idChamado++;
                                break;

                            //visualizar chamados
                            case "2":
                                VisualizaChamados(nome, tituloChamado, descricao, id2, dataAberturaChamado, cont);

                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "3":
                                VisualizaChamados(nome, tituloChamado, descricao, id2, dataAberturaChamado, cont);

                                Console.WriteLine("Digite o id do chamado que deseja editar: ");
                                int idEditarChamado = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                Console.WriteLine("EDIÇÃO DE CHAMADO: ");
                                Console.WriteLine("Insira o título do chamado: ");
                                string tituloEditado = Console.ReadLine();
                                Console.WriteLine("Insira a descrição do chamado: ");
                                string descricaoEditada = Console.ReadLine();
                                Console.WriteLine("Insira a data de abertura do chamado: ");
                                dataAberturaChamadoEditado = Convert.ToDateTime(Console.ReadLine());

                                for (int i = 0; i <= cont; i++)
                                {
                                    if (tituloChamado[i] != null && descricao[i] != null)
                                    {
                                        if (id2[i] == idEditarChamado)
                                        {
                                            tituloChamado.SetValue(tituloEditado, i);
                                            descricao.SetValue(descricaoEditada, i);
                                            dataAberturaChamado = dataAberturaChamadoEditado;
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Chamado editado com sucesso.");
                                Console.ResetColor();

                                Console.ReadLine();
                                Console.Clear();

                                break;
                            case "4":
                                VisualizaChamados(nome, tituloChamado, descricao, id2, dataAberturaChamado, cont);

                                Console.WriteLine("Digite o id do chamado que deseja exluir: ");
                                int idExcluirChamado = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                Console.WriteLine("EXCLUSÃO DE CHAMADO: ");
                                for (int i = 0; i <= cont; i++)
                                {
                                    if (tituloChamado[i] != null && descricao[i] != null)
                                    {
                                        if (id2[i] == idExcluirChamado)
                                        {
                                            tituloChamado = tituloChamado.Where(val => val != tituloChamado[i]).ToArray();
                                            descricao = descricao.Where(val => val != descricao[i]).ToArray();
                                            dataAberturaChamado = DateTime.MinValue;
                                            cont--;
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Chamado excluído com sucesso.");
                                Console.ResetColor();

                                break;
                        }



                     break;
                }
            }
        }

        private static void VisualizaChamados(string[] nome, string[] tituloChamado, string[] descricao, int[] id2, DateTime dataAberturaChamado, int cont)
        {
            for (int i = 0; i <= cont; i++)
            {
                if (tituloChamado[i] != null && descricao[i] != null)
                {
                    Console.WriteLine($"Id do chamado {id2[i]}");
                    Console.WriteLine("Título do chamado: " + tituloChamado[i]);
                    Console.WriteLine("Equipamento: " + nome[i]);
                    Console.WriteLine("Data de abertura: " + dataAberturaChamado);
                    //contar dias
                    //TimeSpan diferenca = dataAberturaChamado.Subtract(dataAberturaChamadoEditado);
                    //Console.WriteLine("Número de dias que o chamado está aberto: ");
                    Console.WriteLine(" ");
                }
            }
        }

        private static void MostraMenuManutencao()
        {
            Console.WriteLine("MENU DE MANUTENÇÃO: ");
            Console.WriteLine("------escolha uma opção------");

            Console.WriteLine("1 - registrar chamado de manutenções que são efetuadas nos equipamentos registrados; ");
            Console.WriteLine("2 - visualizar todos os chamados registrados para controle;");
            Console.WriteLine("3 - editar um chamado;");
            Console.WriteLine("4 - excluir um chamado;");
        }

        private static void VisualizaEquipamentos(string[] nome, string[] precoAquisicao, string[] nSerie, string[] data, string[] fabricante, int[] id, int cont)
        {
            for (int i = 0; i <= cont; i++)
            {
                if (nome[i] != null && precoAquisicao[i] != null && nSerie[i] != null && data[i] != null && fabricante[i] != null)
                {
                    Console.WriteLine($"Id do equipamento {id[i]}");
                    Console.WriteLine("Nome: " + nome[i]);
                    Console.WriteLine("Preço: " + precoAquisicao[i]);
                    Console.WriteLine("Número de série: " + nSerie[i]);
                    Console.WriteLine("Data de fabricação: " + data[i]);
                    Console.WriteLine("Fabricante: " + fabricante[i]);
                    Console.WriteLine(" ");
                }
            }
        }

        private static void RegistraEquipamentos(string[] nome, ref bool nomeInvalido, string[] precoAquisicao, string[] nSerie, string[] data, string[] fabricante, int[] id, ref int cont, ref int idEquipamento)
        {
            Console.WriteLine("REGISTRAR EQUIPAMENTOS: ");
            do
            {
                Console.WriteLine("Insira o nome do equipamento: ");
                nome[cont] = Console.ReadLine();
                if (nome[cont].Length < 6)
                {
                    nomeInvalido = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nome inválido! No mínimo 6 caracteres. Tente novamente.");
                    Console.ResetColor();
                }
            } while (nomeInvalido);

            Console.WriteLine("Insira o preço de aquisição: ");
            precoAquisicao[cont] = Console.ReadLine();
            Console.WriteLine("Insira o número de série: ");
            nSerie[cont] = Console.ReadLine();
            //data
            Console.WriteLine("Insira a data de fabricação: ");
            data[cont] = Console.ReadLine();
            Console.WriteLine("Insira o fabricante: ");
            fabricante[cont] = Console.ReadLine();
            id[cont] = idEquipamento;
            cont++;
            idEquipamento++;
        }

        private static void MostraMenuEquipamentos()
        {
            Console.WriteLine("MENU EQUIPAMENTOS: ");
            Console.WriteLine("------escolha uma opção------");

            Console.WriteLine("1 - registrar equipamento;");
            Console.WriteLine("2 - visualizar todos os equipamentos registrados no inventário;");
            Console.WriteLine("3 - editar um equipamento;");
            Console.WriteLine("4 - excluir um equipamento;");
        }

        private static void MostraMenuPrincipal()
        {
            Console.WriteLine("MENU PRINCIPAL");
            Console.WriteLine("------escolha uma opção------");
            Console.WriteLine("1 - Acessar menu equipamentos;");
            Console.WriteLine("2 - Acessar menu de manutenção;");
            Console.WriteLine("s - para sair do menu;");
        }
    }
}