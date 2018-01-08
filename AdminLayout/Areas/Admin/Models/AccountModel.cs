
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace AdminLayout.Areas.Admin.Models
{
    
    public class LoginModel
    {
        [Required(ErrorMessage = "E-Posta Boş geçilemez.")]
        [EmailAddress(ErrorMessage = "E-posta formatında giriş yapınız.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Parola Boş geçilemez.")]
        [StringLength(8, ErrorMessage = "En az 8 karakter olmalıdır.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "İsim Boş geçilemez.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim Boş geçilemez.")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "UserName Boş geçilemez.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Boş geçilemez.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "En az 1 harf, 1 numara girilmelidir. Minimum 8 Maksimum 12 karakteri geçemezsiniz.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Parola Boş geçilemez.")]
        public string PasswordConfirm { get; set; }

        [EmailAddress(ErrorMessage = "E-posta formatında giriş yapınız.")]
        [Required(ErrorMessage = "E-posta Boş geçilemez.")]
        public string EmailAddress { get; set; }
    }
}