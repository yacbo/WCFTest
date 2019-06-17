using MyService;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace httpPost
{
    class Program
    {
        static void Main(string[] args)
        {
            string ServerPage = "http://127.0.0.1:11000" + "/alarmIBMS/alarmNotify";
            List<AppAlarmDTO> alarm = new List<AppAlarmDTO>() { new AppAlarmDTO() { AlarmDesc = "123123" } };//
            var input = new { alarmId = alarm };
            string json = JsonConvert.SerializeObject(input);
            HttpConnectToServer(ServerPage, json);



            string ServerPage1 = "http://127.0.0.1:11000" + "/parkRecordIBMS/createBlacklistRecord";
            CarPassRecordDTO car = new CarPassRecordDTO();
            car.carPlate = "65421";
            string json1 = JsonConvert.SerializeObject(car);
            HttpConnectToServer(ServerPage1, json1);

            string ServerPage3 = "http://127.0.0.1:11000/doorRecordIBMS/createBlacklistRecord";
            DoorLogDTO door = new DoorLogDTO();
            var aIsoDateTimeConverter = new IsoDateTimeConverter(); 
            aIsoDateTimeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            var json3 = JsonConvert.SerializeObject(door, Formatting.Indented, aIsoDateTimeConverter);
            HttpConnectToServer(ServerPage3, json3);
        }
        public static string HttpConnectToServer(string ServerPage, string json)
        {
            //创建请求
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(ServerPage);
            request.Method = "POST";
            request.ContentType = "text/json";
            //创建输入流

            //string paraUrlCoded = System.Web.HttpUtility.UrlEncode("paramaters");
            //paraUrlCoded += "=" + System.Web.HttpUtility.UrlEncode(json);

            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(json);
            //设置请求的ContentLength   
            request.ContentLength = payload.Length;
            //发送请求，获得请求流  

            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                Console.Write("连接服务器失败!");
            }
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流


            //读取返回消息
            string res = string.Empty;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                res = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                return null;//连接服务器失败
            }
            return res;
        }
    }
}
