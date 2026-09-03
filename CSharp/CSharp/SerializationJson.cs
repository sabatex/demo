using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharp;

public class Student
{
    [Translate(Russian = "Имя")]
    public string Name { get; set; }
    public string SurName { get; set; }
    static void Go(string[] args)
    {
        ConsoleTraceListener consoleTrace = new ConsoleTraceListener();
        Trace.Listeners.Add(new ConsoleTraceListener());
        var group = new Student[] { new Student { Name = "Pedro", SurName = "Gonzales" } };
        File.WriteAllText(@"c:\temp\test.json", System.Text.Json.JsonSerializer.Serialize(group));

        Trace.WriteLine("Hello World!");
    }
}
public class TranslateAttribute : Attribute
{
    public string Russian { get; set; }
}