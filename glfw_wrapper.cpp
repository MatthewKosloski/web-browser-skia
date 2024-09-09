extern "C" {
    #include <GLFW/glfw3.h>

    int getVersionNumber()
    {
        int major, minor, revision;
        glfwGetVersion(&major, &minor, &revision);
        return 1;
    }
}
