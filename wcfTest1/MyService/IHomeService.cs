using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    [ServiceContract]
    public interface IHomeService
    {
        [OperationContract]
        int GetLength(string name);

        //门记录
        [OperationContract]
        [WebInvoke(UriTemplate = "/doorRecordIBMS/createBlacklistRecord", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void DoorRecord(DoorLogDTO doorLog);  

        //车记录
        [OperationContract]
        [WebInvoke(UriTemplate = "/parkRecordIBMS/createBlacklistRecord", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void CarRecord(CarPassRecordDTO carLog);

        ////告警记录
        [OperationContract]
        [WebInvoke(UriTemplate = "/alarmIBMS/alarmNotify", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void AlarmRecord(Object almList);

    }


    [ServiceContract]
    public interface IHttpsService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/Test", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<int> Test(); 
    }

}
