
namespace DataModel.Model.BDD.Views
{
    public class Mob_InventaireConsulter : View
    {
        [FieldAttribute]
        public string? TAG {  get; set; }
        [FieldAttribute]
        public string? Code { get; set; }
        [FieldAttribute]
        public int? EtatRepere { get; set; }
        [FieldAttribute]
        public string? Description { get; set; }
        [FieldAttribute]
        public string? Commentaire { get; set; }
        [FieldAttribute]
        public string? Emplacement { get; set; }
        [FieldAttribute]
        public string? EmplacementCode { get; set; }
        [FieldAttribute]
        public string? Zone { get; set; }
        [FieldAttribute]
        public string? Secteur { get; set; }
        [FieldAttribute]
        public string? Site { get; set; }
        [FieldAttribute]
        public string? EmplacementTag { get; set; }
        [FieldAttribute]
        public string? Local { get; set; }
        [FieldAttribute]
        public string? Localisation { get; set; }
        [FieldAttribute]
        public string? NumSerie { get; set; }
        [FieldAttribute]
        public string? DateAchat { get; set; }
        [FieldAttribute]
        public string? GarantieDateDebut { get; set; }
        [FieldAttribute]
        public string? GarantieDateFin { get; set; }
        [FieldAttribute]
        public string? GarantieLibelle { get; set; }
        [FieldAttribute]
        public string? GarantieCommentaire { get; set; }
        [FieldAttribute]
        public string? Date_Sortie { get; set; }
        [FieldAttribute]
        public string? RaisonSortie { get; set; }
        [FieldAttribute]
        public string? EquipementTAG { get; set; }
        [FieldAttribute]
        public string? Modele { get; set; }
        [FieldAttribute]
        public string? Marque { get; set; }
        [FieldAttribute]
        public string? Materiel { get; set; }
        [FieldAttribute]
        public string? AdressesMac { get; set; }

        [FieldAttribute]
        public string? AdressesIP { get; set; }
    }
}