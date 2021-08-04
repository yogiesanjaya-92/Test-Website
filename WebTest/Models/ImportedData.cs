namespace WebTest.Models
{
    public class ImportedData
    {
        public string StringID { get; set; }
        public string StringContent { get; set; }
        public int MatchTimes { get; set; }

        public ImportedData(string[] split)
        {
            StringID = Helper.substring(split[0], 1, 37);
            StringContent = split[1];
            MatchTimes = 0;
        }
    }
}