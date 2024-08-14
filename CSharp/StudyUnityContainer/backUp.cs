using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyUnityContainer
{
    using System;
    using Unity;
    using Unity.Injection;


    namespace StudyUnityContainer
    {
        class BackUp
        {
            //static void Main( string[] args )
            //{
            //    //(略)
            //    IUnityContainer container = new UnityContainer();
            //    //(略)

            //    //(略)
            //    // 同じ型に対して、複数の型情報を登録するため名前付きにする
            //    container.RegisterType<IVehicle, Car>(nameof(Car));
            //    container.RegisterType<IVehicle, Bike>(nameof(Bike));
            //    container.RegisterType<Driver>(nameof(Car) + "Driver", new InjectionConstructor(container.Resolve<IVehicle>(nameof(Car))));
            //    container.RegisterType<Driver>(nameof(Bike) + "Driver", new InjectionConstructor(container.Resolve<IVehicle>(nameof(Bike))));
            //    //(略)

            //    if(container.Resolve<IVehicle>(nameof(Car)) is Car)
            //    {
            //        Console.WriteLine("Return Car");
            //    }
            //    if(container.Resolve<IVehicle>(nameof(Bike)) is Bike)
            //    {
            //        Console.WriteLine("Return Bike");
            //    }
            //    var CarDriver = container.Resolve<Driver>(nameof(Car) + "Driver");
            //    CarDriver.Run();
            //    var BikeDriver = container.Resolve<Driver>(nameof(Bike) + "Driver");
            //    BikeDriver.Run();
            //}
        }

        public interface IVehicle
        {
            int Run();
        }

        public class Car : IVehicle
        {
            private int _miles = 0;
            public int Run()
            {
                return ++_miles;
            }
        }

        public class Bike : IVehicle
        {
            private int _miles = 0;

            public int Run()
            {
                return ++_miles;
            }
        }

        public class Driver
        {
            private IVehicle _vehicle = null;
            [InjectionConstructor]
            public Driver( IVehicle vehicle )
            {
                _vehicle = vehicle;
            }

            public void Run()
            {
                Console.WriteLine($"Run {_vehicle.GetType().Name} - {_vehicle.Run()} mile");
            }
        }

        public class CustomerService
        {
            private CustomerBusinessLogic _customerBusinessLogic;

            public CustomerService()
            {
                _customerBusinessLogic = new CustomerBusinessLogic(new CustomerDataAccess());
            }

            public string GetCustomerName( int id )
            {
                return _customerBusinessLogic.ProcessCustomerData(id);
            }
        }

        public interface ICustomerDataAccess
        {
            string GetCustomerName( int id );
        }

        public class CustomerDataAccess : ICustomerDataAccess
        {
            public CustomerDataAccess()
            {
            }

            public string GetCustomerName( int id )
            {
                return "Dummy Customer Name";
            }
        }

        public class DataAccessFactory
        {
            public static ICustomerDataAccess GetDataAccessObj()
            {
                return new CustomerDataAccess();
            }
        }

        public class CustomerBusinessLogic
        {
            private ICustomerDataAccess _dataAccess;

            public CustomerBusinessLogic( ICustomerDataAccess customerDataAccess )
            {
                _dataAccess = customerDataAccess;
            }

            public CustomerBusinessLogic()
            {
                _dataAccess = DataAccessFactory.GetDataAccessObj();
            }

            public string ProcessCustomerData( int id )
            {
                return _dataAccess.GetCustomerName(id);
            }
        }

        public class Demo
        {
            static void FlowControlDemo()
            {
                bool cotinueExectuion = true;
                do
                {
                    Console.WriteLine("Enter First Name:");
                    var firstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name:");
                    var lastName = Console.ReadLine();
                    Console.WriteLine("Do you want to save it ? Y/N:");
                    var wantToSave = Console.ReadLine();
                    if(wantToSave.ToUpper() == "Y")
                    {
                        SaveToDB(firstName, lastName);
                    }

                    Console.WriteLine("Do you want to exit? Y/N:");
                    var wantToExit = Console.ReadLine();

                    if(wantToExit.ToUpper() == "Y")
                        cotinueExectuion = false;
                } while(cotinueExectuion);
            }

            private static void SaveToDB( string firstName, string lastName )
            {
                //save firstName and lastName to the DB...
            }
        }
    }
}
