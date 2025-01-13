module ProjectInfo

open Fake.Core

/// Contains relevant information about a project (e.g. version info, project location)
type ProjectInfo = {
    Name: string
    ProjFile: string
    ReleaseNotes: ReleaseNotes.ReleaseNotes Option
    PackageVersionTag: string
    mutable PackagePrereleaseTag: string
    AssemblyVersion: string
    AssemblyInformationalVersion: string
} with 
    /// creates a ProjectInfo given a name, project file path, and release notes file path.
    /// version info is created from the version header of the uppermost release notes entry.
    /// Assembly version is set to X.0.0, where X is the major version from the releas enotes.
    static member create(
        name: string,
        projFile: string,
        releaseNotesPath: string
    ): ProjectInfo = 
        let release = releaseNotesPath |> ReleaseNotes.load
        let stableVersion = release.NugetVersion |> SemVer.parse
        let stableVersionTag = $"{stableVersion.Major}.{stableVersion.Minor}.{stableVersion.Patch}"
        let assemblyVersion = $"{stableVersion.Major}.0.0"
        let assemblyInformationalVersion = stableVersionTag
        {
            Name = name
            ProjFile = projFile
            ReleaseNotes = Some release
            PackagePrereleaseTag = ""
            PackageVersionTag = stableVersionTag
            AssemblyVersion = assemblyVersion
            AssemblyInformationalVersion = assemblyInformationalVersion
        }    
    static member create(
        name: string,
        projFile: string
    ): ProjectInfo = 
        {
            Name = name
            ProjFile = projFile
            ReleaseNotes = None
            PackagePrereleaseTag = ""
            PackageVersionTag = ""
            AssemblyVersion = ""
            AssemblyInformationalVersion = ""
        }

let projectName = "Plotly.NET"

let solutionFile = $"{projectName}.sln"

let gitOwner = "plotly"
let gitHome = $"https://github.com/{gitOwner}"
let projectRepo = $"https://github.com/{gitOwner}/{projectName}"

/// packages are generated in this directory.
let pkgDir = "pkg"

/// binaries are built using this configuration.
let configuration = "Release"

// test base projects (need to be built first)
let FSharpTestBaseProject = ProjectInfo.create("FSharpTestBase", "tests/Common/FSharpTestBase/FSharpTestBase.fsproj")
let CSharpTestBaseProject = ProjectInfo.create("CSharpTestBase", "tests/Common/CSharpTestBase/CSharpTestBase.csproj")

let testBaseProjects = [
    FSharpTestBaseProject
    CSharpTestBaseProject
]

// test projects (.NET)
let CoreTestProject = ProjectInfo.create("CoreTests", "tests/CoreTests/CoreTests/CoreTests.fsproj")

/// contains project info about the core test projects
let testProjectsCore = [
    CoreTestProject
]

let ImageExportTestProject = ProjectInfo.create("ImageExportTests", "tests/ExtensionLibsTests/ImageExportTests/ImageExportTests.fsproj")
let CSharpTestProject = ProjectInfo.create("CSharpTests", "tests/ExtensionLibsTests/CSharpTests/CSharpTests.csproj")

///
let testProjectsExtensionsLibs = [
    ImageExportTestProject
    CSharpTestProject
]

// test projects (.NET framework)
let StrongNameTestProject = ProjectInfo.create("StrongNameTests", "tests/CoreTests/StrongNameTests/StrongNameTests.fsproj")

let testProjectsNetFX = [
    StrongNameTestProject
]

let CoreProject = ProjectInfo.create("Plotly.NET", "src/Plotly.NET/Plotly.NET.fsproj", "src/Plotly.NET/RELEASE_NOTES.md")
let InteractiveProject = ProjectInfo.create("Plotly.NET.Interactive", "src/Plotly.NET.Interactive/Plotly.NET.Interactive.fsproj", "src/Plotly.NET.Interactive/RELEASE_NOTES.md")
let ImageExportProject = ProjectInfo.create("Plotly.NET.ImageExport", "src/Plotly.NET.ImageExport/Plotly.NET.ImageExport.fsproj", "src/Plotly.NET.ImageExport/RELEASE_NOTES.md")
let CSharpProject = ProjectInfo.create("Plotly.NET.CSharp", "src/Plotly.NET.CSharp/Plotly.NET.CSharp.csproj", "src/Plotly.NET.CSharp/RELEASE_NOTES.md")

/// contains project info about all projects
let projects = [
   CoreProject
   InteractiveProject
   ImageExportProject
   CSharpProject
]

/// docs are always targeting the version of the core project
let stableDocsVersionTag = CoreProject.PackageVersionTag

/// branch tag is always the version of the core project
let branchTag = CoreProject.PackageVersionTag

/// prerelease suffix used by prerelease buildtasks
let mutable prereleaseSuffix = ""

/// prerelease tag used by prerelease buildtasks
let mutable prereleaseTag = ""

/// mutable switch used to signal that we are building a prerelease version, used in prerelease buildtasks
let mutable isPrerelease = false
