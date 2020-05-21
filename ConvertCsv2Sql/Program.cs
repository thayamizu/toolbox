using System;
using System.IO;
using System.Text;
using YamlDotNet;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using ConvertCsv2Sql;

namespace ConvertCsv2Sql
{
    class Program
    {
        static void Main()
        {
            System.Console.WriteLine("生成元のCSVファイルを入力してください。");
            var filePath = System.Console.ReadLine();
            var outputPath = "./out/result.sql";
            var settingFilePath = "./settings.yaml";

            //設定ファイル読み込み
            var stream = new StreamReader(settingFilePath);
            var desirializer = new YamlDotNet.Serialization.Deserializer();
            var yamlData = desirializer.Deserialize<YamlSetting>(stream);

            //変換処理を実行
            var converter = new Converter(yamlData);
            converter.execute(filePath, outputPath);
        }

    }
}
