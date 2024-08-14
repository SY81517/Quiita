package example;

public class HelloWorldImpl implements HelloWorld{

	@Override
	public String sayHi(String text) {
		return "Hello " + text;
	}
}
