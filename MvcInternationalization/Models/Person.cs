using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcInternationalization.Models
{
    public class Person
    {
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]    
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "FirstNameRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "FirstNameLong")]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resources.Resources))]    
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "LastNameRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "LastNameLong")]
        public string LastName { get; set; }


        [Display(Name = "Age", ResourceType = typeof(Resources.Resources))]    
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "AgeRequired")]
        [Range(0, 130, ErrorMessageResourceType = typeof(Resources.Resources),
                       ErrorMessageResourceName = "AgeRange")]
        public int Age { get; set; }


        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]    
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "EmailRequired")]
        [RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(Resources.Resources),
                                         ErrorMessageResourceName = "EmailInvalid")]
        public string Email { get; set; }


        [Display(Name = "Biography", ResourceType = typeof(Resources.Resources))]    
        public string Biography { get; set; }
    }
}