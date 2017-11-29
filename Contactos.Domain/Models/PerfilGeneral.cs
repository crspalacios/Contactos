namespace Contactos.Domain
{
    using Contactos.Domain.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PerfilGeneral
    {
        [Key]
        public int PerfilId
        {

            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string PerfilImage
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<Addresses> Addressess
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<BussinessPerfils> BussinessPerfilss
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<Phone> Phones
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<Phone> SocialPerfilss
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<Url> Urls
        {
            get;
            set;
        }
        [JsonIgnore]
        public virtual ICollection<Emails> Emails
        {
            get;
            set;
        }

    }
}
