using System;

public static class SimpleCalculator
{
    private const string ADDITION = "+";
    private const string MULTIPLICATION = "*";
    private const string DIVISION = "/";
    private static readonly string DIVISION_ERR = "Division by zero is not allowed.";

    private delegate int Operation(int a, int b);

    private static string Format(int a, int b, string operation, Operation CalculateResult) =>
        $"{a} {operation} {b} = {CalculateResult(a, b)}";

    public static string Calculate(int operand1, int operand2, string operation)
    {
        switch (operation)
        {
            case var symbol when operation == null:
                throw new ArgumentNullException("operation cannot be null!");
            case string symbol when operation is "":
                throw new ArgumentException("Operation cannot be empty!");
            case string symbol when operation is ADDITION:
                return Format(operand1, operand2, symbol, SimpleOperation.Addition);
            case string symbol when operation is MULTIPLICATION:
                return Format(operand1, operand2, symbol, SimpleOperation.Multiplication);
            case string symbol when operation is DIVISION:
                return (operand2 == 0)
                    ? DIVISION_ERR
                    : Format(operand1, operand2, symbol, SimpleOperation.Division);
            default:
                throw new ArgumentOutOfRangeException("Unknown operation!");
        }
        ;
    }
}
