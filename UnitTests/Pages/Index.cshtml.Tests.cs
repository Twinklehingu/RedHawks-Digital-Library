using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Pages.Index
{
    /// <summary>
    /// Index test unit test
    /// </summary>
    public class IndexTests
    {
        
        #region TestSetup
        public static IndexModel pageModel;

        /// <summary>
        /// Test Initialized.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();
            JsonFileProductService productService;
            productService = TestHelper.ProductService;
            pageModel = new IndexModel(MockLoggerDirect, productService)
            {
            };
        }
        #endregion TestSetup
        
        /// <summary>
        /// test onGet returns books.
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}