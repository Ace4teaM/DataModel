namespace DataModel.Model.BDD.Tables
{
    public class TACHE : Table
    {
        private int tACHE_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int TACHE_ID { get { return tACHE_ID; } set { tACHE_ID = value; OnPropertyChanged(); } }

        public string tACHE_Nom;
        [FieldAttribute]
        public string TACHE_Nom { get { return tACHE_Nom; } set { tACHE_Nom = value; OnPropertyChanged(); } }

        public DateTime tACHE_Date;
        [FieldAttribute]
        public DateTime TACHE_Date { get { return tACHE_Date; } set { tACHE_Date = value; OnPropertyChanged(); } }

        public DateTime? tACHE_Date_Debut;
        [FieldAttribute]
        public DateTime? TACHE_Date_Debut { get { return tACHE_Date_Debut; } set { tACHE_Date_Debut = value; OnPropertyChanged(); } }

        public DateTime? tACHE_Date_Fin;
        [FieldAttribute]
        public DateTime? TACHE_Date_Fin { get { return tACHE_Date_Fin; } set { tACHE_Date_Fin = value; OnPropertyChanged(); } }

        public byte[]? tACHE_Data_Sortie;
        [FieldAttribute]
        public byte[]? TACHE_Data_Sortie { get { return tACHE_Data_Sortie; } set { tACHE_Data_Sortie = value; OnPropertyChanged(); } }
        public string? tACHE_Nom_Sortie;
        [FieldAttribute]
        public string? TACHE_Nom_Sortie { get { return tACHE_Nom_Sortie; } set { tACHE_Nom_Sortie = value; OnPropertyChanged(); } }
        public byte[]? tACHE_Data_Entree;
        [FieldAttribute]
        public byte[]? TACHE_Data_Entree { get { return tACHE_Data_Entree; } set { tACHE_Data_Entree = value; OnPropertyChanged(); } }
        public string? tACHE_Nom_Entree;
        [FieldAttribute]
        public string? TACHE_Nom_Entree { get { return tACHE_Nom_Entree; } set { tACHE_Nom_Entree = value; OnPropertyChanged(); } }
    }
}