#region Console Buffer Wrapper

using System.Runtime.InteropServices;

using System;

/// <summary>
/// Обертка для работы с консольным буфером через внешнюю C++ DLL
/// </summary>
public static class ConsoleBuffer
{
    private const string dllName = "ConsoleBufferDLL.dll";

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void Initialize();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void Cleanup();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void ClearScreen();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    private static extern void Present();

    // Заменили UnmanagedType.LPStr на LPWStr для поддержки Unicode (русского)
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    private static extern void WriteString(short x, short y, [MarshalAs(UnmanagedType.LPWStr)] string text, ushort attributes);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    private static extern int ReadKey();

    /// <summary>
    /// Инициализация буфера (вызывать в начале программы)
    /// </summary>
    public static void Init()
    {
        Initialize();
    }

    /// <summary>
    /// Освобождение ресурсов (вызывать в конце программы)
    /// </summary>
    public static void Dispose()
    {
        Cleanup();
    }

    /// <summary>
    /// Очистка буфера экрана (заполняет пробелами)
    /// </summary>
    public static void Clear()
    {
        ClearScreen();
    }

    /// <summary>
    /// Отобразить буфер на экране (отрисовать всё)
    /// </summary>
    public static void Render()
    {
        Present();
    }

    /// <summary>
    /// Записать текст в буфер по координатам с указанным цветом
    /// </summary>
    /// <param name="x">Позиция X (столбец)</param>
    /// <param name="y">Позиция Y (строка)</param>
    /// <param name="text">Текст для записи (русский поддерживается)</param>
    /// <param name="foreground">Цвет текста</param>
    /// <param name="background">Цвет фона</param>
    public static void Write(short x, short y, string text, ConsoleColor foreground = ConsoleColor.Gray, ConsoleColor background = ConsoleColor.Black)
    {
        ushort attr = (ushort)(((int)background << 4) | (int)foreground);
        WriteString(x, y, text, attr);
    }

    /// <summary>
    /// Неблокирующее чтение клавиши из консоли, возвращает ASCII код или 0 если клавиша не нажата
    /// </summary>
    /// <returns>Код клавиши или 0</returns>
    public static int ReadKeyNonBlocking()
    {
        return ReadKey();
    }
}

#endregion