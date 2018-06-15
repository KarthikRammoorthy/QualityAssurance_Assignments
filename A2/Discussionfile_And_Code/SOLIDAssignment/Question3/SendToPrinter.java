import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.util.ArrayList;

import javax.print.Doc;
import javax.print.DocFlavor;
import javax.print.DocPrintJob;
import javax.print.PrintService;
import javax.print.PrintServiceLookup;
import javax.print.SimpleDoc;
import javax.print.attribute.HashPrintRequestAttributeSet;
import javax.print.attribute.PrintRequestAttributeSet;
import javax.print.attribute.standard.Copies;
import javax.print.event.PrintJobAdapter;
import javax.print.event.PrintJobEvent;

public class SendToPrinter {
	
	public void FnSendToPrinter(ArrayList<String> reportData)
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


}
