# UncommonSense.CBreeze

## Why use C/Breeze?
- Script your development work as much as possible
- Avoid the friction caused by an outdated development environment

## Design decisions
### Keep UncommonSense.CBreeze.Core lean and mean
Any cleverness like auto-captioning, auto-objectproperties or even auto-assigning (U)IDs (see also below) would unnecessarily complexify UncommonSense.CBreeze.Core, and could always be implemented later as extension methods.
### Auto-assigned (U)IDs
(U)IDs are mandatory for items, and should be tested when adding an item to a collection. Auto-assigning (U)IDs complexifies the container code too much. We could aways introduce a (set of) extension method(s) later that will add container items with auto-assigned (U)IDs.

## Next
- Replace fdb with c# builder code
- PowerShell functions for Core
- PowerShell functions for Meta

## Someday
- Parse NAVW12015
- fdb creates separate files per class
- intermediate tables for classes etc. in fdb
- add a notice: generated code
- way to copy object models
- NAV 2015 in fdb as separate object model
