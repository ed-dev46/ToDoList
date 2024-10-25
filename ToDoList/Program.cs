using ToDoList;

const string PATH = "temp/";
List<ToDoList.Task> tasksList = new List<ToDoList.Task>();
createAndLoadList();

Console.WriteLine("--TO DO LIST--");
Console.WriteLine("1 . Add a new task\n" +
    "2 . Remove a task\n" +
    "3 . List all tasks\n" +
    "0 . Exit");

while (true)
{
    Console.Write("\nSelect an option: ");
    switch(Console.ReadLine())
    {
        case "0":
            return;
        case "1":
            addNewTask();
            break;
        case "2":
            removeTask();
            break;
        case "3":
            listAllTasks();
            break;
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
}

void createAndLoadList()
{
    if (!Directory.Exists(PATH))
    {
        Directory.CreateDirectory(PATH);
        File.Create(PATH + "ToDoList.txt").Close();
        Console.WriteLine("A new list was created in " + PATH);
    } else
    {
        using (StreamReader streamReader = new StreamReader(PATH + "ToDoList.txt"))
        {
            string? line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] taskLine = line.Split(";");
                ToDoList.Task task = new ToDoList.Task(taskLine[0]);
                tasksList.Add(task);
            }
        }
        Console.WriteLine("A existing list was found at " + PATH);
    }
}

void addNewTask()
{
    Console.Write("Enter a description for the task: ");
    string description = Console.ReadLine()!;
    ToDoList.Task task = new ToDoList.Task(description);
    tasksList.Add(task);
    using (StreamWriter sw = new StreamWriter(PATH + "ToDoList.txt", true))
    {
        sw.WriteLine(task.Description + ";" + task.Status);
    }
    Console.WriteLine("Task successfully created");
}

void removeTask()
{
    Console.WriteLine("Select a task for remove: ");
    int count = 0;
    foreach (ToDoList.Task task in tasksList)
    {
        count++;
        Console.WriteLine(count + " . " + task);
    }
    tasksList.RemoveAt((Convert.ToInt16(Console.ReadLine()) - 1));
    using (StreamWriter sw = new StreamWriter(PATH + "ToDoList.txt"))
    {
        foreach (ToDoList.Task task in tasksList)
        {
            sw.WriteLine(task.Description + ";" + task.Status);
        }
    }
    Console.WriteLine("Task removed successfully");
}

void listAllTasks()
{
    foreach (ToDoList.Task task in tasksList)
    {
        Console.WriteLine(task);
    }
    Console.WriteLine("End of list");
}