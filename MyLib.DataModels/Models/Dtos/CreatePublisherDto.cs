﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.DataModels.Models.Dtos
{
    public class CreatePublisherDto
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
