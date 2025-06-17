#include "pch.h"
#include <windows.h>

extern "C"
{
    const SHORT WIDTH = 80;
    const SHORT HEIGHT = 25;

    CHAR_INFO* buffer = nullptr;
    HANDLE hConsole = nullptr;

    COORD bufferSize = { WIDTH, HEIGHT };
    COORD bufferCoord = { 0, 0 };
    SMALL_RECT writeRegion = { 0, 0, WIDTH - 1, HEIGHT - 1 };

    __declspec(dllexport) void Initialize()
    {
        // Установка кодовой страницы UTF-8
        SetConsoleOutputCP(CP_UTF8);
        SetConsoleCP(CP_UTF8);

        // Создание альтернативного буфера консоли
        hConsole = CreateConsoleScreenBuffer(
            GENERIC_READ | GENERIC_WRITE,
            0,
            nullptr,
            CONSOLE_TEXTMODE_BUFFER,
            nullptr);

        if (hConsole == INVALID_HANDLE_VALUE)
        {
            hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
        }
        else
        {
            SetConsoleActiveScreenBuffer(hConsole);
        }

        // Установка шрифта Consolas с размером 16
        CONSOLE_FONT_INFOEX cfi = { sizeof(CONSOLE_FONT_INFOEX) };
        if (GetCurrentConsoleFontEx(hConsole, FALSE, &cfi))
        {
            wcscpy_s(cfi.FaceName, L"Consolas");
            cfi.dwFontSize.Y = 16;
            SetCurrentConsoleFontEx(hConsole, FALSE, &cfi);
        }

        // Установка размера буфера
        SetConsoleScreenBufferSize(hConsole, bufferSize);

        // Установка размера окна консоли (соответствует буферу)
        SetConsoleWindowInfo(hConsole, TRUE, &writeRegion);

        // Инициализация буфера CHAR_INFO
        if (buffer == nullptr)
        {
            buffer = new CHAR_INFO[WIDTH * HEIGHT];
            for (int i = 0; i < WIDTH * HEIGHT; i++)
            {
                buffer[i].Char.UnicodeChar = L' '; // пробел
                buffer[i].Attributes = FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE; // белый цвет
            }
        }
    }

    __declspec(dllexport) void Cleanup()
    {
        if (buffer != nullptr)
        {
            delete[] buffer;
            buffer = nullptr;
        }

        if (hConsole != nullptr && hConsole != GetStdHandle(STD_OUTPUT_HANDLE))
        {
            // Закрываем альтернативный буфер (если мы его создавали)
            CloseHandle(hConsole);
            hConsole = nullptr;
        }
    }

    __declspec(dllexport) void ClearScreen()
    {
        if (buffer == nullptr) return;

        for (int i = 0; i < WIDTH * HEIGHT; i++)
        {
            buffer[i].Char.UnicodeChar = L' ';
            buffer[i].Attributes = 7;
        }
    }

    __declspec(dllexport) void WriteString(short x, short y, const wchar_t* text, unsigned short attributes)
    {
        if (buffer == nullptr) return;
        if (x < 0 || y < 0 || x >= WIDTH || y >= HEIGHT) return;

        int len = lstrlenW(text);
        for (int i = 0; i < len; i++)
        {
            short px = x + i;
            if (px >= 0 && px < WIDTH)
            {
                buffer[y * WIDTH + px].Char.UnicodeChar = text[i];
                buffer[y * WIDTH + px].Attributes = attributes;
            }
        }
    }

    __declspec(dllexport) void Present()
    {
        if (buffer == nullptr || hConsole == INVALID_HANDLE_VALUE) return;

        WriteConsoleOutputW(
            hConsole,
            buffer,
            bufferSize,
            bufferCoord,
            &writeRegion
        );
    }

    __declspec(dllexport) int ReadKey()
    {
        HANDLE hInput = GetStdHandle(STD_INPUT_HANDLE);
        INPUT_RECORD inputRecord;
        DWORD eventsRead = 0;

        while (PeekConsoleInput(hInput, &inputRecord, 1, &eventsRead) && eventsRead > 0)
        {
            ReadConsoleInput(hInput, &inputRecord, 1, &eventsRead);

            if (inputRecord.EventType == KEY_EVENT)
            {
                KEY_EVENT_RECORD ker = inputRecord.Event.KeyEvent;
                if (ker.bKeyDown)
                {
                    return ker.uChar.UnicodeChar != 0 ? ker.uChar.UnicodeChar : ker.wVirtualKeyCode;
                }
            }
        }
        return 0;
    }

    __declspec(dllexport) void InitConsoleForRussian()
    {
        // Установка UTF-8 для консоли
        SetConsoleOutputCP(CP_UTF8);
        SetConsoleCP(CP_UTF8);
    }
}
