# Basic Information

This package provides some extremely useful C# extensions on top of the base type string.
These extensions can easily be used off of any string in C#.
The bulk of these extensions are simply syntactic sugar to allow for easier reading of code

# Usage

Below is an example of the usage of one of the methods

```
using Newteq.Extensions.String;
using System;

namespace Newteq.Extensions.Usage.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var helloWorld = "hello world with all the first letter's capitalized";
            Console.WriteLine(helloWorld.IsNullOrEmpty());
        }
    }
}

```

# Available Methods

All the methods are striaght forward, but if you need more information, simply see the summary from the method. These have all been documented.

  - BytesFromBase64
  - ConvertToBaseEnum
  - ConvertToTypedEnum
  - GetBytes
  - IsCompletelyEmpty
  - IsNullOrEmpty
  - IsNullOrWhiteSpace
  - Reverse
  - StringFromBase64
  - ToBase64
  - ToCamelCase
  - ToTitle
  - NaturalJoin
