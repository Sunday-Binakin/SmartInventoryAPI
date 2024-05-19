
//using Microsoft.AspNetCore.Identity;

// Microsoft.AspNet.Identity.EntityFramework;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



public class ApplicationUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Custom { get; set; }
}