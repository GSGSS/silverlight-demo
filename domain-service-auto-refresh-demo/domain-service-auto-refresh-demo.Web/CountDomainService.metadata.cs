
namespace domain_service_auto_refresh_demo.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies CountMetadata as the class
    // that carries additional metadata for the Count class.
    [MetadataTypeAttribute(typeof(Count.CountMetadata))]
    public partial class Count
    {

        // This class allows you to attach custom attributes to properties
        // of the Count class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CountMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CountMetadata()
            {
            }

            public string message { get; set; }

            public int value { get; set; }
        }
    }
}
