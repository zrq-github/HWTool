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
    public static class ProductBuilder
    {
        public static List<Product> AllProducts { get; set; } = GetInternalProducts();

        /// <summary>
        /// 建模大师(建筑) - AEC
        /// </summary>
        private static Product CreateAEC()
        {
            Product product = new()
            {
                Name = "建模大师(建筑)",
                Description = "建模大师(建筑)",
                Abbr = "AEC",
                Id = "AEC",
            };
            return product;
        }

        /// <summary>
        /// 建模大师(通用) - CC
        /// </summary>
        private static Product CreateCC()
        {
            Product product = new()
            {
                Name = "建模大师(通用)",
                Description = "建模大师(通用)",
                Abbr = "CC",
                Id = "CC",
            };
            return product;
        }

        /// <summary>
        /// 建模大师(施工) - CST
        /// </summary>
        /// <returns> </returns>
        private static Product CreateCST()
        {
            Product product = new()
            {
                Name = "建模大师(施工)",
                Description = "建模大师(施工)",
                Abbr = "CST",
                Id = "CST",
            };
            return product;
        }

        /// <summary>
        /// 建模大师(精装) - DEC
        /// </summary>
        /// <returns> </returns>
        private static Product CreateDEC()
        {
            Product product = new()
            {
                Name = "建模大师(精装)",
                Description = "建模大师(精装)",
                Abbr = "DEC",
                Id = "DEC",
            };

            return product;
        }

        /// <summary>
        /// MaxiBIM
        /// </summary>
        private static Product CreateMaxiBIM()
        {
            Product product = new()
            {
                Name = "MaxiBIM",
                Description = "海外产品",
                Abbr = "MaxiBIM",
                Id = "MaxiBIM",
            };
            return product;
        }

        /// <summary>
        /// 建模大师(机电) - MEP
        /// </summary>
        private static Product CreateMEP()
        {
            Product product = new()
            {
                Name = "建模大师(机电)",
                Description = "建模大师系列产品",
                Abbr = "MEP",
                Id = "MEP",
            };
            return product;
        }

        /// <summary>
        /// 装配式混凝土(PC) - PC
        /// </summary>
        private static Product CreatePC()
        {
            Product product = new()
            {
                Name = "建模大师(PC)",
                Description = "装配式混凝土",
                Abbr = "PC",
                Id = "PC",
            };
            return product;
        }

        /// <summary>
        /// 建模大师PMEP - PMEP
        /// </summary>
        private static Product CreatePMEP()
        {
            Product product = new()
            {
                Name = "建模大师PMEP",
                Description = "装配式机电（PMEP）",
                Abbr = "PMEP",
                Id = "PMEP",
            };
            return product;
        }

        /// <summary>
        /// 建模大师(钢构) - ST
        /// </summary>
        private static Product CreateST()
        {
            Product product = new()
            {
                Name = "建模大师(钢构)",
                Description = "建模大师(钢构)",
                Abbr = "ST",
                Id = "ST",
            };
            return product;
        }

        /// <summary>
        /// 协同大师 - XT
        /// </summary>
        /// <returns> </returns>
        private static Product CreateXT()
        {
            Product product = new()
            {
                Name = "协同大师",
                Description = "协同大师",
                Abbr = "XT",
                Id = "XT",
            };
            return product;
        }

        /// <summary>
        /// 族库大师
        /// </summary>
        /// <returns> </returns>
        private static Product CreateZK()
        {
            Product product = new()
            {
                Name = "族库大师",
                Description = "族库大师",
                Abbr = "ZK",
                Id = "ZK",
            };
            return product;
        }

        private static Dictionary<ProductEnum, Product> GetHWProducts()
        {
            Dictionary<ProductEnum, Product> products = new()
            {
                {ProductEnum.AEC, CreateAEC()},
                {ProductEnum.CC, CreateCC()},
                {ProductEnum.CST, CreateCST()},
                {ProductEnum.DEC, CreateDEC()},
                {ProductEnum.MaxiBIM, CreateMaxiBIM()},
                {ProductEnum.MEP, CreateMEP()},
                {ProductEnum.PC, CreatePC()},
                {ProductEnum.PMEP, CreatePMEP()},
                {ProductEnum.ST, CreateST()},
                {ProductEnum.XT, CreateXT()},
                {ProductEnum.ZK, CreateZK()},
            };
            return products;
        }

        public static List<Product> GetInternalProducts()
        {
            List<Product> products = new()
            {
                CreateAEC(),
                CreateCC(),
                CreateCST(),
                CreateDEC(),
                CreateMaxiBIM(),
                CreateMEP(),
                CreatePC(),
                CreatePMEP(),
                CreateST(),
                CreateXT(),
                CreateZK()
            };
            return products;
        }
    }
}
