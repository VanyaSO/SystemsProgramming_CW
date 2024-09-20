using System.Diagnostics;
using System.Reflection;
using System.Threading.Channels;

namespace lesson_09_16;


class Program
{
    static void Main()
    {
        Type personType = typeof(Person);
        object[] attributes = personType.GetCustomAttributes(typeof(MyCustomAttribute), false);
    }
}
 
public class MyCustomAttribute : Attribute
{
    public MyCustomAttribute(string description)
    {
        Description = description;
    }
 
    public string Description { get; }
}
 
[MyCustom("Attribute applied to the module")]
public class Person
{
    public string Name { get; set; }
    public void SayHello()
    {
        Console.WriteLine("Hello from Person!");
    }
}
//
//
// [AttributeUsage(AttributeTargets.Method)]
// public class PriorityAttribute : Attribute
// {
//     public int Priority { get; }
//  
//  
//     public PriorityAttribute(int priority)
//     {
//         Priority = priority;
//     }
// }
//  
//  
// [AttributeUsage(AttributeTargets.Method)]
// public class DescriptionAttribute : Attribute
// {
//     public string Description { get; }
//  
//  
//     public DescriptionAttribute(string description)
//     {
//         Description = description;
//     }
// }
//  
//  
// class TaskManager
// {
//     [Priority(1)]
//     [Description("Выполнить анализ данных")]
//     public void AnalyzeData()
//     {
//         Console.WriteLine("Анализ данных выполняется...");
//     }
//  
//  
//     [Priority(2)]
//     [Description("Обновить базу данных")]
//     public void UpdateDatabase()
//     {
//         Console.WriteLine("Обновление базы данных выполняется...");
//     }
// }
//  
//  
// class Program
// {
//     static void Main()
//     {
//         // Получаем информацию о методах с атрибутами
//         var taskManager = new TaskManager();
//         var methods = typeof(TaskManager).GetMethods();
//  
//  
//         foreach (var method in methods)
//         {
//             // Получаем атрибуты приоритета и описания
//             var priorityAttribute = (PriorityAttribute)Attribute.GetCustomAttribute(method, typeof(PriorityAttribute));
//             var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(method, typeof(DescriptionAttribute));
//  
//  
//             if (priorityAttribute != null && descriptionAttribute != null)
//             {
//                 Console.WriteLine($"Метод: {method.Name}, Приоритет: {priorityAttribute.Priority}, Описание: {descriptionAttribute.Description}");
//             }
//         }
//     }
// }


// class Program
// {
    // static void Main(string[] args)
    // {
        // Console.WriteLine(string.Join(" ", args));
        //
        // Process process = new Process();
        // process.StartInfo.FileName = "open";
        // process.StartInfo.Arguments = "-a TextEdit";
        // process.Start();
        //
        // Console.ReadKey();
        // Process.GetCurrentProcess().Kill();

        // Assembly entryAssembly = Assembly.GetEntryAssembly();
        // object instance = entryAssembly.CreateInstance("ConsoleApp1.Person");
        
        // Assembly myAssembly = Assembly.LoadFrom("lesson_09_16_lb.dll");
        //
        // Type myType = myAssembly.GetType("lesson_09_16_lb.Person");
        // if (myType != null)
        // {
        //     object instance = Activator.CreateInstance(myType);
        //     MethodInfo method = myType.GetMethod("SayHello");
        //     if (method != null)
        //     {
        //         method.Invoke(instance, null);
        //     }
        // }

        // Module module = typeof(Program).Module;
        // Assembly assembly = module.Assembly;
    // }
// }

// public class Person
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
// }