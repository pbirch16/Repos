using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbTestManyToMany3_CF
{
    public class Project
    {
    public Project()
    {            
            this.Keywords = new ObservableListSource<Keyword>();
            this.XRefs = new ObservableListSource<XRef>();
        }
        public int Id{ get; set; }
        public string ProjectName{ get; set; }
        public string Location{ get; set; }
        

        public virtual ObservableListSource<Keyword> Keywords { get; set; }
        public virtual ObservableListSource<XRef> XRefs { get; set; }
    }
}
