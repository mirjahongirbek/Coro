using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Service
{
    public class Start
    {
        public static void Builder(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                           .Where(t => t.Name.EndsWith("Service"))
                           .AsImplementedInterfaces().SingleInstance();
            builder.RegisterAssemblyTypes(dataAccess)
                 .Where(t => t.Name.EndsWith("SmsCommand"))
                 .AsImplementedInterfaces().SingleInstance();
            //ProxyCommand
            //ConfigCommand
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("ProxyCommand"))
                .AsImplementedInterfaces().SingleInstance();
            builder.RegisterAssemblyTypes(dataAccess)
            .Where(t => t.Name.EndsWith("ConfigCommand"))
            .AsImplementedInterfaces().SingleInstance();
        }
    }
}
