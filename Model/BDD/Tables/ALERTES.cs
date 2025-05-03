using System.ComponentModel;

namespace DataModel.Model.BDD.Tables
{
    public class ALERTES : Table, INotifyPropertyChanged
    {
        private int aLERTES_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int ALERTES_ID { get { return aLERTES_ID; } set { aLERTES_ID = value; OnPropertyChanged(); } }

        public string aLERTES_Libelle;
        [FieldAttribute]
        public string ALERTES_Libelle { get { return aLERTES_Libelle; } set { aLERTES_Libelle = value; OnPropertyChanged(); } }


        public string aLERTES_Date;
        [FieldAttribute]
        public string ALERTES_Date { get { return aLERTES_Date; } set { aLERTES_Date = value; OnPropertyChanged(); } }


        public int aLERTES_Etat;
        [FieldAttribute]
        public int ALERTES_Etat { get { return aLERTES_Etat; } set { aLERTES_Etat = value; OnPropertyChanged(); } }


        public int aLERTES_MaterielId;
        [FieldAttribute]
        public int ALERTES_MaterielId { get { return aLERTES_MaterielId; } set { aLERTES_MaterielId = value; OnPropertyChanged(); } }

                public string TempsRestant
        {
            get
            {
                TimeSpan timeRemaining = DateTime.Parse(ALERTES_Date) - DateTime.Now;
                if (timeRemaining.TotalDays > 0)
                    return $"{timeRemaining.Days} jours, {timeRemaining.Hours} heures";
                else if (timeRemaining.TotalHours > 0)
                    return $"{timeRemaining.Hours} heures, {timeRemaining.Minutes} minutes";
                else if (timeRemaining.TotalMinutes > 0)
                    return $"{timeRemaining.Minutes} minutes";
                else
                    return "Expiré";
            }
        }
    }
}