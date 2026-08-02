namespace Odev33_Constructor_Athlete.Models
{
    public class Athlete
    {
        // Auto-property'ler
        public string FullName { get; set; }
        public string SportBranch { get; set; }
        public string TeamName { get; set; }
        public int JerseyNumber { get; set; }

        // 1. Constructor: Ad ve Branş zorunlu, Takım varsayılan "Free Agent"
        public Athlete(string fullName, string sportBranch)
        {
            FullName = fullName;
            SportBranch = sportBranch;
            TeamName = "Free Agent"; // Varsayılan takım
        }

        // 2. Constructor Overloading: Ad, Branş, Takım ve Forma No birlikte alınır 
        public Athlete(string fullName, string sportBranch, string teamName, int jerseyNumber)
        {
            FullName = fullName;
            SportBranch = sportBranch;
            TeamName = teamName;
            JerseyNumber = jerseyNumber;
        }
    }
}