using System.Data;
using System.Globalization;
using Gerenciador_Tarefas.Models;
using Newtonsoft.Json;

string op = " ";

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
    Console.WriteLine("[4] Salvar e Sair");
    Console.WriteLine();
    Console.Write("Opção: ");
    op = Console.ReadLine();

    switch (op)
    {
        case "1":

            Tarefa novaTarefa = Tarefa.AdicionarTarefa();
            ListaDeTerefas.Add(novaTarefa);

            break;
        case "2":
            string nomeTarefa;

            Tarefa.VisualizarTabelaPendentes(ListaDeTerefas);

            Console.WriteLine("\nDigite o nome da tarefa que será apagada: ");
            nomeTarefa = Console.ReadLine() ?? " ";

            Tarefa.RemoverTarefaPeloNome(nomeTarefa, ListaDeTerefas);

            break;
        case "3":

            Tarefa.VisualizarTabelaPendentes(ListaDeTerefas);

            break;
        case "4":

            string output = JsonConvert.SerializeObject(ListaDeTerefas, Formatting.Indented);
            File.WriteAllText("Arquivos/tarefas.json", output);
            Console.Write("Tarefas salvas com sucesso");
            return;

        default:

            break;
    }

} while (true);


