//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MV_P1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Pacientes
    {
        public tbl_Pacientes()
        {
            this.tbl_ImagenesPacientes = new HashSet<tbl_ImagenesPacientes>();
        }
    
        public int idPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Nullable<System.DateTime> Edad { get; set; }
        public int idTipoParkinson { get; set; }
        public Nullable<System.DateTime> UltimoAnalisis { get; set; }
        public string Genero { get; set; }
        public Nullable<int> Activo { get; set; }
    
        public virtual ICollection<tbl_ImagenesPacientes> tbl_ImagenesPacientes { get; set; }
        public virtual tbl_TipoParkinson tbl_TipoParkinson { get; set; }
    }
}
