using Microsoft.Extensions.Options;
using Nexmo.Api;
using Nexmo.Api.Request;
using System;
using TodoApp.Models.User;
using Twilio;
using Twilio.Rest.Preview.AccSecurity.Service;

namespace TodoApp.Common.Helpers
{
    public static class SMSHelper
    {
        private static Client client = new Client(creds: new Credentials
        {
            ApiKey = "453e872f",
            ApiSecret = "AOraziJsNA4Vh7QL"
        });

        public static bool SendMessage(string text, string to)
        {
            //var client = new Client(creds: new Credentials
            //{
            //    ApiKey = "453e872f",
            //    ApiSecret = "AOraziJsNA4Vh7QL"
            //});
            var results = client.SMS.Send(request: new SMS.SMSRequest
            {
                from = "Nexmo",
                to = "84974076085",
                text = "Your verify number: " + GenerateVerifyNumber()
            });

            return true;
        }

        public static string MakeRequest()
        {
            //var start = client.NumberVerify.Verify(new NumberVerify.VerifyRequest
            //{
            //    number = "84974076085",
            //    brand = "Nexmo",
            //    code_length = "4"
            //});

            //return start.request_id;


            //==================

            const string accountSid = "ACcc94bdb5e63f5d18a39cb479b39ccbde";
            const string authToken = "20c2e1517fddd3dc6f83cbae74dfe9c9";

            TwilioClient.Init(accountSid, authToken);

            var verification = VerificationResource.Create(
                to: "+84774543399",
                channel: "sms",
                pathServiceSid: "VAf73a8e1e711d3d54b9e738823e3543ff"
            );

            return "abc";
        }

        public static string CheckRequest(VerifyModel verifyModel)
        {
            //var result = client.NumberVerify.Check(new NumberVerify.CheckRequest
            //{
            //    request_id = verifyModel.RequestId,
            //    code = verifyModel.Code
            //});

            //return result.error_text;

            //=========================

            const string accountSid = "ACcc94bdb5e63f5d18a39cb479b39ccbde";
            const string authToken = "20c2e1517fddd3dc6f83cbae74dfe9c9";

            TwilioClient.Init(accountSid, authToken);

            var verificationCheck = VerificationCheckResource.Create(
                to: "+84774543399",
                code: verifyModel.Code,
                pathServiceSid: "VAf73a8e1e711d3d54b9e738823e3543ff"
            );

            return "xyz";
        }

        public static string GenerateVerifyNumber()
        {
            Random generator = new Random();
            return generator.Next(0, 999999).ToString("D6");
        }
    }
}
