using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIPlanningActivities.Models
{
    //esta clase lo que hace es poder hacer el registro de actividades en la tabla actividades 
    // aqui ademas haremos la comprobacion del maxlengh de la base de datos en los datos que lo necesitemos 
    public class RegisterActivity
    {
        public string Nombre { get; set; }
        public string Cuando { get; set; }
        public string Donde { get; set; }
        public string Informacion { get; set; }
        public string horarioInicial { get; set; }
        public string horarioFinal { get; set; }

    }
}
