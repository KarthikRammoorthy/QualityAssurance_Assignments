public class Calculator
{
	public static int Divide(int left, int right)
	{
		MathOperation op = new DivideMathOperation(left, right);
		return op.GetResult();
	}

	public static int Multiply(int left, int right)
	{
		MathOperation op = new MultiplyMathOperation(left, right);
		return op.GetResult();
	}

	public static int Add(int left, int right)
	{
		MathOperation op = new AddMathOperation(left, right);
		return op.GetResult();
	}

	public static int Subtract(int left, int right)
	{
		MathOperation op = new SubtractMathOperation(left, right);
		return op.GetResult();
	}
}