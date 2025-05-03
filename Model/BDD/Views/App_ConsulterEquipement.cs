using DataModel.Model.BDD.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.BDD.Views
{
    public class App_ConsulterEquipement : View
    {

        private string? tag;
        [FieldAttribute]
        public string? TAG { get { return tag; } set { tag = value; OnPropertyChanged(); } }

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
        public DateTime? DATE_ACHAT { get { return date_achat; } set { date_achat = value; OnPropertyChanged(); } }

        private DateTime? date_sortie;
        [FieldAttribute]
        public DateTime? DATE_SORTIE { get { return date_sortie; } set { date_sortie = value; OnPropertyChanged(); } }

        private string? modele;
        [FieldAttribute]
        public string? MODELE { get { return modele; } set { modele = value; OnPropertyChanged(); } }

        private string? marque;
        [FieldAttribute]
        public string? MARQUE { get { return marque; } set { marque = value; OnPropertyChanged(); } }

        private int? equipement_id;
        [FieldAttribute]
        public int? EQUIPEMENT_ID { get { return equipement_id; } set { equipement_id = value; OnPropertyChanged(); } }

        private string? type_materiel;
        [FieldAttribute]
        public string? TYPE_MATERIEL { get { return type_materiel; } set { type_materiel = value; OnPropertyChanged(); } }

        private DateTime? garantiedatedebut;
        [FieldAttribute]
        public DateTime? GARANTIEDATEDEBUT { get { return garantiedatedebut; } set { garantiedatedebut = value; OnPropertyChanged(); } }

        private DateTime? garantiedatefin;
        [FieldAttribute]
        public DateTime? GARANTIEDATEFIN { get { return garantiedatefin; } set { garantiedatefin = value; OnPropertyChanged(); } }

        private string? garantielibelle;
        [FieldAttribute]
        public string? GARANTIELIBELLE { get { return garantielibelle; } set { garantielibelle = value; OnPropertyChanged(); } }

        private string? codeemplacement;
        [FieldAttribute]
        public string? CODEEMPLACEMENT { get { return codeemplacement; } set { codeemplacement = value; OnPropertyChanged(); } }

        private string? empzone;
        [FieldAttribute]
        public string? EMPZONE { get { return empzone; } set { empzone = value; OnPropertyChanged(); } }

        private string? empsecteur;
        [FieldAttribute]
        public string? EMPSECTEUR { get { return empsecteur; } set { empsecteur = value; OnPropertyChanged(); } }

        private string? empsite;
        [FieldAttribute]
        public string? EMPSITE { get { return empsite; } set { empsite = value; OnPropertyChanged(); } }

        private int? IdEmplacement;
        [FieldAttribute]
        public int? IDEMPLACEMENT { get { return IdEmplacement; } set { IdEmplacement = value; OnPropertyChanged(); } }
        
        private string? Equipement_Commentaire;
        [FieldAttribute]
        public string? EQUIPEMENT_Commentaire { get { return Equipement_Commentaire; } set { Equipement_Commentaire = value; OnPropertyChanged(); } }

        private string? garantiecommentaire;
        [FieldAttribute]
        public string? GarantieCommentaire { get { return garantiecommentaire; } set { garantiecommentaire = value; OnPropertyChanged(); } }

        private int? materielId;
        [FieldAttribute]
        public int? MaterielId { get { return materielId; } set { materielId = value; OnPropertyChanged(); } }
        private string? reseau;
        [FieldAttribute]
        public string? RESEAU { get { return reseau; } set { reseau = value; OnPropertyChanged(); } }

    }
}
