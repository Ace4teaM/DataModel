namespace DataModel.Model.BDD.Tables
{
    public class EMPLACEMENT : Table
    {
        public string FullName
        {
            get
            {
                return String.Format("{1} > {2} > {3} > {4} ({0})", EMPLACEMENT_Code, EMPLACEMENT_Site, EMPLACEMENT_Zone, EMPLACEMENT_Secteur, EMPLACEMENT_Libelle);
            }
        }
        public string FullNameByCode
        {
            get
            {
                return String.Format("{0} : {1} > {2} > {3} > {4}", EMPLACEMENT_Code, EMPLACEMENT_Site, EMPLACEMENT_Zone, EMPLACEMENT_Secteur, EMPLACEMENT_Libelle);
            }
        }
        private int eMPLACEMENT_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int EMPLACEMENT_ID { get { return eMPLACEMENT_ID; } set { eMPLACEMENT_ID = value; OnPropertyChanged(); } }
        public string? eMPLACEMENT_Libelle;
        [FieldAttribute]
        public string? EMPLACEMENT_Libelle { get { return eMPLACEMENT_Libelle; } set { eMPLACEMENT_Libelle = value; OnPropertyChanged(); } }
        public string? eMPLACEMENT_Code;
        [FieldAttribute]
        public string? EMPLACEMENT_Code { get { return eMPLACEMENT_Code; } set { eMPLACEMENT_Code = value; OnPropertyChanged(); } }
        public string? eMPLACEMENT_Zone;
        [FieldAttribute]
        public string? EMPLACEMENT_Zone { get { return eMPLACEMENT_Zone; } set { eMPLACEMENT_Zone = value; OnPropertyChanged(); } }
        public string? eMPLACEMENT_Secteur;
        [FieldAttribute]
        public string? EMPLACEMENT_Secteur { get { return eMPLACEMENT_Secteur; } set { eMPLACEMENT_Secteur = value; OnPropertyChanged(); } }
        public string? eMPLACEMENT_Site;
        [FieldAttribute]
        public string? EMPLACEMENT_Site { get { return eMPLACEMENT_Site; } set { eMPLACEMENT_Site = value; OnPropertyChanged(); } }
        public string? eMPLACEMENT_Tag;
        [FieldAttribute]
        public string? EMPLACEMENT_Tag { get { return eMPLACEMENT_Tag; } set { eMPLACEMENT_Tag = value; OnPropertyChanged(); } }
        public string? eMPLACEMENT_Local;
        [FieldAttribute]
        public string? EMPLACEMENT_Local { get { return eMPLACEMENT_Local; } set { eMPLACEMENT_Local = value; OnPropertyChanged(); } }
        public string? eMPLACEMENT_Localisation;
        [FieldAttribute]
        public string? EMPLACEMENT_Localisation { get { return eMPLACEMENT_Localisation; } set { eMPLACEMENT_Localisation = value; OnPropertyChanged(); } }
    }
}