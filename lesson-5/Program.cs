
namespace lesson_5;

class Program
{
    static string? userName = null;

    static void Greetings()
    {
        Console.WriteLine("Добро пожаловать! Список доступных команд: /start, /help, /info, /exit.");
        Console.WriteLine("Введите команду:");
    }

    static void StartCommand()
    {
        Console.WriteLine("Введите имя:");
        userName = Console.ReadLine();

        if (userName?.Length > 0 )
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
    static void Main(string[] args)
    {
        Greetings();
        string? command = "";
        while (command != "/exit")
        {
            command = Console.ReadLine();
            ExecuteCommand(command);
        }
    }

    static void EchoCommand(string echo)
    {
        Console.WriteLine($"{userName}: {echo}");
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
            case string parts when parts.StartsWith("/echo") && userName != null:
                EchoCommand(parts.Substring("/echo ".Length)); break;
            case "/exit": return;
            default:
                Console.WriteLine("Недоступная команда. Используйте '/help' для списка доступных команд");
                break;

        }
    }
}
