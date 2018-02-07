using System;
using System.Linq;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseSection(Lines lines, ObjectType objectType)
        {
            var match = lines.FirstLineMustMatch(Patterns.SectionSignature);
            var sectionType = match.Groups[1].Value.ToSectionType();

            Listener.OnBeginSection(sectionType);

            lines.FirstLineMustMatch(Patterns.BeginSection);
            lines.LastLineMustMatch(Patterns.EndSection);
            lines.Unindent(2);

            switch (sectionType)
            {
                case SectionType.ObjectProperties:
                    ParseObjectPropertiesSection(lines);
                    break;

                case SectionType.Properties:
                    ParsePropertiesSection(lines);
                    break;

                case SectionType.Fields:
                    ParseFieldsSection(lines);
                    break;

                case SectionType.Keys:
                    ParseKeysSection(lines);
                    break;

                case SectionType.FieldGroups:
                    ParseFieldGroupsSection(lines);
                    break;

                case SectionType.Controls:
                    ParseControlsSection(lines);
                    break;

                case SectionType.Elements:
                    switch (objectType)
                    {
                        case ObjectType.Query:
                            ParseQueryElementsSection(lines);
                            break;
                        case ObjectType.XmlPort:
                            ParseXmlPortElementsSection(lines);
                            break;
                    }
                    break;

                case SectionType.Events:
                    break;

                case SectionType.Dataset:
                    ParseDatasetSection(lines);
                    break;

                case SectionType.Labels:
                    ParseLabelsSection(lines);
                    break;

                case SectionType.RdlData:
                    break;

                case SectionType.WordLayout:
                    ParseWordLayoutSection(lines);
                    break;

                case SectionType.Code:
                    ParseCodeSection(lines);
                    break;

                case SectionType.RequestPage:
                    ParseRequestPageSection(lines, objectType);
                    break;

                case SectionType.MenuNodes:
                    ParseMenuNodesSection(lines);
                    break;

                default:
                    Exceptions.ThrowException(Exceptions.UnknownSectionType, sectionType);
                    break;
            }

            Listener.OnEndSection();
        }
    }
}

