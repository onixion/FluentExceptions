<img src="https://github.com/onixion/FluentExceptions/blob/main/Assets/Icon.png" width="200" height="200">

# FluentExceptions
[![NuGet version (FluentArguments)](https://img.shields.io/nuget/v/AlinSpace.FluentExceptions.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentExceptions/)

A simple fluent library for exception handling.

Sometimes exception handling (try-catch-finally) can take up a lot of lines of code.
In many situations this can make the code less readable and maintainable.
This fluent exception library tries to make this more simple using a fluent and functional design.

[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentExceptions/)

# Examples

```csharp
 
// Bad (needs 8 lines)
try
{
   DoSomethingThatMightThrow();
}
catch(Exception e)
{
   logger.Error(e);
}
 
// Good (needs 1 line)
Try.Catch(() => DoSomethingThatMightThrow(), e => logger.Error(e));
 
// Bad (needs 8 lines)
try
{
   DoSomethingThatMightThrow();
}
catch
{
   // ignore
}
 
// Good (needs 1 line)
Try.CatchIgnore(() => DoSomethingThatMightThrow());
```

The following code snippet would take up a lot more lines of code when writing it in a traditional way:

 ```csharp
public void Dispose()
{
    Try.CatchIgnore(() => DisposeResourceA();
    Try.CatchIgnore(() => DisposeResourceB();
    Try.CatchIgnore(() => DisposeResourceC();
    Try.CatchIgnore(() => DisposeResourceD();
}
```

Also works nicely with asynchronous code:

 ```csharp
await Try.CatchAsync(async () => await MaybeThrowsAsync(), e => logger.Error(e));
```
