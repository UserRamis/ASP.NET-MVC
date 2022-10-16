using System.ComponentModel.DataAnnotations;

namespace building_materials_store.Models
{
    public class Category
    {
        [Key]
        
        public int Id { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }


    }
}
