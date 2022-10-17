using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace building_materials_store.Models
{
    public class ApplicationType
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
