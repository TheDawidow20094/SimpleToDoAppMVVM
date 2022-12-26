using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using ToDoAppMVVM.Core.Helpers;
using ToDoAppMVVM.Core.ViewModels.Base;
using ToDoAppMVVM.Core.ViewModels.Controls;
using ToDoAppMVVM.Core.ViewModels.Models.LanguageModel;
using static ToDoAppMVVM.Core.ToDoAppCoreEnums;

namespace ToDoAppMVVM.Core.ViewModels.Pages
{
    public class WorkTasksPageViewModel : BaseViewModel
    {
        public ObservableCollection<WorkTaskViewModel> WorkTasksList { get; set; } = new ObservableCollection<WorkTaskViewModel>();
        public string NewWorkTaskTitle { get; set; }
        public string NewWorkTaskDescription { get; set; }

        private DateTime _selectedDate;

        public DateTime SelectedDate 
        { 
            get { return _selectedDate; } 
            set 
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            } 
        }
        public ICommand AddNewTaskCommand { get; set; }
        public ICommand DeleteSelectedTasksCommand { get; set; }
        public ICommand DeleteAllTasksCommand { get; set; }
        public Action OpenMsgBoxWhenTitleOrDescriptionIsEmpty { get; set; }

        #region Translation props
        public string YourTasksTranslatedText { get; set; }
        public string TitleTranslatedText { get; set; }
        public string DescriptionTranslatedText { get; set; }
        public string AddNewTaskTranslatedText { get; set; }
        public string DeleteAllSelectedTaskTranslatedText { get; set; }
        public string DeleteAllTasksTranslatedText { get; set; }
        public MessageBox MessageBoxTranslation { get; set; }
        #endregion

        public WorkTasksPageViewModel()
        {
            SetPageLanguage(SelectedLanguage.English);
            SelectedDate = DateTime.Now;
            AddNewTaskCommand = new RelayCommand(AddNewTask);
            DeleteSelectedTasksCommand = new RelayCommand(DeleteSelectedTasks);
            DeleteAllTasksCommand = new RelayCommand(DeleteAllTasks);
        }

        public void SetPageLanguage(SelectedLanguage selectedLanguage)
        {
            Language language = null;
            switch (selectedLanguage)
            {
                case SelectedLanguage.Polish:
                    language = JsonConvert.DeserializeObject<Language>(File.ReadAllText(@"C:\Users\Dawid\Documents\Projects\ToDoAppMVVM\ToDoAppMVVM\ToDoAppMVVM.Core\Languages\PolishLanguage.json"));
                    Globals.Language = language;
                    break;
                case SelectedLanguage.English:
                    language = JsonConvert.DeserializeObject<Language>(File.ReadAllText(@"C:\Users\Dawid\Documents\Projects\ToDoAppMVVM\ToDoAppMVVM\ToDoAppMVVM.Core\Languages\EnglishLanguage.json"));
                    Globals.Language = language;
                    break;
            }
            if (WorkTasksList.Count > 0)
            {
                TranslateWorkTaskList();
            }

            YourTasksTranslatedText = language.application.taskswindow.Yourtasks;
            TitleTranslatedText = language.application.taskswindow.Title;
            DescriptionTranslatedText = language.application.taskswindow.Description;
            AddNewTaskTranslatedText = language.application.taskswindow.AddNewTaskButton;
            DeleteAllSelectedTaskTranslatedText = language.application.taskswindow.DeleteSelectedTasksButton;
            DeleteAllTasksTranslatedText = language.application.taskswindow.DeleteAllTasksButton;
            MessageBoxTranslation = language.application.MessageBox;         
            OnPropertyChanged(nameof(YourTasksTranslatedText));
            OnPropertyChanged(nameof(TitleTranslatedText));
            OnPropertyChanged(nameof(DescriptionTranslatedText));
            OnPropertyChanged(nameof(AddNewTaskTranslatedText));
            OnPropertyChanged(nameof(DeleteAllSelectedTaskTranslatedText));
            OnPropertyChanged(nameof(DeleteAllTasksTranslatedText));
        }

        private void TranslateWorkTaskList()
        {
            WorkTask translation = Globals.Language.application.WorkTask;

            WorkTasksList = new ObservableCollection<WorkTaskViewModel>(WorkTasksList.Select(t =>
            {
                t.TitleTextTranslated = translation.TaskTitle;
                t.DescriptionTextTranslated = translation.TaskDescription;
                t.CreationDateTextTranslated = translation.TaskCreationDate;
                return t;
            }));
            OnPropertyChanged(nameof(WorkTasksList));
        }

        private void AddNewTask()
        {
            if (string.IsNullOrEmpty(NewWorkTaskTitle) || string.IsNullOrEmpty(NewWorkTaskDescription))
            {
                OpenMsgBoxWhenTitleOrDescriptionIsEmpty.Invoke();
                return;
            }
            WorkTaskViewModel task = new WorkTaskViewModel
            {
                Title = NewWorkTaskTitle,
                Description = NewWorkTaskDescription,
                CreatedDate = DateTime.Now,
                TitleTextTranslated = Globals.Language.application.WorkTask.TaskTitle,
                DescriptionTextTranslated = Globals.Language.application.WorkTask.TaskDescription,
                CreationDateTextTranslated = Globals.Language.application.WorkTask.TaskCreationDate,
            };

            WorkTasksList.Add(task);
            NewWorkTaskTitle = string.Empty;
            NewWorkTaskDescription = string.Empty;
            OnPropertyChanged(nameof(NewWorkTaskTitle));
            OnPropertyChanged(nameof(NewWorkTaskDescription));
        }

        private void DeleteSelectedTasks()
        {
            foreach (WorkTaskViewModel task in WorkTasksList.Where(i => i.IsSelected == true).ToList())
            {
                WorkTasksList.Remove(task);
            }
        }

        private void DeleteAllTasks()
        {
            WorkTasksList.Clear();
        }
    }
}
