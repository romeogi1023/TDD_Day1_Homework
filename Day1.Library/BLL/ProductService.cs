using Day1.Library.DAL;
using Day1.Library.IBLL;
using Day1.Library.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Library.BLL
{
    public partial class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService()
        {
            this._productRepository = new ProductRepository();
        }

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        /// <summary>
        /// {多少}筆為一組，取{某欄位}值總和
        /// 例如：3筆一組，取Cost總和
        /// </summary>
        /// <param name="field">欲加總欄位</param>
        /// <param name="num">以多少筆為一組</param>
        /// <returns></returns>
        public int[] GroupSum(string field, int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("");
            }
            if (num == 0)
            {
                return new[] { 0 };
            }

            var productList = this._productRepository.GetAll();

            var dictionarilizedSource = productList.Select(ObjectAsDictionary).ToList();
            if (!dictionarilizedSource.First().ContainsKey(field))
            {
                throw new ArgumentException("");
            }

            var chunkedList = Chunk(dictionarilizedSource, num);

            return chunkedList.Select(list => list.Aggregate(0, (sum, obj) => sum += (int)obj[field]))
                .ToArray();
        }

        private static Dictionary<string, object> ObjectAsDictionary(object source)
        {
            return source.GetType().GetProperties().ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );
        }

        private static IEnumerable<List<T>> Chunk<T>(IEnumerable<T> collection, int chunkSize) where T : class
        {
            return collection.Select((obj, idx) => new { obj, idx })
                .GroupBy(part => part.idx / chunkSize)
                .Select(group => group.Select(part => part.obj).ToList())
                .ToList();
        }
    }
}
