using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amor.Core.Entities
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}
