using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
  public interface Dictionary<K, V> where K : IComparable
  {
    void Add(K key, V value);
    void Delete(K key);
    V Find(K key);
  }

  public class Node<K, V> where K : IComparable
  {

    public K Key { get; set; }
    public V Value { get; set; }
    public Node<K, V> Left { get; set; }
    public Node<K, V> Right { get; set; }
    public Node<K, V> Parent { get; set; }

    public Node(K key, V value)
    {
      Key = key;
      Value = value;
    }

    public bool IsLeaf
    {
      get { return Left == null && Right == null; }
    }
  }

  public class BinarySearchTree<K, V> where K : IComparable
  {
    public Node<K, V> Root { get; private set; }
    public int Count { get; private set; } = 0;

    public int TraversalCount
    {
      get
      {
        return InOrderFold((acc, _) => acc += 1, 0, Root);
      }
    }


    public override string ToString()
    {
      return InOrderFold((acc, n) => acc += "(" + n.Key.ToString() + "," + n.Value.ToString() + ")", "", Root);
    }

    private T InOrderFold<T>(Func<T, Node<K, V>, T> op, T accumulator, Node<K, V> node)
    {
      if (node.Left != null)
        accumulator = InOrderFold(op, accumulator, node.Left);
      accumulator = op(accumulator, node);
      if (node.Right != null)
        accumulator = InOrderFold(op, accumulator, node.Right);
      return accumulator;
    }

    public void Add(K key, V value)
    {
      Count++;

            if (Root == null)
            {
                //complete
                Root = new Node<K, V>(key, value);
            }
            else
            {
                //complete
                Node<K, V> focusNode = Root;
                Node<K, V> parent;


                while (true)
                {
                    parent = focusNode;
                    if (key.CompareTo(focusNode.Key) < 0)
                    {
                        focusNode = focusNode.Left;

                        if (focusNode == null)
                        {
                            parent.Left = new Node<K, V>(key, value);
                            parent.Left.Parent = parent;
                            return;
                        }
                    }
                    else
                    {
                        focusNode = focusNode.Right;

                        if (focusNode == null)
                        {
                            parent.Right = new Node<K, V>(key, value);
                            parent.Right.Parent = parent;
                            return;
                        }
                    }
                }
            }
        }

    private Node<K, V> Traversal(K key, Node<K,V> node)
    {
      if (node == null)
        return null;
      if (key.CompareTo(node.Key) == 0)
        return node;
      else if (key.CompareTo(node.Key) < 0)
        return Traversal(key, node.Left);
      else
        return Traversal(key, node.Right);
    }

    public V Find(K key)
    {
      Node<K,V> node = Traversal(key, Root);
      if (node == null)
        throw new System.ArgumentException("The key is not in the dictionary");
      else
        return node.Value;
    }

    public void Remove(K key)
    {
      Node<K, V> nodeToRemove = Traversal(key, Root);
            if (nodeToRemove == null)
            {
                return;
            }


      Delete(nodeToRemove);
      Count--;
    }

    private void Delete(Node<K, V> node)
    {
            if (node.IsLeaf)
            {
                //complete
                //node = null;
                if (node.Parent.Left == node)
                {
                    node.Parent.Left = null;
                }
                if (node.Parent.Right == node)
                {
                    node.Parent.Right = null;
                }
            }
            else if (node.Right == null)
            {
                //complete
                if (node.Parent == null)
                {
                    node = node.Left;
                }
                else if (node == node.Parent.Left)
                {
                    node.Parent.Left = node.Left;
                }
                else
                {
                    node.Parent.Right = node.Left;
                }
            }
            else if (node.Left == null)
            {
                //complete
                if (node.Parent == null)
                {
                    node = node.Right;
                }
                else if (node == node.Parent.Right)
                {
                    node.Parent.Right = node.Right;
                }
                else
                {
                    node.Parent.Left = node.Right;
                }
            }
            else
            {
                //complete
                var replacement = replacementNode(node);

                if (node.Parent == null)
                {
                    Console.WriteLine(replacement.Key);
                    Console.WriteLine(node.Left.Key);
                    node.Left.Parent = replacement;
                    Console.WriteLine(node.Left.Parent.Key);
                    return;
                }

                if (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                    {
                        node.Parent.Left = replacement;
                    }

                    if (node.Parent.Right == node)
                    {
                        node.Parent.Right = replacement;
                    }
                }
                replacement.Left = node.Left;
            }
        }

        public Node<K, V> replacementNode(Node<K, V> replacedNode)
        {
            Node<K, V> replacementParent = replacedNode;
            Node<K, V> replacement = replacedNode;
            Node<K, V> focusNode = replacedNode.Right;

            while (focusNode != null)
            {
                replacementParent = replacement;
                replacement = focusNode;
                focusNode = focusNode.Left;
            }

            if (replacement != replacedNode.Right)
            {
                replacementParent.Left = replacement.Right;
                replacement.Right = replacedNode.Right;
            }
            return replacement;
        }
    }
}
