//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaMVC2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subject_Profesor
    {
        public int Id_SubjProf { get; set; }
        public int Id_Profesor { get; set; }
        public int Id_Subject { get; set; }
    
        public virtual Subject Subject { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
