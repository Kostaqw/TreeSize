using System;
using TreeSize.Service.Model;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
namespace TreeSize.Service.Service
{
    public class NodeService
    {
        public Node GetNode(string path)
        {
            var nodes = new List<Node>();
            var dirInfo = new DirectoryInfo(path);

            var files = dirInfo.GetFiles();
            foreach (var item in files)
            {
                nodes.Add(CreateFileNode(item));
            }

            var directory = dirInfo.GetDirectories();
            foreach (var item in directory)
            {
                nodes.Add(CreateFolderNode(item));
            }

            byte level = (byte)dirInfo.FullName.Count(s=>s=='\\');
            var node = new Node(dirInfo.FullName, 0, 0, 0, dirInfo.CreationTime, false,level);
            node.Childs = nodes;
            return node;
        }

        private Node CreateFileNode(FileInfo file)
        {
            byte level = (byte)file.FullName.Count(s => s == '\\');
            return new Node(file.FullName, file.Length, 0, 0, file.CreationTime, true, level);
        }
        private Node CreateFolderNode(DirectoryInfo directory)
        {
            
            var nodes = new List<Node>();
            var dirInfo = new DirectoryInfo(directory.FullName);

            var files = dirInfo.GetFiles();
            var directories = dirInfo.GetDirectories();
            foreach (var item in files)
            {
                nodes.Add(CreateFileNode(item));
            }

            if (directories.Length != 0)
            {
                foreach (var d in directories)
                {
                   nodes.Add(CreateFolderNode(d));
                }
            }

            long size = 0;

            foreach (var item in files)
            {
                size += item.Length;
            }
            byte level = (byte)directory.FullName.Count(s => s == '\\');
            var node = new Node(directory.FullName, size, directories.Length, files.Length, directory.CreationTime, false, level);
            node.Childs = nodes;
            return node;
        }

    }
}
