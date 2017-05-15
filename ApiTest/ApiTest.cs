using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace ApiTest
{
    [TestClass]
    public class ApiTest
    {
        const string BaseUrl = "http://kn-ktapp.herokuapp.com";

        [TestMethod]
        public void TestBaseResponse()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("/apitest/accounts", Method.GET);
            IRestResponse response = client.Execute(request);            
            if (response.ErrorException != null)
            {
                Assert.Fail("Ответ не получен");
            }

            string content = response.Content;
            string expected = "[{\"design_url\":\"/content/images/MasterCard_Gold_EMV_PayPass_ЕжикСобака.png\",\"transactions_total_amount\":0,\"tariff_avg_month_balance\":472465,\"type\":1,\"closing_date\":\"2019-10-31T00:00:00\",\"partial_withdraw_available\":1,\"refill_available\":1,\"blocked_amount\":-1000.0,\"scheme_id\":\"xint\",\"pan\":\"5449***1331\",\"account_id\":12345678,\"title_small\":\"MasterCard1331\",\"title\":\"Master1\",\"balance\":1000.0,\"currency\":\"RUR\",\"isSalary\":false},{\"design_url\":\"/content/images/MasterCard_Gold_EMV_PayPass_ЕжикСобака.png\",\"transactions_total_amount\":0,\"tariff_avg_month_balance\":472465,\"type\":1,\"closing_date\":\"2019-10-31T00:00:00\",\"partial_withdraw_available\":1,\"refill_available\":1,\"blocked_amount\":-100.0,\"scheme_id\":\"xint\",\"pan\":\"5449***1332\",\"account_id\":12345679,\"title_small\":\"MasterCard1332\",\"title\":\"Master2\",\"balance\":100.0,\"currency\":\"RUR\",\"isSalary\":false},{\"design_url\":\"/content/images/MasterCard_Gold_EMV_PayPass_ЕжикСобака.png\",\"transactions_total_amount\":0,\"tariff_avg_month_balance\":472465,\"type\":1,\"closing_date\":\"2019-10-31T00:00:00\",\"partial_withdraw_available\":1,\"refill_available\":1,\"blocked_amount\":-10000.0,\"scheme_id\":\"xint\",\"pan\":\"5449***1333\",\"account_id\":12345680,\"title_small\":\"MasterCard1333\",\"title\":\"Master3\",\"balance\":10000.0,\"currency\":\"RUR\",\"isSalary\":false},{\"design_url\":\"/content/images/MasterCard_Gold_EMV_PayPass_ЕжикСобака.png\",\"transactions_total_amount\":0,\"tariff_avg_month_balance\":472465,\"type\":1,\"closing_date\":\"2019-10-31T00:00:00\",\"partial_withdraw_available\":1,\"refill_available\":1,\"blocked_amount\":-2000.0,\"scheme_id\":\"xint\",\"pan\":\"5449***1334\",\"account_id\":12345681,\"title_small\":\"MasterCard1334\",\"title\":\"Master4\",\"balance\":2000.0,\"currency\":\"RUR\",\"isSalary\":false},{\"design_url\":\"/content/images/MasterCard_Gold_EMV_PayPass_ЕжикСобака.png\",\"transactions_total_amount\":0,\"tariff_avg_month_balance\":472465,\"type\":1,\"closing_date\":\"2019-10-31T00:00:00\",\"partial_withdraw_available\":1,\"refill_available\":1,\"blocked_amount\":-4000.0,\"scheme_id\":\"xint\",\"pan\":\"5449***1335\",\"account_id\":12345682,\"title_small\":\"MasterCard1335\",\"title\":\"Master5\",\"balance\":4000.0,\"currency\":\"RUR\",\"isSalary\":false},{\"design_url\":\"/content/images/MasterCard_Gold_EMV_PayPass_ЕжикСобака.png\",\"transactions_total_amount\":0,\"tariff_avg_month_balance\":472465,\"type\":1,\"closing_date\":\"2019-10-31T00:00:00\",\"partial_withdraw_available\":1,\"refill_available\":1,\"blocked_amount\":-6000.0,\"scheme_id\":\"xint\",\"pan\":\"5449***1336\",\"account_id\":12345683,\"title_small\":\"MasterCard1336\",\"title\":\"Master6\",\"balance\":6000.0,\"currency\":\"RUR\",\"isSalary\":false}]";
            Assert.AreEqual(expected, content);
        }

        [TestMethod]
        public void TestSingleResponse()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("/apitest/accounts/{id}", Method.GET);
            string account_id = "12345678";
            request.AddUrlSegment("id", account_id);
            IRestResponse response = client.Execute(request);
            if (response.ErrorException != null)
            {
                Assert.Fail("Ответ не получен");
            }

            string content = response.Content;

            dynamic jsonObject = JObject.Parse(content);
            int recieved_id = (int)jsonObject.account_id;
            Assert.AreEqual(Int32.Parse(account_id), recieved_id);
        }
    }
}
