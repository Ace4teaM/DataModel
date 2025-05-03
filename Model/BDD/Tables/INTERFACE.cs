namespace DataModel.Model.BDD.Tables
{
    public class INTERFACE : Table
    {

        private int iNTERFACE_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int INTERFACE_ID { get { return iNTERFACE_ID; } set { iNTERFACE_ID = value; OnPropertyChanged(); } }

        public string? iNTERFACE_AdresseMac;
        [FieldAttribute]
        public string? INTERFACE_AdresseMac { get { return iNTERFACE_AdresseMac; } set { iNTERFACE_AdresseMac = value; OnPropertyChanged(); } }

        public string? iNTERFACE_AdresseIp;
        [FieldAttribute]
        public string? INTERFACE_AdresseIp { get { return iNTERFACE_AdresseIp; } set { iNTERFACE_AdresseIp = value; OnPropertyChanged(); } }

        public string? iNTERFACE_TcpServices;
        [FieldAttribute]
        public string? INTERFACE_TcpServices { get { return iNTERFACE_TcpServices; } set { iNTERFACE_TcpServices = value; OnPropertyChanged(); OnPropertyChanged(nameof(TcpServicesList)); } }

        public string TcpServicesList
        {
            get
            {
                return iNTERFACE_TcpServices != null ? String.Join(Environment.NewLine, iNTERFACE_TcpServices.Split(',')) : String.Empty;
            }
        }

        public int? iNTERFACE_MaterielId;
        [FieldAttribute]
        public int? INTERFACE_MaterielId { get { return iNTERFACE_MaterielId; } set { iNTERFACE_MaterielId = value; OnPropertyChanged(); } }

        public string? iNTERFACE_CodeSuffixe;
        [FieldAttribute]
        public string? INTERFACE_CodeSuffixe { get { return iNTERFACE_CodeSuffixe; } set { iNTERFACE_CodeSuffixe = value; OnPropertyChanged(); } }

    }
}
