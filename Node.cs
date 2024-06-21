public class Node
{
    private readonly Move value;
    private readonly List<int> eval;
    private readonly List<Node> children;

    public Node() : this(new Move(), new List<Node>(), 0) { }

    public Node(Move _move) : this(_move, new List<Node>(), 0) { }

    public Node(Move _move, int _eval) : this(_move, new List<Node>(), _eval) { }

    public Node(Move _move, List<Node> _children, int _eval)
    {
        value = _move;
        eval = new List<int> { _eval };
        children = _children;
    }

    public int Eval()
    {
        return eval.First();
    }

    public void Eval(int _eval)
    {
        eval.Clear();
        eval.Add(_eval);
    }

    public Move Value()
    {
        return value;
    }

    public Node Value(Move _move)
    {
        return new Node(_move, children, eval.First());
    }

    public List<Node> Children()
    {
        return children;
    }

    public Node Child(int idx)
    {
        if (Children().Count > 0)
        {
            return new Node();
        }

        return children.ElementAt(idx);
    }
}
