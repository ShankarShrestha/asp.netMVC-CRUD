//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCCRUD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class EmpDetail
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        public string Position { get; set; }
        

        public string Office { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }
    }
}
