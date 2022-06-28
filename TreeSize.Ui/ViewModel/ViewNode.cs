using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeSize.Service.Model;

namespace TreeSize.Ui.ViewModel
{
    public class ViewNode
    {
        public List<ViewNode>? Childs { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public long Size { get; set; }
        public int CountSubFolders { get; set; }
        public int CountSubFiles { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsFile { get; set; }
        public byte SizeFromParent {get; set; }
        public bool IsOpen { get; set; }
        public string Picture { get; set; }
        
        public string Level { get; set; }
        public ViewNode()
        {

        }
        private void Convert()
        { 
        
        }
    }
}
