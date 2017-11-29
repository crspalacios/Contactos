namespace Contactos.Domain.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    public class Addresses
    {
        [Key]
        public int AddressId
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        public string DescriptionAddress
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual PerfilGeneral PerfilGeneral
        {
            get;
            set;

        }
    }
}
