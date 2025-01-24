using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalBrouwerService.Models;

public class Brouwer
{
    public int Id { get; set; }
    public required string Naam { get; set; }
    public int Postcode { get; set; }
    public required string Gemeente { get; set; }
}
