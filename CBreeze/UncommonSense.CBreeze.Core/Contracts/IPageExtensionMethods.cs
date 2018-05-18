using System.Linq;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Page.Control;

namespace UncommonSense.CBreeze.Core.Contracts
{
    public static class IPageExtensionMethods
    {
        public static PageActionContainer GetPageActionContainer(this IPage page, PageActionContainerType type)
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

        public static PageControlContainer GetPageControlContainer(this IPage page, PageControlContainerType type)
        {
            var result = page.Controls.OfType<PageControlContainer>().FirstOrDefault(c => c.Properties.ContainerType == type) ?? page.Controls.Insert(0, new PageControlContainer(indentationLevel: 0));
            result.Properties.ContainerType = type;
            return result;
        }
    }
}