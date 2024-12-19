using System;

public class Program
{
    public static void Main(string[] args)
    {
        Project project = new Project("Разработка нового приложения", DateTime.Now.AddMonths(3), "Клиент", "Руководитель команды");

        for (int i = 1; i <= 10; i++)
        {
            Task task = new Task($"Задача {i}", DateTime.Now.AddDays(30), "Клиент");
            project.AddTask(task);
        }

        project.StartExecution();

        Random random = new Random();
        foreach (var task in project.Tasks)
        {
            task.TakeTask($"Исполнитель {random.Next(1, 11)}");
            Console.WriteLine($"Задача: {task.Description}, Статус: {task.Status}, Исполнитель: {task.Executor}");

            Report report = new Report($"Отчет по задаче {task.Description}", DateTime.Now, task.Executor);
            task.AddReport(report);
            task.ApproveReport();
            Console.WriteLine($"Отчет по задаче: {task.Description}, Статус: {task.Status}");
        }

        if (project.IsClosed())
        {
            project.Status = ProjectStatus.Closed;
            Console.WriteLine("Проект закрыт.");
        }
    }
}