using Sieve.Attributes;
using System;
using System.Collections.Generic;

namespace CRUDAPI.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string StudentName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Standard { get; set; } = null!;
    }
}
