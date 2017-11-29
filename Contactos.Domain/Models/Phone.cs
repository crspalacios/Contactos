using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Domain.Models
{
    public class Phone
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
        
        public virtual PerfilGeneral PerfilGeneral
        {
            get;
            set;

        }


    }
}
