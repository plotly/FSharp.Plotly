# Clean up the previously-cached NuGet packages.
# Lower-case is intentional (that's how nuget stores those packages).
Remove-Item -Recurse ~\.nuget\packages\plotly.net* -Force

# build and pack Plotly.NET.Interactive
dotnet pack ../../src/Plotly.NET/Plotly.NET.fsproj -tl -c Release -p:PackageVersion=0.0.1-dev -o "./pkg"

