using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Tool.Data
{
    /// <summary>
    /// HW产品生成器类
    /// </summary>
    public static class HWProductBuilder
    {
        public static List<HWProduct> GetAllHWProducts()
        {
            List<HWProduct> hwProducts = new()
            {
                CreateCC(),
                CreateAEC(),
                CreateMEP(),
                CreatePMEP(),
                CreateCST(),
                CreatePC(),
                CreateDEC(),
                CreateST(),
                CreateXT(),
                CreateZK(),
                CreateMaxiBIM()
            };
            return hwProducts;
        }

        /// <summary>
        /// MaxiBIM
        /// </summary>
        private static HWProduct CreateMaxiBIM()
        {
            HWProduct product = new()
            {
                Name = "MaxiBIM",
                Description = "海外产品",
                Abbr = "MaxiBIM",
            };
            return product;
        }

        /// <summary>
        /// 族库大师
        /// </summary>
        /// <returns></returns>
        private static HWProduct CreateZK()
        {
            HWProduct product = new()
            {
                Name = "族库大师",
                Description = "族库大师",
                Abbr = "ZK",
            };
            return product;
        }

        /// <summary>
        /// 协同大师 - XT
        /// </summary>
        /// <returns></returns>
        private static HWProduct CreateXT()
        {
            HWProduct product = new()
            {
                Name = "协同大师",
                Description = "协同大师",
                Abbr = "XT",
            };
            return product;
        }

        /// <summary>
        /// 建模大师(钢构) - ST
        /// </summary>
        private static HWProduct CreateST()
        {
            HWProduct product = new()
            {
                Name = "建模大师(钢构)",
                Description = "建模大师(钢构)",
                Abbr = "ST",
            };
            return product;
        }

        /// <summary>
        /// 建模大师(精装) - DEC
        /// </summary>
        /// <returns></returns>
        private static HWProduct CreateDEC()
        {
            HWProduct product = new()
            {
                Name = "建模大师(精装)",
                Description = "建模大师(精装)",
                Abbr = "DEC",
            };

            return product;
        }

        /// <summary>
        /// 装配式混凝土(PC) - PC
        /// </summary>
        private static HWProduct CreatePC()
        {
            HWProduct product = new()
            {
                Name = "建模大师(PC)",
                Description = "装配式混凝土",
                Abbr = "PC",
            };
            return product;
        }

        /// <summary>
        /// 建模大师(施工) - CST
        /// </summary>
        /// <returns></returns>
        private static HWProduct CreateCST()
        {
            HWProduct product = new()
            {
                Name = "建模大师(施工)",
                Description = "建模大师(施工)",
                Abbr = "CST",
            };
            return product;
        }

        /// <summary>
        /// 建模大师PMEP - PMEP
        /// </summary>
        private static HWProduct CreatePMEP()
        {
            HWProduct product = new()
            {
                Name = "建模大师PMEP",
                Description = "装配式机电（PMEP）",
                Abbr = "PMEP",
            };
            return product;
        }

        /// <summary>
        /// 建模大师(机电) - MEP
        /// </summary>
        private static HWProduct CreateMEP()
        {
            HWProduct product = new()
            {
                Name = "建模大师(机电)",
                Description = "建模大师系列产品",
                Abbr = "MEP",
            };
            return product;
        }

        /// <summary>
        /// 建模大师(建筑) - AEC
        /// </summary>
        private static HWProduct CreateAEC()
        {
            HWProduct product = new()
            {
                Name = "建模大师(建筑)",
                Description = "建模大师(建筑)",
                Abbr = "AEC",
            };
            return product;
        }

        /// <summary>
        /// 建模大师(通用) - CC
        /// </summary>
        private static HWProduct CreateCC()
        {
            HWProduct product = new()
            {
                Name = "建模大师(通用)",
                Description = "建模大师(通用)",
                Abbr = "CC",
            };
            return product;
        }
    }
}
