
public class SubtractMathOperation extends MathOperation {
	

	
	public SubtractMathOperation(int leftOperand, int rightOperand)
	{
		super(leftOperand, rightOperand);
		
	}
	
	@Override
	public int GetResult()
	{
		return leftOperand - rightOperand;
	}

}
