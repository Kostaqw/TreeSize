using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSize.Service.Model
{
    public class Node
    {
        public List<Node> Childs { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int CountSubFolders { get; set; }
        public int CountSubFiles { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsFile { get; set; }
    }
}
