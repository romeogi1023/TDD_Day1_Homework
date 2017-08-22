using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1.Library.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day1.Library.IDAL;
using NSubstitute;
using FluentAssertions;
using Day1.Library.Models;

namespace Day1.Library.BLL.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {
        /// <summary>
        /// 測試的假資料
        /// </summary>
        /// <returns></returns>
        private List<Product> FakeData()
        {
            List<Product> ProductList = new List<Product>();

            ProductList.Add(new Product() { Id = "1", Cost = 1, Revenue = 11, SellPrice = 21 });
            ProductList.Add(new Product() { Id = "2", Cost = 2, Revenue = 12, SellPrice = 22 });
            ProductList.Add(new Product() { Id = "3", Cost = 3, Revenue = 13, SellPrice = 23 });
            ProductList.Add(new Product() { Id = "4", Cost = 4, Revenue = 14, SellPrice = 24 });
            ProductList.Add(new Product() { Id = "5", Cost = 5, Revenue = 15, SellPrice = 25 });
            ProductList.Add(new Product() { Id = "6", Cost = 6, Revenue = 16, SellPrice = 26 });
            ProductList.Add(new Product() { Id = "7", Cost = 7, Revenue = 17, SellPrice = 27 });
            ProductList.Add(new Product() { Id = "8", Cost = 8, Revenue = 18, SellPrice = 28 });
            ProductList.Add(new Product() { Id = "9", Cost = 9, Revenue = 19, SellPrice = 29 });
            ProductList.Add(new Product() { Id = "10", Cost = 10, Revenue = 20, SellPrice = 30 });
            ProductList.Add(new Product() { Id = "11", Cost = 11, Revenue = 21, SellPrice = 31 });

            return ProductList;
        }

        /// <summary>
        /// 該11筆資料，如果要3筆成一組，取得Cost的總和的話，預期結果是 6,15, 24, 21
        /// </summary>
        [TestMethod()]
        public void GroupSumTest_11筆資料_3筆一組_取得Cost欄位值總和_預期結果_6_15_24_21()
        {
            //arrange
            IProductRepository productRepository = Substitute.For<IProductRepository>();
            productRepository.GetAll().Returns(FakeData());
            var target = new ProductService(productRepository);
            var field = "Cost";
            var num = 3;

            var expected = new int[] { 6, 15, 24, 21 };

            //act
            var actual = target.GroupSum(field, num);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 該11筆資料，如果是4筆一組，取得 Revenue 總和的話，預期結果會是 50,66,60
        /// </summary>
        [TestMethod()]
        public void GroupSumTest_11筆資料_4筆一組_取得Revenue欄位值總和_預期結果_50_66_60()
        {
            //arrange
            IProductRepository productRepository = Substitute.For<IProductRepository>();
            productRepository.GetAll().Returns(FakeData());
            var target = new ProductService(productRepository);
            var field = "Revenue";
            var num = 4;

            var expected = new int[] { 50, 66, 60 };

            //act
            var actual = target.GroupSum(field, num);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 筆數輸入負數，預期會拋 ArgumentException
        /// </summary>
        [TestMethod()]
        public void GroupSumTest_11筆資料_負2筆一組_取得Revenue欄位值總和_預期結果_ArgumentException()
        {
            //arrange
            IProductRepository productRepository = Substitute.For<IProductRepository>();
            productRepository.GetAll().Returns(FakeData());
            var target = new ProductService(productRepository);
            var field = "Revenue";
            var num = -2;

            //act
            Action act = () => target.GroupSum(field, num);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        /// <summary>
        /// 尋找的欄位若不存在，預期會拋 ArgumentException
        /// </summary>
        [TestMethod()]
        public void GroupSumTest_11筆資料_4筆一組_取得不存在的欄位值總和_預期結果_ArgumentException()
        {
            //arrange
            IProductRepository productRepository = Substitute.For<IProductRepository>();
            productRepository.GetAll().Returns(FakeData());
            var target = new ProductService(productRepository);
            var field = "test";
            var num = 4;

            //act
            Action act = () => target.GroupSum(field, num);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        /// <summary>
        /// 筆數若輸入為0, 則傳回0
        /// </summary>
        [TestMethod()]
        public void GroupSumTest_11筆資料_0筆一組_取得Revenue欄位值總和_預期結果_0()
        {
            //arrange
            IProductRepository productRepository = Substitute.For<IProductRepository>();
            productRepository.GetAll().Returns(FakeData());
            var target = new ProductService(productRepository);
            var field = "Revenue";
            var num = 0;

            var expected = new int[] { 0 };

            //act
            var actual = target.GroupSum(field, num);

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}