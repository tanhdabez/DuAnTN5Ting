
using System.ComponentModel.DataAnnotations.Schema;
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBanQuanAo.Models
{
    public class Role
    {
        public string Id { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public string Ten { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string TrangThai { get; set; }

        public User? User { get; set; }

        public ICollection<User> Users { get; set; }

    }

}
