# UncommonSense.CBreeze

## Introduction
How would you go about changing all present instances of a certain table property in an object text file? Maybe using regular expressions?

Now, how would you go about changing a certain property in all tables in an object text file, but currently the property doesn't have a value? More difficult, but still probably regular expressions!

What if that property needs to be set to the value of another property, e.g. the ENU CaptionML must be set equal to the Name?

How would you do similar operations in an XML file? Probably using something like the XMLDOM, right?

*That's why we need a DOM for the NAV object text format.*

Think of C/Breeze as an API for interacting with NAV object text files. Each and every aspect of your application's objects, represented by an in-memory tree structure much like e.g. the XMLDOM or HTMLDOM, can be queried and manipulated through C/Breeze Core's members. Any change you can make to your application from NAV's Development Environment can also be made from C/Breeze, but without the manual actions, and therefore completely repeatable.

## Why use C/Breeze?
- Script your development work as much as possible
- Avoid the friction caused by an outdated development environment
- Focus on the semantics; leave the syntax to C/Breeze
- Don't just apply design patterns - automate them!

## FAQ
<dl>
<dt>Isn't this the same as https://github.com/Microsoft/AL?</dt>
<dd>No, not quite, as far as I understand. Microsoft's new AL format is a less fragile, more intuitive to describe C/SIDE objects, but does not include a way to programmatically interact with the code, thus limiting e.g. macro building to simple, static snippets.
And of course, AL could be just another future import/export format for C/Breeze applications! :)</dd>

<dt>What is the current status of the project?</dt>
<dd>I want to use AppVeyor or a similar service to automatically test the C# and PowerShell interface on each check-in. The tests should import the NAV base app using the C# and PowerShell interfaces, export it again and compare the exported objects against their original counterparts. A 100% match means that all C/SIDE features used by the NAV base app are implemented correctly in C/CBreeze.
In order to use AppVeyor, C/Breeze needed to be a public repo first. Manual tests of the NAV W1 tables went OK. I'm currently working the pages.</dd>
</dl>

## Design Goals
- Intuitive object model for anybody familiar with C/SIDE;
- Separate assemblies for each supported NAV version, at least for UncommonSense.CBreeze.Core and UncommonSense.CBreeze.Automation;
- Keep namespaces the same for all supported NAV versions, so that PowerShell scripts can run against any version (Good idea?!).

## Design Decisions
### Supporting multiple NAV versions from the same codebase
- Conditional compilation symbols for each NAV version;
- If `NAV2016` is set, also set `NAV2015`; if `NAV2015` is set, also set `NAV2013R2` etc.;
- NAV 2013 is our starting point; no conditional compilation symbol is required for NAV 2013;
- Features introduced in e.g. NAV 2015 can test for `#if NAV2015`;
- Features declared obsolete in e.g. NAV 2015 can test for `#if !NAV2015`
- Features introduced in e.g. NAV 2013R2 and declared obsolete in NAV 2015 should test for `#if NAV2013R2 && !NAV2015`: in NAV 2013, `NAV2013R2` is still false, in NAV 2013R2, `NAV2013R2` is true *and* `NAV2015` is not true yet (meaning `!NAV2015` evaluates to true), and in NAV 2015, `NAV2015` is true (meaning `!NAV2015` evaluates to false).
Sample codebase, build script and test script here: https://gist.github.com/jhoek/18bca9bddc5d05c904c6.

Between NAV 2013 and NAV 2013 R2, the KeyGroups property was removed from table keys. In other words, the NAV 2013 R2 developer UI no longer offers an option to set the KeyGroups for a table key. Importing a text file, created in an older version of NAV, that still contains key groups will not change this, but behind the scenes, the key groups are imported and stored as before. Exporting the containing table from NAV 2013 R2 results in a text file that is byte-by-byte identical with the original file.

In other words: the ability to declare properties obsolete may not be as important as it first seems. The C/Breeze Core library should still expose the obsolete property, the parser should still report it, the application builder should still set it, and the writer should still write it. It seems that conditional compilation will be primarily important for *introducing*, not for removing features.

### Keep UncommonSense.CBreeze.Core lean and mean
Any cleverness like auto-captioning, auto-objectproperties or even auto-assigning (U)IDs (see also below) would unnecessarily complexify UncommonSense.CBreeze.Core, and could always be implemented later as extension methods.
### Auto-assigned (U)IDs
(U)IDs are mandatory for items, and should be tested when adding an item to a collection. Auto-assigning (U)IDs complexifies the container code too much. We could aways introduce a (set of) extension method(s) later that will add container items with auto-assigned (U)IDs.
### Type property for derived types
If type AB and AC derive from type A, type A should have an abstract read-only property of an enum type that has B and C as its values. AB and AC should implement the abstract property and return the correct enum value.
### Why not use hashtable parameters for e.g. multilanguage properties?
Giving cmdlet `Add-CBreeze{SubObject}` properties of type HashTable for e.g. multilanguage properties would make perfect sense (so: `Add-CBreeze{SubObject} -CaptionML @{'ENU'='Foo';'NLD'='Baz'}`). However, adding multilanguage values to existing *{subobjects}* would still require a call to `Set-CBreezeMLValue`. For consistency's sake, I have decided to require the use of `Set-BreezeMLValue` in both scenarios.

## To dos and Roadmap
- Pester tests for PowerShell functions
- Automation: make dynamic parameters protected fields instead of properties; combine declaration with initialization
- Eliminate types derived from e.g. NullableValueProperty; use NullableValueProperty<T> directly
- See https://gist.github.com/jhoek/059f1bafe28d1ee24cb8. 
- A pattern for adding dimension support
- Leave reading and writing to model.dll
- DSL for defining application objects

## Known issues
### Objects with a time and no date
Objects with a time and no date will have 01-01-01 as their date after an import/export cycle. In order to add the object time to the non-existent object date (which are stored together in a single property of type DateTime), the date is initialised to DateTime.MinValue.Date. Separating the Date and Time object properties would probably resolve this.
