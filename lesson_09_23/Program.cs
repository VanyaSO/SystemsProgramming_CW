using System.Text;

namespace lesson_09_23;


// Создайте эмуляцию конных скачек. В гонке участвуют пять лошадей. Каждая лошадь — это отдельный прогресс-бар.
// При нажатии кнопки Старт начинается гонка. Скорость бега каждой лошади определяется в процессе гонки случайным образом.
// По итогам скачки нужно показать таблицу результатов. Используйте механизм многопоточности.
using System;
using System.Threading;

class Program
{
    public static Random Random = new Random();
    private static int[] progressBars = new int[5];

    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            ThreadPool.QueueUserWorkItem(Run, i);
        }

        while (true)
        {
            for (int i = 0; i < progressBars.Length; i++)
            {
                Console.CursorLeft = 0;
                Console.Write($"Лошадь {i + 1}: {new string('-', progressBars[i])}, {progressBars[i]}");
                Console.WriteLine();
            }

            if (progressBars.Any(e => e >= 100))
            {
                Console.WriteLine("\nГонка закончена!");
                Console.ReadKey();
                break;
            }
            
            Thread.Sleep(1000);
        }
    }

    static void Run(object state)
    {
        int horseIndex = (int)state;
        int progressBar = 0;
        while (progressBar < 100)
        {
            Console.Clear();
            Thread.Sleep(Random.Next(500, 1000));
            progressBar += Random.Next(1, 10);
            progressBars[horseIndex] = progressBar;
            Thread.Sleep(500);
        }
    }
}


// class Program
// {
//     static void Main()
//     {
//         FileStream fs = new FileStream("random_bytes.bin", FileMode.Open, FileAccess.Read, FileShare.Read, 100_000_000, FileOptions.Asynchronous);
//         Byte[] data = new Byte[100_000_000];
//         IAsyncResult ar = fs.BeginRead(data, 0, data.Length, null, null);
//  
//         while (!ar.IsCompleted)
//         {
//             Console.WriteLine("Операция не завершена, ожидайте...");
//             Thread.Sleep(10);
//         }
//  
//         int bytesRead = fs.EndRead(ar);
//         fs.Close();
//         
//         
//         
//         
//         // FileStream fs = new FileStream(@"../../../Program.cs", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);
//         // Byte[] data = new Byte[100];
//         // IAsyncResult ar = fs.BeginRead(data, 0, data.Length, null, null);
//         //
//         // while (!ar.IsCompleted)
//         // {
//         //     Console.WriteLine("Операция не завершена, ожидайте...");
//         //     Thread.Sleep(10);
//         // }
//         //
//         // int bytesRead = fs.EndRead(ar);
//         // fs.Close();
//         // Console.WriteLine($"Количество считанных байт = {bytesRead}"); ;
//         // Console.WriteLine(Encoding.UTF8.GetString(data).Remove(0, 1));
//     }
//     // static void Main()
//     // {
//     //     string[] files = {
//     //         "../../../Program.cs",
//     //         "../../../ConsoleApp1.csproj", //указываем название проекта
//     //         "../../../appsettings.json" //создаем и наполняем файл, если его нет
//     //     };
//     //
//     //
//     //     AsyncReader[] array = new AsyncReader[3];
//     //     for (int i = 0; i < array.Length; i++)
//     //     {
//     //         array[i] = new AsyncReader(new FileStream(files[i], FileMode.Open, FileAccess.Read), 100);
//     //     }
//     //
//     //
//     //     foreach (AsyncReader item in array)
//     //     {
//     //         Console.WriteLine(item.EndRead());
//     //     }
//     // }
// }
// class AsyncReader
// {
//     private FileStream stream;
//     private byte[] data;
//     private IAsyncResult asRes;
//     public AsyncReader(FileStream s, int size)
//     {
//         stream = s;
//         data = new byte[size];
//         asRes = s.BeginRead(data, 0, size, null, null);
//     }
//     public string EndRead()
//     {
//         int countByte = stream.EndRead(asRes);
//         stream.Close();
//  
//  
//         Array.Resize(ref data, countByte);
//         return $"File: {stream.Name}\n{Encoding.UTF8.GetString(data)}\n\n";
//     }
// }

    

// class Program
// {
//     static void Main()
//     {
//         FileStream fs = new FileStream(@"../../../Program.cs", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);
//         byte[] data = new byte[100];
//         // Начало асинхронной операции чтения из
//         // файла FileStream.
//         IAsyncResult ar = fs.BeginRead(data, 0, data.Length, null, null);
//  
//         int bytesRead = fs.EndRead(ar);
//         // Других операций нет. Закрытие файла.
//         fs.Close();
//         // Теперь можно обратиться к байтовому  массиву и вывести результат операции.
//         Console.WriteLine("Количество прочитаных байт = {0} ", bytesRead);
//  
//         Console.WriteLine(Encoding.UTF8.
//             GetString(data));
//     }
// }
// class Program
// {
//     static void Main(string[] args)
//     {
//         // ThreadPool.GetMaxThreads(out int workerThreads, out int completionPortThreads);
//         // Console.WriteLine(workerThreads);
//         // Console.WriteLine(completionPortThreads);
//     }
// }