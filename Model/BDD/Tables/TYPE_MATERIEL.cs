namespace DataModel.Model.BDD.Tables
{
    public class TYPE_MATERIEL : Table
    {
        private int tYPE_MATERIEL_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int TYPE_MATERIEL_ID { get { return tYPE_MATERIEL_ID; } set { tYPE_MATERIEL_ID = value; OnPropertyChanged(); } }

        public string? tYPE_MATERIEL_LIBELLE;
        [FieldAttribute]
        public string? TYPE_MATERIEL_LIBELLE { get { return tYPE_MATERIEL_LIBELLE; } set { tYPE_MATERIEL_LIBELLE = value; OnPropertyChanged(); } }
    }
}
