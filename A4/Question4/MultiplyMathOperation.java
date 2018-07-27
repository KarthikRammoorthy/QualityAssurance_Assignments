
public class MultiplyMathOperation extends MathOperation {
	

	public MultiplyMathOperation(int leftOperand, int rightOperand)
	{
		super(leftOperand, rightOperand);
		
	}
	
	@Override
	public int GetResult()
	{
		return leftOperand * rightOperand;
	}
	

}
