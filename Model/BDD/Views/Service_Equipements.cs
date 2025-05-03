namespace DataModel.Model.BDD.Views
{
    public class Service_Equipements : View
    {

        private string? tag;
        [FieldAttribute]
        public string? TAG { get { return tag; } set { tag = value; OnPropertyChanged(); } }

        private string? description;
        [FieldAttribute]
        public string? DESCRIPTION { get { return description; } set { description = value; OnPropertyChanged(); } }

        private string? libelle_emplacement;
        [FieldAttribute]
        public string? LIBELLE_EMPLACEMENT { get { return libelle_emplacement; } set { libelle_emplacement = value; OnPropertyChanged(); } }

        private int? equipement_id;
        [FieldAttribute]
        public int? EQUIPEMENT_ID { get { return equipement_id; } set { equipement_id = value; OnPropertyChanged(); } }
        private int? emplacement_id;
        [FieldAttribute]
        public int? EMPLACEMENT_ID { get { return emplacement_id; } set { emplacement_id = value; OnPropertyChanged(); } }
        private int? materiel_id;
        [FieldAttribute]
        public int? MATERIEL_ID { get { return materiel_id; } set { materiel_id = value; OnPropertyChanged(); } }
    }
}