using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TreeSize.Service.Model;
using TreeSize.Service.Service;
using TreeSize.Ui.ViewModel;

namespace TreeSize.Ui.Context
{
    public class ViewModelContext
    {
        private NodeService nodeService = new NodeService();
        public ObservableCollection<ViewNode> viewNodes { get; set; }

        private Node Node;
        private Node TempNode;
        public ViewModelContext(string path)
        {
            Node = nodeService.GetNode(@"D:\Dead Cells v23.9");
            CreateViewNode();
            viewNodes = new ObservableCollection<ViewNode>(viewNodes.OrderByDescending(x => x.Name));
           // AddInNode(@"D:\Dead Cells v23.9\_Redist", viewNodes[1]);
        }

        public void CreateViewNode()
        {
            viewNodes = new ObservableCollection<ViewNode>(ConvertToViewNode(Node));
        }

        public void AddInNode(string path, ViewNode viewNode)
        { 
            TempNode = nodeService.GetNode(path);
            var viewNodeList = ConvertToViewNode(TempNode);
            var index = viewNodes.IndexOf(viewNode);
            var j = 0;

            for (int i = index; i < index + viewNodeList.Count; i++)
            {
                viewNodes.Insert(i, viewNodeList[j]);
                j++;
            }
        }

        public List<ViewNode> ConvertToViewNode(Node node)
        {
            var viewNodeList = new List<ViewNode>();
            long size = 0;
            foreach (var item in node.Childs)
            {
                var vn = new ViewNode()
                {
                    Name = Path.GetFileName(item.Name),
                    FullName = item.Name,
                    CountSubFiles = item.CountSubFiles,
                    CountSubFolders = item.CountSubFolders,
                    DateCreate = item.DateCreate,
                    IsFile = item.IsFile,
                    Size = item.Size,
                    IsOpen = false,
                    Level = $"{item.Level*5} 0 0 0"
                };
                size += item.Size;
                viewNodeList.Add(vn);
            }

            foreach (var item in viewNodeList)
            {
                if (size != 0)
                {
                    item.SizeFromParent = (byte)(item.Size * 100 / size);
                }
                else
                {
                    item.SizeFromParent = (byte)(item.Size * 100 / 1);
                }
               

                if (item.SizeFromParent == 0)
                {
                    item.SizeFromParent = 1;
                }

                if (item.IsFile)
                {
                    item.Picture = "./ViewModel/img/file.png";
                }
                else
                {
                    item.Picture = "./ViewModel/img/folder.png";
                }
            }
            return viewNodeList;
        }


    }
}
