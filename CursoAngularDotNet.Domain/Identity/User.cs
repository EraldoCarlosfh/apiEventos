using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAngularDotNet.Domain.Identity
{
    public class User : IdentityUser<int>
    {   
        [Column(TypeName = "varchar(150)")]
        public string Fullname { get; set; }      
        public List<UserRole> UserRoles { get; set; }
    }
}
