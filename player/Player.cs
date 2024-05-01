abstract class Player
{
    private readonly int side;
    private readonly string name;

    public Player(int _side, Board _chessBoard, string _name)
    {
        side = _side;
        name = _name;
    }

    public Move AskMove(Board chessBoard)
    {
        Console.WriteLine("Tile1: ");
        string tile1 = Console.ReadLine();
        int x1 = tile1[0] - '0', y1 = tile1[0] - '0';

        if (tile1 == "") AskMove(chessBoard);

        Console.WriteLine("Tile2: ");
        string tile2 = Console.ReadLine();
        int x2 = tile2[0] - '0', y2 = tile2[1] - '0';

        if (tile2 == "") AskMove(chessBoard);

        Move move = new Move(chessBoard.Tile(x1, y1), chessBoard.Tile(x2, y2));

        return move;
    }

    protected Boolean ValidMove(Move _move)
    {
        return true;
    }

    public Point findPointByPiece(Dictionary<Point, ChessPiece> pieces, ChessPiece piece)
    {
        foreach (var pair in pieces)
        {
            if (pair.Value == piece)
            {
                return pair.Key;
            }
        }

        throw new KeyNotFoundException("PIECE NOT FOUND BY GIVEN VALUE");
    }

    public Board Play(Move _move, Board _position)
    {
        Board newPosition = _position.Update(_move);

        return newPosition;
    }
}
