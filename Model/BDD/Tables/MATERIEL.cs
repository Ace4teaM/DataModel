namespace DataModel.Model.BDD.Tables
{
    public class MATERIEL : Table
    {

        private int mATERIEL_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int MATERIEL_ID { get { return mATERIEL_ID; } set { mATERIEL_ID = value; OnPropertyChanged(); } }

        public string? mATERIEL_NumSerie;
        [FieldAttribute]
        public string? MATERIEL_NumSerie { get { return mATERIEL_NumSerie; } set { mATERIEL_NumSerie = value; OnPropertyChanged(); } }

        public DateTime? mATERIEL_DateAchat;
        [FieldAttribute]
        public DateTime? MATERIEL_DateAchat { get { return mATERIEL_DateAchat; } set { mATERIEL_DateAchat = value; OnPropertyChanged(); } }

        public DateTime? mATERIEL_GarantieDateDebut;
        [FieldAttribute]
        public DateTime? MATERIEL_GarantieDateDebut { get { return mATERIEL_GarantieDateDebut; } set { mATERIEL_GarantieDateDebut = value; OnPropertyChanged(); } }

        public DateTime? mATERIEL_GarantieDateFin;
        [FieldAttribute]
        public DateTime? MATERIEL_GarantieDateFin { get { return mATERIEL_GarantieDateFin; } set { mATERIEL_GarantieDateFin = value; OnPropertyChanged(); } }

        public string? mATERIEL_GarantieLibelle;
        [FieldAttribute]
        public string? MATERIEL_GarantieLibelle { get { return mATERIEL_GarantieLibelle; } set { mATERIEL_GarantieLibelle = value; OnPropertyChanged(); } }

        public int? mATERIEL_ModeleId;
        [FieldAttribute]
        public int? MATERIEL_ModeleId { get { return mATERIEL_ModeleId; } set { mATERIEL_ModeleId = value; OnPropertyChanged(); } }

        public int? mATERIEL_TypeMateriel;
        [FieldAttribute]
        public int? MATERIEL_TypeMateriel { get { return mATERIEL_TypeMateriel; } set { mATERIEL_TypeMateriel = value; OnPropertyChanged(); } }

        public DateTime? mATERIEL_DateSortie;
        [FieldAttribute]
        public DateTime? MATERIEL_DateSortie { get { return mATERIEL_DateSortie; } set { mATERIEL_DateSortie = value; OnPropertyChanged(); } }

        public string? mATERIEL_RaisonSortie;
        [FieldAttribute]
        public string? MATERIEL_RaisonSortie { get { return mATERIEL_RaisonSortie; } set { mATERIEL_RaisonSortie = value; OnPropertyChanged(); } }

        public string? mATERIEL_GarantieCommentaire;
        [FieldAttribute]
        public string? MATERIEL_GarantieCommentaire { get { return mATERIEL_GarantieCommentaire; } set { mATERIEL_GarantieCommentaire = value; OnPropertyChanged(); } }

        public string? mATERIEL_EquipementTAG;
        [FieldAttribute]
        public string? MATERIEL_EquipementTAG { get { return mATERIEL_EquipementTAG; } set { mATERIEL_EquipementTAG = value; OnPropertyChanged(); } }

        public int? mATERIEL_NUMBER;
        [FieldAttribute]
        [Default]
        public int? MATERIEL_NUMBER { get { return mATERIEL_NUMBER; } set { mATERIEL_NUMBER = value; OnPropertyChanged(); } }

    }
}
