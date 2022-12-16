using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWDevelopTool.Core
{
    class DataInfo
    {
        private static Dictionary<string, string> Products { get; } = new Dictionary<string, string>
        {
            { "建模大师AEC" ,"BuildMaster(AEC)"},
            { "建模大师CC"  ,"BuildMaster(CC)"},
            { "建模大师CP"  ,"BuildMaster(CP)"},
            { "建模大师CST" ,"BuildMaster(CST)"},
            { "建模大师DEC" ,"BuildMaster(DEC)"},
            { "建模大师MEP" ,"BuildMaster(MEP)"},
            { "建模大师PC"  ,"BuildMaster(PC)"},
            { "建模大师ST"  ,"BuildMaster(ST)"},
            { "协同大师"    ,"BuildMaster(XT)"},
            { "族库大师"    ,"FamilyMaster"   },
            { "MaxiBIM"    ,"MaxiBIM"   },
        };

        /// <summary>
        /// 初始化产品信息
        /// </summary>
        public void InitHWProducts()
        {
            List<HWProduct> products = new();

            products.Add(new HWProduct()
            {
                Name = "建模大师AEC",
                Abbr = "AEC"
            });

            products.Add(new HWProduct()
            {
                Name = "建模大师CC",
                Abbr = "CC"
            });

            products.Add(new HWProduct()
            {
                Name = "建模大师CP",
                Abbr = "CP"
            });

            products.Add(new HWProduct()
            {
                Name = "建模大师CST",
                Abbr = "CST"
            });

            products.Add(new HWProduct()
            {
                Name = "建模大师DEC",
                Abbr = "DEC"
            });

            products.Add(new HWProduct()
            {
                Name = "建模大师MEP",
                Abbr = "MEP"
            });

            products.Add(new HWProduct()
            {
                Name = "建模大师PC",
                Abbr = "PC"
            });

            products.Add(new HWProduct()
            {
                Name = "建模大师ST",
                Abbr = "ST"
            });

            products.Add(new HWProduct()
            {
                Name = "协同大师",
                Abbr = "XT"
            });

            products.Add(new HWProduct()
            {
                Name = "族库大师",
                Abbr = "ZK"
            });

            products.Add(new HWProduct()
            {
                Name = "MaxiBIM",
                Abbr = "MaxiBIM"
            });
        }
    }
}
