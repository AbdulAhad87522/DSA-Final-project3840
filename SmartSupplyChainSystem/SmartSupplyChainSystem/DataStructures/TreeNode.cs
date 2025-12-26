// DataStructures/TreeNode.cs
using System.Collections.Generic;

namespace SmartSupplyChainSystem.DataStructures
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; }
        public TreeNode<T> Parent { get; set; }

        public TreeNode(T data)
        {
            Data = data;
            Children = new List<TreeNode<T>>();
        }

        public void AddChild(TreeNode<T> child)
        {
            child.Parent = this;
            Children.Add(child);
        }

        public void RemoveChild(TreeNode<T> child)
        {
            Children.Remove(child);
        }
    }

    public class InventoryTree
    {
        public TreeNode<string> Root { get; private set; }

        public InventoryTree()
        {
            Root = new TreeNode<string>("Warehouse");
        }

        // Add category
        public TreeNode<string> AddCategory(string categoryName, TreeNode<string> parent = null)
        {
            var node = new TreeNode<string>(categoryName);
            if (parent == null)
                Root.AddChild(node);
            else
                parent.AddChild(node);
            return node;
        }

        // Find node by name
        public TreeNode<string> FindNode(TreeNode<string> current, string name)
        {
            if (current.Data == name)
                return current;

            foreach (var child in current.Children)
            {
                var found = FindNode(child, name);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
}