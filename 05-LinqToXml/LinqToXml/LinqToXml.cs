using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace LinqToXml
{
    public static class LinqToXml
    {
        /// <summary>
        /// Creates hierarchical data grouped by category
        /// </summary>
        /// <param name="xmlRepresentation">Xml representation (refer to CreateHierarchySourceFile.xml in Resources)</param>
        /// <returns>Xml representation (refer to CreateHierarchyResultFile.xml in Resources)</returns>
        public static string CreateHierarchy(string xmlRepresentation)
        {
            XDocument document = XDocument.Parse(xmlRepresentation);

            var elementWhereCategoryIsA = document.Root.Elements("Data").Where(i => i.Element("Category").Value == "A").ToList();
            var elementWhereCategoryIsB = document.Root.Elements("Data").Where(i => i.Element("Category").Value == "B").ToList();
            elementWhereCategoryIsA.Elements("Category").Remove();
            elementWhereCategoryIsB.Elements("Category").Remove();

            var newDocument = XElement.Parse("<Root></Root>");
            newDocument.Add(new XElement("Group", new XAttribute("ID", "A")));
            newDocument.Element("Group").Add(elementWhereCategoryIsA);
            newDocument.Add(new XElement("Group", new XAttribute("ID", "B")));
            newDocument.Elements("Group").LastOrDefault().Add(elementWhereCategoryIsB);

            return newDocument.ToString();
        }

        /// <summary>
        /// Get list of orders numbers (where shipping state is NY) from xml representation
        /// </summary>
        /// <param name="xmlRepresentation">Orders xml representation (refer to PurchaseOrdersSourceFile.xml in Resources)</param>
        /// <returns>Concatenated orders numbers</returns>
        /// <example>
        /// 99301,99189,99110
        /// </example>
        public static string GetPurchaseOrders(string xmlRepresentation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads csv representation and creates appropriate xml representation
        /// </summary>
        /// <param name="customers">Csv customers representation (refer to XmlFromCsvSourceFile.csv in Resources)</param>
        /// <returns>Xml customers representation (refer to XmlFromCsvResultFile.xml in Resources)</returns>
        public static string ReadCustomersFromCsv(string customers)
        {
            var records = customers.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            XDocument document = new XDocument();
            XElement rootElement = new XElement("Root");
            document.Add(rootElement);
            foreach (var record in records)
            {
                var elements = record.Split(',');
                XElement element = new XElement("Customer", new XAttribute("CustomerID", elements[0]),
                    new XElement("CompanyName", elements[1]),
                    new XElement("ContactName", elements[2]),
                    new XElement("ContactTitle", elements[3]),
                    new XElement("Phone", elements[4]),
                    new XElement("FullAddress",
                        new XElement("Address", elements[5]),
                        new XElement("City", elements[6]),
                        new XElement("Region", elements[7]),
                        new XElement("PostalCode", elements[8]),
                        new XElement("Country", elements[9])));
                rootElement.Add(element);
            }

            return document.ToString();
        }

        /// <summary>
        /// Gets recursive concatenation of elements
        /// </summary>
        /// <param name="xmlRepresentation">Xml representation of document with Sentence, Word and Punctuation elements. (refer to ConcatenationStringSource.xml in Resources)</param>
        /// <returns>Concatenation of all this element values.</returns>
        public static string GetConcatenationString(string xmlRepresentation) => string.Join("", XDocument.Parse(xmlRepresentation).Root.Elements().Select(i => i.Value));

        /// <summary>
        /// Replaces all "customer" elements with "contact" elements with the same childs
        /// </summary>
        /// <param name="xmlRepresentation">Xml representation with customers (refer to ReplaceCustomersWithContactsSource.xml in Resources)</param>
        /// <returns>Xml representation with contacts (refer to ReplaceCustomersWithContactsResult.xml in Resources)</returns>
        public static string ReplaceAllCustomersWithContacts(string xmlRepresentation)
        {
            XDocument document = XDocument.Parse(xmlRepresentation);
            document.Root.Elements("customer").ToList().ForEach(i => i.Name = "contact");
            return document.ToString();
        }

        /// <summary>
        /// Finds all ids for channels with 2 or more subscribers and mark the "DELETE" comment
        /// </summary>
        /// <param name="xmlRepresentation">Xml representation with channels (refer to FindAllChannelsIdsSource.xml in Resources)</param>
        /// <returns>Sequence of channels ids</returns>
        public static IEnumerable<int> FindChannelsIds(string xmlRepresentation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sort customers in docement by Country and City
        /// </summary>
        /// <param name="xmlRepresentation">Customers xml representation (refer to GeneralCustomersSourceFile.xml in Resources)</param>
        /// <returns>Sorted customers representation (refer to GeneralCustomersResultFile.xml in Resources)</returns>
        public static string SortCustomers(string xmlRepresentation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets XElement flatten string representation to save memory
        /// </summary>
        /// <param name="xmlRepresentation">XElement object</param>
        /// <returns>Flatten string representation</returns>
        /// <example>
        ///     <root><element>something</element></root>
        /// </example>
        public static string GetFlattenString(XElement xmlRepresentation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets total value of orders by calculating products value
        /// </summary>
        /// <param name="xmlRepresentation">Orders and products xml representation (refer to GeneralOrdersFileSource.xml in Resources)</param>
        /// <returns>Total purchase value</returns>
        public static int GetOrdersValue(string xmlRepresentation)
        {
            throw new NotImplementedException();
        }
    }
}
