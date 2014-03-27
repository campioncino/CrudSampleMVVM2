using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;

using SQLite;

namespace CrudSampleMVVM.Business.Model
{
    public class Entity : PropertyChangedBase
    {
        
         private int _id;
        
        // se usiamo anche Autoincrement, poi non abbiamo più la possibilità di 
        // inserire noi il valore dell'id...
        [PrimaryKey, AutoIncrement]
        public int Id 
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }
    }
    
}

