
using System.Text;

namespace lesson_5;

class Program
{
    static string? userName = null;
    static List<string> tasks = new List<string>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.GetEncoding("utf-16"); //почемуто в bash не принимает нормально кририлицу

        Greetings();
        string? command = "";
        while (command != "/exit")
        {
            command = Console.ReadLine();
            ExecuteCommand(command);
        }
    }

    private static void ExecuteCommand(string? command)
    {
        switch (command)
        {
            case "/start":
                StartCommand();
                break;
            case "/info":
                InfoCommand(); break;
            case "/help":
                HelpCommand(); break;
            case "/addtask":
                AddTaskCommand(); break;
            case "/removetask":
                RemoveTaskCommand(); break;
            case "/showtasks":
                ShowTasksCommand(); break;
            case string parts when parts.StartsWith("/echo") && userName != null:
                EchoCommand(parts.Substring("/echo ".Length)); break;
            case "/exit": return;
            default:
                Console.WriteLine("Недоступная команда. Используйте '/help' для списка доступных команд");
                break;

        }
    }

    static void Greetings()
    {
        Console.WriteLine("Привет, мир!");
        Console.WriteLine("Добро пожаловать! Доступные команды: /start, /help, /info, /echo, /addtask, /showtasks, /removetask, /exit");
        Console.WriteLine("Введите команду:");
    }

    static void StartCommand()
    {
        Console.Write("Введите имя: ");
        userName = Console.ReadLine();

        if (!string.IsNullOrEmpty(userName))
        {
            Console.WriteLine($"{userName} теперь вам доступна команда /echo");
        }
        else
        {
            Console.WriteLine($"Неправильное имя");
        }
    }

    static void HelpCommand()
    {
        Console.WriteLine("Информация о командах:");
        Console.WriteLine("/start - ввести имя");
        Console.WriteLine("/info - информация о программе");
        Console.WriteLine("/help - получить информацию о командах");
        if (userName != null) { Console.WriteLine("/echo - возвращает введенный текст"); }
        Console.WriteLine("/exit - выход из приложения");
    }

    static void InfoCommand()
    {
        Console.WriteLine("Информация о приложении:");
        Console.WriteLine("Версия 0.1.0");
    }

    static void EchoCommand(string echo)
    {
        Console.WriteLine($"{userName}: {echo}");
    }

    static void AddTaskCommand()
    {
        Console.Write("Пожалуйста, введите описание задачи: ");

        var task = Console.ReadLine();
        if (!string.IsNullOrEmpty(task))
        {
            tasks.Add(task);
            Console.WriteLine($"Задача \"{task}\" добавлена.");
        }


    }

    static void RemoveTaskCommand()
    {
        Console.WriteLine("Вот ваш список задач:");
        ShowTasks();
        Console.Write("Введите номер задачи для удаления: ");

        var isNumber = int.TryParse(Console.ReadLine(), out int index);

        if (isNumber)
        {
            var task = tasks[index - 1];

            tasks.RemoveAt(index - 1);
            Console.WriteLine($"Задача \"{task}\" удалена.");
        }


    }

    static void ShowTasks()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    static void ShowTasksCommand()
    {
        ShowTasks();

    }

}
