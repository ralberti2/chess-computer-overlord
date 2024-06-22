public sealed class MoveTree
{
    private readonly Node root;

    public MoveTree(Node _root = null)
    {
        root = _root;
    }

    public Node Root()
    {
        return root;
    }

    public MoveTree Insert(Node _move, Node _node = null)
    {
        if (root == null)
        {
            return new MoveTree(_move);
        }

        return new MoveTree(InsertIntoNode(_move, _node, root));
    }

    private Node InsertIntoNode(Node _move, Node _node, Node _root)
    {
        if (_root == _node)
        {
            _root.Children().Add(_move);
            Node best = bestChildNode(_root, _root.Value().Piece().Side());
            _root.Eval(best.Eval());
            return _root;
        }

        foreach (var child in _root.Children())
        {
            var result = InsertIntoNode(_move, _node, child);
            if (result != null)
            {
                child.Children().Add(_move);
                Node best = bestChildNode(child, child.Value().Piece().Side());
                child.Eval(best.Eval());
                return _root;
            }
        }

        return null;
    }

    private Node bestChildNode(Node _root, int _side)
    {
        List<Node> children = _root.Children();
        Node bestNode = _root.Children().First(); 

        foreach (Node child in children)
        {
            if (_side == 1 && bestNode.Eval() > child.Eval())
            {
                bestNode = child;
            }

            if (_side == 0 && bestNode.Eval() < child.Eval())
            {
                bestNode = child;
            }
        }

        return bestNode;
    }

    public void Print(Node _root)
    {
        Console.Write("\n1. ");
        _root.Value().Print();

        foreach (Node child in _root.Children())
        {
            Console.Write("child: ");
            child.Value().Print();
            Console.Write(child.Eval());
            Console.Write("\t");
        }
    }
}
