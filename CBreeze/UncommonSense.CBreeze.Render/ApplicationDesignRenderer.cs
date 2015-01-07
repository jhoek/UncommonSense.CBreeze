using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using System.Globalization;
using UncommonSense.CBreeze.Model;

namespace UncommonSense.CBreeze.Render
{
    public static class ApplicationDesignRenderer
    {
        public static Application RenderTo(this ApplicationDesign applicationDesign, Application application, RenderingContext renderingContext)
        {
            Allocate(applicationDesign, application, renderingContext);
            Finalize(renderingContext);
            return application;
        }

        private static void Finalize(RenderingContext renderingContext)
        {
            foreach (var keyValuePair in renderingContext.Manifests)
            {
                TypeSwitch.Do(
                    keyValuePair.Key,
                    TypeSwitch.Case<SetupEntityType>(e => e.Finalize(renderingContext, keyValuePair.Value as SetupEntityTypeManifest)),
                    TypeSwitch.Case<SupplementalEntityType>(e => e.Finalize(renderingContext, keyValuePair.Value as SupplementalEntityTypeManifest)),
                    TypeSwitch.Case<MasterEntityType>(e => e.Finalize(renderingContext, keyValuePair.Value as MasterEntityTypeManifest)),
                    TypeSwitch.Case<SubsidiaryEntityType>(e => e.Finalize(renderingContext, keyValuePair.Value as SubsidiaryEntityTypeManifest)),
                    TypeSwitch.Case<DocumentEntityType>(e => e.Finalize(renderingContext, keyValuePair.Value as DocumentEntityTypeManifest)),
                    TypeSwitch.Case<DocumentHistoryEntityType>(e => e.Finalize(renderingContext, keyValuePair.Value as DocumentHistoryEntityTypeManifest)),
                    TypeSwitch.Case<JournalEntityType>(e => e.Finalize(renderingContext, keyValuePair.Value as JournalEntityTypeManifest)),
                    TypeSwitch.Case<LedgerEntityType>(e => e.Finalize(renderingContext, keyValuePair.Value as LedgerEntityTypeManifest)),
                    TypeSwitch.Case<RegisterEntityType>(e => e.Finalize(renderingContext, keyValuePair.Value as RegisterEntityTypeManifest))
                    );
            }
        }

        private static void Allocate(ApplicationDesign applicationDesign, Application application, RenderingContext renderingContext)
        {
            foreach (var setupEntityType in applicationDesign.OfType<SetupEntityType>())
            {
                renderingContext.AddManifest(setupEntityType, setupEntityType.Allocate(renderingContext, application));
            }

            foreach (var supplementalEntityType in applicationDesign.OfType<SupplementalEntityType>())
            {
                renderingContext.AddManifest(supplementalEntityType, supplementalEntityType.Allocate(renderingContext, application));
            }

            foreach (var masterEntityType in applicationDesign.OfType<MasterEntityType>())
            {
                renderingContext.AddManifest(masterEntityType, masterEntityType.Allocate(renderingContext, application));
            }

            foreach (var subsidiaryEntityType in applicationDesign.OfType<SubsidiaryEntityType>())
            {
                renderingContext.AddManifest(subsidiaryEntityType, subsidiaryEntityType.Allocate(renderingContext, application));
            }

            foreach (var documentEntityType in applicationDesign.OfType<DocumentEntityType>())
            {
                renderingContext.AddManifest(documentEntityType, documentEntityType.Allocate(renderingContext, application));
            }

            foreach (var documentHistoryEntityType in applicationDesign.OfType<DocumentHistoryEntityType>())
            {
                renderingContext.AddManifest(documentHistoryEntityType, documentHistoryEntityType.Allocate(renderingContext, application));
            }

            foreach (var journalEntityType in applicationDesign.OfType<JournalEntityType>())
            {
                renderingContext.AddManifest(journalEntityType, journalEntityType.Allocate(renderingContext, application));
            }

            foreach (var ledgerEntityType in applicationDesign.OfType<LedgerEntityType>())
            {
                renderingContext.AddManifest(ledgerEntityType, ledgerEntityType.Allocate(renderingContext, application));
            }

            foreach (var registerEntityType in applicationDesign.OfType<RegisterEntityType>())
            {
                renderingContext.AddManifest(registerEntityType, registerEntityType.Allocate(renderingContext, application));
            }
        }
    }
}
