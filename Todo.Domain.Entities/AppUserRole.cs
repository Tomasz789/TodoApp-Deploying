using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Entities
{
    public class AppUserRole : IdentityRole<Guid>
    {
    }
}
