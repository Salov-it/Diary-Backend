

namespace NotesServices.Domain
{
    public class Note
    {
        public int id { get; set; }
        public string NickId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
