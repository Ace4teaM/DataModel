namespace DataModel.Model.BDD.Tables
{
    public class MODELE : Table
    {
        private int mODELE_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int MODELE_ID { get { return mODELE_ID; } set { mODELE_ID = value; OnPropertyChanged(); } }

        public string? mODELE_NOM;
        [FieldAttribute]
        public string? MODELE_NOM { get { return mODELE_NOM; } set { mODELE_NOM = value; OnPropertyChanged(); } }

        public string? mODELE_MARQUE;
        [FieldAttribute]
        public string? MODELE_MARQUE { get { return mODELE_MARQUE; } set { mODELE_MARQUE = value; OnPropertyChanged(); } }

        public string Libelle
        {
            get
            {
                return string.Format("{1} ({0})", mODELE_MARQUE, mODELE_NOM);
            }
        }

    }
}
