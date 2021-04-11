using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library.Api.Data.Models
{
    [Keyless]
    public partial class VRandomNumber
    {
        public double? RandomNumber { get; set; }
    }
}
