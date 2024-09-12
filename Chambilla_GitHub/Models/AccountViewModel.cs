using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chambilla_GitHub.Models
{
    public class AccountViewModel
    {
        public Usuario Usuario { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public string RegistroError { get; set; }
    }
}