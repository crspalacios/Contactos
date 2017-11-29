using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Domain.Models
{
    public class Emails
    {
        [Key]
        public int EmailId
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        //[Index("Emails_Email_Index", IsUnique = true)]
        public string Email
        {
            get;
            set;
        }
        public string DescriptionEmail
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
