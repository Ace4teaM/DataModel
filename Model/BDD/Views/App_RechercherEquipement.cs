using DataModel.Model.BDD.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.BDD.Views
{
    public class App_RechercherEquipement : View
    {
        private string? emplacement_code;
        [FieldAttribute]
        public string? EMPLACEMENT_CODE { get { return emplacement_code; } set { emplacement_code = value; OnPropertyChanged(); } }

        private string? emplacement_site;
        [FieldAttribute]
        public string? EMPLACEMENT_Site { get { return emplacement_site; } set { emplacement_site = value; OnPropertyChanged(); } }

        private string? emplacement_zone;
        [FieldAttribute]
        public string? EMPLACEMENT_Zone { get { return emplacement_zone; } set { emplacement_zone = value; OnPropertyChanged(); } }

        private string? emplacement_secteur;
        [FieldAttribute]
        public string? EMPLACEMENT_Secteur { get { return emplacement_secteur; } set { emplacement_secteur = value; OnPropertyChanged(); } }

        private string? equipement_code;
        [FieldAttribute]
        public string? EQUIPEMENT_CODE { get { return equipement_code; } set { equipement_code = value; OnPropertyChanged(); } }

        private string? equipement_description;
        [FieldAttribute]
        public string? EQUIPEMENT_Description { get { return equipement_description; } set { equipement_description = value; OnPropertyChanged(); } }

        private string? emplacement_libelle;
        [FieldAttribute]
        public string? EMPLACEMENT_Libelle { get { return emplacement_libelle; } set { emplacement_libelle = value; OnPropertyChanged(); } }

        private string? etat;
        [FieldAttribute]
        public string? Etat { get { return etat; } set { etat = value; OnPropertyChanged(); } }

        private string? numserie;
        [FieldAttribute]
        public string? NumSerie { get { return numserie; } set { numserie = value; OnPropertyChanged(); } }

        private DateTime? date_achat;
        [FieldAttribute]
        public DateTime? Date_Achat { get { return date_achat; } set { date_achat = value; OnPropertyChanged(); } }

        private string? modele;
        [FieldAttribute]
        public string? Modele { get { return modele; } set { modele = value; OnPropertyChanged(); } }

        private string? marque;
        [FieldAttribute]
        public string? Marque { get { return marque; } set { marque = value; OnPropertyChanged(); } }

        private int? equipement_id;
        [FieldAttribute]
        public int? Equipement_ID { get { return equipement_id; } set { equipement_id = value; OnPropertyChanged(); } }

        private string? typemateriel;
        [FieldAttribute]
        public string? TypeMateriel { get { return typemateriel; } set { typemateriel = value; OnPropertyChanged(); } }
    }
}
