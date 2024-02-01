using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace APIEntryDtls
{
    public class EntryDetailsClass
    {
        [Key][Required][DisplayName("ID")]
        public int PId { get; set; }
        [Required][DisplayName("First Name")]
        public string FName { get; set; }
        [DisplayName("Last Name")]
        public string? LName { get; set; }
        public string?Address { get; set; }
        public string? City { get; set; }
        [Required][StringLength(10)][DisplayName("PinCode")]
        public string Pin { get; set; }
    }
}
