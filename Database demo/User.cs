using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_demo
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Challenge> Challenges { get; set; } = new();
        public List<Enrollment> Enrollments { get; set; } = new();
    }
}
