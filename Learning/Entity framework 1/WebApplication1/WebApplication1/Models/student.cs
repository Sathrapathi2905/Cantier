using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.Models
{
    public class student
    {
        [Key]     
        public int id { get; set; }        
        public string studept { get; set; }
        public string stuname { get; set; }
    }
}
