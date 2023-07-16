using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Game.Enums;

namespace Game.Models
{
    [DataContract]
    public class PlayRequest
    {
        [DataMember]
        [Required]
        [EnumDataType(typeof(Symbol))]
        public Symbol Player { get; set; }
    }
}
