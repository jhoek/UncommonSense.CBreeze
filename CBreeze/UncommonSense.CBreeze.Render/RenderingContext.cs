using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Model;

namespace UncommonSense.CBreeze.Render
{
    public class RenderingContext
    {
        private int nextTableID;
        private int nextPageID;
        private int nextCodeunitID;
        private DateTime? dateTime;
        private string versionList;
        private Dictionary<EntityType, RenderingManifest> manifests = new Dictionary<EntityType, RenderingManifest>();

        public RenderingContext(int nextTableID = 50000, int nextPageID = 50000, int nextCodeunitID = 50000, DateTime? dateTime = null, string versionList = null)
        {
            this.nextTableID = nextTableID;
            this.nextPageID = nextPageID;
            this.nextCodeunitID = nextCodeunitID;
            this.dateTime = dateTime;
            this.versionList = versionList;
        }

        internal void AddManifest(EntityType entityType, RenderingManifest manifest)
        {
            this.manifests.Add(entityType, manifest);
        }

        internal RenderingManifest GetManifest(EntityType entityType)
        {
            return Manifests.Where(k => k.Key == entityType).FirstOrDefault().Value;
        }

        public int GetNextTableID()
        {
            return nextTableID++;
        }

        public int GetNextPageID()
        {
            return nextPageID++;
        }

        public int GetNextCodeunitID()
        {
            return nextCodeunitID++;  
        }

        public DateTime? DateTime
        {
            get
            {
                return this.dateTime;
            }
        }

        public string VersionList
        {
            get
            {
                return this.versionList;
            }
        }

        public IEnumerable<EntityType> EntityTypes
        {
            get
            {
                foreach (var entityType in this.manifests.Keys)
                {
                    yield return entityType;
                }
            }
        }

        public IEnumerable<KeyValuePair<EntityType, RenderingManifest>> Manifests
        {
            get
            {
                foreach (var manifest in this.manifests)
                {
                    yield return manifest;
                }
            }
        }
    }
}
