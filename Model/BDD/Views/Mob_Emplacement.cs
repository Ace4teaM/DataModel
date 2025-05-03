
namespace DataModel.Model.BDD.Views
{
    public class Mob_Emplacement : View
    {
        [FieldAttribute]
        public string? Libelle { get; set; }
        [FieldAttribute]

        public string? Code { get; set; }
        [FieldAttribute]

        public string? Zone { get; set; }
        [FieldAttribute]

        public string? Secteur { get; set; }
        [FieldAttribute]

        public string? Site { get; set; }
        [FieldAttribute]
        public string? Tag { get; set; }
        [FieldAttribute]
        public string? Local { get; set; }
        [FieldAttribute]
        public string? Localisation { get; set; }
    }
}