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
    public class Phone1
    {
        [Key]
        public int PhoneId
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        //[Index("Phone1_PhoneNumber_Index", IsUnique = true)]
        public string PhoneNumber
        {
            get;
            set;
        }
        public string DescriptionPhone
        {
            get;
            set;
        }
        [DataType(DataType.Date)]
        public DateTime LastUpdate
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
