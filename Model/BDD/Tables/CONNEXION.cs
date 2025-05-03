namespace DataModel.Model.BDD.Tables
{
    public class CONNEXION : Table
    {
        private int cONNEXION_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int CONNEXION_ID { get { return cONNEXION_ID; } set { cONNEXION_ID = value; OnPropertyChanged(); } }

        public string cONNEXION_Libelle;
        [FieldAttribute]
        public string CONNEXION_Libelle { get { return cONNEXION_Libelle; } set { cONNEXION_Libelle = value; OnPropertyChanged(); } }

        public string cONNEXION_AboutissantTag;
        [FieldAttribute]
        public string CONNEXION_AboutissantTag { get { return cONNEXION_AboutissantTag; } set { cONNEXION_AboutissantTag = value; OnPropertyChanged(); } }

        public string cONNEXION_TenantTag;
        [FieldAttribute]
        public string CONNEXION_TenantTag { get { return cONNEXION_TenantTag; } set { cONNEXION_TenantTag = value; OnPropertyChanged(); } }

        public string? CONNEXION_AboutissantEmplacement
        {
            get
            {
                var index = CONNEXION_AboutissantTag.LastIndexOf("+");
                if (index == -1)
                    return null;

                return CONNEXION_AboutissantTag.Substring(0, index);
            }
        }

        public string? CONNEXION_TenantEmplacement
        {
            get
            {
                var index = CONNEXION_TenantTag.LastIndexOf("+");
                if (index == -1)
                    return null;

                return CONNEXION_TenantTag.Substring(0, index);
            }
        }

        public string? CONNEXION_AboutissantEquipement
        {
            get
            {
                var index = CONNEXION_AboutissantTag.LastIndexOf("+");
                if (index == -1)
                    return null;

                var port = CONNEXION_AboutissantTag.LastIndexOf(".");
                if (port == -1)
                    return CONNEXION_AboutissantTag.Substring(index + 1);

                return CONNEXION_AboutissantTag.Substring(index + 1, port - index);
            }
        }

        public string? CONNEXION_TenantEquipement
        {
            get
            {
                var index = CONNEXION_TenantTag.LastIndexOf("+");
                if (index == -1)
                    return null;

                var port = CONNEXION_TenantTag.LastIndexOf(".");
                if (port == -1)
                    return CONNEXION_TenantTag.Substring(index + 1);

                return CONNEXION_TenantTag.Substring(index + 1, port - index);
            }
        }

        public int? CONNEXION_AboutissantPort
        {
            get
            {
                var index = CONNEXION_AboutissantTag.LastIndexOf(".");
                if (index == -1)
                    return null;

                int port;
                if (int.TryParse(CONNEXION_AboutissantTag.Substring(index + 1), out port))
                    return port;

                return null;
            }
        }

        public int? CONNEXION_TenantPort
        {
            get
            {
                var index = CONNEXION_TenantTag.LastIndexOf(".");
                if (index == -1)
                    return null;

                int port;
                if(int.TryParse(CONNEXION_TenantTag.Substring(index + 1), out port))
                    return port;

                return null;
            }
        }
    }
}