---
layout: default
title: Console Kihon
---
```
protected override void Write_FooBar_To_The_Console(IConsoleWrapper console)
{
    console.Write("FooBar");
}

protected override void WriteLine_FooBar_To_The_Console(IConsoleWrapper console)
{
    console.WriteLine("FooBar");
}

protected override void Write_Foo_In_Blue_To_The_Console(IConsoleWrapper console)
{
    console.ForegroundColor = ConsoleColor.Blue;
    console.Write("Foo");
}

protected override object Read_Line_From_Console_And_Return_Value(IConsoleWrapper console)
{
    return console.ReadLine();
}
```
