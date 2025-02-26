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
                string? nome = Console.ReadLine();

                Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");
                string? inputData = Console.ReadLine();

                if (!DateTime.TryParseExact(inputData, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime DataVenciomento))
                {
                    throw new ArgumentException("Data Inválida, user o formato dd/MM/yyyy");
                }

                Console.Write("Escolha a Prioridade (Alta/Media/Baixa): ");
                string? prioridade = Console.ReadLine();

                return new Tarefa(nome, DataVenciomento, prioridade);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static void RemoverTaredaPeloNome(string nome, List<Tarefa> ListaTarefas)
        {
            Tarefa tarefaASerRemovida = null;
            foreach (Tarefa item in ListaTarefas)
            {
                if (item.NomeTarefa == nome)
                {
                    tarefaASerRemovida = item;
                }
            }

            if (tarefaASerRemovida != null)
            {
                ListaTarefas.Remove(tarefaASerRemovida);
            }
        }

        public static void VisualizarTabelaPendentes(List<Tarefa> ListaTarefasPendentes)
        {
            int cont = 0;
            foreach (Tarefa item in ListaTarefasPendentes)
            {
                Console.WriteLine($"{cont + 1} - tarefa");
                Console.WriteLine($"Nome da Tarefa: {item.NomeTarefa}");
                Console.WriteLine($"Data de vencimento (dd/MM/yyyy): {item.DataVencimento}");
                Console.WriteLine($"Prioridade: {item.Prioridade}\n");
            }
            Console.Read();
        }
    }
}