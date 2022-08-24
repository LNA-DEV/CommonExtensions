---
title: "Mapping"
date: 2022-08-23T22:46:02-06:00
draft: false

weight: 5
chapter: true
---

# Mapping
Here there are all methods which deal with mapping

<br>

## Methods

### 1. MapSimple
This method maps an object to another object. It uses the AutoMapper nuget.

```csharp
var result = model.MapSimple<MappedExampleModel, ExampleModel>();
```