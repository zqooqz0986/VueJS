using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VueJS.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        // POST api/values
        [HttpPost]
        [HttpGet]
        [Route("BuyStep2")]
        public async Task BuyStep2(string JSESSIONID, string IRS_SESSION, string THSRC_IRS)
        {
            var step2 = "https://irs.thsrc.com.tw/IMINT/?wicket:interface=:1:BookingS2Form::IFormSubmitListener";       
            //var cookie2 = "JSESSIONID=7A34C1B96C0EC01F4AC7F78A6231D192; IRS-SESSION=1525179260; THSRC-IRS=!1PsAj/EhjdJpMMIrtm+Lom00d6XFOewu4KPcX67z7mhUQt4VqILXFockNH5Rnm90+gx86L9v8JMytg==;";                
            //var formdata2 = "BookingS2Form%3Ahf%3A0=&TrainQueryDataViewPanel%3ATrainGroup=radio102&SubmitButton=%E7%A2%BA%E8%AA%8D%E8%BB%8A%E6%AC%A1";
            var uri = new Uri(step2); 
            
            var handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            
            handler.CookieContainer.Add(uri, new Cookie("JSESSIONID", JSESSIONID));
            handler.CookieContainer.Add(uri, new Cookie("IRS-SESSION", IRS_SESSION));
            handler.CookieContainer.Add(uri, new Cookie("THSRC-IRS", THSRC_IRS));
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = uri;
                var formKeyValues = new Dictionary<string, string>();
                formKeyValues.Add("BookingS2Form:hf:0", string.Empty);
                formKeyValues.Add("TrainQueryDataViewPanel:TrainGroup", "radio102");
                formKeyValues.Add("SubmitButton", "確認車次");                
                var body = new FormUrlEncodedContent(formKeyValues);
                var response = await client.PostAsync("", body);
            }
        }

        [HttpPost]
        [HttpGet]
        [Route("BuyStep3")]
        public async Task BuyStep3(string JSESSIONID, string IRS_SESSION, string THSRC_IRS)
        {
            var step3 = "https://irs.thsrc.com.tw/IMINT/?wicket:interface=:2:BookingS3Form::IFormSubmitListener";            
            //var cookie3 ="name=value; JSESSIONID=7A34C1B96C0EC01F4AC7F78A6231D192; _ga=GA1.3.1060086878.1509714283; __utma=214205650.1060086878.1509714283.1512216207.1524390445.2; __utmz=214205650.1524390445.2.2.utmcsr=google|utmccn=(organic)|utmcmd=organic|utmctr=(not%20provided); IRS-SESSION=1525179260; THSRC-IRS=!1PsAj/EhjdJpMMIrtm+Lom00d6XFOewu4KPcX67z7mhUQt4VqILXFockNH5Rnm90+gx86L9v8JMytg==; __utma=98625990.1060086878.1509714283.1524390446.1525179260.4; __utmc=98625990; __utmz=98625990.1525179260.4.4.utmcsr=google|utmccn=(organic)|utmcmd=organic|utmctr=(not%20provided); __utmt=1; __utmb=98625990.3.10.1525179260";               
            //var formdata3 ="BookingS3FormSP%3Ahf%3A0=&diffOver=1&idInputRadio=radio33&idInputRadio%3AidNumber=s123306056&eaiPhoneCon%3AphoneInputRadio=radio44&eaiPhoneCon%3AphoneInputRadio%3AmobilePhone=0976736358&email=zqooqz0986%40gmail.com&agree=on&isGoBackM=&backHome=";
                
            var uri = new Uri(step3); 
            var handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            
            handler.CookieContainer.Add(uri, new Cookie("JSESSIONID", JSESSIONID));
            handler.CookieContainer.Add(uri, new Cookie("IRS-SESSION", IRS_SESSION));
            handler.CookieContainer.Add(uri, new Cookie("THSRC-IRS", THSRC_IRS));

            using (var client = new HttpClient())
            {              
                client.BaseAddress = uri;              
                var formKeyValues = new Dictionary<string, string>();
                formKeyValues.Add("BookingS3FormSP:hf:0:", string.Empty);
                formKeyValues.Add("diffOver:", "1");
                formKeyValues.Add("idInputRadio:", "radio33");                
                formKeyValues.Add("idInputRadio:idNumber:", "s123306056");
                formKeyValues.Add("eaiPhoneCon:phoneInputRadio:", "radio44");
                formKeyValues.Add("eaiPhoneCon:phoneInputRadio:mobilePhone:", "0976736358");
                formKeyValues.Add("email:", "zqooqz0986@gmail.com");
                formKeyValues.Add("agree:", "on");
                formKeyValues.Add("isGoBackM:", string.Empty);
                formKeyValues.Add("backHome:", string.Empty);
                var body = new FormUrlEncodedContent(formKeyValues);
                var response = await client.PostAsync("", body);
            }
        }
    }
}
