using System.Drawing;
using Glfw;
using SkiaSharp;

class Program
{

    private const int WINDOW_WIDTH = 800;
    private const int WINDOW_HEIGHT = 800;

    private static Window window;

    private static SKCanvas canvas;

    static int Main(string[] args)
    {
        // Create a window.
        window = GlfwWrapper.CreateWindow(WINDOW_WIDTH, WINDOW_HEIGHT, "Hello World");

        if (window == IntPtr.Zero)
        {
            // Failed to create a window.
            GlfwWrapper.Terminate();
            return -1;
        }

        // Set a key callback.
        GlfwWrapper.SetKeyCallback(window, KeyCallback);

        // Make the window's context current.
        GlfwWrapper.MakeContextCurrent(window);

        var skContext = GenerateSkiaContext();
        var skSurface = GenerateSkiaSurface(skContext, new Size(WINDOW_WIDTH, WINDOW_HEIGHT));

        canvas = skSurface.Canvas;

        while (!GlfwWrapper.WindowShouldClose(window))
        {
            Render();
            canvas.Flush();
            GlfwWrapper.SwapBuffers(window);
            GlfwWrapper.PollEvents();
        }

        GlfwWrapper.Terminate();

        return 0;
    }

    private static void Render()
    {
        canvas.Clear(SKColor.Parse("#ff9900"));
    }

    private static SKSurface GenerateSkiaSurface(GRContext skiaContext, Size surfaceSize)
    {
        var colorType = SKColorType.Rgba8888;
        var frameBufferInfo = new GRGlFramebufferInfo((uint)new UIntPtr(0), colorType.ToGlSizedFormat());
        var backendRenderTarget = new GRBackendRenderTarget(
            surfaceSize.Width,
            surfaceSize.Height,
            0, 
            0,
            frameBufferInfo);
        return SKSurface.Create(
            skiaContext,
            backendRenderTarget,
            GRSurfaceOrigin.BottomLeft,
            colorType);
    }

    private static GRContext GenerateSkiaContext()
    {
        var glInterface = GRGlInterface.Create();
        return GRContext.CreateGl(glInterface);
    }

    private static void KeyCallback(Window window, Keys key, int scancode, InputState state, ModifierKeys mods)
    {
        switch (key)
        {
            case Keys.Space:
                Console.WriteLine("Spacebar pressed.");
            break;
        }
    }
}