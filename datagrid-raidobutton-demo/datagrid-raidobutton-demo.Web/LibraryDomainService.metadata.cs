﻿
namespace datagrid_raidobutton_demo.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies BookMetadata as the class
    // that carries additional metadata for the Book class.
    [MetadataTypeAttribute(typeof(Book.BookMetadata))]
    public partial class Book
    {

        // This class allows you to attach custom attributes to properties
        // of the Book class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class BookMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private BookMetadata()
            {
            }

            public int Id { get; set; }

            public string Isbn { get; set; }

            public string Name { get; set; }
        }
    }
}
