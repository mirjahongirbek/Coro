using System.Collections.Generic;
using System.Linq;

namespace OtpClient.Modals
{
    public class ProjectConfig
    {
        public List<IConfigCommand> commands;
        public ProjectConfig()
        {
            commands = new List<IConfigCommand>()
            {
                new StirngCommand(),
                 new ClassCommand(),
               new  NumberCommand()
            };

        }
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
        public T Get<T>(string text)
        {
            string name = "";
            if (typeof(T).IsClass && typeof(T).Name.ToLower() == "string")
            {
                name = "class";
            }
            else
            {

            }
            var cmd = commands.FirstOrDefault(m => typeof(T).Name == name);
            var pair = Data.FirstOrDefault(m => m.Key.ToLower() == text);
            return cmd.Convert<T>(pair.Value);
        }
    }
    public interface IConfigCommand
    {
        List<string> Types { get; }
        T Convert<T>(object value);


    }
    public class StirngCommand : IConfigCommand
    {
        public List<string> Types { get; }

        public T Convert<T>(object value)
        {
            throw new System.NotImplementedException();
        }
    }
    public class ClassCommand : IConfigCommand
    {
        public List<string> Types => new List<string>() { "class" };

        public T Convert<T>(object value)
        {
            throw new System.NotImplementedException();
        }
    }
    public class NumberCommand : IConfigCommand
    {
        public List<string> Types => new List<string>() { typeof(double).Name.ToLower(),
            typeof(int).Name.ToLower(),
            typeof(float).Name.ToLower(),
            typeof(decimal).Name.ToLower() };

        public T Convert<T>(object value)
        {
            throw new System.NotImplementedException();
        }
    }

}
