﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DataProtection.Web.Models
{
    public partial class Product
    {
        [NotMapped]
        public string EncryptedId { get; set; }
    }
}
