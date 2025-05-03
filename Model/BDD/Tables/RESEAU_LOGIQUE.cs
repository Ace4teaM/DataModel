namespace DataModel.Model.BDD.Tables
{
    public class RESEAU_LOGIQUE : Table
    {
        public int rESEAU_LOGIQUE_ID;
        [IdentityKey]
        [PrimaryKeyAttribute]
        public int RESEAU_LOGIQUE_ID { get { return rESEAU_LOGIQUE_ID; } set { rESEAU_LOGIQUE_ID = value; OnPropertyChanged(); } }
        
        private string rESEAU_LOGIQUE_Libelle;
        [FieldAttribute]
        public string RESEAU_LOGIQUE_Libelle { get { return rESEAU_LOGIQUE_Libelle; } set { rESEAU_LOGIQUE_Libelle = value; OnPropertyChanged(); } }
        private string? rESEAU_LOGIQUE_Couleur;
        [FieldAttribute]
        public string? RESEAU_LOGIQUE_Couleur { get { return rESEAU_LOGIQUE_Couleur; } set { rESEAU_LOGIQUE_Couleur = value; OnPropertyChanged(); } }
    }
}