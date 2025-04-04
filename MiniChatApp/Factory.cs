
using System;

namespace MiniChatApp
{
    public class Factory
    {
        internal static GenericCommands mySqlGenericCommands = new GenericCommands("convo_instance");

        public static IConvoRepository ConvoRepository() => new ConvoRepository(mySqlGenericCommands);

      
    }
}
