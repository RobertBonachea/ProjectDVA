using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Address
    {
        /// <summary>
        /// Address Identifier
        /// </summary>
        [ForeignKey("Person")]
        [Key]
        public int AddressId { get; set; }


        /// <summary>
        /// Person Address Line 1
        /// </summary>
        [Required]
        [MaxLength(120)]
        [Display(Name = "Address")]
        public string Address1 { get; set; }

        /// <summary>
        /// Person Address Line 2
        /// </summary>
        [MaxLength(120)]
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        /// <summary>
        /// Person City
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        /// <summary>
        /// Person Zip Code
        /// </summary>
        [Required]
        [MaxLength(10)]
        [Display(Name = "Zip/Postal Code")]
        public string Zipcode { get; set; }

        /// <summary>
        /// Person State
        /// </summary>
        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        public virtual Person Person { get; set; }

    }
}
