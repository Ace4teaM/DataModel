namespace DataModel.Model.BDD.Views
{
    public class App_AjouterEquipementMateriel : View
    {
        private string? numserie;
        [FieldAttribute]
        public string? NumSerie { get { return numserie; } set { numserie = value; OnPropertyChanged(); } }

        private string? type_materiel;
        [FieldAttribute]
        public string? Type_Materiel { get { return type_materiel; } set { type_materiel = value; OnPropertyChanged(); } }

        private string? modele;
        [FieldAttribute]
        public string? Modele { get { return modele; } set { modele = value; OnPropertyChanged(); } }

        private string? marque;
        [FieldAttribute]
        public string? Marque { get { return marque; } set { marque = value; OnPropertyChanged(); } }
    }
}
