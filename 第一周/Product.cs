using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string 商品名稱 { get; set; }
    public string 類型 { get; set; }
    public int 數量 { get; set; }
    public decimal 價格 { get; set; }
}




class Program
{
    static void Main()
    {
        // 建立商品集合
        List<Product> products = new List<Product>
        {
            new Product { 商品名稱 = "衛生紙", 類型 = "紙類", 數量 = 30, 價格 = 180 },
            new Product { 商品名稱 = "濕紙巾", 類型 = "紙類", 數量 = 5, 價格 = 45 },
            new Product { 商品名稱 = "貓飼料", 類型 = "寵物用品", 數量 = 15, 價格 = 599 },
            new Product { 商品名稱 = "倉鼠跑輪", 類型 = "寵物用品", 數量 = 6, 價格 = 125 },
            new Product { 商品名稱 = "滑鼠", 類型 = "3C用品", 數量 = 12, 價格 = 3250 },
            new Product { 商品名稱 = "鍵盤", 類型 = "3C用品", 數量 = 8, 價格 = 3200 },
        };

        // 1. 篩選出數量大於10的商品
        var quantityGreaterThan10 = products.Where(p => p.數量 > 10);//=>: 表示 "goes to" 或 "becomes"。
        Console.WriteLine("1. 數量大於10的商品:");
        PrintProducts(quantityGreaterThan10);

        // 2. 列出各商品的總價格
        var totalPrices = products.Select(p => new { p.商品名稱, TotalPrice = p.數量 * p.價格 });
        Console.WriteLine("\n2. 各商品的總價格:");
        foreach (var item in totalPrices)
        {
            Console.WriteLine($"{item.商品名稱}: {item.TotalPrice:C}");
        }

        // 3. 依類型做分群
        var groupedByType = products.GroupBy(p => p.類型);
        Console.WriteLine("\n3. 依類型分群:");
        foreach (var group in groupedByType)
        {
            Console.WriteLine($"類型: {group.Key}");
            PrintProducts(group);
        }

        // 4. 用數量降序排序
        var sortedByQuantity = products.OrderByDescending(p => p.數量);
        Console.WriteLine("\n4. 用數量降序排序:");
        PrintProducts(sortedByQuantity);
    }

    static void PrintProducts(IEnumerable<Product> products)
    {
        foreach (var product in products)
        {
            Console.WriteLine($"商品名稱: {product.商品名稱}, 類型: {product.類型}, 數量: {product.數量}, 價格: {product.價格:C}");
        }
        Console.WriteLine();
    }
}

