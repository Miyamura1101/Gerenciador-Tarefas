using System.Data;
using System.Globalization;
using Gerenciador_Tarefas.Models;
using Newtonsoft.Json;

string op = " ";
bool FinaliarPrograma = true;

List<Tarefa> ListaDeTerefas = new List<Tarefa>();

if (File.Exists("Arquivos/tarefas.json"))
{
    Console.WriteLine("Deseja pegar os dados salvos(N/Y):");
    string save = Console.ReadLine().ToUpper();

    if (save == "Y")
    {
        string ListaTarefasArquivo = File.ReadAllText("Arquivos/tarefas.json");
        ListaDeTerefas = JsonConvert.DeserializeObject<List<Tarefa>>(ListaTarefasArquivo);
    }
}

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
                ListaDeTerefas.Add(novaTarefa);
                Console.WriteLine("Tarefa inserida com sucesso");
            }
            else
            {
                Console.WriteLine("A terefa não foi inicializada devido a um erro ");
            }
            break;
        case "2":
            string nomeTarefa;

            Tarefa.VisualizarTabelaPendentes(ListaDeTerefas);

            Console.WriteLine("\nDigite o nome da tarefa que será apagada: ");
            nomeTarefa = Console.ReadLine();

            Tarefa.RemoverTaredaPeloNome(nomeTarefa, ListaDeTerefas);

            break;
        case "3":

            Tarefa.VisualizarTabelaPendentes(ListaDeTerefas);

            break;
        case "4":

            break;
        case "5":

            break;
        case "6":

            string output = JsonConvert.SerializeObject(ListaDeTerefas, Formatting.Indented);

            File.WriteAllText("Arquivos/tarefas.json", output);

            FinaliarPrograma = false;
            break;
        default:

            break;
    }

} while (FinaliarPrograma);


