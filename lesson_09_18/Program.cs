using System.Diagnostics;

namespace lesson_09_18;


// Создать массив на 100_000_000 значений. Заполнить в методе Main.
// Используя 2 отдельных потока, отсортировать массив 2-мя любыми способами, после завершения сортировки n-ым методом,
// вывести информирующее сообщение на экран.
class Program
{
    static List<int> _numbers = new List<int>();
    static Random _random = new Random();
    
    static void Main()
    {
        for (int i = 0; i < 100000000; i++)
        {
            _numbers.Add(_random.Next());
        }
        
        
        Thread t1 = new Thread(SortNumbers1);
        Thread t2 = new Thread(SortNumbers2);
        
        t1.Start();
        t2.Start();
    }

    static void SortNumbers1()
    {
        Stopwatch watch = Stopwatch.StartNew();
        _numbers.Sort();
        Console.WriteLine($"Первый {watch}");
    }
    
    static void SortNumbers2()
    {
        Stopwatch watch = Stopwatch.StartNew();
        _numbers.Reverse();
        Console.WriteLine($"Второй {watch}");
    }
}

// Реализовать метод, который в отдельном потоке, каждые 2 секунды выводит символ табуляции,
// смещая тем самым текущую позицию курсора.
// В главном потоке, реализовать ввод пользователем текст.
// class Program
// {
//     static void Main()
//     {
//         Thread t = new Thread(Tab);
//         t.Start();
//
//         Console.ReadLine();
//     }
//
//     static void Tab()
//     {
//         while (true)
//         {
//             Console.Write("\t");
//             Thread.Sleep(2000);  
//         }
//     }
// }
    
    

// Создать отдельный метод, выводящий цифры от 1 до 1000, с интервалом в 1 секунду.
// В методе Main, через 10 секунд после запуска отдельного потока, досрочно прервать его работу,
// вывести сообщение о том, что работа второго потока окончена.
// class Program
// {
//     private static bool stop = false;
//     static void Main()
//     {
//         Thread t = new Thread(() => PrintNumbers(1, 1000));
//         t.Start();
//         
//         Thread.Sleep(10000);
//         stop = true;
//         Console.WriteLine("Остановлен поток");
//     }
//
//     static void PrintNumbers(int firstNum, int lastNum)
//     {
//         for (int i = firstNum; i <= lastNum; i++)
//         {
//             if (stop) break;
//             Console.WriteLine(i);
//             Thread.Sleep(1000);  
//         }
//     }
// }




// Написать программу, в которой при запуске начинают одновременно работать 3 метода,
// выводящие на экран числа в интервале от 10 до 20, 30 до 40, 50 до 60, с интервалом на вывод – полсекунды.
// Использовать массив потоков.
// class Program
// {
//     
//     static void Main()
//     {
//         List<Thread> threads = new List<Thread>()
//         {
//             new Thread(Method1),
//             new Thread(Method2),
//             new Thread(Method3),
//         };
//
//         foreach (var thread in threads)
//         {
//             thread.Start();
//         }
//     }
//     
//     static void Method1(object? obj)
//     {
//         for (int i = 10; i <= 20; i++)
//         {
//             Console.WriteLine(i);
//             Thread.Sleep(500);
//         }
//     }
//     static void Method2(object? obj)
//     {
//         for (int i = 30; i <= 40; i++)
//         {
//             Console.WriteLine(i);
//             Thread.Sleep(500);
//         }
//     }
//     static void Method3(object? obj)
//     {
//         for (int i = 50; i <= 60; i++)
//         {
//             Console.WriteLine(i);
//             Thread.Sleep(500);
//         }
//     }
// }


    
    
// Создать метод, выводящий на консоль каждую секунду, текущее время, в отдельном потоке.
// class Program
// {
//     private static int _second = 0; 
//     static void Main()
//     {
//         Thread t1 = new Thread(Method);
//         t1.Start();
//         Console.ReadKey();
//     }
//     
//     static void Method(object? obj)
//     {
//         while (true)
//         {
//             Console.WriteLine($"{++_second}, {DateTime.Now}");
//             Thread.Sleep(1000);
//         }
//     }
// }




// class Program
// {
//     static void Main()
//     {
//         // Создание делегата, который будет связан с методом
//         // шифрования или дешифрования
//         ParameterizedThreadStart Param = null;
//         while (true)
//         {
//             // Меню, где пользователю предлагается выбрать
//             // действие. Console.Clear();
//             Console.WriteLine("1. Шифровать");
//             Console.WriteLine("2. Дешифровать");
//             ConsoleKeyInfo Select = Console.ReadKey(true);
//             Console.Clear();
//  
//             if (ConsoleKey.D1 == Select.Key)
//             {
//                 // Если пользователь выбрал шифрование,
//                 //мы связаваем делегат с методом шифрования
//                 Param = new ParameterizedThreadStart(Encryption);
//                 Console.WriteLine("Введите путь к файлу, который хотите зашифровать");
//             }
//             else if (ConsoleKey.D2 == Select.Key)
//             {
//                 // Если пользователь выбрал дешифрование,
//                 // мы связываем делегат с методом дешифрования
//                 Param = new ParameterizedThreadStart(Decryption);
//                 Console.WriteLine("Введите путь к файлу, который хотите расшифровать");
//             }
//             if (ConsoleKey.D1 == Select.Key || ConsoleKey.D2 == Select.Key)
//             {
//                 // Пользователь вводит путь к файлу,
//                 // с которым собирается работать
//                 string FilePath = Console.ReadLine();
//                 // Создание потока, который будет шифровать
//                 // дешифровать
//                 Thread thread = new Thread(Param);
//                 // Старт потока в параметр передается путь
//                 // к файлу
//                 thread.Start((object)FilePath);
//                 Console.WriteLine("Нажмите символ, чтобы выполнить действие");
//                 do
//                 {
//                     // В цикле пользователю предлагаются выбрать
//                     // действие с потоком
//                     Console.WriteLine("[c] Отменить работу  потока");
//                     Console.WriteLine("[p] приостановить или возобновить работу потока");
//                     ConsoleKeyInfo Selects = Console.ReadKey(true);
//                     if (Selects.Key == ConsoleKey.C)
//                     {
//                         if (thread.ThreadState == ThreadState.Running)
//                         {
//                             // Если поток выполнялся
//                             // и пользователь выбрал завершение
//                             thread.Abort();// Завершаем работу потока
//                             Console.WriteLine("Поток остановлен");
//                         }
//                     }
//                     else if (Selects.Key == ConsoleKey.P)
//                     {
//                         if (thread.ThreadState == ThreadState.Running)
//                         {
//                             // Если поток выполнялся
//                             // и пользователь выбрал приостановление
//                             thread.Suspend();
//                             // Приостанавливаем поток
//                             Console.WriteLine("Поток приостановлен");
//                         }
//                         else if (thread.ThreadState == ThreadState.Suspended)
//                         {
//                             // если поток остановлен
//                             // и пользователь выбрал возобновление
//                             thread.Resume();
//                             // Возобновляем поток
//                             Console.WriteLine("Поток восстановил работу");
//                         }
//                         Thread.Sleep(100);
//                     }
//                     // Если поток приостановлен или работает,
//                     // то показать это меню пользователю еще
//                 } while (thread.ThreadState == ThreadState.Suspended || thread.ThreadState == ThreadState.Running);
//                 Console.ReadKey(true);
//                 Console.Clear();
//             }
//         }
//     }
//     private static void Decryption(object? obj)
//     {
//         
//     }
//  
//     private static void Encryption(object? obj)
//     {
//        
//     }
// }



// class Program
// {
//     static ThreadLocal<int> _threadLocal = new ThreadLocal<int>(trackAllValues: true);
//     static void ThreadMethod()
//     {
//         _threadLocal.Value = 42;
//     }
//     static void Main()
//     {
//         Thread thread = new Thread(ThreadMethod);
//         thread.Start();
//         thread.Join();
//         int result = _threadLocal.Values[0];
//         Console.WriteLine("Результат: " + result); 
//     }
// }






// class Program
// {
//     static AutoResetEvent waitHandle = new AutoResetEvent(false);
//     static void Main()
//     {
//         Console.WriteLine("Главный поток: " + Thread.CurrentThread.ManagedThreadId);
//         Thread t = new Thread(Add);
//         Thread t2 = new Thread(Add2);
//         t.Start();
//         waitHandle.WaitOne();
//         t2.Start();
//         waitHandle.WaitOne();
//         Console.WriteLine("Все потоки завершились");
//         Console.ReadLine();
//     }
//  
//     static void Add()
//     {
//         for (int i = 0; i < 10; i++)
//         {
//             Console.WriteLine("Поток: " + Thread.CurrentThread.ManagedThreadId);
//             Thread.Sleep(500);
//         }
//         waitHandle.Set();
//     }
//     static void Add2()
//     {
//         for (int i = 0; i < 10; i++)
//         {
//             Console.WriteLine("Поток: " + Thread.CurrentThread.ManagedThreadId);
//             Thread.Sleep(500);
//         }
//         waitHandle.Set();
//     }
// }


// class Program
// {
//     static void Main()
//     {
//         ThreadStart TS = new ThreadStart(Method);
//         Thread T = new Thread(TS);
//         Console.WriteLine("A thread will now be started");
//        
//         T.Start();
//         Thread.Sleep(200);
//         Console.WriteLine("Waiting for the thread to complete");
//         T.Join();
//         Console.WriteLine("Termination of the program");
//     }
//     static void Method()
//     {
//         Console.WriteLine("The flow is working");
//         Thread.Sleep(2000);
//         Console.WriteLine("The stream has completed its work");
//     }
// }







// class Program
// {
//     static void Main(string[] args)
//     {
//         Counter counter = new Counter(5, 4);
//         Thread myThread = new Thread(new ThreadStart(counter.Count));
//         myThread.Start();
//     }
// }
// public class Counter
// {
//     private int x;
//     private int y;
//  
//     public Counter(int _x, int _y)
//     {
//         this.x = _x;
//         this.y = _y;
//     }
//     public void Count()
//     {
//         for (int i = 1; i < 9; i++)
//         {
//             Console.WriteLine("Второй поток:");
//             Console.WriteLine(i * x * y);
//             Thread.Sleep(400);
//         }
//     }
// }











// class Printer
// {
//     public delegate bool ResetHandler();
//     public event ResetHandler Notify;
//     public void Do(object obj)
//     {
//         for (int i = 0; i < 100; i++)
//         {
//             Console.WriteLine(i);
//             Thread.Sleep(500);
//             if(Notify.Invoke()) break;
//         }
//     }
// }
// class Program
// {
//     static void Main(string[] args)
//     {
//         Printer printer = new Printer();
//         printer.Notify += () => false;
//         Thread thread = new Thread(printer.Do);
//         thread.Start();
//         Thread.Sleep(3000);
//         //К примеру, что-то пользователь ввел, тогда мы останавливаем поток.
//         printer.Notify += () => true;
//         Console.ReadLine();
//     }
// }

// class Program
// {
    // static void Main()
    // {
        // ParameterizedThreadStart ts = new ParameterizedThreadStart(Method);
        // Thread t1 = new Thread(ts);
        // Thread t2 = new Thread(ts);

        // t1.Priority = ThreadPriority.Highest;
        // t2.Priority = ThreadPriority.Lowest;

        // t1.Start("1");
        // t2.Start("\t\t\t2");

        // Console.ReadLine();
    // }

    // static void Method(object obj)
    // {
        // string text = obj.ToString();
        // for (int i = 0; i < 2000; i++)
        // {
            // Console.WriteLine("{0} #{1}", text, i.ToString());
        // }
    // }

    
    // static void Main(string[] args)
    // {
        // Timer timer = new Timer(new TimerCallback(Method), null, 0, 1000);
        // Thread thread = new Thread(Method);
        // thread.Start((object)"1");
        //
        // Thread thread1= new Thread(Method);
        // thread1.Start((object)"\t\t2");
        //
        
        // Thread t = Thread.CurrentThread;
        // Console.WriteLine($"Имя потока: {t.Name}");
        // Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
        // Console.WriteLine($"Приоритет потока: {t.Priority}");
        // Console.WriteLine($"Статус потока: {t.ThreadState}");
        // Console.WriteLine($"Домен приложения: {Thread.GetDomain().FriendlyName}");

        // Console.ReadKey();
    // }

    // static void Method(object obj)
    // {
    //     for (int i = 0; i < 100; i++)
    //     {
    //         Console.WriteLine(obj);
    //         Thread.Sleep(200);
    //     }
    // }
// }