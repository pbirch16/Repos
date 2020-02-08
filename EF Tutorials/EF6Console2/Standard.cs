using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Console2
{
    public class Standard
    {
    public int StandardKey{ get; set; }
    public string StandardName{ get; set; }

    public ICollection<Student>Students{ get; set; }
    }
}
