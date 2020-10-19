// бинарное не рекурсивное дерево 

using System;
using System.Collections.Generic;
using System.IO;


/* Класс, содержащий левый и правый дочерние элементы
текущий узел и значение ключа */
public class Node
{
    public int data;
    public Node left, right;

    public Node(int item)
    {
        data = item;
        left = right = null;
    }
}

// Класс для порядкового обхода
public class BinaryTree
{
    public Node root;
    public virtual void inorder()
    {
        if (root == null)
        {
            return;
        }


        Stack<Node> s = new Stack<Node>();
        Node curr = root;

        // пройти по дереву  
        while (curr != null || s.Count > 0)
        {

            // Дойти до крайнего левого узла curr Node
            while (curr != null)
            {
                // поместить указатель на узел дерева в стеке перед обходом левого поддерева узла
                s.Push(curr);
                curr = curr.left;
            }

            // curr должен быть NULL в этот момент
            curr = s.Pop();

            using (StreamWriter file = new StreamWriter(@"text.txt", true))
                file.Write(curr.data + " ");

            // Мы посетили узел и его левое поддерево.Теперь очередь правого поддерева
            curr = curr.right;
        }
    }

    public static void Main(string[] args)
    {

        // создание двоичного дерева и ввод узлов
        BinaryTree tree = new BinaryTree();
        tree.root = new Node(1);
        tree.root.left = new Node(2);
        tree.root.right = new Node(3);
        tree.root.left.left = new Node(4);
        tree.root.left.right = new Node(5);
        tree.inorder();
    }
}