using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLibrary
{

    public class JsonDiff
    {
        public void Run() {
            // 原始 JSON 对象
            string originalJson = "{\"name\": \"John\", \"age\": 30, \"city\": \"New York\"}";

            // 差分信息 JSON 对象
            string diffJson = "{\"age\": 31, \"city\": \"New York1\"}";

            // 将 JSON 字符串解析为 JObject
            JObject originalObject = JObject.Parse(originalJson);
            JObject diffObject = JObject.Parse(diffJson);

            // 合并差分信息到原始对象
            MergeJsonObjects(originalObject, diffObject);

            // 打印合并后的 JSON 对象
            Console.WriteLine(originalObject.ToString(Formatting.Indented));
        }

        static void MergeJsonObjects(JObject original, JObject diff)
        {
            foreach (var property in diff.Properties())
            {
                // 如果差分对象中的属性值不为 null，则更新原始对象的属性值
                if (property.Value.Type != JTokenType.Null)
                {
                    original[property.Name] = property.Value;
                }
                else
                {
                    // 如果差分对象中的属性值为 null，则从原始对象中删除该属性
                    original.Remove(property.Name);
                }
            }
        }
    }

}
