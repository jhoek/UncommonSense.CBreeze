using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Common
{
    public enum DataClassification
    {
        CustomerContent,
        ToBeClassified,
        EndUserIdentifiableInformation,
        AccountData,
        EndUserPseudonymousIdentifiers,
        OrganizationIdentifiableInformation,
        SystemMetadata
    }
}