﻿using System.ComponentModel.DataAnnotations;

namespace WithoutBordersASP.Models
{
    public class LoginModel
    {
        [Required] [Display(Name = "Логін")] public string UserName { get; set; }

        [Required] [Display(Name = "Пароль")] public string Password { get; set; }

        [Display(Name = "Запам'ятати мене?")] public bool Remember { get; set; }
    }
}