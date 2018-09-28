# VSCode-CSharp-Template
This is a simple C# project template meant to accelerate .NET Framework and Mono workflows in Visual Studio Code.

Rather than using .NET Core, this project exclusively uses Mono and .NET Framework tooling (via `msbuild`). As a result, output binaries will be .exe files instead of the .dll files that .NET Core produces. This is more in line with the behavior of the Visual Studio 2017 / Visual Studio for Mac.

**Features:**
- Uses the new .csproj format, so you can easily edit the project by hand.
  - Because of this, the template folder is copy-pastable. No need to worry about unique project GUIDs!
- Convenient build tasks:
  - `Restore Project`: Initializes the project and updates project data. Run this every time you set up a new project, and again if you add references to other projects.
  - `Build (Debug/Release)`: Builds the project with the selected configuration.
  - `Build and Run (Debug/Release)`: Builds the project with the selected configuration and subsequently runs it with `mono` on Mac or `cmd /k` on Windows.
  - `Clean Project`: Cleans the output directory.
- Debugging support:
  - Integrates with the Mono Debug extension (or, optionally, `clr` [for 64-bit programs on Windows](https://github.com/OmniSharp/omnisharp-vscode/wiki/Desktop-.NET-Framework)) with pre-written Launch and Attach tasks.

**Prerequisites:**
- [Visual Studio Code](https://code.visualstudio.com)
  - [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
  - [Mono Debug extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.mono-debug) (required for Mac, optional for Windows)
- [Mono](https://www.mono-project.com/download/stable/) (required for Mac, optional for Windows)
- [Visual Studio 2017](https://visualstudio.microsoft.com/vs/) or [Build Tools for Visual Studio 2017](https://visualstudio.microsoft.com/downloads/#build-tools-for-visual-studio-2017) (required for Windows to get MSBuild)

**Instructions:**
- Download and unzip the ZIP archive.
- Copy the Template folder and paste it wherever you want. Rename it to the name of your new project.
- Rename the csproj file from `<project_name>` to the intended name of your project.
- Do a Find+Replace for `<project_name>` in the files to change every occurence in the sample `Program.cs`, `tasks.json`, and `launch.json`.
- From the Command Pallete, run the "Restore Project" build task to initialize the project.
- From the VSCode Command list, restart OmniSharp so that Intellisense can take effect. You may also want to change the project's `settings.json` so you don't have to do this every time you open the project.
- From the Command Pallete, you can now build (and optionally run) your project.

**Why Does This Exist?**

The creation of this project was motivated by wanting to develop C# projects on Mac, and finding out that...

1. .NET Core is a opinionated and temperamental beast. I have high hopes for its future, but it's got a lot of weird bits right now. For instance, it builds dll's instead of exe's (???), the CoreCLR behaves very differently than Mono or .NET Framework in certain conditions, and it's not always compatible with projects created for .NET Framework.
2. Visual Studio for Mac runs projects in some black-box way that differs from just running Mono, leading to frustrating and inconsistent behavior. For instance, VS for Mac doesn't appear to use any of the default Mac search paths for .dylib files, making dynamic linking near impossible. In contrast, `mono` finds and links external libraries without a problem.

**Known Issues:**
- This hasn't been thoroughly tested, so there may be glaring bugs.
- No Linux support for Build+Run tasks. In theory this should be really easy to add (just copy-paste the `osx` part of the `tasks.json` file and change it to `linux`) but I don't have a Linux machine to test on.
