using System.ComponentModel.DataAnnotations;

namespace Final_youtube.Model
{
    public class Incident
    {
        [Key,Required]
        public int IncidentId { get; set; }
        public string IncidentTitle { get; set; } = string.Empty;
        public string Reportedby {  get; set; }=string.Empty;
        public string IncidentType {  get; set; }=string.Empty;
        public string IncidentDetails { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Severity {  get; set; } = string.Empty;   
        public DateTime TimeStamp { get; set; } 

    }
}
