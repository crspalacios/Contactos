namespace Contactos.Domain.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    public class SocialPerfils
    {
        [Key]
        public int SocialPerfilId
        {
            get;
            set;
        }
        public string DescriptionSocialPerfil
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        public string SocialPerfil
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
