# Build C++ Library Code

From the root directory, run:

```
cmake --preset=default \
    && cmake --build build \
    && cp build/libGlfwWrapper.so app/bin/Debug/net8.0/libGlfwWrapper.so

# Build and Run App

From the `app` directory, run:

```
dotnet build app.csproj && dotnet run app.csproj
```