// See https://aka.ms/new-console-template for more information
namespace SimpleTaskManager
{
    using System.IO;
    enum Category
    {
        Personal,
        Work,
        Errand
    }

    class Task
    {
        public string Name;
        public string Description;
        public Category category;
        public bool isComplete = false;

        //overload the tostring method
        public override string ToString()
        {
            return ("Name: " + Name) + "\n" + ("Description: " + Description) + "\n" + ("Status: " + (isComplete ? "Completed" : "Not Completed\n"));
        }
    }

    class TaskManager
    {
        public TaskManager()
        {
            readTask();
        }

        private List<Task> tasks = new List<Task>();

        public void addTask(Task task)
        {
            tasks.Add(task);
            writeTask();
        }

        public void removeTask(string title)
        {
            foreach (Task task in tasks)
            {
                if (task.Name == title)
                {
                    tasks.Remove(task);
                    break;
                }
            }
            writeTask();
        }

        List<Task> filterTasks(Category filterCategory)
        {
            return tasks.Where(task => task.category == filterCategory).ToList();
        }

        public void completeTask(string completeTaskName)
        {
            foreach (Task task in tasks)
            {
                if (task.Name == completeTaskName)
                    task.isComplete = true;
            }
            writeTask();
        }


        public void updateTask(string Name, string Description, Category category)
        {
            foreach (Task t in tasks)
            {
                if (t.Name == task.Name)
                {
                    t.isComplete = task.isComplete;
                    t.Description = task.Description;
                }
            }
        }

        public async void writeTask()
        {
            List<string> lineTasks = new List<string>();
            foreach (Task task in tasks)
            {
                lineTasks.Add(task.Name + "," + task.Description + "," + (int)task.category + "," + task.isComplete + "\n");

            }
            // Set a variable to the Documents path.
            string docPath = Directory.GetCurrentDirectory();


            // Write the text to a new file named "tasks.txt".
            await File.WriteAllLinesAsync(Path.Combine(docPath, "tasks.csv"), lineTasks);
        }

        public async void readTask()
        {
            tasks.Clear();

            // Set a variable to the Documents path.
            string docPath = Directory.GetCurrentDirectory();
            try
            {
                var lines = await File.ReadAllLinesAsync(Path.Combine(docPath, "tasks.csv"));

                foreach (string line in lines)
                {
                    string[] lineTask = line.Split(",");
                    if (lineTask.Length == 4)
                    {

                        addTask(new Task
                        {
                            Name = lineTask[0],
                            Description = lineTask[1],
                            category = (Category)int.Parse(lineTask[2]),
                            isComplete = bool.Parse(lineTask[3])
                        }
                        );
                    }
                }
            }
            catch (FileNotFoundException)
            {
                FileStream fileStream = new FileStream(Path.Combine(docPath, "tasks.csv"), FileMode.Create);
                fileStream.Close();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error");
            }
        }

        public void printTasks()
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task.ToString());
            }
        }
    }
}



namespace Application
{
    using SimpleTaskManager;


    public class Program
    {
        public static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Choose A Number");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. List Tasks");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Complete Task");
                Console.WriteLine("5. Update Task - Description, Category");
                Console.WriteLine("6. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Enter Task Name");
                        string taskName = Console.ReadLine();
                        Console.WriteLine("Enter Task Description");
                        string taskDescription = Console.ReadLine();
                        Console.WriteLine("Choose Category:\n1. Personal\n,2. Work\n,3. Errand");
                        string taskCategory = Console.ReadLine();
                        Task newTask = new Task
                        {
                            Name = taskName,
                            Description = taskDescription,
                        };

                        if (taskCategory == "1")
                        {
                            newTask.category = Category.Personal;
                        }
                        else if (taskCategory == "2")
                        {
                            newTask.category = Category.Work;
                        }
                        else
                        {
                            newTask.category = Category.Errand;
                        }
                        taskManager.addTask(newTask);
                        break;
                    case "2":
                        taskManager.printTasks();
                        break;
                    case "3":
                        Console.WriteLine("Enter Task Name");
                        string deleteTaskName = Console.ReadLine();
                        taskManager.removeTask(deleteTaskName);
                        break;
                    case "4":
                        Console.WriteLine("Enter Task Name");
                        string completeTaskName = Console.ReadLine();
                        taskManager.completeTask(completeTaskName);
                        break;
                    case "5":
                        Console.WriteLine("Enter Task Name");
                        string updateTaskName = Console.ReadLine();
                        Console.WriteLine("Enter Task Description");
                        string updateTaskDescription = Console.ReadLine();
                        Console.WriteLine("Choose Category:\n1. Personal\n,2. Work\n,3. Errand");
                        string updateTaskCategory = Console.ReadLine();
                        taskManager.updateTask(updateTaskName, updateTaskDescription, (Category)int.Parse(updateTaskCategory));
                    case "6":
                        quit = true;
                        break;

                }

            }



        }
    }
}
