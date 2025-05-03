using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.BDD.Views
{
    public class App_ConsulterEmplacementConnexions : View
    {
        private int? emplacement_Id;
        [FieldAttribute]
        public int? Emplacement_Id { get { return emplacement_Id; } set { emplacement_Id = value; OnPropertyChanged(); } }

        private int? connexion_id;
        [FieldAttribute]
        public int? Connexion_ID { get { return connexion_id; } set { connexion_id = value; OnPropertyChanged(); } }

        private string? emplacement_Code;
        [FieldAttribute]
        public string? Emplacement_Code { get { return emplacement_Code; } set { emplacement_Code = value; OnPropertyChanged(); } }

        private string? source;
        [FieldAttribute]
        public string? Source { get { return source; } set { source = value; OnPropertyChanged(); } }

        private string? destination;
        [FieldAttribute]
        public string? Destination { get { return destination; } set { destination = value; OnPropertyChanged(); } }

        private string? cONNEXION_Libelle;
        [FieldAttribute]
        public string? CONNEXION_Libelle { get { return cONNEXION_Libelle; } set { cONNEXION_Libelle = value; OnPropertyChanged(); } }

    }
}
