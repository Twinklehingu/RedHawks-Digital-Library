using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{
    /// <summary>
    /// Unit test for the delete functionality
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup
        public static DeleteModel pageModel;
        /// <summary>
        ///Test initialized.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
            {   // Defualt construtor
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// get method to get the valid product.
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("Refactoring: Improving the Design of Existing Code");
            //REST Get request Loads the data.

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            //verifiying two object are equal.
            Assert.AreEqual("Refactoring: Improving the Design of Existing Code", pageModel.Product.Title);
            //considering equal if both are null or both have same value.       
        }

        /// <summary>
        /// when product id is null it will redirect to the read page.
        /// </summary>
        [Test]
        public void OnGet_Null_Product_Id_Return_To_Index_Page()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet(null) as RedirectToPageResult;
            //Targets a registered route.

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            //verifiying two object are equal.
            Assert.AreEqual(true, result.PageName.Contains("Index"));
            //considering equal if both are null or both have same value.
        }
        #endregion OnGet

        #region OnPost
        /// <summary>
        /// onPost when product id is invalid it will return to notvalid page.
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange

            // First Create the product to delete
            pageModel.Product = TestHelper.ProductService.CreateData();
            //adding title.
            pageModel.Product.Title = "Example to Delete";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            //verifiying two object are equal.
            Assert.AreEqual(true, result.PageName.Contains("Index"));
            //considering equal if both are null or both have same value.

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }

        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}