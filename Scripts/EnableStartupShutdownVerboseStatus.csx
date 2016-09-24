#r "mscorlib"

using System;
using Microsoft.Win32;

var registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true);

if (registryKey != null)
{
    Console.WriteLine("Found the key!");

    var keyValue = registryKey.GetValue("VerboseStatus");
    Console.WriteLine("Setting Verbose Status... ");

    if (keyValue != null)
    {
        Console.WriteLine("Found Verbose status...");
        registryKey.SetValue("VerboseStatus", 1);
    }
    else
    {
        Console.WriteLine("Verbose status not found. A new value will be created...");
        registryKey.SetValue("VerboseStatus", 1, RegistryValueKind.DWord);
    }

    registryKey.Close();
    Console.WriteLine("Done");
}
else
{
    Console.WriteLine("Key not found!");
}