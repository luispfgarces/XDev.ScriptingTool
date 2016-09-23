// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

#r "..\WindowsSystemCustomizations.dll"

namespace Scripts

open System.Security
open Microsoft.Win32
open WindowsSystemCustomizations.Attributes

[<ScriptClass("RegistryEnhancements")>]
type Script() =

    [<ScriptMethod("EnableStartupShutdownVerboseStatus")>]
    member this.EnableStartupShutdownVerboseStatus() =
        let registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true)
        if registryKey <> null then
            printfn "Found the key!"

            let keyValue = registryKey.GetValue("VerboseStatus")
            printfn "Setting Verbose Status... "

            if keyValue <> null
            then
                printfn "Found Verbose status..."
                registryKey.SetValue("VerboseStatus", 1)

            else
                printfn "Verbose status not found. A new value will be created..."
                registryKey.SetValue("VerboseStatus", 1, RegistryValueKind.DWord)

            registryKey.Close()
            printfn "Done"

        else printfn "Key not found!"