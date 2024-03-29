using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



using S7.Net;

namespace Purification
{
    public class PurifySystem
    {
        //private static readonly PurifySystem instance = new PurifySystem();
        //private PurifySystem()
        //{
        //}
        //public static PurifySystem Instance
        //{
        //    get { return instance; }
        //}

        public PurifySystem()
        {
            try
            {
                //siemens = new SiemensControl(SiemensCpuType.S7200Smart, "192.168.1.1", 0, 0, 1);
                //siemens.Connect();

            }
            catch (Exception)
            {
            }
        }

        #region 交互文件

        SiemensControl siemens;

        #endregion



        #region 交互方法

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="ipAddress">ip地址</param>
        /// <param name="cpuType">cpu类型 默认为S7smart200</param>
        /// <param name="rack">plc机架 默认为0</param>
        /// <param name="slot">卡槽 默认为0</param>
        /// <param name="dbint">内存区域 默认为1</param>
        /// <returns></returns>
        public bool Connect(string ipAddress, SiemensCpuType cpuType = SiemensCpuType.S7200Smart,  int rack=0, int slot=0, int dbint=1)
        {
            try
            {
                siemens = new SiemensControl(cpuType, ipAddress, rack, slot, dbint);
                return siemens.Connect();

            }
            catch(Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void DisConnect()
        {
            try
            {
                siemens.Disconnect();
            }
            catch(Exception)
            {

            }
            
        }

        /// <summary>
        /// 连接状态
        /// </summary>
        /// <returns></returns>
        public bool IsConnect()
        {
            try
            {
                return siemens.IsConnected;
            }
            catch(Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// 读取节点
        /// </summary>
        /// <typeparam name="T"> bool int float</typeparam>
        /// <param name="Note"> 节点</param>
        /// <returns></returns>
        public T Read<T>(SiemensNote Note)
        {
            try
            {
                string NoteName = SiemensNoteExtensions.ToStringValue(Note);
                return siemens.ReadPLC<T>(NoteName);
            }
            catch(Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 写入节点
        /// </summary>
        /// <typeparam name="T"> bool int float</typeparam>
        /// <param name="Note">节点</param>
        /// <param name="Data">数据</param>
        public void Write<T>(SiemensNote Note, T Data)
        {
            try
            {
                string NoteName = SiemensNoteExtensions.ToStringValue(Note);
                siemens.WritePLC<T>(NoteName, Data);
            }
            catch(Exception)
            {

            }
        }

        #endregion




    }

    #region 西门子配置文件

    public enum SiemensCpuType
    {
        S7200 = 0,
        S7200Smart = 1,
        S7300 = 2,
        S7400 = 3,
        S71200 = 4,
        S71500 = 5
    }

    public enum SiemensNote
    {
        #region 烘箱

        /// <summary>
        /// 烘箱抽气阀 bool
        /// </summary>
        BakeOvenBleed,
        /// <summary>
        /// 烘箱排气阀 bool
        /// </summary>
        BakeOvenExhaust,
        /// <summary>
        /// 烘箱补气阀 bool
        /// </summary>
        BakeOvenAerate,
        /// <summary>
        /// 烘箱内门压紧 bool
        /// </summary>
        BakeOvenInnerdoor1Press,
        /// <summary>
        /// 烘箱外门压紧 bool
        /// </summary>
        BakeOvenOuterdoor1Press,
        /// <summary>
        /// 烘箱内门松开 bool
        /// </summary>
        BakeOvenInnerdoor1Release,
        /// <summary>
        /// 烘箱外门松开 bool
        /// </summary>
        BakeOvenOuterdoor1Release,
        /// <summary>
        /// 烘箱内门升 bool 按1松0
        /// </summary>
        BakeOvenInnerdoor2Up,
        /// <summary>
        /// 烘箱外门升 bool 按1松0
        /// </summary>
        BakeOvenOuterdoor2Up,
        /// <summary>
        /// 烘箱内门降 bool 按1松0
        /// </summary>
        BakeOvenInnerdoor2Down,
        /// <summary>
        /// 烘箱外门降 bool 按1松0
        /// </summary>
        BakeOvenOuterdoor2Down,
        /// <summary>
        /// 烘箱内门自动开 bool
        /// </summary>
        BakeOvenInnerdoorOpen,
        /// <summary>
        /// 烘箱外门自动开 bool
        /// </summary>
        BakeOvenOuterdoorOpen,
        /// <summary>
        /// 烘箱内门自动关 bool
        /// </summary>
        BakeOvenInnerdoorClose,
        /// <summary>
        /// 烘箱外门自动关 bool
        /// </summary>
        BakeOvenOuterdoorClose,
        /// <summary>
        /// 烘箱外门自动停 bool
        /// </summary>
        BakeOvenOuterdoorStop,
        /// <summary>
        /// 烘箱内门自动停 bool
        /// </summary>
        BakeOvenInnerdoorStop,
        /// <summary>
        /// 烘箱外门开到位
        /// </summary>
        BakeOvenOuterdoorUpSta,
        /// <summary>
        /// 烘箱外门关到位
        /// </summary>
        BakeOvenOuterdoorDownSta,
        /// <summary>
        /// 烘箱外门压紧到位
        /// </summary>
        BakeOvenOuterdoorPressSta,
        /// <summary>
        /// 烘箱外门松开到位
        /// </summary>
        BakeOvenOuterdoorReleaseSta,
        /// <summary>
        /// 烘箱内门开到位
        /// </summary>
        BakeOvenInnerdoorUpSta,
        /// <summary>
        /// 烘箱内门关到位
        /// </summary>
        BakeOvenInnerdoorDownSta,
        /// <summary>
        /// 烘箱内门压紧到位
        /// </summary>
        BakeOvenInnerdoorPressSta,
        /// <summary>
        /// 烘箱内门松开到位
        /// </summary>
        BakeOvenInnerdoorReleaseSta,


        /// <summary>
        /// 烘箱压力 float
        /// </summary>
        BakeOvenPressure,
        /// <summary>
        /// 烘箱真空 short 
        /// </summary>
        BakeOvenVacuum,
        /// <summary>
        /// 烘箱上板温度 float 
        /// </summary>
        BakeOvenUPtemp,
        /// <summary>
        /// 烘箱下板温度 float 
        /// </summary>
        BakeOvenDowntemp,
        /// <summary>
        /// 烘箱加热目标温度 float 
        /// </summary>
        BakeOvenTargettemp,
        /// <summary>
        /// 烘箱加热报警温度 float 
        /// </summary>
        BakeOvenAlarmtemp,
        /// <summary>
        /// 烘箱保温时间小时 short 小时
        /// </summary>
        BakeOvenHoldingTimeH,
        /// <summary>
        /// 烘箱保温时间分钟 short 分钟
        /// </summary>
        BakeOvenHoldingTimeM,
        /// <summary>
        /// 烘箱已保温时间小时 short 小时
        /// </summary>
        BakeOvenPassedTimeH,
        /// <summary>
        /// 烘箱已保温时间分钟 short 分钟
        /// </summary>
        BakeOvenPassedTimeM,
        /// <summary>
        /// 烘箱报警压力 float
        /// </summary>
        BakeOvenAlarmPressure,
        /// <summary>
        /// 烘箱上板P
        /// </summary>
        BakeOvenUpHeatPID_P,
        /// <summary>
        /// 烘箱上板I
        /// </summary>
        BakeOvenUpHeatPID_I,
        /// <summary>
        /// 烘箱上板D
        /// </summary>
        BakeOvenUpHeatPID_D,
        /// <summary>
        /// 烘箱上板P
        /// </summary>
        BakeOvenDownHeatPID_P,
        /// <summary>
        /// 烘箱上板I
        /// </summary>
        BakeOvenDownHeatPID_I,
        /// <summary>
        /// 烘箱上板D
        /// </summary>
        BakeOvenDownHeatPID_D,


        /// <summary>
        /// 烘箱抽充压力上限 float 
        /// </summary>
        BakeOvenPFUpPressure,
        /// <summary>
        /// 烘箱抽充压力下限 float 
        /// </summary>
        BakeOvenPFDownPressure,
        /// <summary>
        /// 烘箱抽充次数 short 
        /// </summary>
        BakeOvenPFnum,
        /// <summary>
        /// 烘箱抽充已完成次数 short 
        /// </summary>
        BakeOvenPFCompletednum,
        /// <summary>
        /// 烘箱抽充时间间隔 short 秒
        /// </summary>
        BakeOvenPFinterval,
        /// <summary>
        /// 烘箱手动抽充 bool
        /// </summary>
        BakeOvenPF,


        /// <summary>
        /// 烘箱自动加热1 bool 不包含抽充
        /// </summary>
        BakeOvenAutoHeat1,
        /// <summary>
        /// 烘箱自动加热1 bool 包含抽充
        /// </summary>
        BakeOvenAutoHeat2,

        #endregion

        #region 交换箱

        /// <summary>
        /// 交换箱抽气阀 bool
        /// </summary>
        ExchangeBoxBleed,
        /// <summary>
        /// 交换箱排气阀 short
        /// </summary>
        ExchangeBoxExhaust,
        /// <summary>
        /// 交换箱补气阀 short
        /// </summary>
        ExchangeBoxAerate,
        /// <summary>
        /// 交换箱外门压紧到位
        /// </summary>
        ExchangeBoxOuterdoorPressSta,
        /// <summary>
        /// 交换箱外门松开到位
        /// </summary>
        ExchangeBoxOuterdoorReleaseSta,
        /// <summary>
        /// 交换箱外门电缸压紧 bool
        /// </summary>
        ExchangeBoxOuterdoorElePress,
        /// <summary>
        /// 交换箱外门电缸打开 bool
        /// </summary>
        ExchangeBoxOuterdoorEleRelease,
        /// <summary>
        /// 交换箱外门自动关 bool
        /// </summary>
        ExchangeBoxOuterdoorClose,
        /// <summary>
        /// 交换箱外门自动开 bool
        /// </summary>
        ExchangeBoxOuterdoorOpen,
        /// <summary>
        /// 交换箱外门自动停 bool
        /// </summary>
        ExchangeBoxOuterdoorStop,
        /// <summary>
        /// 交换箱外门电机压紧 bool 按1松0
        /// </summary>
        ExchangeBoxOuterdoorPress,
        /// <summary>
        /// 交换箱外门电机松开 bool 按1松0
        /// </summary>
        ExchangeBoxOuterdoorRelease,
        /// <summary>
        /// 交换箱压力 float 
        /// </summary>
        ExchangeBoxPressure,
        /// <summary>
        /// 交换箱真空 float 
        /// </summary>
        ExchangeBoxVacuum,
        /// <summary>
        /// 交换箱抽充压力上限 float 
        /// </summary>
        ExchangeBoxPFUpPressure,
        /// <summary>
        /// 交换箱抽充压力下限 float 
        /// </summary>
        ExchangeBoxPFDownPressure,
        /// <summary>
        /// 交换箱抽充次数 short 
        /// </summary>
        ExchangeBoxPFnum,
        /// <summary>
        /// 交换箱抽充已完成次数 short 
        /// </summary>
        ExchangeBoxPFCompletednum,
        /// <summary>
        /// 交换箱抽充时间间隔 short 秒
        /// </summary>
        ExchangeBoxPFinterval,
        /// <summary>
        /// 交换箱手动抽充 bool
        /// </summary>
        ExchangeBoxPF,
        /// <summary>
        /// 交换箱报警压力 float
        /// </summary>
        ExchangeBoxAlarmPressure,
        /// <summary>
        /// 交换箱外门速度
        /// </summary>
        ExchangeBoxOuterdoorspeed,



        #endregion

        #region 纯化系统

        /// <summary>
        /// 设定清洗时间 short 分钟
        /// </summary>
        PurifyCleanTime,
        /// <summary>
        /// 清洗剩余时间 short 分钟
        /// </summary>
        PurifyCleanResidueTime,
        /// <summary>
        /// 箱体压力 float
        /// </summary>
        PurifyPressure,
        /// <summary>
        /// 箱体压力上限 float
        /// </summary>
        PurifyUpPressure,
        /// <summary>
        /// 箱体压力下限 float
        /// </summary>
        PurifyDownPressure,
        /// <summary>
        /// 清洗露点 float
        /// </summary>
        PurifyDewpoint,
        /// <summary>
        /// 清洗露点上限 float
        /// </summary>
        PurifyUpDewpoint,
        /// <summary>
        /// 清洗露点下限 float
        /// </summary>
        PurifyDownDewpoint,

        /// <summary>
        /// 再生状态 bool
        /// </summary>
        PurifyRegenerateSta,
        /// <summary>
        /// 再生时间时 short
        /// </summary>
        PurifyRegenerateH,
        /// <summary>
        /// 再生时间分 short
        /// </summary>
        PurifyRegenerateM,
        /// <summary>
        /// 再生时间秒 short
        /// </summary>
        PurifyRegenerateS,

        /// <summary>
        /// 循环 bool
        /// </summary>
        PurifyCirculate,
        /// <summary>
        /// 再生 bool
        /// </summary>
        PurifyRegenerate,
        /// <summary>
        /// 清洗 bool
        /// </summary>
        PurifyClean,
        /// <summary>
        /// 箱体压力确认 bool
        /// </summary>
        PurifyPressureConfirm,
        /// <summary>
        /// 露点自动判断 bool
        /// </summary>
        PurifyDewpointConfirm,

        /// <summary>
        /// 真空泵 bool
        /// </summary>
        PurifyVacuumpumps,

        #endregion

        #region 其他

        /// <summary>
        /// 自动加热流程结束
        /// </summary>
        BakeOvenAutoHeatEnd,

        /// <summary>
        /// 交换箱超压报警
        /// </summary>
        ExchangeBoxOverpressWarning,
        /// <summary>
        /// 烘箱超压报警
        /// </summary>
        BakeOvenOverpressWarning,
        /// <summary>
        /// 交换箱超温报警
        /// </summary>
        BakeOvenOvertempWarning,






        /// <summary>
        /// 报警信息 short
        /// </summary>
        Warning,
        /// <summary>
        /// 伺服电机报警 bool
        /// </summary>
        ServoWarning,

        #endregion

    }

    public static class SiemensNoteExtensions
    {
        private static readonly Dictionary<SiemensNote, string> EnumToStringMapping = new Dictionary<SiemensNote, string>
        {
#region 烘箱
		
        { SiemensNote.BakeOvenBleed, "VW451.5" },
        { SiemensNote.BakeOvenExhaust, "VW451.7" },
        { SiemensNote.BakeOvenAerate, "VW451.6" },
        { SiemensNote.BakeOvenInnerdoor1Press, "V451.1" },
        { SiemensNote.BakeOvenOuterdoor1Press, "V450.3" },
        { SiemensNote.BakeOvenInnerdoor1Release, "V451.2" },
        { SiemensNote.BakeOvenOuterdoor1Release, "V450.4" },
        { SiemensNote.BakeOvenInnerdoor2Up, "V450.7" },
        { SiemensNote.BakeOvenOuterdoor2Up, "V450.1" },
        { SiemensNote.BakeOvenInnerdoor2Down, "V451.0" },
        { SiemensNote.BakeOvenOuterdoor2Down, "V450.2" },
        { SiemensNote.BakeOvenInnerdoorOpen, "V451.4" },
        { SiemensNote.BakeOvenOuterdoorOpen, "V450.5" },
        { SiemensNote.BakeOvenInnerdoorClose, "V451.3" },
        { SiemensNote.BakeOvenOuterdoorClose, "V450.6" },
        { SiemensNote.BakeOvenInnerdoorStop, "V454.0" },
        { SiemensNote.BakeOvenOuterdoorStop, "V453.7" },
        { SiemensNote.BakeOvenInnerdoorPressSta, "I8.6" },
        { SiemensNote.BakeOvenOuterdoorPressSta, "I8.2" },
        { SiemensNote.BakeOvenInnerdoorReleaseSta, "I8.7" },
        { SiemensNote.BakeOvenOuterdoorReleaseSta, "I8.3" },
        { SiemensNote.BakeOvenInnerdoorUpSta, "I8.4" },
        { SiemensNote.BakeOvenOuterdoorUpSta, "I8.0" },
        { SiemensNote.BakeOvenInnerdoorDownSta, "I8.5" },
        { SiemensNote.BakeOvenOuterdoorDownSta, "I8.1" },

        { SiemensNote.BakeOvenPressure, "VD1222" },
        { SiemensNote.BakeOvenVacuum, "VD1218" },
        { SiemensNote.BakeOvenUPtemp, "VD1210" },
        { SiemensNote.BakeOvenDowntemp, "VD1214" },
        { SiemensNote.BakeOvenTargettemp, "VD1226" },
        { SiemensNote.BakeOvenAlarmtemp, "VD1230" },
        { SiemensNote.BakeOvenAlarmPressure, "VD1258" },
        { SiemensNote.BakeOvenHoldingTimeH, "VW1274" },
        { SiemensNote.BakeOvenHoldingTimeM, "VW1276" },
        { SiemensNote.BakeOvenPassedTimeH, "VW1278" },
        { SiemensNote.BakeOvenPassedTimeM, "VW1280" },

        { SiemensNote.BakeOvenUpHeatPID_P, "VW1294" },
        { SiemensNote.BakeOvenUpHeatPID_I, "VW1296" },
        { SiemensNote.BakeOvenUpHeatPID_D, "VW1298" },
        { SiemensNote.BakeOvenDownHeatPID_P, "VW1300" },
        { SiemensNote.BakeOvenDownHeatPID_I, "VW1302" },
        { SiemensNote.BakeOvenDownHeatPID_D, "VW1304" },

        { SiemensNote.BakeOvenPFUpPressure, "VD1234" },
        { SiemensNote.BakeOvenPFDownPressure, "VD1238" },
        { SiemensNote.BakeOvenPFnum, "VW1284" },
        { SiemensNote.BakeOvenPFCompletednum, "VW1286" },
        { SiemensNote.BakeOvenPFinterval, "VW1282" },
        { SiemensNote.BakeOvenPF, "V453.4" },

        { SiemensNote.BakeOvenAutoHeat1, "V453.5" },
        { SiemensNote.BakeOvenAutoHeat2, "V450.0" },

	#endregion

#region 交换箱

        { SiemensNote.ExchangeBoxBleed, "VW452.6" },
        { SiemensNote.ExchangeBoxExhaust, "VW453.0" },
        { SiemensNote.ExchangeBoxAerate, "VW452.7" },
        { SiemensNote.ExchangeBoxOuterdoorPressSta, "I1.3" },
        { SiemensNote.ExchangeBoxOuterdoorReleaseSta, "I1.2" },
        { SiemensNote.ExchangeBoxOuterdoorElePress, "V452.2" },
        { SiemensNote.ExchangeBoxOuterdoorEleRelease, "V452.3" },
        { SiemensNote.ExchangeBoxOuterdoorPress, "V452.1" },
        { SiemensNote.ExchangeBoxOuterdoorRelease, "V452.0" },
        { SiemensNote.ExchangeBoxOuterdoorOpen, "V452.4" },
        { SiemensNote.ExchangeBoxOuterdoorClose, "V452.5" },
        { SiemensNote.ExchangeBoxOuterdoorStop, "V454.1" },
        { SiemensNote.ExchangeBoxPressure, "VD1246" },
        { SiemensNote.ExchangeBoxVacuum, "VD1242" },
        { SiemensNote.ExchangeBoxPFUpPressure, "VD1250" },
        { SiemensNote.ExchangeBoxPFDownPressure, "VD1254" },
        { SiemensNote.ExchangeBoxPFnum, "VW1290" },
        { SiemensNote.ExchangeBoxPFCompletednum, "VW1292" },
        { SiemensNote.ExchangeBoxPFinterval, "VW1288" },
        { SiemensNote.ExchangeBoxPF, "V453.6" },
        { SiemensNote.ExchangeBoxAlarmPressure, "VD1262" },
        { SiemensNote.ExchangeBoxOuterdoorspeed, "VD1266" },
        

	#endregion

#region 纯化系统

        { SiemensNote.PurifyCleanTime, "VW88" },
        { SiemensNote.PurifyCleanResidueTime, "AIW64" },
        { SiemensNote.PurifyPressure, "VD2640" },
        { SiemensNote.PurifyUpPressure, "VD95" },
        { SiemensNote.PurifyDownPressure, "VD91" },
        { SiemensNote.PurifyDewpoint, "VD3626" },
        { SiemensNote.PurifyUpDewpoint, "" },
        { SiemensNote.PurifyDownDewpoint, "" },

        { SiemensNote.PurifyRegenerateSta, "M15.0" },
        { SiemensNote.PurifyRegenerateH, "VW64" },
        { SiemensNote.PurifyRegenerateM, "VW62" },
        { SiemensNote.PurifyRegenerateS, "VW60" },

        { SiemensNote.PurifyCirculate, "M01.0" },
        { SiemensNote.PurifyRegenerate, "M02.0" },
        { SiemensNote.PurifyClean, "M07.0" },
        { SiemensNote.PurifyPressureConfirm, "M10.1" },
        { SiemensNote.PurifyDewpointConfirm, "" },
        { SiemensNote.PurifyVacuumpumps, "" },

	#endregion

#region 其他
		
        { SiemensNote.BakeOvenAutoHeatEnd, "" },
        { SiemensNote.Warning, "" },
        { SiemensNote.ServoWarning, "V457.6" },

        { SiemensNote.ExchangeBoxOverpressWarning, "V453.1" },
        { SiemensNote.BakeOvenOverpressWarning, "V453.2" },
        { SiemensNote.BakeOvenOvertempWarning, "V453.3" },
        

	#endregion

        };

        public static string ToStringValue(this SiemensNote value)
        {
            return EnumToStringMapping[value];
        }
    }

    class SiemensControl
    {
        private Plc plc;

        public SiemensControl()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cputype"></param>
        /// <param name="ipAddress"></param>
        /// <param name="rack"></param>
        /// <param name="slot"></param>
        public SiemensControl(SiemensCpuType cpuType, string ipAddress, int rack, int slot, int dbint)
        {
            this.dbInt = dbint;
            CpuType Type = CpuType.S7200;
            switch (cpuType)
            {
                case SiemensCpuType.S7200:
                    Type = CpuType.S7200;
                    break;
                case SiemensCpuType.S7200Smart:
                    Type = CpuType.S7200Smart;
                    break;
                case SiemensCpuType.S7300:
                    Type = CpuType.S7300;
                    break;
                case SiemensCpuType.S7400:
                    Type = CpuType.S7400;
                    break;
                case SiemensCpuType.S71200:
                    Type = CpuType.S71200;
                    break;
                case SiemensCpuType.S71500:
                    Type = CpuType.S71500;
                    break;
                default:
                    Type = CpuType.S7200;
                    break;
            }
            plc = new Plc(Type, ipAddress, (short)rack, (short)slot);
        }

        #region 通信

        public int dbInt = 1;

        private bool S7_Connect()
        {
            try
            {
                plc.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void S7_Disconnect()
        {
            try
            {
                if (plc.IsConnected)
                {
                    plc.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }

        public T ReadPLC<T>(string DataTag)
        {
            try
            {
                //var A = S71500.Read(DataTag);
                Type t = typeof(T);
                if (t == typeof(bool))
                {
                    if (DataTag.StartsWith("V") || DataTag.StartsWith("M"))
                    {
                        var mat = Regex.Match(DataTag, @"(\d+)\.(\d+)");

                        int Inte = int.Parse(mat.Groups[1].Value);
                        int Dec = int.Parse(mat.Groups[2].Value);

                        var Done1 = plc.ReadBytes(DataType.DataBlock, dbInt, Inte, 8);
                        bool boolvalue = Done1[Dec] != 0;
                        return (T)Convert.ChangeType("" + boolvalue, typeof(T));
                    }
                    else
                    {
                        var Done = plc.Read(DataTag);
                        return (T)plc.Read(DataTag);
                    }



                }
                if (t == typeof(short))
                {
                    int strAdr = int.Parse(Regex.Match(DataTag, @"\d+$").ToString());
                    var A = plc.Read(DataType.DataBlock, dbInt, strAdr, VarType.Word, 1);
                    T value = (T)Convert.ChangeType("" + A, typeof(T));
                    return value;


                }
                if (t == typeof(int))
                {
                    int strAdr = int.Parse(Regex.Match(DataTag, @"\d+$").ToString());
                    return (T)plc.Read(DataType.DataBlock, dbInt, strAdr, VarType.Word, 1);
                }
                if (t == typeof(float))
                {
                    int strAdr = int.Parse(Regex.Match(DataTag, @"\d+$").ToString());
                    return (T)plc.Read(DataType.DataBlock, dbInt, strAdr, VarType.Real, 1);
                }
                if (t == typeof(double))
                {
                    int strAdr = int.Parse(Regex.Match(DataTag, @"\d+$").ToString());
                    return (T)plc.Read(DataType.DataBlock, dbInt, strAdr, VarType.LReal, 1);
                }
                return default(T);
            }
            catch (Exception ex)
            {

                return default(T);
            }

        }

        public void WritePLC<T>(string DataTag, T Data)
        {
            try
            {
                Type t = typeof(T);

                if (t == typeof(bool))
                {
                    //plc.Write(DataTag.ToUpper(), Convert.ToBoolean(Data));

                    var mat = Regex.Match(DataTag, @"(\d+)\.(\d+)");

                    int Inte = int.Parse(mat.Groups[1].Value);
                    int Dec = int.Parse(mat.Groups[2].Value);

                    plc.WriteBit(DataType.DataBlock, dbInt, Inte,Dec, Convert.ToBoolean(Data));
                }
                if (t == typeof(short))
                {
                    int strAdr = int.Parse(Regex.Match(DataTag, @"\d+$").ToString());
                    plc.Write(DataType.DataBlock, dbInt, strAdr, Convert.ToUInt16(Data));
                }
                if (t == typeof(int))
                {
                    int strAdr = int.Parse(Regex.Match(DataTag, @"\d+$").ToString());
                    plc.Write(DataType.DataBlock, dbInt, strAdr, Convert.ToInt32(Data));
                }
                if (t == typeof(float))
                {
                    int strAdr = int.Parse(Regex.Match(DataTag, @"\d+$").ToString());
                    plc.Write(DataType.DataBlock, dbInt, strAdr, Convert.ToSingle(Data));
                }
                if (t == typeof(double))
                {
                    int strAdr = int.Parse(Regex.Match(DataTag, @"\d+$").ToString());
                    plc.Write(DataType.DataBlock, dbInt, strAdr, Convert.ToDouble(Data));
                }
            }
            catch (Exception ex)
            {

            }
        }


        #endregion

        #region 纯化系统交互

        public bool Connect()
        {
            return S7_Connect();
        }

        public void Disconnect()
        {
            S7_Disconnect();
        }

        public bool IsConnected
        {
            get
            {
                return plc.IsConnected;
            }
        }



        #endregion
    }

    #endregion



}
