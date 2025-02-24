using JOMonitoringApp.Interface;
using JOMonitoringApp.Repository;

namespace JOMonitoringApp
{
    public class Factory
    {
        private static readonly GenericCommands mySqlGenericCommands;


        public static IUsersRepository UsersRepository() => new UsersRepository(mySqlGenericCommands);

       
    }
}
