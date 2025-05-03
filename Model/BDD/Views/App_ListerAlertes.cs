using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Model.BDD.Views
{
    public class App_ListerAlertes : View
    {

        private int aLERTES_ID;
        [FieldAttribute]
        public int ALERTES_ID { get { return aLERTES_ID; } set { aLERTES_ID = value; OnPropertyChanged(); } }

        private string aLERTES_Libelle;
        [FieldAttribute]
        public string ALERTES_Libelle { get { return aLERTES_Libelle; } set { aLERTES_Libelle = value; OnPropertyChanged(); } }

        private DateTime aLERTES_Date;
        [FieldAttribute]
        public DateTime ALERTES_Date { get { return aLERTES_Date; } set { aLERTES_Date = value; OnPropertyChanged(); } }

        private string aLERTES_Etat;
        [FieldAttribute]
        public string ALERTES_Etat { get { return aLERTES_Etat; } set { aLERTES_Etat = value; OnPropertyChanged(); } }

        private string aLERTES_MaterielId;
        [FieldAttribute]
        public string ALERTES_MaterielId { get { return aLERTES_MaterielId; } set { aLERTES_MaterielId = value; OnPropertyChanged(); } }

        private string equipementTag;
        [FieldAttribute]
        public string EquipementTag { get { return equipementTag; } set { equipementTag = value; OnPropertyChanged(); } }

        private string tempsRestant;
        [FieldAttribute]
        public string TempsRestant { get { return tempsRestant; } set { tempsRestant = value; OnPropertyChanged(); } }

        private string etatAlerte;
        [FieldAttribute]
        public string EtatAlerte { get { return etatAlerte; } set { etatAlerte = value; OnPropertyChanged(); } }
    }
}