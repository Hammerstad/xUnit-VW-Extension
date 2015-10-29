#load "common.csx"

var solution = @"..\src\xUnit-VW.sln";
var currentVersion = "0.1.0";

MsBuild.Clean(solution);
Nuget.Restore(solution);
MsBuild.Build(solution, configuration: "Release");
foreach (string file in Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), "*.nupkg"))
{
    File.Delete(file);
}
			
Chocolatey.CreatePackage("../choco/xunit.vw.extension.nuspec", 
	version: currentVersion);