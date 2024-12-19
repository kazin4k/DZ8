using System;
using System.Collections.Generic;

public class Task
{
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public string Initiator { get; set; }
    public string Executor { get; set; }
    public TaskStatus Status { get; set; }
    public List<Report> Reports { get; set; }

    public Task(string description, DateTime deadline, string initiator)
    {
        Description = description;
        Deadline = deadline;
        Initiator = initiator;
        Status = TaskStatus.Assigned;
        Reports = new List<Report>();
    }

    public void TakeTask(string executor)
    {
        Executor = executor;
        Status = TaskStatus.InProgress;
        Console.WriteLine($"Задача '{Description}' принята исполнителем '{executor}'.");
    }

    public void AddReport(Report report)
    {
        Reports.Add(report);
        Status = TaskStatus.UnderReview;
        Console.WriteLine($"Отчет добавлен к задаче '{Description}'.");
    }

    public void ApproveReport()
    {
        Status = TaskStatus.Completed;
        Console.WriteLine($"Отчет по задаче '{Description}' утвержден.");
    }
}