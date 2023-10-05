
using Wheelzy;

string apiUrl = "https://notrealapi.com/lottery/play";
int numberOfRequests = 10;

for(int i = 0; i < numberOfRequests; i++)
{
    int customerNumber = ApiRequest.GenerateNumber();

    Console.WriteLine($"Sending request {i + 1}: Customer Number = {customerNumber}");

    try
    {
        int result = await ApiRequest.MakeApiRequest(apiUrl, customerNumber);

        Console.WriteLine($"API Response: {result}");

        if(result == customerNumber)
        {
            Console.WriteLine("Congratulations! You won!");
        }
        else
        {
            Console.WriteLine("No win this time.");
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();

    // Test cases
    List<Tuple<int, int>> moves1 = ChessKnight.GetPossibleMoves(1, 1);
    List<Tuple<int, int>> moves2 = ChessKnight.GetPossibleMoves(4, 4);
    List<Tuple<int, int>> moves3 = ChessKnight.GetPossibleMoves(8, 8);

    Console.WriteLine("Possible moves for a knight at (1, 1):");
    PrintMoves(moves1);

    Console.WriteLine("\nPossible moves for a knight at (4, 4):");
    PrintMoves(moves2);

    Console.WriteLine("\nPossible moves for a knight at (8, 8):");
    PrintMoves(moves3);

    static void PrintMoves(List<Tuple<int, int>> moves)
    {
        foreach(var move in moves)
        {
            Console.WriteLine($"({move.Item1}, {move.Item2})");
        }
    }
}