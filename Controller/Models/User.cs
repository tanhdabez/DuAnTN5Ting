using DemoBanQuanAo.Models;
﻿using DemoBanQuanAo.Models;
using System.ComponentModel.DataAnnotations;
namespace DemoBanQuanAo.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Ma { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(255, ErrorMessage = "Password cannot be longer than 255 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [StringLength(120, ErrorMessage = "Email cannot be longer than 120 characters.")]
        public string Email { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;
        public DateTime NgayCapNhat { get; set; }
        public string TrangThai { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Role> Roles { get; set; }
        public string RoleId { get; set; }

        public Role Role { get; set; }
    }
}