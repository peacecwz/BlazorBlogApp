namespace BlogApp.API.Data.Entities
{
    public class CategoryEntity : EntityBase<int>
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool IsSpotlight { get; set; }
    }
}