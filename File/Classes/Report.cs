using System;

public class Report
{
    public string Description { get; set; }
    public DateTime DateCompleted { get; set; }
    public string Executor { get; set; }

    public Report(string description, DateTime dateCompleted, string executor)
    {
        Description = description;
        DateCompleted = dateCompleted;
        Executor = executor;
    }
}
