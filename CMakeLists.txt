cmake_minimum_required(VERSION 3.10)

project(HelloWorld)

find_package(glfw3 CONFIG REQUIRED)

add_library(GlfwWrapper SHARED main.cpp)

set_target_properties(GlfwWrapper PROPERTIES
  ARCHIVE_OUTPUT_DIRECTORY "${PROJECT_BINARY_DIR}/Static")

target_link_libraries(GlfwWrapper PRIVATE glfw)

include_directories(GlfwWrapper PUBLIC
    "${PROJECT_SOURCE_DIR}/build"
)

set(CMAKE_BUILD_TYPE Debug)