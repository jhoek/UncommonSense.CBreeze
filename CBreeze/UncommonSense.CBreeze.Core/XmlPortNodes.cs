using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class XmlPortNodes : IEnumerable<XmlPortNode>
    {
        private Dictionary<Guid,XmlPortNode> innerList = new Dictionary<Guid,XmlPortNode>();

        internal XmlPortNodes()
        {
        }

        public XmlPortFieldAttribute AddXmlPortFieldAttribute(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortFieldAttribute item = new XmlPortFieldAttribute(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortFieldElement AddXmlPortFieldElement(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortFieldElement item = new XmlPortFieldElement(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortTableAttribute AddXmlPortTableAttribute(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortTableAttribute item = new XmlPortTableAttribute(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortTableElement AddXmlPortTableElement(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortTableElement item = new XmlPortTableElement(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortTextAttribute AddXmlPortTextAttribute(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortTextAttribute item = new XmlPortTextAttribute(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortTextElement AddXmlPortTextElement(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortTextElement item = new XmlPortTextElement(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Guid id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<XmlPortNode> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }
}
