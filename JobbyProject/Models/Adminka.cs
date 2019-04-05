using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class Adminka
    {

    public int ID { get; set; }

    [StringLength(200), Required]
    public string Fullname { get; set; }

    [StringLength(200), Required]
    public string NickName { get; set; }

    [StringLength(250), Required]
    public string Password { get; set; }

    [StringLength(200), Required]
    public string Email { get; set; }
}
}