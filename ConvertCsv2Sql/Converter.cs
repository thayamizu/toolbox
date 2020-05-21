using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace ConvertCsv2Sql
{
    class Converter
    {
        
        /// <summary>
        /// 設定情報
        /// </summary>
        private YamlSetting _options;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="options"></param>
        public Converter(YamlSetting options)
        {
            _options = options;
        }

        /// <summary>
        /// 変換処理
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="outputPath"></param>
        public void execute(string filePath, string outputPath)
        {
            using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("UTF-8")))
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                // 最後まで読み込む
                while (reader.Peek() >= 0)
                {
                    // 読み込んだ文字列をカンマ区切りで配列に格納
                    var data = reader.ReadLine().Split(',');
                    var columns = this._options.columns;

                    List<string> list = new List<string>();
                    for (int i = 0; i < columns.Length; i++)
                    {
                        list.Add($"`{columns[i]}`=\"{data[i]}\"");
                    }
                    
                    var query = $"update {this._options.table} set {String.Join(", ", list)};";
                    System.Console.WriteLine(query);
                    writer.WriteLine(query);
                }

            }
        }
    }

}
