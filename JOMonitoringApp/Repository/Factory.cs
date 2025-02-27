
using JOMonitoringApp.Interface;
using JOMonitoringApp.Repository;
using System;

namespace JOMonitoringApp
{
    public class Factory
    {
        internal static GenericCommands mySqlGenericCommands = new GenericCommands("jo_monitoring_instance");

        public static IUsersRepository UsersRepository() => new UsersRepository(mySqlGenericCommands);

        public static IJobOrdersRepository JobOrdersRepository() => new JobOrdersRepository(mySqlGenericCommands);

        public static ICustomersRepository CustomersRepository() => new CustomersRepository(mySqlGenericCommands);

        public static IParticularsRepository ParticularsRepository() => new ParticularsRepository(mySqlGenericCommands);

        public static IEmployeesRepository EmployeeRepository() => new EmployeeRepository(mySqlGenericCommands);

        public static IStatusRepository StatusRepository() => new StatusRepository(mySqlGenericCommands);

        public static IError CreateErrors(Array errors) => new Error(errors);
    }
}
