using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSharp_Web_Notification_Sample
{
    public partial class ServerPushData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPushAllUsers_Click(object sender, EventArgs e)
        {

            string serverKey = "AAAAN8t6HnQ:APA91bGCvCr9S3FMvu-uCByrUSE3-KWjtL8iUW20xaRe9GsCFlXiuz23f4mpupI9PPP9V5ZXvtxzglbm-18daM35hwamVleztf34wWnzjfTGU-7-gaF9NRb2d3tVSG91xkli5hrwhSUlHC4PPis500LJMVwWFVoElA";

            var files = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "user_token");

            var wc = new System.Net.WebClient();
            wc.Headers.Add("Authorization", "key="+ serverKey);
            wc.Headers.Add("Content-Type", "application/json");
            wc.Encoding = System.Text.Encoding.UTF8;

            if (files != null)
            {

                foreach (var file in files)
                {

                    var token = System.IO.File.ReadAllText(file);
                    Response.Write("TOKEN:" + token.ToString() + "<br>");


                    var d = new PushRequestInfo();
                    d.registration_ids = new List<string>();
                    d.registration_ids.Add(token);

                    d.priority = "normal";
                    d.data = new Data();
                    d.data.body = "Donma TEST";
                    d.data.title = "HI,許當麻123";

                    var res = wc.UploadString("https://fcm.googleapis.com/fcm/send", Newtonsoft.Json.JsonConvert.SerializeObject(d));
                    Response.Write(res + "<br><br>");
                }
            }
        }
    }
}