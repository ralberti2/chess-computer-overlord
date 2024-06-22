public sealed class Game
{
    private Game() { }
    private static Game _instance;
    public static Game Instance()
    {
        if (_instance == null)
        {
            _instance = new Game();
        }
        return _instance;
    }

    private void WinnerPrompt(Board positionState)
    {
        string result = positionState.GameOverResult()[true];

        if (result == "tie")
        {
            Console.WriteLine("Tie");
        }

        else if (result == "white")
        {
            Console.WriteLine("White wins");
        }

        else
        {
            Console.WriteLine("Black wins");
        }
    }

    public void Start()
    {
        Board chessBoard = new Board();

        Robot Robot0 = new Robot(1, chessBoard, new MoveTree(), "robot1");
        Robot Robot1 = new Robot(0, chessBoard, new MoveTree(), "robot2");

        Move move = new Move();
        MoveTree movetree = new MoveTree();

        chessBoard.SetPieces();
        chessBoard.Print();

        while (!chessBoard.GameOver())
        {
            movetree = Robot0.Calculate(chessBoard, 1);
            move = Robot0.MoveToPlay(movetree);
            chessBoard = chessBoard.Update(move);
            chessBoard.Print();

            movetree = Robot1.Calculate(chessBoard, 2);
            move = Robot1.MoveToPlay(movetree);
            chessBoard = chessBoard.Update(move);
            chessBoard.Print();
        }

        WinnerPrompt(chessBoard);
    }
}
