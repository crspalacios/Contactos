namespace Contactos.Domain
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    public class BussinessPerfils
    {

        [Key]
        public int BussinessPerfilId
        {
            get;
            set;
        }
        public int PerfilId
        {

            get;
            set;
        }
        public string BussinessPerfilStudyDescription
        {
            get;
            set;
        }
        public string BussinessPerfilWorkDescription
        {
            get;
            set;
        }
        public string BussinessPerfilPositionDescription
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
