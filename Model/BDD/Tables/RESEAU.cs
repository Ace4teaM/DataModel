namespace DataModel.Model.BDD.Tables
{
    public class RESEAU : Table
    {
        private string rESEAU_Libelle;
        [FieldAttribute]
        public string RESEAU_Libelle { get { return rESEAU_Libelle; } set { rESEAU_Libelle = value; OnPropertyChanged(); } }

        public string rESEAU_Prefixe;
        [PrimaryKeyAttribute]
        public string RESEAU_Prefixe { get { return rESEAU_Prefixe; } set { rESEAU_Prefixe = value; OnPropertyChanged(); } }

        public int rESEAU_VLAN;
        [FieldAttribute]
        public int RESEAU_VLAN { get { return rESEAU_VLAN; } set { rESEAU_VLAN = value; OnPropertyChanged(); } }
    }
}