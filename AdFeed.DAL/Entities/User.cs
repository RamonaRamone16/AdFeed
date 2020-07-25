using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdFeed.DAL.Entities
{
    public class User : IdentityUser<int>, IEntity
    {
    }
}
