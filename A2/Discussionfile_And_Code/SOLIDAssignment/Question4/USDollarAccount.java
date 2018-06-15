public class USDollarAccount extends Account
{
	static final float EXCHANGE_RATE = 0.75f;

	public void Credit(float amount)
	{
		balance += amount * EXCHANGE_RATE;
	}

	public float GetBalance()
	{
		return balance;
	}
	
	public void Debit(float amount)
	{
		balance -= amount * EXCHANGE_RATE;
	}
}