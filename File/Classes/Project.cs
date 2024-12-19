using System;
using System.Collections.Generic;

public class Project
{
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public string Initiator { get; set; }
    public string TeamLead { get; set; }
    public List<Task> Tasks { get; set; }
    public ProjectStatus Status { get; set; }

    public Project(string description, DateTime deadline, string initiator, string teamLead)
    {
        Description = description;
        Deadline = deadline;
        Initiator = initiator;
        TeamLead = teamLead;
        Tasks = new List<Task>();
        Status = ProjectStatus.InProgress;
    }

    public void AddTask(Task task)
    {
        if (Status == ProjectStatus.InProgress)
        {
            Tasks.Add(task);
            Console.WriteLine($"Задача '{task.Description}' добавлена в проект.");
        }
        else
        {
            Console.WriteLine("Невозможно добавить задачи в проект, который не находится в статусе 'В процессе'.");
        }
    }

    public void StartExecution()
    {
        if (Status == ProjectStatus.InProgress)
        {
            Status = ProjectStatus.InProgress;
            Console.WriteLine("Проект начат.");
        }
    }

    public bool IsClosed()
    {
        return Tasks.TrueForAll(t => t.Status == TaskStatus.Completed);
    }
}
