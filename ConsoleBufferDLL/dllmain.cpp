#include "pch.h"
#include <windows.h>
#include <wchar.h>

// Размеры буфера (можно изменить при необходимости)
const SHORT WIDTH = 80;
const SHORT HEIGHT = 25;

// Буфер и дескриптор
CHAR_INFO buffer[WIDTH * HEIGHT];
HANDLE hConsole = nullptr;

// Размеры и координаты для вывода
COORD bufferSize = { WIDTH, HEIGHT };
COORD bufferCoord = { 0, 0 };
SMALL_RECT writeRegion = { 0, 0, WIDTH - 1, HEIGHT - 1 };

extern "C" {

    // Инициализация альтернативного буфера
    __declspec(dllexport) void Initialize()
    {
        SetConsoleOutputCP(CP_UTF8);
        SetConsoleCP(CP_UTF8);

        hConsole = CreateConsoleScreenBuffer(
            GENERIC_READ | GENERIC_WRITE,
            0,
            nullptr,
            CONSOLE_TEXTMODE_BUFFER,
            nullptr
        );

        if (hConsole != INVALID_HANDLE_VALUE) {
            SetConsoleActiveScreenBuffer(hConsole);

            // Установка шрифта
            CONSOLE_FONT_INFOEX cfi = { sizeof(CONSOLE_FONT_INFOEX) };
            if (GetCurrentConsoleFontEx(hConsole, FALSE, &cfi)) {
                wcscpy_s(cfi.FaceName, L"Consolas");
                cfi.dwFontSize.Y = 16;
                SetCurrentConsoleFontEx(hConsole, FALSE, &cfi);
            }

            SetConsoleScreenBufferSize(hConsole, bufferSize);
            SetConsoleWindowInfo(hConsole, TRUE, &writeRegion);

            // ✅ Ключевой блок для включения обработки ввода
            HANDLE hStdin = GetStdHandle(STD_INPUT_HANDLE);
            DWORD mode = 0;
            GetConsoleMode(hStdin, &mode);
            SetConsoleMode(hStdin, mode | ENABLE_EXTENDED_FLAGS | ENABLE_WINDOW_INPUT | ENABLE_MOUSE_INPUT | ENABLE_PROCESSED_INPUT);
        }
    }

    // Очистка буфера
    __declspec(dllexport) void ClearScreen()
    {
        for (int i = 0; i < WIDTH * HEIGHT; i++) {
            buffer[i].Char.UnicodeChar = L' ';
            buffer[i].Attributes = FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE;
        }
    }

    // Отображение буфера на экране
    __declspec(dllexport) void Present()
    {
        if (hConsole != nullptr) {
            WriteConsoleOutputW(hConsole, buffer, bufferSize, bufferCoord, &writeRegion);
        }
    }

    // Вывод строки в позицию x, y
    __declspec(dllexport) void WriteString(short x, short y, const wchar_t* text, unsigned short attributes)
    {
        if (x < 0 || x >= WIDTH || y < 0 || y >= HEIGHT || text == nullptr)
            return;

        int offset = y * WIDTH + x;
        size_t len = wcslen(text);

        for (size_t i = 0; i < len && offset + i < WIDTH * HEIGHT; ++i) {
            buffer[offset + i].Char.UnicodeChar = text[i];
            buffer[offset + i].Attributes = attributes;
        }
    }

    // Считывание кода нажатой клавиши
    __declspec(dllexport) int ReadKey()
    {
        INPUT_RECORD inputRecord;
        DWORD events;
        HANDLE hStdin = GetStdHandle(STD_INPUT_HANDLE);
        while (true) {
            ReadConsoleInput(hStdin, &inputRecord, 1, &events);
            if (inputRecord.EventType == KEY_EVENT && inputRecord.Event.KeyEvent.bKeyDown) {
                return inputRecord.Event.KeyEvent.wVirtualKeyCode;
            }
        }
    }

    // Очистка ресурсов
    __declspec(dllexport) void Cleanup()
    {
        if (hConsole != nullptr) {
            SetConsoleActiveScreenBuffer(GetStdHandle(STD_OUTPUT_HANDLE));
            CloseHandle(hConsole);
            hConsole = nullptr;
        }
    }
}
