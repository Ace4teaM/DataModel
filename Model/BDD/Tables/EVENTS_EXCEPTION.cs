namespace DataModel.Model.BDD.Tables
{
    /// <summary>
    /// Liste les éventuelles exceptions à la liste des événements
    /// </summary>
    public class EVENTS_EXCEPTION : Table
    {

        private int eVENTS_EXCEPTION_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int EVENTS_EXCEPTION_ID { get { return eVENTS_EXCEPTION_ID; } set { eVENTS_EXCEPTION_ID = value; OnPropertyChanged(); } }

        public string? eVENTS_EXCEPTION_Commentaire;
        [FieldAttribute]
        public string? EVENTS_EXCEPTION_Commentaire { get { return eVENTS_EXCEPTION_Commentaire; } set { eVENTS_EXCEPTION_Commentaire = value; OnPropertyChanged(); } }

        public string? eVENTS_EXCEPTION_Requete_Valide;
        [FieldAttribute]
        public string? EVENTS_EXCEPTION_Requete_Valide { get { return eVENTS_EXCEPTION_Requete_Valide; } set { eVENTS_EXCEPTION_Requete_Valide = value; OnPropertyChanged(); } }

    }
}
