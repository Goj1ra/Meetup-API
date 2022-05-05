using System.ComponentModel.DataAnnotations;

namespace Meetup.API.Models
{
    public class EventModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Speaker is required")]
        public string Speaker { get; set; }

        [Required(ErrorMessage = "Time of the event is required")]
        public DateTime TimeOfTheEvent { get; set; }

        [Required(ErrorMessage = "Venue is required")]
        public string Venue { get; set; }
    }
}
