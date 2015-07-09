# UncommonSense.CBreeze

## Why use C/Breeze?
- Script your development work as much as possible
- Avoid the friction caused by an outdated development environment

## Design decisions
### Auto-assigned (U)IDs
(U)IDs are mandatory for items, and should be tested when adding an item to a collection. Auto-assigning (U)IDs complexifies the container code too much. We could aways introduce a (set of) extension method(s) later that will add container items with auto-assigned (U)IDs.

## TODO
- Parse NAVW12015
- fdb creates separate files per class
- intermediate tables for classes etc. in fdb
- add a notice: generated code
- way to copy object models
- NAV 2015 in fdb as separate object model
