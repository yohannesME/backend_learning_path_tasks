// See https://aka.ms/new-console-template for more information
namespace SimpleTaskManager{
    using System.IO;
    enum Category{
        Personal,
        Work,
        Errand
    }

    class Task{
        public string Name;
        public string Description;
        public Category category;
        public bool isComplete = false;
    }

    class TaskManager{
        private List<Task> tasks = new List<Task>();

        public void addTask(Task task){
            tasks.Add(task);
        }

        public void removeTask(Task task){
            tasks.Remove(task);
        }

        List<Task> filterTasks(Category filterCategory){
            return tasks.Where(task => task.category == filterCategory).ToList();
        }

        public void completeTask(Task task){
            task.isComplete = true;
        }

        public void viewTask(Task task){
            Console.WriteLine("Name: " + task.Name);
            Console.WriteLine("Description: "+task.Description);
            Console.WriteLine("Status: " + (task.isComplete ? "Completed" : "Not Completed"));
            Console.WriteLine("----------------------------------------------");

        }

        public void updateTask(Task task){
            foreach (Task t in tasks){
                if (t.Name == task.Name){
                    t.isComplete = task.isComplete;
                    t.Description = task.Description;
                }
            }
        }

        public async void writeTask(){
            List<string> lineTasks = new List<string>();
            foreach(Task task in tasks){
                lineTasks.Add(task.Name + "," + task.Description + "," + task.category + "," +task.isComplete + "\n");
                
            }
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the text to a new file named "WriteFile.txt".
            await File.WriteAllLinesAsync(Path.Combine(docPath, "tasks.csv"), lineTasks);
        }

        public async void readTask(){
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var lines = await File.ReadAllLinesAsync(Path.Combine(docPath, "tasks.csv"));
            foreach (string line in lines){
                string[] lineTask = line.Split(",");
                addTask(new Task{
                    Name = lineTask[0],
                    Description = lineTask[1],
                    category = (Category)int.Parse(lineTask[2]),
                    isComplete = bool.Parse(lineTask[3])
                    }
                );
            }
        }
    }
}



namespace Application{
    using SimpleTaskManager;
    using System.IO;

    public class Program{
        public static void Main(string[] args){
            bool quit = false;
            while(!quit){  
                Console.WriteLine("Choose A Number");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Complete Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput){
                    case "1":
                        Console.WriteLine("Enter Task Name");
                        string taskName = Console.ReadLine();
                        Console.WriteLine("Enter Task Description");
                        string taskDescription = Console.ReadLine();
                        Console.WriteLine("Choose Category:\n1. Personal\n,2. Work\n,3. Errand");
                        string taskCategory = Console.ReadLine();
                        Task newTask = new Task{
                            Name = taskName,
                            Description = taskDescription,
                        };

                        if (taskCategory == "1"){
                            newTask.category = Category.Personal;
                        }else if(taskCategory == "2"){
                            newTask.category = Category.Work;
                        }else{
                            newTask.category = Category.Errand;
                        }
                    
                        break;
                }

            }



        }
    }
}
