namespace aura_web_blazor.Data
{
    public class Categories
    {
        public static Dictionary<string, string> Category = new Dictionary<string, string>();
        static Categories(){
            Category.Add("Banaku", "B");
            Category.Add("Kuzhina","K");
            //Category.Add("Pizza", "P");
            //Category.Add("Embelsira", "E");
            //Category.Add("Sallata", "S");
        }
    }
    
}
