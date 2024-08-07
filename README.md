# lifecycle-grapher
 A simple tool to generate lifecycle graphs from Tacton CPQ APIs

## Description
I wrote up this tool because I found myself doing a lot of documentation recently and I wanted to illustrate my documentation with the lifecycle graphs for various Tacton objects.
Lifecycle-grapher is a console application written in dotnet that currently takes two parameters - a base url for a Tacton CPQ installation and an object to interrogate over the v2.2 API for Objects. It does this by generating a /describe endpoint and generating a DOT file, that can be read by [Graphviz](https://graphviz.org/) to render an image.


## Next things on the TODO list (by all means, feel free to contribute)
[] Write full test cases
[] Expand the argument capabilities so that the tool can be run with several different ways of passing arguments
[] Introduce interactive mode
[] Ensure everything runs on Linux
[] Integrate with code library to generate images

