using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_youtube.Model
{
    public class MediaAttachment
    {
        [Key,Required]
        public int AttachmentId { get; set; }
        [ForeignKey("Incident")]
        public int IncidentId { get; set; }
        
        public string ImageUrl { get; set; } = string.Empty; 
        

        // Navigation property for the related Incident
        public Incident Incident { get; set; }=new Incident();
    }
}
