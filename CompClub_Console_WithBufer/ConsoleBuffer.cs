using System;
using System.Runtime.InteropServices;

namespace CompClub_Console
{
    /// <summary>
    /// Обёртка над ConsoleBufferDLL.dll — управление альтернативным буфером консоли.
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

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void WriteString(short x, short y, [MarshalAs(UnmanagedType.LPWStr)] string text, ushort attributes);

        [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int ReadKey();

        private static bool initialized = false;

        /// <summary>
        /// Инициализация альтернативного буфера консоли.
        /// </summary>
        public static void Init()
        {
            try
            {
                Initialize();
                initialized = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка инициализации ConsoleBuffer: " + ex.Message);
            }
        }

        /// <summary>
        /// Очистка ресурсов и возврат к стандартному буферу.
        /// </summary>
        public static void Dispose()
        {
            try
            {
                if (initialized)
                {
                    Cleanup();
                    initialized = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выходе из ConsoleBuffer: " + ex.Message);
            }
        }

        /// <summary>
        /// Очистка содержимого буфера.
        /// </summary>
        public static void Clear()
        {
            try
            {
                if (initialized)
                    ClearScreen();
            }
            catch { }
        }

        /// <summary>
        /// Отображает текущий буфер на экране.
        /// </summary>
        public static void PresentBuffer()
        {
            try
            {
                if (initialized)
                    Present();
            }
            catch { }
        }

        /// <summary>
        /// Записывает строку текста в заданные координаты.
        /// </summary>
        public static void WriteAt(int x, int y, string text, ushort attributes = 7)
        {
            try
            {
                if (initialized && !string.IsNullOrEmpty(text))
                    WriteString((short)x, (short)y, text, attributes);
            }
            catch { }
        }

        /// <summary>
        /// Ожидает и возвращает код нажатой клавиши.
        /// </summary>
        public static int ReadKeyCode()
        {
            try
            {
                if (initialized)
                    return ReadKey();
            }
            catch { }

            return -1;
        }
    }
}