[![Nuget](https://img.shields.io/nuget/dt/buildergenerator)](https://www.nuget.org/packages/BuilderGenerator/)
[![GitHub](https://img.shields.io/github/license/melgrubb/buildergenerator)](https://opensource.org/licenses/MIT)
[![GitHub Workflow Status](https://img.shields.io/github/workflow/status/MelGrubb/BuilderGenerator/CI%20Workflow)](https://github.com/MelGrubb/BuilderGenerator/actions/workflows/CI%20Workflow.yml)
[![GitHub issues](https://img.shields.io/github/issues/melgrubb/buildergenerator)](https://github.com/MelGrubb/BuilderGenerator/issues)

[![Gitter](https://img.shields.io/gitter/room/melgrubb/buildergenerator?logo=gitter)](https://gitter.im/BuilderGenerator/community)


# Builder Generator #

This is a .Net Source Generator designed to add "Builders" to your projects. [Builders](https://en.wikipedia.org/wiki/Builder_pattern) are an object creation pattern, similar to the [Object Mother](https://martinfowler.com/bliki/ObjectMother.html) pattern. Object Mothers and Builders are most commonly used to create objects for testing, but they can be used anywhere you want "canned" objects.

For more complete documentation, please see the [documentation site](https://melgrubb.github.io/BuilderGenerator/) or the raw [documentation source](https://github.com/MelGrubb/BuilderGenerator/blob/main/docs/index.md).

## Known Issues ##

This project has moved to the .Net 6 version of source generators, which unfortuntely means that it's incompatible with Visual Studio 2019. It's also breaking the GitHub build pipeline at the moment. It all seems to work just fine in VS2022 though. If you're stuck on .Net 5 and VS2019, you can always use the v1.x series, although its usage is different.

## Installation ##

BuilderGenerator is installed as an analyzer via NuGet package (https://www.nuget.org/packages/BuilderGenerator/). You can find it through the "Manage NuGet Packages" dialog in Visual Studio, or from the command line.

```ps
Install-Package BuilderGenerator
```

## Usage ##

After installation, decorate your classes with the ```GenerateBuilder``` attribute to mark them for generation. Builder classes will be generated in a "Builders" namespace next to the source classes.

## Version History ##
- v2.0.3
  - Attempting to fix NuGet packaging problems

- v2.0.2
  - Setters for base class properties rendering properly

- v2.0.1
  - Improved error handling

- v2.0.0
  - Updated to .Net 6 and IIncrementalGenerator (See note above about incompatibility with VS2019)
  - Changed usage pattern from marking target classes with attributes to marking partial builder classes

- v1.2
  - Solution reorganization
  - Version number synchronization
  - Automated build pipeline

- v1.0
  - First major release

- v0.5
  - Public beta
  - Working NuGet package
  - Customizable templates

## Roadmap ##

- Read-only collection support in default templates
- Attribute-less generation of partial classes
- Completed documentation
- Unit tests for generation components

## Attributions ##

The BuilderGenerator logo includes [tools](https://thenounproject.com/term/tools/11192) by John Caserta from the Noun Project.
