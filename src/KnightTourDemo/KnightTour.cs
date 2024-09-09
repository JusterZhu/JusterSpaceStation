namespace KnightTourDemo;

public class KnightTour
{
    public int N = 8; // 棋盘大小

    // 棋子的可能移动
    public int[] moveX = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };
    public int[] moveY = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };

    // 检查移动是否合法
    public bool IsValid(int x, int y, int[,] board)
    {
        return (x >= 0 && x < N && y >= 0 && y < N && board[x, y] == -1);
    }

    // 打印棋盘
    public void PrintSolution(int[,] board)
    {
        for (int x = 0; x < N; x++)
        {
            for (int y = 0; y < N; y++)
                Console.Write(board[x, y] + "\t");
            Console.WriteLine();
        }
    }

    // 解决骑士周游问题的核心函数
    public bool SolveKnightTour()
    {
        int[,] board = new int[N, N];

        // 初始化棋盘
        for (int x = 0; x < N; x++)
        for (int y = 0; y < N; y++)
            board[x, y] = -1;

        // 骑士的初始位置
        int startX = 0;
        int startY = 0;
        board[startX, startY] = 0;

        // 从初始位置开始递归求解
        if (!SolveKnightTourUtil(startX, startY, 1, board))
        {
            Console.WriteLine("解决方案不存在");
            return false;
        }
        else
            PrintSolution(board);

        return true;
    }

    // 递归求解函数
    public bool SolveKnightTourUtil(int x, int y, int movei, int[,] board)
    {
        int nextX, nextY;
        if (movei == N * N)
            return true;

        for (int k = 0; k < 8; k++)
        {
            nextX = x + moveX[k];
            nextY = y + moveY[k];
            if (IsValid(nextX, nextY, board))
            {
                board[nextX, nextY] = movei;
                if (SolveKnightTourUtil(nextX, nextY, movei + 1, board))
                    return true;
                else
                    board[nextX, nextY] = -1; // 回溯
            }
        }

        return false;
    }
}