using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Skia;
using SkiaSharp;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace AvaloniaSVG.ViewModels
{
    public class SvgToPathConverter
    {
        public static Avalonia.Controls.Shapes.Path ConvertSvgToPath(string svgFilePath)
        {
            if (string.IsNullOrEmpty(svgFilePath) || !File.Exists(svgFilePath))
                throw new FileNotFoundException("SVG file not found.");

            XDocument xdoc = XDocument.Load(svgFilePath);
            XNamespace ns = "http://www.w3.org/2000/svg";
            XElement svgPath = xdoc.Root.Element(ns + "path");

            if (svgPath == null)
                throw new FormatException("SVG file format is not correct.");

            string data = svgPath.Attribute("d").Value;

            PathGeometry pathGeometry = PathGeometry.Parse(data);

            var path = new Avalonia.Controls.Shapes.Path
            {
                Data = pathGeometry
            };

            return path;
        }
    }

    //public class SvgToAvaloniaPathConverter
    //{
    //    public static Path ConvertSvgToAvaloniaPath(string svgFilePath)
    //    {
    //        // 加载SVG文件
    //        XDocument xDoc = XDocument.Load(svgFilePath);

    //        // 创建Avalonia的Path对象
    //        Path path = new Path();

    //        // 遍历SVG中的所有路径元素
    //        var svgPaths = xDoc.Descendants().Where(e => e.Name.LocalName == "path");

    //        foreach (var svgPath in svgPaths)
    //        {
    //            // 获取SVG路径数据
    //            string dAttribute = svgPath.Attribute("d")?.Value;

    //            if (!string.IsNullOrEmpty(dAttribute))
    //            {
    //                // 使用SkiaSharp解析SVG路径数据
    //                using (var skStream = new SKFileStream(svgFilePath))
    //                using (var skCanvas = new SKCanvas())
    //                using (var skPaint = new SKPaint { Style = SKPaintStyle.Stroke })
    //                {
    //                    // 将SVG路径数据转换为SKPath
    //                    var skPath = SKPath.ParseSvgPathData(dAttribute);

    //                    // 将SKPath转换为Avalonia.PathGeometry
    //                    var geometry = new SKPathGeometry();
    //                    geometry.AddPath(skPath);

    //                    // 将PathGeometry添加到Avalonia.Path的几何形状列表中
    //                    foreach (var figure in geometry.Figures)
    //                    {
    //                        path.Data = new PathGeometry
    //                        {
    //                            Figures = new Avalonia.Media.PathFigure[]
    //                            {
    //                            new Avalonia.Media.PathFigure
    //                            {
    //                                StartPoint = figure.Start,
    //                                Segments = figure.Segments.Select(segment =>
    //                                {
    //                                    switch (segment)
    //                                    {
    //                                        case SKPathLineSegment line:
    //                                            return new LineSegment { Point = line.Point };
    //                                        // 根据需要添加其他类型，如BezierSegment等
    //                                        default:
    //                                            throw new NotImplementedException();
    //                                    }
    //                                }).ToArray()
    //                            }
    //                            }
    //                        };
    //                    }
    //                }
    //            }
    //        }

    //        return path;
    //    }
    //}
}
