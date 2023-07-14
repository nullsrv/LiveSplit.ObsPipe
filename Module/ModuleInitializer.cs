using System;
using System.IO;
using System.Reflection;

namespace LiveSplit.ObsPipe
{
    internal static class ModuleInitializer
    {
        internal static void Run()
        {
            lock (typeof(ModuleInitializer))
            {
                System.AppDomain.CurrentDomain.AssemblyResolve += ComponentAssembly_Resolver;
            }
        }

        internal static System.Reflection.Assembly ComponentAssembly_Resolver(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name).Name + ".dll";

            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var dll = System.IO.Path.Combine(path, (Environment.Is64BitProcess ? @"x64\" : @"x86\") + assemblyName);

            return File.Exists(dll) ? System.Reflection.Assembly.LoadFile(dll) : null;
        }
    }
}