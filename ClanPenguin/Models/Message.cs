using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClanPenguin.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
    }
}
