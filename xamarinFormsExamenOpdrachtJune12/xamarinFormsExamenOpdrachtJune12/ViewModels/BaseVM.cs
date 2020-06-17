using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using xamarinFormsExamenOpdrachtJune12.Models;
using xamarinFormsExamenOpdrachtJune12.Services;

namespace xamarinFormsExamenOpdrachtJune12.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        public IStore<TodoList, Todo> DataStore => DependencyService.Get<IStore<TodoList, Todo>>();

        bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        
        bool isBusyTodoList = false;

        public bool IsBusyTodoList
        {
            get { return isBusyTodoList; }
            set { SetProperty(ref isBusyTodoList, value); }
        }
        



        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);

            return true;
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
