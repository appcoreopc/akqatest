using AkqaDataServices.DataModel;
using AkqaWebApi.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AkqaWebApiTest.Util
{
    [TestClass]
    public class HttpResultIntentionTest : TestBase
    {


        [TestMethod]
        public void ReturnJson()
        {
            var userAmountFakeData = new List<UserAmount>
            {
                JeremyUser,
                RobUser,
                NickUser
            };

            var result = HttpResultIntention.GetStatusCode(ActionIntent.Get, true, userAmountFakeData);

            Assert.IsNotNull(result);

            var restResult = result as JsonResult;
            if (restResult != null)
            {
                var data = restResult.Value as IList<UserAmount>;
                Assert.IsTrue(data.Count == 3);
                Assert.AreEqual(JeremyUser.Username, data[0].Username);
                Assert.AreEqual(JeremyUser.Amount, data[0].Amount);
            }

        }

        [TestMethod]
        public void ReturnJsonForNullData()
        {
            var result = HttpResultIntention.GetStatusCode(ActionIntent.Get, true, null);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SaveReturn201Sucessfull()
        {
            var result = HttpResultIntention.GetStatusCode(ActionIntent.Save, true, null);

            Assert.IsNotNull(result);
            var restResponse = (result as ObjectResult);

            if (restResponse != null)
                Assert.IsTrue(restResponse.StatusCode == 201);
        }

        [TestMethod]
        public void FailedSaveReturnBadRequest()
        {
            var result = HttpResultIntention.GetStatusCode(ActionIntent.Save, false, null);

            Assert.IsNotNull(result);
            var restResponse = (result as StatusCodeResult);

            if (restResponse != null)
                Assert.IsTrue(restResponse.StatusCode == 204);

        }
    }
}
