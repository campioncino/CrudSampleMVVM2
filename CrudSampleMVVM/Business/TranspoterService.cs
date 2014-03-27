using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;

using CrudSampleMVVM.Business.Dao;
using CrudSampleMVVM.Business.Model;

namespace CrudSampleMVVM.Business
{
    class TransporterService
    {

        public static void createDb()
        {
            TransporterMapper.CreateDatabase();
        }

        public async static Task<bool> Exist(int transId)
        {
            bool exist = await TransporterMapper.Exisits(transId);
            return exist;
        }
        public static async Task SaveTransporter(Transporter trans)
        {
            await TransporterMapper.SaveOrUpdate(trans);
        }

        public static async Task UpdateTransporter(Transporter trans)
        {
            await TransporterMapper.UpdateTransporter(trans);
        }


        /* SEARCH FUNCTIONS */ 

        public static async Task<BindableCollection<Transporter>> GetAll()
        {
            var list = new BindableCollection<Transporter>();
            list = await TransporterMapper.GetAllTransporters();
            return list;
        }

        public static async Task<BindableCollection<Transporter>> Search(Transporter transporter)
        {
            BindableCollection<Transporter> transList = new BindableCollection<Transporter>();
            transList = await TransporterMapper.SearchTransporter(transporter);
            return transList;
        }

        public static async Task<Int32> GetId(int transId)
        {
            Int32 tableId;
            tableId = await TransporterMapper.GetTransporterId(transId);
            return tableId;
        }
        public static async Task<int> getId(int id)
        {

            Transporter t = await TransporterMapper.GetTransporterById(id);
            return t.Id;
        }

        public static async Task<BindableCollection<Transporter>> Search(int id, string name, string url, string code)
        {

            Transporter trans = new Transporter();
            BindableCollection<Transporter> transList = new BindableCollection<Transporter>();

            if (id != 0)
            {
                trans = await TransporterMapper.GetTransporterById(id);
                transList.Add(trans);
            }

            else if ((!String.IsNullOrEmpty(name)) || (!String.IsNullOrEmpty(url)) || (!String.IsNullOrEmpty(code)))
            {
                if (!String.IsNullOrEmpty(name))
                {
                    transList = await TransporterMapper.GetTransporterByName(name);
                }
                else if (!String.IsNullOrEmpty(url))
                {
                    transList = await TransporterMapper.GetTransporterByUrl(url);
                }
                else if (!String.IsNullOrEmpty(code))
                {
                    transList = await TransporterMapper.GetTransporterByCode(code);
                }

            }

            else if ((String.IsNullOrEmpty(name)) && (id == 0) && (String.IsNullOrEmpty(url)) && (String.IsNullOrEmpty(code)))
            {
                transList = await TransporterMapper.GetAllTransporters();
            }

            return transList;

        }
    }
}
