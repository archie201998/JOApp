using JOMonitoringApp.Interface;
using JOMonitoringApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOMonitoringApp
{
    public class Factory
    {
        internal static GenericCommands mySqlGenericCommands;

        public static IUsersRepository UsersRepository() => new UsersRepository(mySqlGenericCommands);
    }
}
