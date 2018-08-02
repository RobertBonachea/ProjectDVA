using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// Person entity
    /// Fields used to identity and describe a Person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Person Identifier
        /// </summary>
        [Key]
        public int PersonId { get; set; }

        /// <summary>
        /// Person First Name
        /// </summary>
        [Required]
        [MaxLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Person Last Name
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Person Home Phone
        /// </summary>
        [Required]
        [MaxLength(15)]
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        /// <summary>
        /// Person Mobile Phone
        /// </summary>
        [Required]
        [MaxLength(15)]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// Person Email
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// Person Date of Birth
        /// </summary>
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public virtual Address Address { get; set; }




    }
}
