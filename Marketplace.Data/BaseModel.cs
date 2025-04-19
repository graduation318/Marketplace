namespace Marketplace.Data
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        protected BaseModel()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            DateUpdated = DateTime.UtcNow;
        }
    }
}