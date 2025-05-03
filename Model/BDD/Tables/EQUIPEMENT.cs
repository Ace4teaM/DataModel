namespace DataModel.Model.BDD.Tables
{
    public class EQUIPEMENT : Table
    {
        private int eQUIPEMENT_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int EQUIPEMENT_ID { get { return eQUIPEMENT_ID; } set { eQUIPEMENT_ID = value; OnPropertyChanged(); } }

        public string? eQUIPEMENT_CODE;
        [FieldAttribute]
        public string? EQUIPEMENT_CODE { get { return eQUIPEMENT_CODE; } set { eQUIPEMENT_CODE = value; OnPropertyChanged(); } }

        public int? eQUIPEMENT_EtatRepere;
        [FieldAttribute]
        public int? EQUIPEMENT_EtatRepere { get { return eQUIPEMENT_EtatRepere; } set { eQUIPEMENT_EtatRepere = value; OnPropertyChanged(); } }

        public string? eQUIPEMENT_Description;
        [FieldAttribute]
        public string? EQUIPEMENT_Description { get { return eQUIPEMENT_Description; } set { eQUIPEMENT_Description = value; OnPropertyChanged(); } }

        public int? eQUIPEMENT_EmplacementId;
        [FieldAttribute]
        public int? EQUIPEMENT_EmplacementId { get { return eQUIPEMENT_EmplacementId; } set { eQUIPEMENT_EmplacementId = value; OnPropertyChanged(); } }

        public string? eQUIPEMENT_Commentaire;
        [FieldAttribute]
        public string? EQUIPEMENT_Commentaire { get { return eQUIPEMENT_Commentaire; } set { eQUIPEMENT_Commentaire = value; OnPropertyChanged(); } }

        public string? eQUIPEMENT_HOSTNAME;
        [FieldAttribute]
        public string? EQUIPEMENT_HOSTNAME { get { return eQUIPEMENT_HOSTNAME; } set { eQUIPEMENT_HOSTNAME = value; OnPropertyChanged(); } }

        public EMPLACEMENT? Emplacement { get; set; }
        private int? eQUIPEMENT_MATERIELID;
        [FieldAttribute]
        public int? EQUIPEMENT_MATERIELID { get { return eQUIPEMENT_MATERIELID; } set { eQUIPEMENT_MATERIELID = value; OnPropertyChanged(); } }

        public int? eQUIPEMENT_ReseauLogiqueId;
        [FieldAttribute]
        public int? EQUIPEMENT_ReseauLogiqueId { get { return eQUIPEMENT_ReseauLogiqueId; } set { eQUIPEMENT_ReseauLogiqueId = value; OnPropertyChanged(); } }

    }
}