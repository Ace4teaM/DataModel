namespace DataModel.Model.BDD.Tables
{
    public class DOCUMENT : Table
    {
        private int dOCUMENT_ID;
        [IdentityKeyAttribute]
        [PrimaryKeyAttribute]
        public int DOCUMENT_ID { get { return dOCUMENT_ID; } set { dOCUMENT_ID = value; OnPropertyChanged(); } }

        public byte[] dOCUMENT_DATA;
        [FieldAttribute]
        public byte[] DOCUMENT_DATA { get { return dOCUMENT_DATA; } set { dOCUMENT_DATA = value; OnPropertyChanged(); } }

        public string dOCUMENT_TAG;
        [FieldAttribute]
        public string DOCUMENT_TAG { get { return dOCUMENT_TAG; } set { dOCUMENT_TAG = value; OnPropertyChanged(); } }

        public string dOCUMENT_FILENAME;
        [FieldAttribute]
        public string DOCUMENT_FILENAME { get { return dOCUMENT_FILENAME; } set { dOCUMENT_FILENAME = value; OnPropertyChanged(); } }

    }
}
