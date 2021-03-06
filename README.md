<img src="https://github.com/onixion/FluentExceptions/blob/main/Assets/Icon.jpg" width="200" height="200">

# FluentExceptions
[![NuGet version (FluentArguments)](https://img.shields.io/nuget/v/AlinSpace.FluentExceptions.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentExceptions/)

A simple fluent library for exception handling.

```csharp
Try.Catch(() => MightThrow(), e => { ... });
```
[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentExceptions/)

## Why?

Sometimes exception handling (try-catch-finally) can take up a lot of lines of code.
In many situations this can make the code less readable and maintainable.
This library tries to improve it by employing a more fluent and functional exception handling design.
Not always is the fluent and functional approach of handling exceptions the best, it always depends.

## Examples - All exception types

Here are some examples where the fluent approach is much better.

```csharp
// Bad (needs 8 lines)
try
{
   // Often there is only a single line in the try-block.
   DoSomethingThatMightThrow();
}
catch
{
   // ignore
}
 
// Bad (needs 8 lines)
try
{
   DoSomethingThatMightThrow();
}
catch(Exception e)
{
   // Often there is only a single line in the catch-block.
   logger.Error(e);
}

// Bad (needs 8 lines)
try
{
   DoSomethingThatMightFail();
}
finally
{
   DiposeResource();
}
 
// Good (only 1 line)
Try.Catch(DoSomethingThatMightThrow, e => logger.Error(e));

// Good (only 1 line)
Try.CatchIgnore(DoSomethingThatMightThrow);

// Good (only 1 line)
Try.Finally(DoSomethingThatMightFail, DisposeResource);
```

The following code snippet would take up a lot more lines of code when writing it in a traditional way:

 ```csharp
public void Dispose()
{
    Try.CatchIgnore(DisposeResourceA);
    Try.CatchIgnore(DisposeResourceB);
    Try.CatchIgnore(DisposeResourceC);
    Try.CatchIgnore(DisposeResourceD);
}
```

## Examples - Specific exception types

The above examples always acts upon all types of thrown exceptions.
You can also specify the exact type of exception that you are interested in.
All other exception types will simply propagate.

```csharp
// Will catch the exception.
Try.Catch<MyException>(() => throw new MyException(), e => logger.Log(e));

// Will not catch the exception.
Try.Catch<MyException>(() => throw new ArgumentNullException(), e => logger.Log(e));
```

## Examples - Asynchronous code

Everything also works fully with asynchronous code:

```csharp
await Try.CatchAsync(MaybeThrowsAsync, e => logger.Error(e));
```

## Examples - Return values

It is also possible to let the catch delegate return a value.
If an exception is thrown, it will be handled accordingly and a default value will be returned instead.

```csharp
// Returns the number on success or null on any exceptions.
var number = await Try.CatchReturnAsync<int?>(() => GetNumberOrThrow(), e => logger.Error(e));

// Returns the number on success or 5 on any exceptions.
var number = await Try.CatchReturnAsync(() => GetNumberOrThrow(), e => logger.Error(e), defaultValue: 5);
```
