namespace AdFeed.DAL.Entities
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }
        public bool Main { get; set; }
        public int AdId { get; set; }

        public Ad Ad { get; set; }
    }
}
