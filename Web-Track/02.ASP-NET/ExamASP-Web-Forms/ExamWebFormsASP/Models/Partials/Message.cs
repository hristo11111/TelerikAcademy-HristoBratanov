using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamWebFormsASP.Models
{
    [MetadataType(typeof(EventMetadata))]
    public partial class Message
    {

    }

    public class EventMetadata
    {
        [ScaffoldColumn(false)]
        public int MessageId { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required, MaxLength(500)]
        public string Text { get; set; }
    }
}