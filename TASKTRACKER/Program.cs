using Newtonsoft.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace TASKTRACKER
{
    internal class Program
    {
        
        public static int tsk_counter = 1;
        public static List<Tasks> tasks = new List<Tasks>();
       // static string Directorypath = @"D:\C#\TASKTRACKER\ConsoleApp1\bin\Debug\net6.0\";
        static string filename = "TaskList.json";
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            LoadTasks();
            int input;
            try
            {
                do
                {
                    Console.WriteLine("Menu");
                    Console.WriteLine("1.Add Task");
                    Console.WriteLine("2.Update Task");
                    Console.WriteLine("3.Delete Task");
                    Console.WriteLine("4.Status Updation");
                    Console.WriteLine("5.List All Tasks");
                    Console.WriteLine("6.List All Completed Tasks");
                    Console.WriteLine("7.List All Pending Tasks");
                    Console.WriteLine("8.List All Tasks in Progress");
                    Console.WriteLine("9.Exit");

                    if (!int.TryParse(Console.ReadLine(),out input))
                    {   
                        Console.WriteLine("Please Enter Valid InPut");
                    }
                    switch (input)
                    {
                        case 1:
                            Tasks t = new Tasks();
                            Console.WriteLine("Enter Task Description");
                            string task_desc = Console.ReadLine();
                            t.AddTask(task_desc);
                            tasks.Add(t);
                            break;
                        case 2:
                            Console.WriteLine("please Enter the TAsk ID you want to Update");
                            int task_id = Convert.ToInt32(Console.ReadLine());

                            var Updtask=tasks.FirstOrDefault(t=>t.task_id == task_id);
                            if (Updtask != null)
                            {
                                // Update task description and time
                                Console.WriteLine("Enter new task description:");
                                string newDescription = Console.ReadLine();
                                Updtask.task_desc = newDescription;
                                Updtask.updated_time = DateTime.Now.ToString("HH:mm:ss tt");
                                Console.WriteLine("Task updated successfully.");
                            }
                            else
                            {
                                // Task ID not found
                                Console.WriteLine("Task ID not found.");
                            }
                            break;
                        //case 3:
                        //    Console.WriteLine("please Enter the TAsk ID you want to delete");
                        //    int task_id1 = Convert.ToInt32(Console.ReadLine());
                        //    for(int i=0;i<tasks.Count;i++)
                        //    {
                        //        if (tasks[i].task_id == task_id1)
                        //        {
                        //            tasks.Remove(tasks[i]);

                        //        }


                        //    }
                        //    break;
                        case 3:
                            Console.WriteLine("Please Enter the Task ID you want to delete:");
                            int task_id1 = Convert.ToInt32(Console.ReadLine());
                            bool removed=tasks.RemoveAll(t => t.task_id == task_id1)>0;
                            if (!removed)
                            {
                                Console.WriteLine("Task Not found");
                            }
                            else
                            {
                                Console.WriteLine("Task Removed Successfully");
                            }
                            break;

                        case 4:
                            Console.WriteLine("please Enter the Task ID you want to Update status");
                            int task_id3 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Task Status Updation");
                            string tsk_sts = Console.ReadLine();
                            Tasks t_upd= tasks.FirstOrDefault(t=>t.task_id==task_id3);
                            if (t_upd != null)
                            {
                                
                                t_upd.task_status = tsk_sts;
                            }
                            else
                            {
                                Console.WriteLine("Task not found.");
                            }
                            break;
                        case 5:
                            foreach (Tasks t3 in tasks)
                            {
                                Console.WriteLine($"Task id= {t3.task_id} Task_Description= {t3.task_desc} Task Status={t3.task_status} created Time= {t3.created_time} Updated Time={t3.updated_time}");
                            }
                            break;
                        case 6:
                            foreach (Tasks t3 in tasks.Where(t => t.task_status.ToUpper() == "COMPLETED"))
                            {
                                Console.WriteLine($"Task id= {t3.task_id} Task_Description= {t3.task_desc} Task Status={t3.task_status} created Time= {t3.created_time} Updated Time={t3.updated_time}");
                            }
                            break;
                        case 8:
                            foreach (Tasks t3 in tasks.Where(t => t.task_status.ToUpper() == "INPROGRESS"))
                            {
                                Console.WriteLine($"Task id= {t3.task_id} Task_Description= {t3.task_desc} Task Status={t3.task_status} created Time= {t3.created_time} Updated Time={t3.updated_time}");
                            }
                            break;
                        case 7:
                            foreach (Tasks t3 in tasks.Where(t => t.task_status.ToUpper() == "TODO"))
                            {
                                Console.WriteLine($"Task id= {t3.task_id} Task_Description= {t3.task_desc} Task Status={t3.task_status} created Time= {t3.created_time} Updated Time={t3.updated_time}");
                            }
                            break;
                      
                        case 9:
                            Console.WriteLine("Thank you Visit Again");
                            break;
                        default:
                            Console.WriteLine("Please Choose Correct Option from MENU");
                            break;

                    }
                } while (input != 9);


                


                string jsonString = System.Text.Json.JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filename, jsonString);
                Console.WriteLine($"Json File saved at :{filename}");
               
            } catch (Exception ex) { Console.WriteLine(ex.ToString()); }

            
        }
        
        public static void LoadTasks()
        {
            if (File.Exists(filename))
            {
                string jsondata=File.ReadAllText(filename);
                tasks =JsonConvert.DeserializeObject<List<Tasks>>(jsondata)?? new List<Tasks>();

            }
        }
            
    }
}
