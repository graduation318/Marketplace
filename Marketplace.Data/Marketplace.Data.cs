namespace Shop.Data
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public BaseModel()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            DateUpdated = DateTime.UtcNow;
        }
    }
}