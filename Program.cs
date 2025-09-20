// See https://aka.ms/new-console-template for more information

static List<List<string>> SolveQueens(int n = 8)
{
    var results = new List<List<string>>();
    var queensRow = new int[n];
    Solve(0, queensRow, results, n);
    return results;
}

static void Solve(int boardRow, int[] queensRow, List<List<string>> results, int n)
{
    if (boardRow == n)
    {
        var board = new List<string>();
        for (int row = 0; row < n; row++)
        {
            string queensPlace = new string('.', n);
            queensPlace = queensPlace.Remove(queensRow[row], 1).Insert(queensRow[row], "Q");
            board.Add(queensPlace);
        }
        results.Add(board);
        return;
    }

    for (int boardCol = 0; boardCol < n; boardCol++)
    {
        if (CheckPlace(boardRow, boardCol, queensRow))
        {
            queensRow[boardRow] = boardCol;
            Solve(boardRow + 1, queensRow, results, n); // 遞迴嘗試下一行
        }
    }
}

static bool CheckPlace(int boardRow, int boardCol, int[] queensRow)
{
    for (int i = 0; i < boardRow; i++)
    {
        if (queensRow[i] == boardCol || Math.Abs(queensRow[i] - boardCol) == boardRow - i)
            return false;
    }
    return true;
}

var solutions = SolveQueens();
Console.WriteLine($"共有 {solutions.Count} 個解法");
foreach (var board in solutions)
{
    foreach (var line in board)
        Console.WriteLine(line);
    Console.WriteLine();
}