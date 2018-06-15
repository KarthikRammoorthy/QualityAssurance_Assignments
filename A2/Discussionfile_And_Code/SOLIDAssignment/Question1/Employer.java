import java.util.ArrayList;

public class Employer
{
	ArrayList<IWorker> hourlyWorkers;
	ArrayList<IWorker> salaryWorkers;
	
	
	public Employer(IWorker iHourlyWorker, IWorker iSalaryWorker)
	{
	
		hourlyWorkers = new ArrayList<IWorker>();
		for (int i = 0; i < 5; i++)
		{
			hourlyWorkers.add(iHourlyWorker);
		}
		salaryWorkers = new ArrayList<IWorker>();
		for (int i = 0; i < 5; i++)
		{
			salaryWorkers.add(iSalaryWorker);
		}
	}

	public void outputWageCostsForAllStaff(int hours)
	{
		float cost = 0.0f;
		for (int i = 0; i < hourlyWorkers.size(); i++)
		{
			IWorker worker = hourlyWorkers.get(i);
			cost += worker.calculatePay(hours);
		}
		for (int i = 0; i < salaryWorkers.size(); i++)
		{
			IWorker worker = salaryWorkers.get(i);
			cost += worker.calculatePay(hours);
		}
		System.out.println("Total wage cost for all staff = $" + cost);
	}
	 
	public static void main(String[] args) {
		IWorker varHourlyWorker = new HourlyWorker();
		IWorker varSalaryWorker = new SalaryWorker();
		
		Employer obj = new Employer(varHourlyWorker, varSalaryWorker);
		obj.outputWageCostsForAllStaff(9);
	}
}