using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoListMAUI.Model;

namespace ToDoListMAUI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "") => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ObservableCollection<ToDoTask> tasks { get; set; }

        public Command AddCommand { get; private set; }
        public Command DeleteCommand { get; private set; }
        public Command CompleteCommand { get; private set; }  


        string _title = string.Empty;
        public string Title
        {
            get => _title;
            set
            {
                if (value != _title)
                {
                    _title = value;
                    OnPropertyChanged();
                    (AddCommand).ChangeCanExecute();
                }
            }
        }

        public MainViewModel() 
        {
            tasks = [];

            AddCommand = new Command(
                execute: () =>
                {
                    tasks.Add(new ToDoTask(Title));
                    Title = string.Empty;
                },
                canExecute: () =>
                {
                    return !string.IsNullOrEmpty(Title);
                }
            );
            
            DeleteCommand = new Command<ToDoTask>(
                execute: (task) =>
                {
                    tasks.Remove(task);
                }
            );  

            CompleteCommand = new Command<ToDoTask>(
                execute: (task) =>
                {
                    (task).IsDone = !(task).IsDone;
                }
            );
        }
    }
}
