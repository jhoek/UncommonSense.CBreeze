## Design Decisions

### Boolean parameters cannot be implemented as PowerShell SwitchParameters
Because of the following:

```powershell
function Test-Switch
{
    [CmdletBinding()]
    Param
    (
        [Switch]$Yep
    )

    Process
    {
        "ToString returns $($Yep.ToString())"
        "ToBool returns $($Yep.ToBool())"
        "IsPresent returns $($Yep.IsPresent)"
    }
}

PS C:\Users\jhoek\Desktop> Test-Switch 
ToString returns False
ToBool returns False
IsPresent returns False

PS C:\Users\jhoek\Desktop> Test-Switch -Yep
ToString returns True
ToBool returns True
IsPresent returns True

PS C:\Users\jhoek\Desktop> Test-Switch -Yep:$false
ToString returns False
ToBool returns False
IsPresent returns False
```

In other words - there is no difference between the absence of the switch and an explicit `$false` value. Boolean properties in C/SIDE are tri-states, whereas Switch parameters in PowerShell are really booleans. That's why in the following example, not all possible values for PasteIsValid can be expressed:

```powershell
Add-CBreezeObject -Type Table -Range $Range -Name Demo -PasteIsValid
```
