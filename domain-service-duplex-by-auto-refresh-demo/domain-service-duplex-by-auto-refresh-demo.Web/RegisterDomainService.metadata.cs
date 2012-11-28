
namespace domain_service_duplex_by_auto_refresh_demo.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies RegisterMetadata as the class
    // that carries additional metadata for the Register class.
    [MetadataTypeAttribute(typeof(Register.RegisterMetadata))]
    public partial class Register
    {

        // This class allows you to attach custom attributes to properties
        // of the Register class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class RegisterMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private RegisterMetadata()
            {
            }

            public int id { get; set; }

            public string name { get; set; }

            public string status { get; set; }
        }
    }
}
