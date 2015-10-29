#r "System.Management.dll"

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Management;

using Microsoft.Win32;

public static class MsBuild
{
    public static void Clean(string pathToSolutionFile, string configuration = "Release", string platform = @"""Any CPU""") 
    {
        Build(pathToSolutionFile, configuration, platform, "Clean");
    }

    public static void Build(string pathToSolutionFile, string configuration = "Release", string platform = @"""Any CPU""", string target = "Build", string arguments = "")
    {
        Console.WriteLine("Running MsBuild for " + pathToSolutionFile + " (" + platform + "/" + configuration + ")");
        string pathToMsBuild = PathUtils.MsBuildPath();
        
        Command.Execute(pathToMsBuild, pathToSolutionFile + String.Format(" /property:Configuration={0} /t:{1} /property:Platform={2} /nologo {3}", 
                                                     configuration, target, platform, arguments));
    }
}

public static class Nuget
{    
    public static void Restore(string solutionPath, string arguments = "")
    {
        Command.Execute("nuget", string.Format("restore {0} {1}", solutionPath, arguments));
    }
}

public static class Chocolatey
{
    public static void CreatePackage(string nuspecPath, string version = "0.0.1", string outputDirectory = ".", string additionalProperties = "")
    {
        Console.WriteLine("Creating chocolatey package from " + nuspecPath);
        var arguments = string.Format("-version {0} -Properties \"Version={1};" + additionalProperties + "\" -NoPackageAnalysis -OutputDirectory {2}",
            version, version, StringUtils.Quote(outputDirectory));
        Command.Execute("nuget", string.Format("pack {0} {1}", nuspecPath, arguments));
    }
}

public static class Command
{
    public static void Execute(string commandPath, string arguments)
    {
        Console.WriteLine("Executing " + commandPath + " " + arguments);
        var startInformation = CreateProcessStartInfo(commandPath, arguments);
        var process = CreateProcess(startInformation);
        SetVerbosityLevel(process);
        RunAndWait(process);
        CheckIfSuccessfull(process.ExitCode, commandPath);
    }

    private static ProcessStartInfo CreateProcessStartInfo(string commandPath, string arguments)
    {
        var startInformation = new ProcessStartInfo(StringUtils.Quote(commandPath));
        startInformation.CreateNoWindow = true;
        startInformation.Arguments =  arguments;
        startInformation.UseShellExecute = false;
        startInformation.RedirectStandardOutput = true;
        startInformation.RedirectStandardError = true;

        return startInformation;
    }

    private static Process CreateProcess(ProcessStartInfo startInformation)
    {
        var process = new Process();
        process.StartInfo = startInformation;
        return process;
    }

    private static void SetVerbosityLevel(Process process)
    {
        process.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
        process.ErrorDataReceived += (s, e) => Console.WriteLine(e.Data);
    }

    private static void RunAndWait(Process process)
    {
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();       
        process.WaitForExit();
    }

    private static void CheckIfSuccessfull(int exitCode, string commandPath)
    {
        if(exitCode != 0 && commandPath != "robocopy")
        {
            throw new Exception();
        }
    }
}

public static class PathUtils
{
    public static string MsBuildPath()
    {
        string keyName = @"SOFTWARE\Wow6432Node\Microsoft\MSBuild\ToolsVersions";
        string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
       
        RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName);
        string[] subKeynames = key.GetSubKeyNames().Select(n => n.Replace(".", decimalSeparator)).ToArray();        
        Collection<decimal> versionNumbers = new Collection<decimal>();
       
        for (int i = 0; i < subKeynames.Length; i++)
        {
            decimal versionNumber;
            if (decimal.TryParse(subKeynames[i], out versionNumber))
            {
                versionNumbers.Add(versionNumber);
            }                        
        }
       
        decimal latestVersionNumber = versionNumbers.OrderByDescending(n => n).First();
        
        RegistryKey latestVersionSubKey = key.OpenSubKey(latestVersionNumber.ToString().Replace(decimalSeparator, "."));
        string pathToMsBuildTools = (string)latestVersionSubKey.GetValue("MSBuildToolsPath");
        return Path.Combine(pathToMsBuildTools, "MsBuild.exe"); 
    }
}

public static class StringUtils
{
    public static string Quote(string value)
    {
        return "\"" + value + "\"";
    }
}