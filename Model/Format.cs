using System.Text.RegularExpressions;

namespace DataModel.Model
{
    public static class Format
    {
        private static readonly Regex RegExCodeEmplacement = new Regex("(E[0-9]{3})");
        private static readonly Regex RegExCodeEquipement = new Regex("([A-Z]|[/-/_])+");

        public static bool IsCodeEmplacement(string code)
        {
            return RegExCodeEmplacement.IsMatch(code);
        }

        public static bool IsCodeEquipement(string code)
        {
            return RegExCodeEquipement.IsMatch(code);
        }
    }
}

