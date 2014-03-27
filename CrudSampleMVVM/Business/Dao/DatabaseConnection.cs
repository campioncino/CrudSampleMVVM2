﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// mi serve per gestire Path.Combine ... concatena la stringa con il path del db
using System.IO;

//con windows.storage recupero i percorso tramite l'application data
using Windows.Storage;

using SQLite;

using CrudSampleMVVM.Business.Model;

namespace CrudSampleMVVM.Business.Dao
{
    public sealed class DatabaseConnection
    {
        private static volatile DatabaseConnection instance;
        private static object syncRoot = new Object();

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

        
        private DatabaseConnection()
        {
            //creiamo una connessione
            using (SQLiteConnection db = new SQLiteConnection(dbPath))
            {
                //utile per il debug, il trace
                db.Trace = true;

                //creiamo una tabella, se non esiste
                db.CreateTable<Truck>();
                db.CreateTable<Transporter>();
            }
        }


        //gestiamo il multithreading
        public static DatabaseConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DatabaseConnection();
                    }
                }

                return instance;
            }

            
        }

        public static void Singleton() {
            var p = DatabaseConnection.Instance;
        }

    }
        
}

