
public class DivideMathOperation extends MathOperation {
	
	
	public DivideMathOperation(int leftOperand, int rightOperand)
	{
		super(leftOperand, rightOperand);
		
	}
	
	@Override
	public int GetResult()
	{
		return leftOperand / rightOperand;
	}

}
