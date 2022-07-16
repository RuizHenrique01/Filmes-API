using System;
using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Models{
    public class Usuario{
        [Key]
        [Required]
        public int Id { get; set; }  
        [Required]
        public string Username { get; set; }  
        [Required]
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}