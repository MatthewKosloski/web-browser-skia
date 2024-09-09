# web-browser-skia

This is a toy web browser built using C#/.Net that uses the [Skia](https://skia.org/) graphics library for painting and
[GLFW](https://www.glfw.org/) for creating a window, receiving events, and initializing an OpenGL context.

## Local development

To start developing, clone this repo and then follow these steps.

### 1. Set up vcpkg

The [vcpkg](https://learn.microsoft.com/en-us/vcpkg/) package manager is used to resolve the GLFW dependency. In order to get GLFW, this package manager must first be installed and configured.

1. Clone the repo. The repo contains the vcpkg executable and the curated libraries maintained by the vcpkg community.
```
git clone https://github.com/microsoft/vcpkg.git
```
2. With the repo cloned, navigate to the `vcpkg` directory and run the bootstrap script (platform dependent). This script performs some checks and downloads the vcpkg executable.
3. Permanently set the `VCPKG_ROOT` environment variable to be the path to the repo and add it to the `PATH`. For example:
```
VCPKG_ROOT=/home/mkosloski/Desktop/vcpkg
```

### 2. Configure and build the library using CMake

A library is used to generate a shared object file that contains all the functions of GLFW. The C#/.Net application calls into these C functions.

1. Configure the library.
```
cmake --preset=default
```
2. Build the library.
```
cmake --build build
```

After running the above commands, there should be a shared library at `build/libGlfwWrapper.so`. Next, this library must be made visible to the C#/.Net app. This is done by copying it into the `app/bin` directory:

```
mkdir -p app/bin/Debug/net8.0
cp build/libGlfwWrapper.so app/bin/Debug/net8.0/libGlfwWrapper.so
```
### 3. Build and run the app

Finally, the C#/.Net app can be built and run. From the `app` directory, run:

```
dotnet build app.csproj
dotnet run app.csproj
```