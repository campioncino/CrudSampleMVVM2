using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Windows.ApplicationModel;
// mi serve per gestire Path.Combine ... concatena la stringa con il path del db
using System.IO;
//con windows.storage recupero i percorso tramite l'application data
using Windows.Storage;

//questo mi serve per i container dinamici observable collection
//using System.Collections.ObjectModel;

//uso caliburn per adottare i container dinamici osservabili e bindabili
//ovvero i bindable collections
using Caliburn.Micro;

using CrudSampleMVVM.Business.Model;



namespace CrudSampleMVVM.Business.Dao
{
    class TransporterMapper
    
    {
        //questa stringa mi servirà per la connessione
        private static string _dbPath = string.Empty;

        private static string dbPath
        {
            get
            {
                if (string.IsNullOrEmpty(_dbPath))
                {
                    _dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "myDb.sqlite");
                }

                return _dbPath;
            }

        }

        public static void CreateDatabase()
        {
            //creiamo una connessione
            using (SQLiteConnection db = new SQLiteConnection(dbPath))
            {
                //utile per il debug, il trace
                db.Trace = true;

                //creiamo una tabella, se non esiste
                db.CreateTable<Transporter>();
            }
        }

        public static void StartUpDb()
        {
            //await Task.Run(() => CreateDatabase());
            CreateDatabase();

        }

        public static async Task<bool> Exisits(int id)
        {
            Transporter tr;
            tr = await GetTransporterById(id);
            if (tr != null)
                return true;
            else
                return false;

        }

        public static async Task SaveOrUpdate(Transporter trans)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                if (await Exisits(trans.trId))
                    db.Update(trans);
                else
                    db.Insert(trans);
            }

        }

        public static async Task UpdateTransporter(Transporter trans)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.Update(trans);
            }
        }

        public static async Task DeleteTransporter(Transporter trans)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                //sempre il tracing
                db.Trace = true;

                //possiamo usare due diversi modi per cancellare gli oggetti
                //sempre perchè stiamo usando una libreria progettata da
                //altri, che in teoria non ci costringe a dover aprire/chiudere
                //esplicitamente ogni volta il db...operazioni trasparenti

                //Object
                db.Delete(trans);

                //Sql 
                //db.Execute("DELETE FROM tmpona WHERE ID =?", tmpon.Id);
            }
        }

        
        /* FUNZIONI DI RICERCA */

        //Elenco completo di tutti i Transporter presenti
        public static async Task<BindableCollection<Transporter>> GetAllTransporters()
        {
            List<Transporter> transporters;
            using (var db = new SQLiteConnection(dbPath))
            {
                // Activate Tracing
                db.Trace = true;

                transporters = (from p in db.Table<Transporter>()
                                select p).ToList();

            }
            var obsTransporters = new BindableCollection<Transporter>();
            foreach (var item in transporters)
            {
                obsTransporters.Add(item);
            }
            return obsTransporters;
        }

        public static async Task<BindableCollection<Transporter>> SearchTransporter(Transporter transporter) 
        {
            List<Transporter> trans;

            using (var db = new SQLiteConnection(dbPath))
            {
                var tmp = from p in db.Table<Transporter>() select p;
                if(transporter.trId !=null)
                    tmp = tmp.Where(p => p.trId==transporter.trId);
                if(string.IsNullOrEmpty(transporter.trName))
                    tmp = tmp.Where(p => p.trName.Contains(transporter.trName));
                if(string.IsNullOrEmpty(transporter.trUrl))
                    tmp=tmp.Where(p=> p.trUrl==transporter.trUrl);
                if (string.IsNullOrEmpty(transporter.trCode))
                    tmp = tmp.Where(p => p.trCode == transporter.trCode);
                trans = tmp.ToList();
            }
            var obsTransporters = new BindableCollection<Transporter>();
            foreach (var item in trans)
            {
                obsTransporters.Add(item);
            }
            return obsTransporters;
        }
        
        // search by Transporter.Id
        public static async Task<Transporter> GetTransporterById(int id)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                Transporter trans = (from p in db.Table<Transporter>()
                                     where p.trId == id
                                     select p).FirstOrDefault();

                return trans;
            }

        }
        
        // seach by Transporter.Name
        public static async Task<BindableCollection<Transporter>> GetTransporterByName(String name)
        {
            List<Transporter> trans;
            using (var db = new SQLiteConnection(dbPath)) 
            {
                trans = (from p in db.Table<Transporter>() 
                         where p.trName.Contains(name) 
                         select p).ToList();
            }
            var obsTransporters = new BindableCollection<Transporter>();
            foreach (var item in trans)
            {
                obsTransporters.Add(item);
            }
            return obsTransporters;
        }


        // search by Transporter.Url  
        public static async Task<BindableCollection<Transporter>> GetTransporterByUrl(String url)
        {
            List<Transporter> trans;
            using (var db = new SQLiteConnection(dbPath))
            {
                trans = (from p in db.Table<Transporter>() where p.trUrl.Contains(url) select p).ToList();
            }
            var obsTransporters = new BindableCollection<Transporter>();
            foreach (var item in trans)
            {
                obsTransporters.Add(item);
            }
            return obsTransporters;
        }

        // search by Transporter.Code 
        public static async Task<BindableCollection<Transporter>> GetTransporterByCode(String code)
        {
            List<Transporter> trans;
            using (var db = new SQLiteConnection(dbPath))
            {
                trans = (from p in db.Table<Transporter>() where p.trCode.Contains(code) select p).ToList();
            }
            var obsTransporters = new BindableCollection<Transporter>();
            foreach (var item in trans)
            {
                obsTransporters.Add(item);
            }
            return obsTransporters;
        } 

        /* DEBUG FUNCTIONS */

        //ci ritorna l'id cercato...funzione usata per qlc debug..mi sa che se po levà
        public static async Task<Int32> GetTransporterId(int transId)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                Transporter trans = (from p in db.Table<Transporter>()
                                     where p.trId == transId
                                     select p).FirstOrDefault();

                return trans.Id;
            }

        }

        
    }//end class
}


