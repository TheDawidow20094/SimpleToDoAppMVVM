using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppMVVM.Core
{
    public class ToDoAppCoreEnums
    {
        public enum SelectedLanguage
        {
            [Description("Polish")]
            Polish = 0,
            [Description("English")]
            English = 1,
        }
    }
}
