using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKTRACKER

{
    internal class Tasks
    {
        public static int task_count=0;
        public int task_id {  get; set; }
        public string task_desc { get; set; }
        public string task_status { get; set; }
        public string created_time { get; set; }
        public string updated_time { get; set; }

        


       

        public Tasks ()
        {
            this.task_id = task_count+1;
            this.task_status = "TODO";
            this.created_time = DateTime.Now.ToString("HH:mm:ss tt"); 
            this.updated_time = DateTime.Now.ToString("HH:mm:ss tt"); 
           
            task_count++;
        }   

        public  void AddTask(string task_desc)
        {
            this.task_desc = task_desc;
            

        }

       
    }
}
