using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.BDD.Views
{
    public class App_ConsulterEquipementConnexions : View
    {
        private int? equipement_Id;
        [FieldAttribute]
        public int? Equipement_Id { get { return equipement_Id; } set { equipement_Id = value; OnPropertyChanged(); } }

        private int? connexion_id;
        [FieldAttribute]
        public int? Connexion_ID { get { return connexion_id; } set { connexion_id = value; OnPropertyChanged(); } }

        private string? libelle;
        [FieldAttribute]
        public string? Libelle { get { return libelle; } set { libelle = value; OnPropertyChanged(); } }

        private string? source;
        [FieldAttribute]
        public string? Source { get { return source; } set { source = value; OnPropertyChanged(); } }

        private string? cible;
        [FieldAttribute]
        public string? Cible { get { return cible; } set { cible = value; OnPropertyChanged(); } }

        private string? sourceDesc;
        [FieldAttribute]
        public string? SourceDesc { get { return sourceDesc; } set { sourceDesc = value; OnPropertyChanged(); } }

        private string? sourceEmpl;
        [FieldAttribute]
        public string? SourceEmpl { get { return sourceEmpl; } set { sourceEmpl = value; OnPropertyChanged(); } }

        private string? destinationDesc;
        [FieldAttribute]
        public string? DestinationDesc { get { return destinationDesc; } set { destinationDesc = value; OnPropertyChanged(); } }

        private string? destinationEmpl;
        [FieldAttribute]
        public string? DestinationEmpl { get { return destinationEmpl; } set { destinationEmpl = value; OnPropertyChanged(); } }

    }
}
