
using JOMonitoringApp.Interface;
using JOMonitoringApp.Repository;
using System;

namespace JOMonitoringApp
{
    public class Factory
    {
        internal static GenericCommands mySqlGenericCommands = new GenericCommands("jo_monitoring_instance");
        internal static GenericCommands sqlGenericCommands = new GenericCommands("water_system_instance");

        public static IUsersRepository UsersRepository() => new UsersRepository(mySqlGenericCommands);

        public static IJobOrdersRepository JobOrdersRepository() => new JobOrdersRepository(mySqlGenericCommands);

        public static ICustomersRepository CustomersRepository() => new CustomersRepository(sqlGenericCommands, mySqlGenericCommands);

        public static IParticularsRepository ParticularsRepository() => new ParticularsRepository(mySqlGenericCommands);

        public static IEmployeesRepository EmployeeRepository() => new EmployeeRepository(mySqlGenericCommands);

        public static IStatusRepository StatusRepository() => new StatusRepository(mySqlGenericCommands);

        public static IError CreateErrors(Array errors) => new Error(errors);

        public static IJobOrdersParticulars JobOrdersParticularsRepository() => new JobOrdersParticularsRepository(mySqlGenericCommands);
        public static IJOLogsRepository JOLogsRepository() => new JobOrdersLogsRepository(mySqlGenericCommands);

        public static IRolesRepository RolesRepository() => new RolesRepository(mySqlGenericCommands);

        public static IInvestigationRepository InvestigationRepository() => new InvestigationRepository(mySqlGenericCommands);
        public static IInvestigationStatFindingsRepository InvestigationStatFindingsRepository() => new InvestigationStatFindingsRepository(mySqlGenericCommands);

        public static IInvestigationConditionOfServiceFacilities InvestigationConditionOfServiceFacilities() => new InvestigationConditionOfServiceFacilitiesRepository(mySqlGenericCommands);



    }
}
