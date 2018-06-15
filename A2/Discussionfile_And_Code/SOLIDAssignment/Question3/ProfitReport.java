import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import javax.print.Doc;
import javax.print.DocFlavor;
import javax.print.DocPrintJob;
import javax.print.PrintException;
import javax.print.PrintService;
import javax.print.PrintServiceLookup;
import javax.print.SimpleDoc;
import javax.print.attribute.HashPrintRequestAttributeSet;
import javax.print.attribute.PrintRequestAttributeSet;
import javax.print.attribute.standard.Copies;
import javax.print.event.PrintJobAdapter;
import javax.print.event.PrintJobEvent;
import java.util.ArrayList;

public class ProfitReport
{
	private ArrayList<String> reportData;

	public ProfitReport()
	{
		reportData = new ArrayList<String>();
	}

	public void CreateReport()
	{
		reportData.add("Canada made $100000");
		reportData.add("Mexico made $1007700");
		reportData.add("Russia made $10009940");
		reportData.add("India made $10004500");
		reportData.add("China made $1045460000");
		reportData.add("Iran made $100466000");
		reportData.add("England made $1006000");
		reportData.add("Germany made $133300000");
		reportData.add("Chile made $1000400");
	}

	public void SendToPrinter()
	{
		try
		{
	    	String defaultPrinter = PrintServiceLookup.lookupDefaultPrintService().getName();
	    	PrintService service = PrintServiceLookup.lookupDefaultPrintService();
	    	StringBuilder builder = new StringBuilder();
	    	for (int i = 0; i < reportData.size(); i++)
	    	{
	    		builder.append(reportData.get(i) + "\f");
	    	}
	    	InputStream is = new ByteArrayInputStream(builder.toString().getBytes("UTF8"));
	    	PrintRequestAttributeSet pras = new HashPrintRequestAttributeSet();
	    	pras.add(new Copies(1));
	    	DocFlavor flavor = DocFlavor.INPUT_STREAM.AUTOSENSE;
	    	Doc doc = new SimpleDoc(is, flavor, null);
	    	DocPrintJob job = service.createPrintJob();
	    	job.addPrintJobListener(new PrintJobAdapter() {
	      		public void printJobCanceled(PrintJobEvent pje) {
	        		allDone();
	      		}
	      		public void printJobCompleted(PrintJobEvent pje) {
	        		allDone();
	      		}
	      		public void printJobFailed(PrintJobEvent pje) {
	        		allDone();
	      		}	
	      		public void printJobNoMoreEvents(PrintJobEvent pje) {
	        		allDone();
	      		}
	      		void allDone() {
	          		System.out.println("Printing done ...");
	      		}
	    	});
	    	job.print(doc, pras);
	    	is.close();
		}
		catch (Exception e)
		{
			System.out.println("Printing failed or something!");
		}
	}

	public void SendToEmail(String emailAddress)
	{
		try
		{
	    	StringBuilder builder = new StringBuilder();
	    	for (int i = 0; i < reportData.size(); i++)
	    	{
	    		builder.append(reportData.get(i) + "\n");
	    	}
	    	EmailSender sender = new EmailSender();
	    	sender.SendEmail(emailAddress, "Profit Report!", builder.toString());
		}
		catch (Exception e)
		{
			System.out.println("Yipes internet must be down!");
		}
	}
}