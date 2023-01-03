using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ZRQ.Utils.ClassTemplate;

namespace HW.DevelopTool.Config;

internal class MySettings : Singleton<MySettings>
{
    string _fileName = "MySettings.json";

    public PullConfig PullConfig { get; set; } = new();

    /// <summary>
    /// 初始化设置
    /// </summary>
    public void InitSetting()
    {
        bool isExists = File.Exists(_fileName);
        if (!isExists) return;

        string jsonString = File.ReadAllText(_fileName);
        MySettings? mySettings = JsonSerializer.Deserialize<MySettings>(jsonString);
        if (mySettings == null) return;

        this.PullConfig = mySettings.PullConfig;
    }

    public void SaveFile()
    {
        var jsonString = JsonSerializer.Serialize<MySettings>(this).Normalize();
        File.WriteAllText(_fileName, jsonString);
    }
}
