using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.MVCWeb.Models
{
    [MetadataType(typeof(IndustryMetaData))]
    public partial class Industry
    {
    }

    internal class IndustryMetaData
    {
        [Required]
        [DisplayName("Industry")]
        public string IndustryName { get; set; }

       
    }
}