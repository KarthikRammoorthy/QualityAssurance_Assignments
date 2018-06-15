public class BankAccount extends Account
{

	public float GetBalance()
	{
		return balance;
	}

	public void Credit(float amount)
	{
		balance += amount;
	}

	public void Debit(float amount)
	{
		balance -= amount;
	}
}