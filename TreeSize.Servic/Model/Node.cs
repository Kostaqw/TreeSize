using System;
using System.Collections.Generic;


namespace TreeSize.Service.Model
{
    public class Node
    {
        public List<Node>? Childs { get; set; }
        public string? Name { get; set; }
        public long Size { get; set; }
        public int CountSubFolders { get; set; }
        public int CountSubFiles { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsFile { get; set; }
        public byte Level { get; set; }

        public Node(string name, long size, int countSubFoleders, int countSubFiles, DateTime dateCreate, bool isFile, byte level)
        {
            Childs = new List<Node>();
            Name = name;
            Size = size;
            CountSubFolders = countSubFoleders;
            CountSubFiles = countSubFiles;
            DateCreate = dateCreate;
            IsFile = isFile;
            Level = level;
        }
        public Node()
        {

        }
    }
}
