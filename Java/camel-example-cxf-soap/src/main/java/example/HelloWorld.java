package example;

import jakarta.jws.WebParam;
import jakarta.jws.WebService;

@WebService
public interface HelloWorld {
    String sayHi(@WebParam(name = "text") String text);
}
