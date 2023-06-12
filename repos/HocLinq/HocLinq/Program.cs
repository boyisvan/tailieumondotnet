using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HocLinq
{
    class Program
    {
        public static List<Brand> brands = new List<Brand>()
        {
            new Brand(){BrandId="B001",BrandName= "Nhà máy điện"},
            new Brand(){BrandId="B002",BrandName= "Nhà máy vải"},
            new Brand(){BrandId="B003",BrandName= "Nhà máy công nghệ"},
        };
        public static List<Product> products = new List<Product>()
        {
            new Product{ProductID="p1",}
        };
        static void Main(string[] args)
        {

            //6.Toán tử chuyển kiểu
            Brand[] arrBrand = brands.ToArray();
            //7.Toán tử nối
            //8.Toán tử tổng hợp
            var sosp = products.Count();
            Console.WriteLine("Tổng số sản phẩm :" + sosp);
        }
    }
}
