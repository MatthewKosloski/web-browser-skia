using System.Runtime.InteropServices;
using System.Text;

namespace Glfw
{

    public static class GlfwWrapper
    {

        public const string LIBRARY = "GlfwWrapper";

        [DllImport(LIBRARY, EntryPoint = "glfwInit", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Init();

        [DllImport(LIBRARY, EntryPoint = "glfwTerminate", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Terminate();

        [DllImport(LIBRARY, EntryPoint = "glfwGetProcAddress", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetProcAddress(byte[] procName);

        [DllImport(LIBRARY, EntryPoint = "glfwGetGLXContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern GLXContext GetGLXContext(Window window);

        [DllImport(LIBRARY, EntryPoint = "glfwMakeContextCurrent", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MakeContextCurrent(Window window);

        [DllImport(LIBRARY, EntryPoint = "glfwSwapBuffers", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SwapBuffers(Window window);

        [DllImport(LIBRARY, EntryPoint = "glfwPollEvents", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PollEvents();

        [DllImport(LIBRARY, EntryPoint = "glfwWindowShouldClose", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool WindowShouldClose(Window window);

        [DllImport(LIBRARY, EntryPoint = "glfwSetKeyCallback", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.FunctionPtr, MarshalTypeRef = typeof(KeyCallback))]
        public static extern KeyCallback SetKeyCallback(Window window, KeyCallback keyCallback);

        [DllImport(LIBRARY, EntryPoint = "glfwCreateWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern Window CreateWindow(int width, int height, byte[] title, Monitor monitor, Window share);

        public static Window CreateWindow(int width, int height, string title, Monitor? monitor = null, Window? share = null)
        {
            return CreateWindow(
                width,
                height,
                Encoding.UTF8.GetBytes(title),
                monitor ?? Monitor.None,
                share ?? Window.None);
        }

        public static IntPtr GetProcAddress(string procName)
        {
            IntPtr addr = GetProcAddress(Encoding.ASCII.GetBytes(procName));
            return addr;
        }

        static GlfwWrapper()
        {
            Init();
        }
    }
}