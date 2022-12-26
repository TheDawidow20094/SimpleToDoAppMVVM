using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppMVVM.Core.ViewModels.Models.LanguageModel
{
    public class TasksWindow
    {
        [JsonProperty("Your tasks")]
        public string Yourtasks { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AddNewTaskButton { get; set; }
        public string DeleteSelectedTasksButton { get; set; }
        public string DeleteAllTasksButton { get; set; }
    }
}
