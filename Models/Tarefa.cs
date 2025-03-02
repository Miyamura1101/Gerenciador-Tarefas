using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_Tarefas.Models
{
    public class Tarefa
    {
        public Tarefa(string nomeTarefa, DateTime dataVenciomento, string prioridade)
        {
            NomeTarefa = nomeTarefa;
            DataVencimento = dataVenciomento;
            Prioridade = prioridade;

        }
        private string _nomeTarefa;
        private DateTime _dataVencimento;
        private string _prioridade;

        public string NomeTarefa
        {
            get => _nomeTarefa;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O nome não pode está vazio");
                }

                _nomeTarefa = value;
            }
        }
        public DateTime DataVencimento
        {
            get => _dataVencimento;
            set
            {
                try
                {
                    _dataVencimento = value;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public string Prioridade
        {
            get => _prioridade;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O nome não pode está vazio");
                }

                _prioridade = value;
            }
        }

        public static Tarefa AdicionarTarefa()
        {
            try
            {
                Console.Write("Digite o nome da tarefa: ");
                string nome = Console.ReadLine() ?? string.Empty;

                DateTime DataVenciomento;
                do
                {
                    Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");
                    string inputData = Console.ReadLine() ?? string.Empty;

                    if (!DateTime.TryParseExact(inputData, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DataVenciomento))
                    {
                        break;
                    }

                } while (true);

                string prioridade = " ";
                do
                {
                    if (prioridade != " ")
                    {
                        Console.WriteLine("As unicas opções são Alta / Media / Baixa");
                    }

                    Console.Write("Escolha a Prioridade: ");
                    Console.Write("- Alta");
                    Console.Write("- Media");
                    Console.Write("- Baixa");

                    prioridade = Console.ReadLine()!.ToUpper();

                } while (prioridade != "ALTA" || prioridade != "MEDIA" || prioridade != "BAIXA");


                return new Tarefa(nome, DataVenciomento, prioridade);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                return new Tarefa(nomeTarefa: "Tarefa Inválida", dataVenciomento: DateTime.Parse("01/01/0001"), prioridade: "N/A");
            }
        }

        public static void RemoverTarefaPeloNome(string nome, List<Tarefa> ListaTarefas)
        {
            //FirstOrDefault -> serve para procurar algo na lista e se achar não vai até o final da lista
            Tarefa tarefaASerRemovida = ListaTarefas.FirstOrDefault(item => (item.NomeTarefa == nome))!;

            if (tarefaASerRemovida != null)
            {
                Console.WriteLine("Tarefa romivada");
                ListaTarefas.Remove(tarefaASerRemovida);
                
            }
            else
            {
                Console.WriteLine("A terefa que foi passada não existe!!!");
            }
        }

        public static void VisualizarTabelaPendentes(List<Tarefa> ListaTarefasPendentes)
        {
            int cont = 0;
            foreach (Tarefa item in ListaTarefasPendentes)
            {
                Console.WriteLine($"{cont++} - tarefa");
                Console.WriteLine($"Nome da Tarefa: {item.NomeTarefa}");
                Console.WriteLine($"Data de vencimento (dd/MM/yyyy): {item.DataVencimento}");
                Console.WriteLine($"Prioridade: {item.Prioridade}\n");
            }
            Console.Read();
        }
    }
}