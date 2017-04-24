using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Core
{
    public static class IPageExtensionMethods
    {
        public static PageActionContainer GetPageActionContainer(this IPage page, ActionContainerType type)
        {
            return
                page
                    .Actions
                    .OfType<PageActionContainer>()
                    .FirstOrDefault(c => c.Properties.ActionContainerType == type) ??
                    page
                        .Actions
                        .Insert(0, new PageActionContainer(0, containerType: type));
        }

        public static ContainerPageControl GetPageControlContainer(this IPage page, ContainerType type)
        {
            var result = page.Controls.OfType<ContainerPageControl>().FirstOrDefault(c => c.Properties.ContainerType == type) ?? page.Controls.Insert(0, new ContainerPageControl(indentationLevel: 0));
            result.Properties.ContainerType = type;
            return result;
        }
    }
}