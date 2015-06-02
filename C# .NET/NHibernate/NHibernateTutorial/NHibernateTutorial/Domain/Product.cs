using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTutorial.Domain
{
    /// <summary>
    /// An example domain object with basic properties
    /// </summary>
    public class Product
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual bool Discontinued { get; set; }

        public virtual Employee Author { get; set; }
    }
}
