using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbTestManyToMany3_CF
{
    public class Keyword
    {
        public Keyword()
        {
            this.Projects = new ObservableListSource<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<Project> Projects { get; set; }
    }
}
