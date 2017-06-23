﻿// 项目名称 :  Yutai
// 项目描述 :  
// 类 名 称 :  IPipelineLayer.cs
// 版 本 号 :  
// 说    明 :  
// 作    者 :  
// 创建时间 :  2017/06/22  17:32
// 更新时间 :  2017/06/22  17:32

using System.Xml;

namespace Yutai.Pipeline.Config.Interfaces
{
    public interface IPipelineLayer
    {
        string Name { get; set; }
        string Code { get; set; }
        IPipePoint PointLayer { get; set; }
        IPipeLine LineLayer { get; set; }
        IPointAssist PointAssistLayer { get; set; }
        ILineAssist LineAssistLayer { get; set; }
        void ReadFromXml(XmlNode xml);
        XmlNode ToXml(XmlDocument doc);
    }
}