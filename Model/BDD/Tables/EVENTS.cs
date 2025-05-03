namespace DataModel.Model.BDD.Tables
{
    public class EVENTS : Table
    {

        private int eVENTS_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int EVENTS_ID { get { return eVENTS_ID; } set { eVENTS_ID = value; OnPropertyChanged(); } }

        public string? eVENTS_Libelle;
        [FieldAttribute]
        public string? EVENTS_Libelle { get { return eVENTS_Libelle; } set { eVENTS_Libelle = value; OnPropertyChanged(); } }

        public DateTime? eVENTS_Date;
        [FieldAttribute]
        public DateTime? EVENTS_Date { get { return eVENTS_Date; } set { eVENTS_Date = value; OnPropertyChanged(); } }

        public string? eVENTS_Requete_Ignore;
        [FieldAttribute]
        public string? EVENTS_Requete_Ignore { get { return eVENTS_Requete_Ignore; } set { eVENTS_Requete_Ignore = value; OnPropertyChanged(); } }

        public string? eVENTS_Requete_Valide;
        [FieldAttribute]
        public string? EVENTS_Requete_Valide { get { return eVENTS_Requete_Valide; } set { eVENTS_Requete_Valide = value; OnPropertyChanged(); } }

        public bool? eVENTS_Exception;
        [FieldAttribute]
        public bool? EVENTS_EXCEPTION { get { return eVENTS_Exception; } set { eVENTS_Exception = value; OnPropertyChanged(); } }

        public string? eVENTS_Type;
        [FieldAttribute]
        public string? EVENTS_Type { get { return eVENTS_Type; } set { eVENTS_Type = value; OnPropertyChanged(); } }
    }
}
