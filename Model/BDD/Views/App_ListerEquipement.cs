using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.BDD.Views
{
    public class App_ListerEquipement : View
    {

        private string? tag;
        [FieldAttribute]
        public string? TAG { get { return tag; } set { tag = value; OnPropertyChanged(); } }

        private string? hostName;
        [FieldAttribute]
        public string? HostName { get { return hostName; } set { hostName = value; OnPropertyChanged(); } }

        private string? description;
        [FieldAttribute]
        public string? DESCRIPTION { get { return description; } set { description = value; OnPropertyChanged(); } }

        private string? etat;
        [FieldAttribute]
        public string? ETAT { get { return etat; } set { etat = value; OnPropertyChanged(); } }

        private string? libelle_emplacement;
        [FieldAttribute]
        public string? LIBELLE_EMPLACEMENT { get { return libelle_emplacement; } set { libelle_emplacement = value; OnPropertyChanged(); } }

        private string? numserie;
        [FieldAttribute]
        public string? NUMSERIE { get { return numserie; } set { numserie = value; OnPropertyChanged(); } }

        private DateTime? date_achat;
        [FieldAttribute]
        public DateTime? DATE_ACHAT { get { return date_achat; } set { date_achat = value; OnPropertyChanged(); OnPropertyChanged("DateAchatFormatee"); } }

        public string? DateAchatFormatee { get { return date_achat?.ToString("dd/MM/yyyy"); } }

        private string? modele;
        [FieldAttribute]
        public string? MODELE { get { return modele; } set { modele = value; OnPropertyChanged(); } }

        private string? marque;
        [FieldAttribute]
        public string? MARQUE { get { return marque; } set { marque = value; OnPropertyChanged(); } }

        private string? typeMateriel;
        [FieldAttribute]
        public string? TypeMateriel { get { return typeMateriel; } set { typeMateriel = value; OnPropertyChanged(); } }

        private int? equipement_id;
        [FieldAttribute]
        public int? EQUIPEMENT_ID { get { return equipement_id; } set { equipement_id = value; OnPropertyChanged(); } }

        private int? materiel_id;
        [FieldAttribute]
        public int? Materiel_Id { get { return materiel_id; } set { materiel_id = value; OnPropertyChanged(); } }

        private string? adressesMac;
        [FieldAttribute]
        public string? AdressesMac { get { return adressesMac; } set { adressesMac = value; OnPropertyChanged(); } }

        private string? adressesIP;
        [FieldAttribute]
        public string? AdressesIP { get { return adressesIP; } set { adressesIP = value; OnPropertyChanged(); } }
        private string? reseauxIP;
        [FieldAttribute]
        public string? ReseauxIP { get { return reseauxIP; } set { reseauxIP = value; OnPropertyChanged(); } }
        private string? secteur;
        [FieldAttribute]
        public string? Secteur { get { return secteur; } set { secteur = value; OnPropertyChanged(); } }
        private string? reseau;
        [FieldAttribute]
        public string? RESEAU { get { return reseau; } set { reseau = value; OnPropertyChanged(); } }
        private int? reseau_id;
        [FieldAttribute]
        public int? RESEAU_ID { get { return reseau_id; } set { reseau_id = value; OnPropertyChanged(); } }
        private int? nUMMATERIEL;
        [FieldAttribute]
        public int? NUMMATERIEL { get { return nUMMATERIEL; } set { nUMMATERIEL = value; OnPropertyChanged(); } }

    }
}