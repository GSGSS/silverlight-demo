
namespace domain_data_source_filter_descriptor_demo.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies SMMetadata as the class
    // that carries additional metadata for the SM class.
    [MetadataTypeAttribute(typeof(SM.SMMetadata))]
    public partial class SM
    {

        // This class allows you to attach custom attributes to properties
        // of the SM class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SMMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SMMetadata()
            {
            }

            public int id { get; set; }

            public string message { get; set; }

            public Nullable<DateTime> time { get; set; }
        }
    }
}
