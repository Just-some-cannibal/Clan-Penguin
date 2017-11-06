using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClanPenguin.Models
{
    public class Chatroom
    {
        public string Name { get; set; }
        public int ChatroomId { get; set; }
        public virtual List<Message> Messages { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
