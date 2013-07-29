using System.Linq;
using System.Xml.Linq;

namespace Alphabetizer
{
    public static class XmlSort
    {
        #region Private Method - Sort

        /// <summary>
        ///     Sort an XML Element based on a minimum level to perform the sort from and either based on the value
        ///     of an attribute of an XML Element or by the name of the XML Element.
        /// </summary>
        /// <param name="file">File to load and sort</param>
        /// <param name="level">Minimum level to apply the sort from.  0 for root level.</param>
        /// <param name="attribute">Name of the attribute to sort by.  "" for no sort</param>
        /// <param name="sortAttributes">Sort attributes none, ascending or decending for all sorted XML nodes</param>
        /// <returns>Sorted XElement based on the criteria passed in.</returns>
        public static XDocument Sort(XDocument file, int level, string attribute, int sortAttributes)
        {
            return new XDocument(Sort(file.Root, level, attribute, sortAttributes));
        }
        /// <summary>
        ///     Sort an XML Element based on a minimum level to perform the sort from and either based on the value
        ///     of an attribute of an XML Element or by the name of the XML Element.
        /// </summary>
        /// <param name="element">Element to sort</param>
        /// <param name="level">Minimum level to apply the sort from.  0 for root level.</param>
        /// <param name="attribute">Name of the attribute to sort by.  "" for no sort</param>
        /// <param name="sortAttributes">Sort attributes none, ascending or decending for all sorted XML nodes</param>
        /// <returns>Sorted XElement based on the criteria passed in.</returns>
        public static XElement Sort(XElement element, int level, string attribute, int sortAttributes)
        {
            var newElement = new XElement(element.Name,
                from child in element.Elements()
                orderby
                    (child.Ancestors().Count() > level)
                        ? ((child.HasAttributes && !string.IsNullOrEmpty(attribute) && child.Attribute(attribute) != null)
                            ? child.Attribute(attribute).Value
                            : child.Name.ToString())
                        : ""
                //End of the orderby clause
                select Sort(child, level, attribute, sortAttributes));
            if (element.HasAttributes)
            {
                switch (sortAttributes)
                {
                    case 0: //None
                        foreach (var attrib in element.Attributes())
                        {
                            newElement.SetAttributeValue(attrib.Name, attrib.Value);
                        }
                        break;
                    case 1: //Ascending
                        foreach (var attrib in element.Attributes().OrderBy(a => a.Name.ToString()))
                        {
                            newElement.SetAttributeValue(attrib.Name, attrib.Value);
                        }
                        break;
                    case 2: //Decending
                        foreach (var attrib in element.Attributes().OrderByDescending(a => a.Name.ToString()))
                        {
                            newElement.SetAttributeValue(attrib.Name, attrib.Value);
                        }
                        break;
                }
            }
            if (!element.HasElements)
            {
                newElement.Add(element.Value);
            }

            return newElement;
        }

        #endregion
    }
}