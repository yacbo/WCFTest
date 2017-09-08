using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyService
{
    public class HomeService : IHomeService
    {

        public int GetLength(string name)
        {
            throw new NotImplementedException();
        }

        public void DoorRecord(DoorLogDTO doorLog)
        {
           if(doorLog!=null)
           {
               Console.WriteLine("门记录："+doorLog.ToString());
               WriteTxt("门记录：" + doorLog.ToString());
               Console.WriteLine();
           }
        }

        public void CarRecord(CarPassRecordDTO carLog)
        {
            if (carLog!=null)
            {
                Console.WriteLine("车辆记录："+carLog.ToString());
                WriteTxt("车辆记录：" + carLog.ToString());
                Console.WriteLine();
            }
            
        }

        public void AlarmRecord(Object alarmId)
        {
            string xml = OperationContext.Current.RequestContext.RequestMessage.ToString();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            Console.WriteLine("告警记录:"+json);
            WriteTxt("告警记录:"+json);
            Console.WriteLine();
        }


        public void WriteTxt(string str)
        {
            string path = System.Environment.CurrentDirectory +"日志" ;
            using (StreamWriter sw = new StreamWriter(path, true))   //false:不允许跟在后面写
            {
                sw.WriteLine("["+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")+"]" + str);
            }
        }

    }
}
