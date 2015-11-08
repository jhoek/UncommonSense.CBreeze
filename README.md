# UncommonSense.CBreeze

## Introduction
- How would you go about changing all present instances of a certain table property in an object text file? Maybe using regular expressions.
- Now, how would you go about changing a certain property in all tables in an object text file, but currently the property doesn't have a value? More difficult, but still probably regular expressions.
- What if that property needs to be set to the value of another property, e.g. the ENU CaptionML must be set equal to the Name?
- How would you do similar operations in an XML file? Probably using the XMLDOM. That's why we need a DOM for the NAV object text format.

## Why use C/Breeze?
- Script your development work as much as possible
- Avoid the friction caused by an outdated development environment
- Focus on the semantics; leave the syntax to C/Breeze
- Don't just apply design patterns - automate them!

## Design Goals
- Intuitive object model for anybody familiar with C/SIDE;
- ...

## Design Decisions
### Keep UncommonSense.CBreeze.Core lean and mean
Any cleverness like auto-captioning, auto-objectproperties or even auto-assigning (U)IDs (see also below) would unnecessarily complexify UncommonSense.CBreeze.Core, and could always be implemented later as extension methods.
### Auto-assigned (U)IDs
(U)IDs are mandatory for items, and should be tested when adding an item to a collection. Auto-assigning (U)IDs complexifies the container code too much. We could aways introduce a (set of) extension method(s) later that will add container items with auto-assigned (U)IDs.
### Type property for derived types
If type AB and AC derive from type A, type A should have an abstract read-only property of an enum type that has B and C as its values. AB and AC should implement the abstract property and return the correct enum value.

## Roadmap
- PowerShell wrapper around the patterns in Meta/Patterns
- Pester tests for PowerShell functions
- Repair FIXME's
- Support for NAV 2013R2, 2015 and 2016:
  - AccessByPermission, EvalForAccessByPermission
  - DefaultLayOut, WordMergeDataItem [report]
  - Temporary [dataitem]
  - UpdatePropagation
  - Scope
  - Image
  - ShowMandatory
  - Upgrade [codeunit type]
  - Upgrade|TableSynchSetup|CheckProcondition [upgrade codeunit function type]

## Ideas for future patterns, improvements
- See https://gist.github.com/jhoek/059f1bafe28d1ee24cb8. 
- A pattern for adding dimension support
