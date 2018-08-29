<#
.Synopsis
   Adds communication fields to a C/Breeze table object
#>
function Add-CBreezeCommunication
{
    Param
    (
        [Parameter(Mandatory, ValueFromPipeline)]
        [UncommonSense.CBreeze.Core.Table]$Table,

        [Parameter()]
        [UncommonSense.CBreeze.Core.Page[]]$Pages,

        [Parameter(Mandatory)]
        [System.Collections.Generic.IEnumerable[int]]$Range,

        [string]$Prefix,

        [string]$GroupCaption = 'Communication',
        
        [Switch]$AlsoOnGeneralTab = $true,

        [Switch]$HasContact = $true,
        [Switch]$HasPhoneNo = $true,
        [Switch]$HasTelexNo = $false,
        [Switch]$HasFaxNo = $true,
        [Switch]$HasTelexAnswerBack = $false,
        [Switch]$HasEMail = $true,
        [Switch]$HasHomePage = $true,

        [Switch]$PassThru
    )

    Process
    {
        if ($GroupCaption -eq 'General')
        {
            $AlsoOnGeneralTab = $false
        }

        if (-not $HasPhoneNo)
        {
            $AlsoOnGeneralTab = $false
        }

        $Result = @{}
        $Result.Fields = @{}
        $Result.Controls = @{}
        $Result.Controls.Contact = @{}
        $Result.Controls.PhoneNo = @{}
        $Result.Controls.TelexNo = @{}
        $Result.Controls.FaxNo = @{}
        $Result.Controls.TelexAnswerBack = @{}
        $Result.Controls.Email = @{}
        $Result.Controls.HomePage = @{}

        if ($AlsoOnGeneralTab)
        {
            $Result.Controls.PhoneNo2 = @{}
        }

        if ($HasContact) 
        { 
            $Result.Fields.Contact = $Table | Add-CBreezeTableField -Range $Range -Type Text -DataLength 50 -Name ('{0}Contact' -f $Prefix) -AutoCaption -PassThru
        }

        if ($HasPhoneNo) 
        { 
            $Result.Fields.PhoneNo = $Table | Add-CBreezeTableField -Range $Range -Type Text -DataLength 30 -Name ('{0}Phone No.' -f $Prefix) -AutoCaption -ExtendedDataType PhoneNo -PassThru
        }

        if ($HasTelexNo) 
        { 
            $Result.Fields.TelexNo = $Table | Add-CBreezeTableField -Range $Range -Type Text -DataLength 30 -Name ('{0}Telex No.' -f $Prefix) -AutoCaption -PassThru
        }

        if ($HasFaxNo) 
        { 
            $Result.Fields.FaxNo = $Table | Add-CBreezeTableField -Range $Range -Type Text -DataLength 30 -Name ('{0}Fax No.' -f $Prefix) -AutoCaption -PassThru
        } 

        if ($HasTelexAnswerBack) 
        { 
            $Result.Fields.TelexAnswerBack = $Table | Add-CBreezeTableField -Range $Range -Type Text -DataLength 20 -Name ('{0}Telex Answer Back' -f $Prefix) -AutoCaption -PassThru
        } 

        if ($HasEMail) 
        { 
            $Result.Fields.Email = $Table | Add-CBreezeTableField -Range $Range -Type Text -DataLength 80 -Name ('{0}E-Mail' -f $Prefix) -AutoCaption -ExtendedDataType EMail -PassThru
        }

        if ($HasHomePage) 
        { 
            $Result.Fields.HomePage = $Table | Add-CBreezeTableField -Range $Range -Type Text -DataLength 80 -Name ('{0}Home Page' -f $Prefix) -AutoCaption -ExtendedDataType Url -PassThru
        }

        foreach ($Page in $Pages | Where-Object { $_.Properties.PageType -eq 'Card' })
        {
            if ($HasContact -or $AlsoOnGeneralTab)
            {
                $Group = $Page | Get-CBreezePageControlGroup -GroupCaption "General" -Range $Range -Position FirstWithinContainer

                if ($HasPhoneNo)
                {
                    $Result.Controls.PhoneNo2.Add($Page, ($Group | Add-CBreezePageControl -Type Field -Name PhoneNo2 -SourceExpr $Result.Fields.PhoneNo.QuotedName -PassThru -Range $Range))
                }

                if ($HasContact)
                {
                    $Result.Controls.Contact.Add($Page, ($FieldPageControl = $Group | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.Contact.QuotedName -PassThru -Range $Range))                    
                }
            }

            $Group = $Page | Get-CBreezePageControlGroup -GroupCaption $GroupCaption -Range $Range -Position LastWithinContainer

            if ($HasPhoneNo)
            {
                $Result.Controls.PhoneNo.Add($Page, ($Group | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.PhoneNo.QuotedName -PassThru -Range $Range))
            }

            if ($HasFaxNo)
            {
                $Result.Controls.FaxNo.Add($Page, ($Group | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.FaxNo.QuotedName -PassThru -Range $Range))
            }

            if ($HasEMail)
            {
                $Result.Controls.EMail.Add($Page, ($Group | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.EMail.QuotedName -PassThru -Range $Range ))
            }

            if ($HasHomePage)
            {
                $Result.Controls.HomePage.Add($Page, ($Group | Add-CBreezePageControl -Type Field -Source $Result.Fields.HomePage.QuotedName -PassThru -Range $Range ))
            }
        }

        foreach ($Page in $Pages | Where-Object { $_.Properties.PageType -eq 'List' })
        {
            $Group = $Page | Get-CBreezePageControlGroup -GroupType Repeater -Range $Range -Position FirstWithinContainer

            if ($HasPhoneNo)
            {
                $Result.Controls.PhoneNo.Add($Page, ($Group | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.PhoneNo.QuotedName -PassThru -Range $Range))
            }

            if ($HasFaxNo)
            {
                $Result.Controls.FaxNo.Add($Page, ($Group | Add-CBreezePageControl -Type Field -SourceExpr $Result.Fields.FaxNo.QuotedName -PassThru -Range $Range -Visible $false))
            }

            if ($HasContact)
            {
                $Result.Controls.Contact.Add($Page, ($Group | Add-CBreezePageControl -Type Field -Source $Result.Fields.Contact.QuotedName -PassThru -Range $Range))
            }
        }

        if ($PassThru) 
        {
            $Result
        }
    }
}