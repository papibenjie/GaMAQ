using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    public abstract class Node : ICloneable
    {
        public string Name { get; set; } = "NONAME";

        public List<Node> Children { get; set; } = new List<Node>();

        public Node Parent { get; set; } = null;

        protected Node(string name)
        {
            Name = name;
        }

        protected abstract double run(List<double> vars);


        public List<Node> getSiblings()
        {
            if(Parent != null)
            {
                return Parent.Children;
            }
            return new List<Node>();
        }

        public double compute()
        {
            List<double> values = new List<double>();
            foreach (Node child in Children)
            {
                values.Add(child.compute());
            }
            return run(values);
        }

        private List<Node> _getNodesList(List<Node> actualList)
        {
            actualList.Add(this);
            foreach (Node child in Children)
            {
                actualList = child._getNodesList(actualList);
            }
            return actualList;
        }

        public Node replaceNode(Node newNode, Node oldNode)
        {
            Node node = null;
            if (this.Equals(oldNode))
            {
                Console.WriteLine("ALLO");
                if (this.Parent != null)
                {
                    newNode.Children = this.Children;
                    newNode.Parent = this.Parent;
                    int childIdx = newNode.Parent.Children.IndexOf(oldNode);
                    Console.WriteLine(childIdx);
                    if (childIdx >= 0)
                    {
                        newNode.Parent.Children[childIdx] = newNode;
                    }
                }
                
                newNode.Children = this.Children;

                Node root1 = newNode;
                do
                {
                    root1 = root1.Parent;
                } while (root1.Parent != null);
               
                return root1;
            }
            else
            {
              
                foreach (Node child in Children)
                {
                   node = child.replaceNode(newNode, oldNode);
                }
            }

            Node root2 = node;
            do
            {
                root2 = root2.Parent;
            } while (root2.Parent != null);

            return root2;
        }

        // override object.Equals
        public bool Equals(Node obj)
        {

            if(obj.Children.Count != this.Children.Count)
            {
     
                return false;
            }

            for (int i = 0; i < obj.Children.Count; i++)
            {
                if(!this.Children[i].Equals(obj.Children[i]))
                {
            
                    return false;
                }
            }

            if(this.Parent != obj.Parent)
            {
        
                return false;
            }

            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }

        public List<Node> getNodesList()
        {
            List<Node> nodes = new List<Node>();
            nodes = _getNodesList(nodes);
            return nodes;
        }

        public void printTree(int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.Write(i == depth - 1 ?  "|---" : "|   ");
            }
            Console.WriteLine(Name);
            foreach (Node child in Children)
            { 
                child.printTree(depth + 1);
            }
            
        }

        public object Clone()
        {
            Node node = (Node)this.MemberwiseClone();
            node.Children = new List<Node>();
            if (this.Parent != null)
            {
                node.Parent = this.Parent;
            }

            foreach (Node child in Children)
            {
                node.Children.Add((Node)child.Clone());
            }
            
         
            return node;
        }
    }
}
