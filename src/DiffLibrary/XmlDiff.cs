using System;
using System;
using System.Xml;
using System.Xml.Linq;


namespace DiffLibrary
{
    internal class XmlDiff
    {

        public XElement MergeXml(XElement originalXml, XElement updatedXml)
        {
            // 创建一个新的XML元素，作为合并后的根元素
            XElement mergedXml = new XElement("root");

            // 将原始XML的内容添加到合并后的XML中
            mergedXml.Add(originalXml.Elements());

            // 遍历更新后的XML元素
            foreach (XElement updatedElement in updatedXml.Elements())
            {
                // 查找原始XML中是否存在相同名称的元素
                XElement existingElement = mergedXml.Elements(updatedElement.Name).FirstOrDefault();

                if (existingElement != null)
                {
                    // 如果存在相同名称的元素，更新其内容
                    existingElement.ReplaceWith(updatedElement);
                }
                else
                {
                    // 如果不存在相同名称的元素，将更新后的元素添加到合并后的XML中
                    mergedXml.Add(updatedElement);
                }
            }

            return mergedXml;
        }
    }
}
