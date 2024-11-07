using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoListMAUI.Model
{
    public class ToDoTask : INotifyPropertyChanged
    {
        private string _title;
        private bool _isDone;

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsDone
        {
            get => _isDone;
            set
            {
                if (_isDone != value)
                {
                    _isDone = value;
                    OnPropertyChanged();
                }
            }
        }

        public ToDoTask(string title)
        {
            Title = title;
            IsDone = false;
        }

        public ToDoTask(string title, bool isDone)
        {
            Title = title;
            IsDone = isDone;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
