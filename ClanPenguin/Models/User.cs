using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClanPenguin.Models
{
    public class User : IdentityUser
    {
        public string Bio { get; set; }
        public virtual List<Chatroom> Chatrooms { get; set; }
        public virtual List<User> Friends { get; set; }
        public virtual List<Message> Messages { get; set; }
    }
}
