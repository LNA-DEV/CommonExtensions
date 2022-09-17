---
title: "ExtensionMethods"
date: 2022-08-23T23:01:04-06:00
draft: false

weight: 5
chapter: false
---

## What are extension methods?

Extensions methods can be applied to a specific data type. They are methods which can be called on this specific type.  

For Example:  

```csharp
string blub = "Hello World";

if(blub.IsNotNullOrEmpty)
{
    Console.WriteLine("The method returned true");
}
```
