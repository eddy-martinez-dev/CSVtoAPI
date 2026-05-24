using System;
using System.Collections.Generic;
using System.Text;

namespace API_REST.Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        required public string Name { get; set; }
        required public string LastName { get; set; }
        required public int Age { get; set; }
        public DateTime Birthate { get; set; }
    }
}
