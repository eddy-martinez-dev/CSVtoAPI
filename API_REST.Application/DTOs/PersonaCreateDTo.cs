using System;
using System.Collections.Generic;
using System.Text;

namespace API_REST.Application.DTOs
{
    public class PersonaCreateDTo
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime Birthate { get; set; }
    }
}
