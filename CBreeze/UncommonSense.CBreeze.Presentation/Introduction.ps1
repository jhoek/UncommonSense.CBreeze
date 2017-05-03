$ErrorActionPreference = 'Stop'
$PSDefaultParameterValues.Clear()
. (Join-Path $PSScriptRoot 'Demo DSL.ps1')

Slide {
    Paragraph {
        Title "Welcome to this demo of C/Breeze Automation."
        Text "C/Breeze is a .NET API for the Microsoft Dynamics NAV object text format,"
        Text "just like e.g. MSXML is an API for the XML file format." 
    }
    Paragraph {
        Text "If you think of the text objects of your Microsoft Dynamics NAV application"
        Text "as the source code of your NAV application, C/Breeze will allow you to query"
        Text "and change any aspect of that source code programmatically - from any .NET"
        Text "language, just like MSXML could be used to query or change any part of an"
        Text "XML document." 
    }
}

Slide {
    Paragraph {
        Title "Introducing C/Breeze Automation" 
        Text "To make using it even easier and more interactive, C/Breeze comes with a" 
        Text "PowerShell interface for most common development tasks (such as adding objects,"
        Text "fields or controls) called C/Breeze Automation - the subject of this demo."
    }
    Paragraph {
        Text "It's like a macro language for doing stuff you would normally do by hand in"
        Text "the Microsoft Dynamics NAV Development Environment. Automating your "
        Text "development work saves time, reduces the chances of errors and eliminates"
        Text "repetitive tasks."
    }
}

Slide {
    Paragraph {
        Title "Creating a new application" 
        Text "Let's get started. In the first example, we will create a NAV application from "
        Text "scratch, but you could just as easily import an existing set of objects. First,"
        Text "we will create an application object:"
    }
    Script { $global:Application = New-CBreezeApplication }
    Paragraph {
        Text "And here's what's inside our newly created application:" 
    }
    Script { $global:Application } 
    Paragraph {
        Text "Not much (yet), eh? ;)" 
    }
}

Slide {
    Paragraph {
        Title "Adding a table to the application"
        Text "Let's add a new table. The PowerShell interface for C/Breeze allows you specify"
        Text "virtually all table properties in a single command. We will divide the call over"
        Text "multiple lines for readability reasons only:" 
    }
    Script { $global:Table = `
        Add-CBreezeObject `
            -Application $global:Application `
            -Type Table `
            -ID 50000 `
            -Name 'My Table' `
            -DateTime (Get-Date) `
            -VersionList Demo1.00 `
            -AutoCaption 
    }
    Paragraph {
        Text "The AutoCaption switch above will take the object's name and use it as the "
        Text 'ENU caption. $Application now contains our new table, as you can see:'
    }
    Script { $global:Application }
}
 
Slide {
    Paragraph {
        Title "Exporting the application to the console"
        Text "However, we would, of course, like to see what all this looks like in the "
        Text "NAV object text format. For now, we will send the output to the console"
        Text "window, but using the same cmdlet, you could also send it to a text file or"
        Text "even directly to a NAV database:" 
    }
    Script { $global:ConsoleOut = ([System.Console]::Out) }
    Script { Export-CBreezeApplication -Application $global:Application -TextWriter $global:ConsoleOut }
}

Slide {
    Paragraph {
        Title "Adding fields to the table"
        Text "Now, let's add our first few fields: a code table field of length 10 called"
        Text "Code, and a text table field of length 50 called Description." 
    }
    Script { $global:CodeTableField = `
        Add-CBreezeTableField `
            -Table $global:Table `
            -Type Code `
            -ID 1 `
            -Name Code `
            -DataLength 10 `
            -NotBlank $true `
            -AutoCaption `
            -PassThru
    }
    Script { $global:DescriptionTableField = `
        Add-CBreezeTableField `
            -Table $global:Table `
            -Type Text `
            -DataLength 50 `
            -ID 10 `
            -Name Description `
            -AutoCaption `
            -PassThru 
    }
}

Slide {
    Paragraph {
        Title "Referencing the new fields from a property"
        Text "With the fields in place, we can also set the DataCaptionFields property for "
        Text "the table. Notice how we use the variables that were assigned to when adding "
        Text "the fields." 
    }
    Script { $global:Table.Properties.DataCaptionFields.AddRange($global:CodeTableField.Name, $global:DescriptionTableField.Name) }
}

Slide {
    Paragraph {
        Title "Exporting the application to the console (again)"
        Text "Let's take another peek at our application:" 
    }
    Script { Export-CBreezeApplication -Application $global:Application -TextWriter ([System.Console]::Out) }
}

Slide {
    Paragraph{
        Title "Using AutoCaption automatically in all cmdlets"
        Text "You may have noticed how certain parameters and switches (e.g. AutoCaption) "
        Text "appear in several places. Whether you are adding objects or table fields, "
        Text "you will probably always want to use the auto-caption feature."
    }
    Paragraph {
        Text "Starting with version 3.0, PowerShell provides a clever way to specify a"
        Text "default property value that lasts for the duration of your PowerShell session."
        Text "The line below will set AutoCaption to $true for all commands whose names"
        Text "contain 'CBreeze'. You could add this line to your PowerShell profile to use it"
        Text "whenever you start PowerShell."
    }
    Script { $PSDefaultParameterValues['*CBreeze*:AutoCaption'] = $true }
}

Slide {
    Paragraph {
        Title 'More $PSDefaultParameterValues'
        Text "We'll do the same for our date, time and version list object properties:"
    }
    Script { $global:DateTime = Get-Date -Year 2015 -Month 8 -Day 10 -Hour 13 -Minute 0 -Second 0 }
    Script { $PSDefaultParameterValues['Add-CBreezeObject:DateTime'] = $global:DateTime }
    Script { $PSDefaultParameterValues['Add-CBreezeObject:VersionList'] = 'Demo1.00' }
}

Slide {
    Paragraph {
        Title "Adding a page to the application"
        Text "When we add a page for our new table, we no longer need to specify -DateTime, "
        Text "-VersionList or -AutoCaption:"
    }
    Script { $global:Page = `
        Add-CBreezeObject `
            -Application $global:Application `
            -Type Page `
            -ID 50000 `
            -Name 'My Page' `
            -SourceTable $global:Table.ID `
            -PageType List }
}

Slide {
    Paragraph {
        Title "Making it easier to export to the console"
        Text "The trick with the default parameter values can also be used to make it easier "
        Text "to send our application's object text to the console window:" 
    }
    Script { $PSDefaultParameterValues['Export-CBreezeApplication:TextWriter'] = [System.Console]::Out }
    Script { Export-CBreezeApplication -Application $global:Application }
    Paragraph {
        Text "Notice how we can override this behaviour whenever we need to by"
        Text "using providing a parameter that belongs to one of "
        Text "Export-CBreezeApplication's other parameter sets, such as Path or the database"
        Text "parameters."
    }
}

Slide { 
    Paragraph {
        Title "Get ready for the next step: building patterns"
        Text "The things we have scripted so far may have saved you some time, compared to"
        Text "doing them by hand in the Microsoft Dynamics NAV Development Environment, but"
        Text "the actual time saving starts when you take these building blocks, and combine"
        Text "them into larger building blocks (which, potentially, could become part of"
        Text "even larger blocks, and so on)."
    }
}

Slide {
    Paragraph {
        Text "Until now, the cmdlets we used created a *single* object or subobject (field, "
        Text "control, etc.). When we start combining our building blocks into larger"
        Text "building blocks, the result may consist of *multiple* objects, fields, "
        Text "controls etc. That's why, instead of a single ID, we pass a range of IDs"
        Text "to our cmdlets. The cmdlets are designed to intelligently select the next"
        Text "available ID:"
    }
    Paragraph {
        Text "For most subobjects, the ID of the containing object is taken into account:"
        Text "e.g. fields get an ID from the range you specify, unless the containing table's"
        Text "ID is also within that range; in that case, the field ID is taken from the"
        Text "range 1..[int]::MaxValue." 
    }
    Script { $global:Range = ([System.Linq.Enumerable]::Range(50000, 100)) }
}

Slide {
    Paragraph {
        Text "C/CBreeze ships with a number of cmdlets that carry out common development"
        Text "tasks. These cmdlets were written in PowerShell, which means you can easily"
        Text "view and modify the code should you wish to do so. As an example, let's add"
        Text "a block of address-related fields to our new table and page." 
    }
    Script { Add-CBreezeAddress -Table $global:Table -Pages $global:Page -Range $global:Range }
}

Slide {
    Paragraph {
        Text "The application now looks like this:" 
    }
    Script { Export-CBreezeApplication -Application $global:Application }
}