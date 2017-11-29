namespace Contactos.Domain.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    public class Url
    {
        [Key]
        public int UrlId
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        public string DescriptionUrl
        {
            get;
            set;
        }
        public string NameUrl
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

