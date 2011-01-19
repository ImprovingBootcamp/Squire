using System;

namespace Squire.Framework.Abstractions
{
    public interface IConsoleWrapper
    {
        ConsoleColor ForegroundColor { get; set; }
        ConsoleColor BackgroundColor { get; set; }
        void Write(bool value);
        void Write(char value);
        void Write(char[] value);
        void Write(decimal value);
        void Write(double value);
        void Write(int value);
        void Write(long value);
        void Write(object value);
        void Write(float value);
        void Write(string value);
        void Write(string format, object value);
        void Write(string format, params object[] args);
        void Write(char[] buffer, int index, int count);
        void WriteLine(bool value);
        void WriteLine(char value);
        void WriteLine(char[] value);
        void WriteLine(decimal value);
        void WriteLine(double value);
        void WriteLine(int value);
        void WriteLine(long value);
        void WriteLine(object value);
        void WriteLine(float value);
        void WriteLine(string value);
        void WriteLine(string format, object value);
        void WriteLine(string format, params object[] args);
        void WriteLine(char[] buffer, int index, int count);
        int Read();
        string ReadLine();
        ConsoleKeyInfo ReadKey();
        ConsoleKeyInfo ReadKey(bool intercept);
        void ResetColor();
    }
}