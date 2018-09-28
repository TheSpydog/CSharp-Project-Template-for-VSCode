# VSCode-CSharp-Template
This is a simple C# project template meant to accelerate .NET Framework and Mono workflows in Visual Studio Code.

Rather than using .NET Core, this project exclusively uses Mono and .NET Framework tooling (via `msbuild`). As a result, output binaries will be .exe files instead of the .dll files that .NET Core produces. This is more in line with the behavior of the Visual Studio 2017 / Visual Studio for Mac.

The creation of this project was motivated by wanting to develop C# projects on Mac, and finding out that...
1. .NET Core is a opinionated and temperamental beast that doesn't always play nice with .NET Framework projects. (Hopefully this will improve in the future!)
2. Visual Studio for Mac runs projects in some black-box way that differs from just running Mono, leading to frustrating and inconsistent behavior.

**Features:**
- Uses the new .csproj format, so you can easily edit the project by hand.
  - Because of this, the template folder is copy-pastable. No need to worry about unique project GUIDs!
- Convenient build tasks:
  - `Restore Project`: Initializes the project and updates project data. Run this every time you set up a new project, and again if you add references to other projects.
  - `Build (Debug/Release)`: Builds the project with the selected configuration.
  - `Build and Run (Debug/Release)`: Builds the project with the selected configuration and subsequently runs it with `mono` on Mac or `cmd /k` on Windows.
  - `Clean Project`: Cleans the output (`/bin`) directory.
- Debugging support:
  - Integrates with the Mono Debug extension (or, optionally, `clr` debugging for 64-bit programs on Windows) for debugging in-editor.

**Prerequisites:**
- [Visual Studio Code](https://code.visualstudio.com)
  - [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
  - [Mono Debug extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.mono-debug) (required for Mac, optional for Windows)
- [Mono](https://www.mono-project.com/download/stable/) (required for Mac, optional for Windows)
- [Visual Studio 2017](https://visualstudio.microsoft.com/vs/) or [Build Tools for Visual Studio 2017](https://visualstudio.microsoft.com/downloads/#build-tools-for-visual-studio-2017) (required for Windows to get MSBuild)

**Instructions:**
- Download and unzip the zip archive.
- Copy, paste, and rename the folder to the name of your new project.
- Rename the csproj file from `<project_name>` to the intended name of your project.
- Do a Find+Replace for `<project_name>` in the files to change every occurence in the sample `Program.cs`, `tasks.json`, and `launch.json`.
- From the Command Pallete, run the "Restore Project" build task to initialize the project.
- From the VSCode Command list, restart OmniSharp so that Intellisense can take effect. You may also want to change the project's `settings.json` so you don't have to do this every time you open the project.
- From the Command Pallete, you can now build (and optionally run) your project.

**Known Issues:**
- This hasn't been thoroughly tested, so there may be glaring bugs.
- No Linux support for Build+Run tasks. In theory this should be really easy to add (just copy-paste the `osx` part of the `tasks.json` file and change it to `linux`) but I don't have a Linux machine to test on so I'm not sure.
