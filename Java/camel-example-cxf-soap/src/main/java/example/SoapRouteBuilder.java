package example;
import org.apache.camel.Processor;
import org.apache.camel.builder.RouteBuilder;

public class SoapRouteBuilder extends RouteBuilder{
	private static final String SOAP_ENDPOINT_URI = "cxf://http://localhost:9006/soap"
	        + "?serviceClass=example.HelloWorld";
	private Processor proc;
	
	SoapRouteBuilder(Processor proc){
		this.proc = proc;
	}
	
	@Override
	public void configure() throws Exception {
		System.out.println("Starting Server");
		from(SOAP_ENDPOINT_URI)
		.process(this.proc);
	}
}
