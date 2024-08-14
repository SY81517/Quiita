package example;

import org.apache.camel.Exchange;
import org.apache.camel.Processor;

public class SoapProcessor implements Processor {
	private HelloWorld instance;

	SoapProcessor(HelloWorld obj) {
		instance = obj;
	}

	@Override
	public void process(Exchange exchange) throws Exception {
		System.out.println("Start Process...");
		String inputText = exchange.getIn().getBody(String.class);
		String response = instance.sayHi(inputText);
		exchange.getMessage().setBody(response);
		System.out.println("End Process...");
	}
}
