using System.Diagnostics;

namespace lesson_09_20;
class Program
{
    private static Stopwatch _watch = new Stopwatch();
    private static string _str;
    private static bool _isStop = false;
    static void Main()
    {
        _str = Console.ReadLine();
        Thread thread = new Thread(() => Watcher());
        thread.Start();
        
        _isStop = true;
    }

    static void Watcher()
    {
        while (!_isStop)
        {
            if (_str[_str.Length-1] == _str[_str.Length-2])
                Console.WriteLine("Error");
        }
    }
}


// Реализуйте консольное игровое приложение "успел, не успел", где будет проверяться скорость реакции пользователя.
// Программа должна подать сигнал пользователю в виде текста, и пользователю должен будет нажать кнопку на клавиатуре,
// после нажатия пользователь должен увидеть, сколько миллисекунд ему потребовалось, чтобы нажать кнопку.
// class Program
// {
//     private static Stopwatch _watch = new Stopwatch();
//     static void Main()
//     {
//         Thread thread = new Thread(() => Signal());
//         thread.Start();
//     }
//
//     static void Signal()
//     {
//         Console.WriteLine("Click");
//         _watch.Start();
//         Console.ReadKey();
//         _watch.Stop();
//         
//         Console.WriteLine(_watch);
//     }
// }


// // Напишите программу, которая создает несколько потоков, каждый из которых моделирует работу клиента в банке.
// // Каждый поток должен периодически совершать случайные операции (пополнение или снятие средств) на своем счете.
// // Программа должна работать в течение заданного времени и выводить на экран текущее состояние счетов клиентов.
// //  
// // 1) Создайте класс Account, который будет представлять банковский счет.
// // 2) Создайте класс Client, который будет представлять клиента и содержать логику выполнения операций.
// // 3) Используйте класс Thread для моделирования работы клиентов.
// // Каждый клиент должен периодически (каждые 1-3 секунды) совершать случайные операции (пополнение или снятие средств).
// // 4) Программа должна завершиться через 30 секунд.
//
// public class Account
// {
//     public double Balance { get; set; }
// }
//
// public class Client
// {
//     public string Name { get; set; }
//     public Account Account { get; set; }
//
//     public void Deposit(double sum) => Account.Balance += sum;
//
//     public void Withdraw(double sum)
//     {
//         if (Account.Balance - sum > 0)
//             Account.Balance -= sum;
//
//         Console.WriteLine("Невозможно снять/вывести вредства");
//     }
// }
//
// class Program
// {
//     private static bool _isStop = false;
//     private static Random _random = new Random();
//     
//     static void Main(string[] args)
//     {
//         List<Thread> threads = new List<Thread>
//         {
//             new Thread(() => RandomAction(new Client {Name = "Genna", Account = new Account{Balance = 0}})),
//             new Thread(() => RandomAction(new Client {Name = "Sasha", Account = new Account{Balance = 0}}))
//         };
//
//         foreach (var thread in threads)
//             thread.Start();
//         
//         Thread.Sleep(30000);
//         _isStop = true;
//     }
//
//     static void RandomAction(Client client)
//     {
//         while (!_isStop)
//         {
//             Console.WriteLine(client.Account.Balance);   
//             if (Convert.ToBoolean(_random.Next(0, 1)))
//                 client.Withdraw(_random.Next(100, 1000));
//             else
//                 client.Deposit(_random.Next(100, 1000));
//             
//             Thread.Sleep(_random.Next(1000, 3000));
//         }
//     }
// }