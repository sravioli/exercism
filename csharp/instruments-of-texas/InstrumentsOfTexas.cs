using System;

public class CalculationException(int operand1, int operand2, string message, Exception inner)
    : Exception(message, inner)
{
    public int Operand1 { get; } = operand1;
    public int Operand2 { get; } = operand2;
}

public class CalculatorTestHarness(Calculator calculator)
{
    public string TestMultiplication(int x, int y)
    {
        try
        {
            Multiply(x, y);
        }
        catch (CalculationException e) when (e.Operand1 < 0 && e.Operand2 < 0)
        {
            return $"Multiply failed for negative operands. {e.Message}";
        }
        catch (CalculationException e) when (e.Operand1 > 0 && e.Operand2 > 0)
        {
            return $"Multiply failed for mixed or positive operands. {e.Message}";
        }
        return "Multiply succeeded";
    }

    public void Multiply(int x, int y)
    {
        try
        {
            calculator.Multiply(x, y);
        }
        catch (OverflowException ex)
        {
            throw new CalculationException(x, y, ex.Message, ex);
        }
    }
}

// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
