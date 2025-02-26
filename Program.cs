using System.Data;
using System.Globalization;
using Gerenciador_Tarefas.Models;

string op = " ";
bool FinaliarPrograma = true;

List<Tarefa> ListaDeTerefasPendentes = new List<Tarefa>();
Stack<Tarefa> ListaDeTaredasRealizadas = new Stack<Tarefa>();

do
{

    Console.WriteLine("[1] Adicionar Tarefa");
    Console.WriteLine("[2] Remover Tarefa");
    Console.WriteLine("[3] Visualizar Tarefas Pendentes");
    Console.WriteLine("[4] Concluir Tarefa");
    Console.WriteLine("[5] Histórico de Tarefas Concluídas");
    Console.WriteLine("[6] Sair");
    Console.WriteLine();
    Console.Write("Opção: ");
    op = Console.ReadLine();

    switch (op)
    {
        case "1":
            Tarefa novaTarefa = Tarefa.AdicionarTarefa();

            if (novaTarefa != null)
            {
                ListaDeTerefasPendentes.Add(novaTarefa);
                Console.WriteLine("Tarefa inserida com sucesso");
            }
            else
            {
                Console.WriteLine("A terefa não foi inicializada devido a um erro ");
            }
                break;
        case "2":
            string nomeTarefa;

            Tarefa.VisualizarTabelaPendentes(ListaDeTerefasPendentes);

            Console.WriteLine("\nDigite o nome da tarefa que será apagada: ");
            nomeTarefa = Console.ReadLine();

            Tarefa.RemoverTaredaPeloNome(nomeTarefa, ListaDeTerefasPendentes);

            break;
        case "3":

            Tarefa.VisualizarTabelaPendentes(ListaDeTerefasPendentes);
            
            break;
        case "4":

            break;
        case "5":
        
            break;
        case "6":
            FinaliarPrograma = false;
            break;
        default:

            break;
    }

} while (FinaliarPrograma);


