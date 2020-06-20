using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace xamarinFormsExamenOpdrachtJune12.Models
{
    public class Todo : INotifyPropertyChanged
    {
        public string Id { get; set; }

        public string Title { get; set; }

            /*
        private string title = "";
        public string Title
        {
            get 
            {
                return title;
            }
            set
            {
                title = value;

                OnPropertyChanged("Title");
            }
        }
        */
        


        public string Description { get; set; }
        

        private bool done = false;
        public bool Done
        {
            get { return done; }
            set 
            { 
                done = value;
                OnPropertyChanged("Done");
            }
        }

        private int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value >= 1 ? value : 1;

                OnPropertyChanged("Quantity");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
