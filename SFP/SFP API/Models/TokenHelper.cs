using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PUCIT.AIMRL.SFP.MainApp.Models
{
    public class TokenHelper
    {

        public static Dictionary<string, string> GetTokenDetails()
        {
            Dictionary<string, string> tokenDetails = null;
            try
            {
                using (var client = new HttpClient())
                {
                    var login = new Dictionary<string, string>
                   {
                       {"grant_type", "password"},
                       {"username", "aaa-abbc-eeed-eedede"},
                       {"password",  "zyzaadfadf-adfadsfasdf"},
                   };

                    var resp = client.PostAsync("http://localhost:60239/Token", new FormUrlEncodedContent(login));

                    var r = resp.Result.Content.ReadAsStringAsync().Result;

                    if (resp.IsCompleted)
                    {
                        //var result = resp.Result.Content.ReadAsStringAsync().Result;

                        if (r.Contains("access_token"))
                        {
                            tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(r);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return tokenDetails;
        }
    }
}
