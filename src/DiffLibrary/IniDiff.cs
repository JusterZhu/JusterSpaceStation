using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffLibrary
{
    public class IniDiff
    {
        //static void Main(string[] args)
        //{
        //    //string originalFilePath = "original.ini";
        //    //string targetFilePath = "target.ini";

        //    //Dictionary<string, Dictionary<string, string>> originalIni = ParseIniFile(originalFilePath);
        //    //Dictionary<string, Dictionary<string, string>> targetIni = ParseIniFile(targetFilePath);

        //    //// 比较两个INI文件的内容，找出差异
        //    //Dictionary<string, Dictionary<string, string>> diffIni = GetIniFileDiff(originalIni, targetIni);

        //    //// 将差异合并到目标INI文件中
        //    //MergeIniFiles(targetIni, diffIni);

        //    //// 将合并后的INI文件保存到磁盘上
        //    //SaveIniFile(targetFilePath, targetIni);

        //    // 准备测试数据
        //    string originalFilePath = "original.ini";
        //    string targetFilePath = "target.ini";

        //    // 模拟原始INI文件内容
        //    Dictionary<string, Dictionary<string, string>> originalIni = new Dictionary<string, Dictionary<string, string>>
        //{
        //    {
        //        "Section1", new Dictionary<string, string>
        //        {
        //            {"Key1", "Value1"},
        //            {"Key2", "Value2"}
        //        }
        //    },
        //    {
        //        "Section2", new Dictionary<string, string>
        //        {
        //            {"Key3", "Value3"}
        //        }
        //    }
        //};

        //    // 模拟目标INI文件内容
        //    Dictionary<string, Dictionary<string, string>> targetIni = new Dictionary<string, Dictionary<string, string>>
        //{
        //    {
        //        "Section1", new Dictionary<string, string>
        //        {
        //            {"Key1", "Value1"},
        //            {"Key2", "Value2"},
        //            {"Key4", "Value4"} // 不同的值
        //        }
        //    },
        //    {
        //        "Section3", new Dictionary<string, string>
        //        {
        //            {"Key5", "Value5"} // 新的部分
        //        }
        //    }
        //};

        //    // 模拟预期的差异
        //    Dictionary<string, Dictionary<string, string>> expectedDiffIni = new Dictionary<string, Dictionary<string, string>>
        //{
        //    {
        //        "Section2", new Dictionary<string, string>
        //        {
        //            {"Key3", "Value3"} // 在原始INI文件中但不在目标INI文件中
        //        }
        //    },
        //    {
        //        "Section3", new Dictionary<string, string>
        //        {
        //            {"Key5", "Value5"} // 在目标INI文件中但不在原始INI文件中
        //        }
        //    }
        //};

        //    // 执行差分合并
        //    //Dictionary<string, Dictionary<string, string>> diffIni = Program.GetIniFileDiff(originalIni, targetIni);
        //    //Program.MergeIniFiles(targetIni, diffIni);

        //    // 验证差异是否与预期相符
        //    //Assert.AreEqual(expectedDiffIni, diffIni);

        //    // 验证合并后的INI文件是否包含所有差异
        //    foreach (var sectionKey in expectedDiffIni.Keys)
        //    {
        //        Console.WriteLine($"{expectedDiffIni[sectionKey].Values} , {targetIni[sectionKey]}");
        //        //CollectionAssert.AreEqual(expectedDiffIni[sectionKey], targetIni[sectionKey]);
        //    }
        //}

        static Dictionary<string, Dictionary<string, string>> ParseIniFile(string filePath)
        {
            Dictionary<string, Dictionary<string, string>> iniData = new Dictionary<string, Dictionary<string, string>>();
            string currentSection = "";

            foreach (string line in File.ReadLines(filePath))
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2);
                    iniData[currentSection] = new Dictionary<string, string>();
                }
                else if (!string.IsNullOrEmpty(trimmedLine) && trimmedLine.Contains("="))
                {
                    string[] parts = trimmedLine.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    iniData[currentSection][key] = value;
                }
            }

            return iniData;
        }

        static Dictionary<string, Dictionary<string, string>> GetIniFileDiff(
            Dictionary<string, Dictionary<string, string>> originalIni,
            Dictionary<string, Dictionary<string, string>> targetIni)
        {
            Dictionary<string, Dictionary<string, string>> diffIni = new Dictionary<string, Dictionary<string, string>>();

            foreach (var sectionKey in originalIni.Keys)
            {
                if (!targetIni.ContainsKey(sectionKey))
                {
                    diffIni[sectionKey] = originalIni[sectionKey];
                }
                else
                {
                    Dictionary<string, string> originalSection = originalIni[sectionKey];
                    Dictionary<string, string> targetSection = targetIni[sectionKey];
                    Dictionary<string, string> diffSection = originalSection
                        .Where(kv => !targetSection.ContainsKey(kv.Key) || targetSection[kv.Key] != kv.Value)
                        .ToDictionary(kv => kv.Key, kv => kv.Value);

                    if (diffSection.Count > 0)
                    {
                        diffIni[sectionKey] = diffSection;
                    }
                }
            }

            return diffIni;
        }

        static void MergeIniFiles(
            Dictionary<string, Dictionary<string, string>> targetIni,
            Dictionary<string, Dictionary<string, string>> diffIni)
        {
            foreach (var sectionKey in diffIni.Keys)
            {
                if (!targetIni.ContainsKey(sectionKey))
                {
                    targetIni[sectionKey] = new Dictionary<string, string>();
                }

                Dictionary<string, string> targetSection = targetIni[sectionKey];
                Dictionary<string, string> diffSection = diffIni[sectionKey];

                foreach (var keyValue in diffSection)
                {
                    targetSection[keyValue.Key] = keyValue.Value;
                }
            }
        }

        static void SaveIniFile(string filePath, Dictionary<string, Dictionary<string, string>> iniData)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                foreach (var sectionKey in iniData.Keys)
                {
                    writer.WriteLine($"[{sectionKey}]");

                    foreach (var keyValue in iniData[sectionKey])
                    {
                        writer.WriteLine($"{keyValue.Key}={keyValue.Value}");
                    }

                    writer.WriteLine(); // 空行分隔不同的部分
                }
            }
        }
    }
}
