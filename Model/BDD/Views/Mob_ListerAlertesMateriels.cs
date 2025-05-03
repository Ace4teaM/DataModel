
namespace DataModel.Model.BDD.Views
{
    public class Mob_ListerAlertesMateriels : View
    {
        [FieldAttribute]
        public string? Libelle { get; set; }
        [FieldAttribute]
        public string? DateAlerte { get; set; }
        [FieldAttribute]
        public int? Etat { get; set; }
        [FieldAttribute]
        public string? MaterielId { get; set; }
        [FieldAttribute]
        public string? NumSerie { get; set; }
        [FieldAttribute]
        public string? Modele { get; set; }
        [FieldAttribute]
        public string? Marque { get; set; }
        [FieldAttribute]
        public string? Materiel { get; set; }
    }
}