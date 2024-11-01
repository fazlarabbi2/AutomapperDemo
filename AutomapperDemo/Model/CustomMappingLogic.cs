namespace AutomapperDemo.Model
{
    public class CustomMappingLogic
    {
        //Passing the Source Object as a Parameter
        public static bool ShouldMapPrice(Product source)
        {
            //return true if the Product is in Stock and it belongs to Electronics Category
            return source.InStock && source.Category == "Electronics";
        }
        //Passing the InStock and Category Properties of the Source Object as Parameters
        public static bool ShouldMapPrice(bool InStock, string Category)
        {
            //return true if the Product is in Stock and it belongs to Electronics Category
            return InStock && Category == "Electornics";
        }

    }
}
