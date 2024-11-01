namespace AutomapperDemo.Model
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> ProductsDTO { get; set; }
    }
}
