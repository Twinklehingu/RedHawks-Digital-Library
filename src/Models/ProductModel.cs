using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Get and set methods that initializes properties for books 
    /// </summary>
    public class ProductModel
    {
        //get set method for product id
        public string Id { get; set; }

        // get set method for Maker 
        public string Maker { get; set; }

        // get set method for Book cover
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // get set method for Book URL (required field)
        [Required]
        public string Url { get; set; }

        // get set method for Book author
        public string Author { get; set; }

        //get set method for Author description (required field)
        [Required]
        public string Author_Description { get; set; }

        // get set method for Publisher
        public string Publisher { get; set; }

        // Publication
        public string Publication { get; set; }

        //ISBN
        public string ISBN { get; set; }

        // Book title (required field)
        [Required]
        public string Title { get; set; }

        //Book description (required field)
        [Required]
        public string Description { get; set; }

        // Book ratings
        public int[] Ratings { get; set; }

        // get set method for JSON attribute Comments
        public string[] Comments { get; set; }

        /// <summary>
        /// serilizing productModel.
        /// </summary>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}