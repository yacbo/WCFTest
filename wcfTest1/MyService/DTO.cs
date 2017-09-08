using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    [DataContract]
    public class DoorLogDTO
    {
        [DataMember]
        public int LogId
        {
            get;
            set;
        }

        [DataMember]
        public string SwapTime
        {
            get;
            set;
        }

        [DataMember]
        public int DoorId
        {
            get;
            set;
        }

        [DataMember]
        public bool SwapResult
        {
            get;
            set;
        }

        [DataMember]
        public string CardId
        {
            get;
            set;
        }

        [DataMember]
        public int CardType
        {
            get;
            set;
        }

        [DataMember]
        public string OwnerName
        {
            get;
            set;
        }

        [DataMember]
        public string Desc
        {
            get;
            set;
        }
        [DataMember]
        public string DoorName
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "LogId:" + LogId +  ",DoorId:" + DoorId + ",CardType:" + CardType + ",OwnerName:" + OwnerName + ",CardType:" + CardType + ",Desc:" + Desc + ",DoorName:" + DoorName;
        }
    }

    [DataContract]
    public class CarPassRecordDTO
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        [DataMember]
        public string carPlate { set; get; }
        /// <summary>
        /// 经过时间（yyyy-MM-dd HH:mm:ss）
        /// </summary>
        [DataMember]
        public string passTime { set; get; }
        /// <summary>
        /// 通行方向，0-入场，1-离场
        /// </summary>
        [DataMember]
        public int passType { set; get; }
        /// <summary>
        /// 车道唯一标识
        /// </summary>
        [DataMember]
        public string laneId { set; get; }

        public override string ToString()
        {
            return "carPlate:" + carPlate + ",passTime:" + passTime + ",passType:" + passType + ",laneId:" + laneId;
        }
    }

    [DataContract]
    public class HisAlarmDTO
    {
        [DataMember]
        public int AlarmId
        {
            get;
            set;
        }

        [DataMember]
        public string AlarmTime
        {
            get;
            set;
        }

        [DataMember]
        public int AlarmCode
        {
            get;
            set;
        }

        [DataMember]
        public int SubsysId
        {
            get;
            set;
        }

        [DataMember]
        public string AlarmDesc
        {
            get;
            set;
        }

        [DataMember]
        public string AlarmLocation
        {
            get;
            set;
        }

        [DataMember]
        public int AlarmObjectid
        {
            get;
            set;
        }

        [DataMember]
        public int Status
        {
            get;
            set;
        }

        [DataMember]
        public DateTime? AlarmAcktime
        {
            get;
            set;
        }

        [DataMember]
        public string AlarmAckuser
        {
            get;
            set;
        }

        [DataMember]
        public DateTime? AlarmProctime
        {
            get;
            set;
        }

        [DataMember]
        public string AlarmProcuser
        {
            get;
            set;
        }

        [DataMember]
        public string AlarmProcdesc
        {
            get;
            set;
        }

        [DataMember]
        public DateTime? AlarmRecovertime
        {
            get;
            set;
        }

        [DataMember]
        public string AlarmRecoveruser
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("AlarmId:{0} Time:{1} AlarmCode:{2} SubsysId:{3} Desc:{4} Location:{5} Objectid:{6} Acktime:{7} Ackuser:{8} Proctime:{9} Procuser:{10} Procdesc:{11} Recovertime:{12} Recoveruser:{13}",
            AlarmId, AlarmTime, AlarmCode, SubsysId, AlarmDesc, AlarmLocation, AlarmObjectid, AlarmAcktime, AlarmAckuser, AlarmProctime, AlarmProcuser, AlarmProcdesc, AlarmRecovertime, AlarmRecoveruser);
        }

    }

    [DataContract]
    public class AppAlarmDTO : HisAlarmDTO
    {
        /// <summary>
        /// The subsys name
        /// </summary>
        [DataMember]
        public string SubsysName { set; get; }
        [DataMember]
        public string AlarmName { set; get; }
        [DataMember]
        public string ObjectName { set; get; }
        /// <summary>
        /// The alarm level
        /// </summary>
        [DataMember]
        public string AlarmLevel;

        public override string ToString()
        {
            return "SubsysName:" + SubsysName + ",AlarmName:" + AlarmName + ",ObjectName:" + ObjectName + ",AlarmLevel:" + AlarmLevel;
        }
    }


    [DataContract]
    public class Alarm
    {
        [DataMember]
        public List<AppAlarmDTO> alarmId
        {
            set;
            get;
        }
    }

}
