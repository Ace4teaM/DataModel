namespace DataModel.Model.BDD.Tables
{
    public class JOURNAL : Table
    {
        private int jOURNAL_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int JOURNAL_ID { get { return jOURNAL_ID; } set { jOURNAL_ID = value; OnPropertyChanged(); } }

        public string jOURNAL_Action;
        [FieldAttribute]
        public string JOURNAL_Action { get { return jOURNAL_Action; } set { jOURNAL_Action = value; OnPropertyChanged(); } }

        public DateTime jOURNAL_Date;
        [FieldAttribute]
        public DateTime JOURNAL_Date { get { return jOURNAL_Date; } set { jOURNAL_Date = value; OnPropertyChanged(); } }
    }

}