using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
  public class RegisterDto
  {
    [Required]
    public string DisplayName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [RegularExpression(
      "(?=^.{6,15}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
      ErrorMessage = "Password must be 6-15 characters long, contain at least 1 lowercase letter, 1 uppercase letter, 1 digit and 1 of the following: @$!%*?&"
    )]
    public string Password { get; set; }   
  }
}