using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppMVVM.Core.ViewModels.Base;

namespace ToDoAppMVVM.Core.ViewModels.Controls
{
    public class WorkTaskViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsSelected { get; set; }
        public string TitleTextTranslated { get; set; }
        public string DescriptionTextTranslated { get; set; }
        public string CreationDateTextTranslated { get; set; }
    }
}
