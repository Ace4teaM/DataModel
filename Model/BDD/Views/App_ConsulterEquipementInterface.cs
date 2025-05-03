using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.BDD.Views
{
    public class App_ConsulterEquipementInterface : View
    {
        private int interfaceid;
        [FieldAttribute]
        public int InterfaceID { get { return interfaceid; } set { interfaceid = value; OnPropertyChanged(); } }

        private string interfaceadressemac;
        [FieldAttribute]
        public string InterfaceAdresseMac { get { return interfaceadressemac; } set { interfaceadressemac = value; OnPropertyChanged(); } }

        private string interfaceadresseip;
        [FieldAttribute]
        public string InterfaceAdresseIp { get { return interfaceadresseip; } set { interfaceadresseip = value; OnPropertyChanged(); } }

        private string? tcpServices;
        [FieldAttribute]
        public string? TcpServices { get { return tcpServices; } set { tcpServices = value; OnPropertyChanged(); } }

        public string TcpServicesList
        {
            get
            {
                return TcpServices != null ? String.Join(Environment.NewLine, TcpServices.Split(',')) : String.Empty;
            }
        }

        private int interfacematerielid;
        [FieldAttribute]
        public int InterfaceMaterielId { get { return interfacematerielid; } set { interfacematerielid = value; OnPropertyChanged(); } }
    }
}