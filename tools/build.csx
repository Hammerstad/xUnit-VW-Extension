#load "common.csx"

var solution = @"..\src\xUnit-VW.sln";

MsBuild.Clean(solution);
Nuget.Restore(solution);
MsBuild.Build(solution, configuration: "Release");
foreach (string file in Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), "*.nupkg"))
{
    File.Delete(file);
}
			
Chocolatey.CreatePackage("../choco/2.0.0/xunit.vw.extension.nuspec", 
	version: "2.0.0");
Chocolatey.CreatePackage("../choco/2.1.0/xunit.vw.extension.nuspec", 
	version: "2.1.0");