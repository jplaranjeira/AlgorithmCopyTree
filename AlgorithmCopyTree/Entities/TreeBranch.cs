using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCopyTree.Entities
{
    public class TreeBranch
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<TreeBranch>? Childs { get; set; } = new List<TreeBranch>();

        public TreeBranch(int id, string? name) 
        {
            this.Id = id;
            this.Name = name;
        }

        public TreeBranch() { }
    }
}
