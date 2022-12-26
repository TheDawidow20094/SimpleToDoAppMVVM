using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppMVVM.Core.ViewModels.Models.LanguageModel
{
    public class Application
    {
        [JsonProperty("tasks window")]
        public TasksWindow taskswindow { get; set; }
        public MessageBox MessageBox { get; set; }
        public WorkTask WorkTask { get; set; }
    }
}
