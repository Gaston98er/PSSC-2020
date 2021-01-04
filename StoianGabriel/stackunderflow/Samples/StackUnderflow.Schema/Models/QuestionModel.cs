using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StackUnderflow.DatabaseModel.Models
{
    [Table("Question")]
    public class QuestionModel
    {
        [Key]
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public string Body { get; set; }
        public string Tags { get; set; }
    }
}
