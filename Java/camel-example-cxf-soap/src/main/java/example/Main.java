package example;

import org.apache.camel.CamelContext;
import org.apache.camel.impl.DefaultCamelContext;

public class Main {

	public static void main(String[] args) throws Exception {
        System.out.println("Server ready...");
		try (CamelContext context = new DefaultCamelContext()) {
			context.addRoutes(new SoapRouteBuilder(new SoapProcessor(new HelloWorldImpl())));
			context.start();
			System.out.println("Sleep...");
			Thread.sleep(5 * 60 * 1000);
		}
        System.out.println("Server exiting");
	}
}
