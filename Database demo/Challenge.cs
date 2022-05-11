using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_demo
{
    public class Challenge
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<User> Members { get; set; } = new();
        public List<Enrollment> Enrollments { get; set; } = new();
    }
}
