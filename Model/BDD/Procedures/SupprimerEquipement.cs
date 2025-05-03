namespace DataModel.Model.BDD.Procedures
{
    public class SupprimerEquipement : Procedure
    {
        [InputParameterAttribute]
        public int? Equipement_Id { get; set; }
    }
}
