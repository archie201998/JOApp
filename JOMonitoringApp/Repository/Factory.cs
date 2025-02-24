
using JOMonitoringApp.Interface;
using JOMonitoringApp.Repository;

namespace JOMonitoringApp
{
    public class Factory
    {

        internal static GenericCommands mySqlGenericCommands = new GenericCommands("jo_monitoring_instance");

        public static IUsersRepository UsersRepository() => new UsersRepository(mySqlGenericCommands);



    }
}
