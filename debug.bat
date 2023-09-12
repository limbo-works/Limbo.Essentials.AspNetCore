@echo off
dotnet build src/Limbo.Essentials.AspNetCore --configuration Debug /t:rebuild /t:pack -p:BuildTools=1 -p:PackageOutputPath=c:/nuget