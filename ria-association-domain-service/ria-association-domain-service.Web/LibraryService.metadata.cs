
namespace ria_association_domain_service.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
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

            public EntityCollection<Record> Records { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies RecordMetadata as the class
    // that carries additional metadata for the Record class.
    [MetadataTypeAttribute(typeof(Record.RecordMetadata))]
    public partial class Record
    {

        // This class allows you to attach custom attributes to properties
        // of the Record class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class RecordMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private RecordMetadata()
            {
            }

            [Include]
            public Book Book { get; set; }

            public int bookId { get; set; }

            public DateTime endTime { get; set; }

            public int id { get; set; }

            public DateTime startTime { get; set; }
        }
    }
}
