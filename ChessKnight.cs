namespace Wheelzy;

public class ChessKnight
{
    public static List<Tuple<int, int>> GetPossibleMoves(int currentX, int currentY)
    {
        List<Tuple<int, int>> possibleMoves = new();

        int[] xOffset = { 1, 1, -1, -1, 2, 2, -2, -2 };
        int[] yOffset = { 2, -2, 2, -2, 1, -1, 1, -1 };

        for(int i = 0; i < 8; i++)
        {
            int newX = currentX + xOffset[i];
            int newY = currentY + yOffset[i];

            if(IsValidMove(newX, newY))
            {
                possibleMoves.Add(new Tuple<int, int>(newX, newY));
            }
        }

        return possibleMoves;
    }

    private static bool IsValidMove(int x, int y)
    {
        return x >= 1 && x <= 8 && y >= 1 && y <= 8;
    }
}
