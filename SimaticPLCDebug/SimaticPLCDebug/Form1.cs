using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Purification;

namespace SimaticPLCDebug
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Private File

        PurifySystem purify = new PurifySystem();

        bool FunctionalEnable = true;

        #endregion

        #region Private Method

        private void ReadAll()
        {
            try
            {
                FunctionalEnable = false;

                if (!purify.IsConnect())
                {
                    FunctionalEnable = true;
                    return;
                }

                #region 烘箱数据 int float


                float BakeOvenPressure = purify.Read<float>(SiemensNote.BakeOvenPressure);
                BOPressure.Text = BakeOvenPressure.ToString();

                int BakeOvenVacuum = purify.Read<int>(SiemensNote.BakeOvenVacuum);
                BOVacuum.Text = BakeOvenVacuum.ToString();

                float BakeOvenUPtemp = purify.Read<float>(SiemensNote.BakeOvenUPtemp);
                BOUPtemp.Text = BakeOvenUPtemp.ToString();

                float BakeOvenDowntemp = purify.Read<float>(SiemensNote.BakeOvenDowntemp);
                BODowntemp.Text = BakeOvenDowntemp.ToString();

                #endregion

                #region 烘箱状态

                bool BakeOvenOuterdoorPressSta = purify.Read<bool>(SiemensNote.BakeOvenOuterdoorPressSta);
                SetLabelColor(BakeOvenOuterdoorPressSta, BOOuterdoorPressSta);

                bool BakeOvenOuterdoorReleaseSta = purify.Read<bool>(SiemensNote.BakeOvenOuterdoorReleaseSta);
                SetLabelColor(BakeOvenOuterdoorReleaseSta, BOOuterdoorReleaseSta);

                bool BakeOvenOuterdoorUpSta = purify.Read<bool>(SiemensNote.BakeOvenOuterdoorUpSta);
                SetLabelColor(BakeOvenOuterdoorUpSta, BOOuterdoorUpSta);

                bool BakeOvenOuterdoorDownSta = purify.Read<bool>(SiemensNote.BakeOvenOuterdoorDownSta);
                SetLabelColor(BakeOvenOuterdoorDownSta, BOOuterdoorDownSta);

                bool BakeOvenInnerdoorPressSta = purify.Read<bool>(SiemensNote.BakeOvenInnerdoorPressSta);
                SetLabelColor(BakeOvenInnerdoorPressSta, BOInnerdoorPressSta);

                bool BakeOvenInnerdoorReleaseSta = purify.Read<bool>(SiemensNote.BakeOvenInnerdoorReleaseSta);
                SetLabelColor(BakeOvenInnerdoorReleaseSta, BOInnerdoorReleaseSta);

                bool BakeOvenInnerdoorUpSta = purify.Read<bool>(SiemensNote.BakeOvenInnerdoorUpSta);
                SetLabelColor(BakeOvenInnerdoorUpSta, BOInnerdoorUpSta);

                bool BakeOvenInnerdoorDownSta = purify.Read<bool>(SiemensNote.BakeOvenInnerdoorDownSta);
                SetLabelColor(BakeOvenInnerdoorDownSta, BOInnerdoorDownSta);

                bool BakeOvenOverpressWarning = purify.Read<bool>(SiemensNote.BakeOvenOverpressWarning);
                SetLabelColor(BakeOvenOverpressWarning, BOOverpressWarning);

                bool BakeOvenOvertempWarning = purify.Read<bool>(SiemensNote.BakeOvenOvertempWarning);
                SetLabelColor(BakeOvenOvertempWarning, BOOvertempWarning);

                //bool BakeOvenAutoHeatEnd = purify.Read<bool>(SiemensNote.BakeOvenAutoHeatEnd);
                //SetLabelColor(BakeOvenAutoHeatEnd, BOAutoHeatEnd);

                #endregion

                #region 烘箱工艺设置

                float BakeOvenTargettemp = purify.Read<float>(SiemensNote.BakeOvenTargettemp);
                BOTargettemp.Text = BakeOvenTargettemp.ToString();

                short BakeOvenHoldingTimeH = purify.Read<short>(SiemensNote.BakeOvenHoldingTimeH);
                BOHoldingTimeH.Text = BakeOvenHoldingTimeH.ToString();
                short BakeOvenHoldingTimeM = purify.Read<short>(SiemensNote.BakeOvenHoldingTimeM);
                BOHoldingTimeM.Text = BakeOvenHoldingTimeM.ToString();

                short BakeOvenPassedTimeH = purify.Read<short>(SiemensNote.BakeOvenPassedTimeH);
                BOPassedTimeH.Text = BakeOvenPassedTimeH.ToString();
                short BakeOvenPassedTimeM = purify.Read<short>(SiemensNote.BakeOvenPassedTimeM);
                BOPassedTimeM.Text = BakeOvenPassedTimeM.ToString();

                float BakeOvenPFUpPressure = purify.Read<float>(SiemensNote.BakeOvenPFUpPressure);
                BOPFUpPressure.Text = BakeOvenPFUpPressure.ToString();

                float BakeOvenPFDownPressure = purify.Read<float>(SiemensNote.BakeOvenPFDownPressure);
                BOPFDownPressure.Text = BakeOvenPFDownPressure.ToString();

                float BakeOvenPFnum = purify.Read<float>(SiemensNote.BakeOvenPFnum);
                BOPFnum.Text = BakeOvenPFnum.ToString();

                float BakeOvenPFCompletednum = purify.Read<float>(SiemensNote.BakeOvenPFCompletednum);
                BOPFCompletednum.Text = BakeOvenPFCompletednum.ToString();

                float BakeOvenPFinterval = purify.Read<float>(SiemensNote.BakeOvenPFinterval);
                BOPFinterval.Text = BakeOvenPFinterval.ToString();

                #endregion

                #region 烘箱开关

                bool BakeOvenBleed = purify.Read<bool>(SiemensNote.BakeOvenBleed);
                BOBleed.Checked = BakeOvenBleed;

                bool BakeOvenExhaust = purify.Read<bool>(SiemensNote.BakeOvenExhaust);
                BOExhaust.Checked = BakeOvenExhaust;

                bool BakeOvenAerate = purify.Read<bool>(SiemensNote.BakeOvenAerate);
                BOAerate.Checked = BakeOvenAerate;

                bool BakeOvenInnerdoor1Press = purify.Read<bool>(SiemensNote.BakeOvenInnerdoor1Press);
                BOInnerdoor1Press.Checked = BakeOvenInnerdoor1Press;

                bool BakeOvenInnerdoor2Up = purify.Read<bool>(SiemensNote.BakeOvenInnerdoor2Up);
                BOInnerdoor2Up.Checked = BakeOvenInnerdoor2Up;

                bool BakeOvenInnerdoor2Down = purify.Read<bool>(SiemensNote.BakeOvenInnerdoor2Down);
                BOInnerdoor2Down.Checked = BakeOvenInnerdoor2Down;

                bool BakeOvenOuterdoor1Press = purify.Read<bool>(SiemensNote.BakeOvenOuterdoor1Press);
                BOOuterdoor1Press.Checked = BakeOvenOuterdoor1Press;

                bool BakeOvenOuterdoor2Up = purify.Read<bool>(SiemensNote.BakeOvenOuterdoor2Up);
                BOOuterdoor2Up.Checked = BakeOvenOuterdoor2Up;

                bool BakeOvenOuterdoor2Down = purify.Read<bool>(SiemensNote.BakeOvenOuterdoor2Down);
                BOOuterdoor2Down.Checked = BakeOvenOuterdoor2Down;

                bool BakeOvenPF = purify.Read<bool>(SiemensNote.BakeOvenPF);
                BOPF.Checked = BakeOvenPF;

                bool BakeOvenAutoHeat1 = purify.Read<bool>(SiemensNote.BakeOvenAutoHeat1);
                BOAutoHeat1.Checked = BakeOvenAutoHeat1;

                bool BakeOvenAutoHeat2 = purify.Read<bool>(SiemensNote.BakeOvenAutoHeat2);
                BOAutoHeat2.Checked = BakeOvenAutoHeat2;

                #endregion


                #region 交换箱数据 int float


                float ExchangeBoxPressure = purify.Read<float>(SiemensNote.ExchangeBoxPressure);
                EBPressure.Text = ExchangeBoxPressure.ToString();

                float ExchangeBoxVacuum = purify.Read<float>(SiemensNote.ExchangeBoxVacuum);
                EBVacuum.Text = ExchangeBoxVacuum.ToString();


                #endregion

                #region 交换箱状态

                bool ExchangeBoxOuterdoorPressSta = purify.Read<bool>(SiemensNote.ExchangeBoxOuterdoorPressSta);
                SetLabelColor(ExchangeBoxOuterdoorPressSta, EBOuterdoorPressSta);

                bool ExchangeBoxOuterdoorReleaseSta = purify.Read<bool>(SiemensNote.ExchangeBoxOuterdoorReleaseSta);
                SetLabelColor(ExchangeBoxOuterdoorReleaseSta, EBOuterdoorReleaseSta);

                bool ExchangeBoxOverpressWarning = purify.Read<bool>(SiemensNote.ExchangeBoxOverpressWarning);
                SetLabelColor(ExchangeBoxOverpressWarning, EBOverpressWarning);

                #endregion

                #region 交换箱工艺设置

                float ExchangeBoxPFUpPressure = purify.Read<float>(SiemensNote.ExchangeBoxPFUpPressure);
                EBPFUpPressure.Text = ExchangeBoxPFUpPressure.ToString();

                float ExchangeBoxPFDownPressure = purify.Read<float>(SiemensNote.ExchangeBoxPFDownPressure);
                EBPFDownPressure.Text = ExchangeBoxPFDownPressure.ToString();

                short ExchangeBoxPFnum = purify.Read<short>(SiemensNote.ExchangeBoxPFnum);
                EBPFnum.Text = ExchangeBoxPFnum.ToString();

                short ExchangeBoxPFCompletednum = purify.Read<short>(SiemensNote.ExchangeBoxPFCompletednum);
                EBPFCompletednum.Text = ExchangeBoxPFCompletednum.ToString();

                short ExchangeBoxPFinterval = purify.Read<short>(SiemensNote.ExchangeBoxPFinterval);
                EBPFinterval.Text = ExchangeBoxPFinterval.ToString();

                #endregion

                #region 交换箱开关

                bool ExchangeBoxBleed = purify.Read<bool>(SiemensNote.ExchangeBoxBleed);
                EBBleed.Checked = ExchangeBoxBleed;

                bool ExchangeBoxExhaust = purify.Read<bool>(SiemensNote.ExchangeBoxExhaust);
                EBExhaust.Checked = ExchangeBoxExhaust;

                bool ExchangeBoxAerate = purify.Read<bool>(SiemensNote.ExchangeBoxAerate);
                EBAerate.Checked = ExchangeBoxAerate;

                bool ExchangeBoxOuterdoorElePress = purify.Read<bool>(SiemensNote.ExchangeBoxOuterdoorElePress);
                EBOuterdoorElePress.Checked = ExchangeBoxOuterdoorElePress;

                bool ExchangeBoxOuterdoorRelease = purify.Read<bool>(SiemensNote.ExchangeBoxOuterdoorRelease);
                EBOuterdoorRelease.Checked = ExchangeBoxOuterdoorRelease;

                bool ExchangeBoxOuterdoorPress = purify.Read<bool>(SiemensNote.ExchangeBoxOuterdoorPress);
                EBOuterdoorPress.Checked = ExchangeBoxOuterdoorPress;

                bool ExchangeBoxPF = purify.Read<bool>(SiemensNote.ExchangeBoxPF);
                EBPF.Checked = ExchangeBoxPF;

                #endregion


                #region 纯化系统数据 int float


                float _PurifyPressure = purify.Read<float>(SiemensNote.PurifyPressure);
                PurifyPressure.Text = _PurifyPressure.ToString();

                float _PurifyDewpoint = purify.Read<float>(SiemensNote.PurifyDewpoint);
                PurifyDewpoint.Text = _PurifyDewpoint.ToString();

                int _PurifyRegenerateH = purify.Read<int>(SiemensNote.PurifyRegenerateH);
                PurifyRegenerateH.Text = _PurifyRegenerateH.ToString();

                int _PurifyRegenerateM = purify.Read<int>(SiemensNote.PurifyRegenerateM);
                PurifyRegenerateM.Text = _PurifyRegenerateM.ToString();

                int _PurifyRegenerateS = purify.Read<int>(SiemensNote.PurifyRegenerateS);
                PurifyRegenerateS.Text = _PurifyRegenerateS.ToString();


                #endregion

                #region 纯化系统状态

                bool _PurifyRegenerateSta = purify.Read<bool>(SiemensNote.PurifyRegenerateSta);
                SetLabelColor(_PurifyRegenerateSta, PurifyRegenerateSta);


                #endregion

                #region 纯化系统工艺设置

                int _PurifyCleanTime = purify.Read<int>(SiemensNote.PurifyCleanTime);
                PurifyCleanTime.Text = _PurifyCleanTime.ToString();

                int _PurifyCleanResidueTime = purify.Read<int>(SiemensNote.PurifyCleanResidueTime);
                PurifyCleanResidueTime.Text = _PurifyCleanResidueTime.ToString();

                float _PurifyUpPressure = purify.Read<float>(SiemensNote.PurifyUpPressure);
                PurifyUpPressure.Text = _PurifyUpPressure.ToString();

                float _PurifyDownPressure = purify.Read<float>(SiemensNote.PurifyDownPressure);
                PurifyDownPressure.Text = _PurifyDownPressure.ToString();

                float _PurifyUpDewpoint = purify.Read<float>(SiemensNote.PurifyUpDewpoint);
                PurifyUpDewpoint.Text = _PurifyUpDewpoint.ToString();

                float _PurifyDownDewpoint = purify.Read<float>(SiemensNote.PurifyDownDewpoint);
                PurifyDownDewpoint.Text = _PurifyDownDewpoint.ToString();

                #endregion

                #region 纯化系统开关

                bool _PurifyCirculate = purify.Read<bool>(SiemensNote.PurifyCirculate);
                PurifyCirculate.Checked = _PurifyCirculate;

                bool _PurifyRegenerate = purify.Read<bool>(SiemensNote.PurifyRegenerate);
                PurifyRegenerate.Checked = _PurifyRegenerate;

                bool _PurifyClean = purify.Read<bool>(SiemensNote.PurifyClean);
                PurifyClean.Checked = _PurifyClean;

                bool _PurifyPressureConfirm = purify.Read<bool>(SiemensNote.PurifyPressureConfirm);
                PurifyPressureConfirm.Checked = _PurifyPressureConfirm;

                bool _PurifyDewpointConfirm = purify.Read<bool>(SiemensNote.PurifyDewpointConfirm);
                PurifyDewpointConfirm.Checked = _PurifyDewpointConfirm;

                bool _PurifyVacuumpumps = purify.Read<bool>(SiemensNote.PurifyVacuumpumps);
                PurifyVacuumpumps.Checked = _PurifyVacuumpumps;


                #endregion


                FunctionalEnable = true;

            }
            catch (Exception)
            {

            }
        }

        private void SetLabelColor(bool Done,System.Windows.Forms.Label label)
        {
            if (label != null)
            {
                if (Done == false)
                {
                    label.BackColor = Color.Red;
                }
                else
                {
                    label.BackColor = Color.LightGreen;
                }
            }
            
        }

        #endregion



        #region MainButton

        private void ConnectPLC_Click(object sender, EventArgs e)
        {
            string IP = PLCip.Text;

            SiemensCpuType type = SiemensCpuType.S7200Smart;
            string selectedString = PLCType.SelectedItem.ToString();
            switch (selectedString)
            {
                case "S7200":
                    type = SiemensCpuType.S7200;
                    break;
                case "S7200Smart":
                    type = SiemensCpuType.S7200Smart;
                    break;
                case "S7300":
                    type = SiemensCpuType.S7300;
                    break;
                case "S7400":
                    type = SiemensCpuType.S7400;
                    break;
                case "S71200":
                    type = SiemensCpuType.S71200;
                    break;
                case "S71500":
                    type = SiemensCpuType.S71500;
                    break;
            }

            purify.Connect(IP, type);

        }

        private void DisConnectPLC_Click(object sender, EventArgs e)
        {
            purify.DisConnect();
        }

        private void UpdateData_Click(object sender, EventArgs e)
        {
            ReadAll();
        }

        #endregion



        #region BakeOvenButton


        private void BOTargettempbutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                float BakeOvenTargettemp = float.Parse(BOTargettemp.Text);
                purify.Write<float>(SiemensNote.BakeOvenTargettemp, BakeOvenTargettemp);

            }
        }

        private void BOHoldingTimebutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                short BakeOvenHoldingTimeH = short.Parse(BOHoldingTimeH.Text);
                purify.Write<short>(SiemensNote.BakeOvenHoldingTimeH, BakeOvenHoldingTimeH);

                short BakeOvenHoldingTimeM = short.Parse(BOHoldingTimeM.Text);
                purify.Write<short>(SiemensNote.BakeOvenHoldingTimeM, BakeOvenHoldingTimeM);
            }
        }

        private void BOPFUpPressurebutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                float BakeOvenPFUpPressure = float.Parse(BOPFUpPressure.Text);
                purify.Write<float>(SiemensNote.BakeOvenPFUpPressure, BakeOvenPFUpPressure);

            }
        }

        private void BOPFDownPressurebutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                float BakeOvenPFDownPressure = float.Parse(BOPFDownPressure.Text);
                purify.Write<float>(SiemensNote.BakeOvenPFDownPressure, BakeOvenPFDownPressure);

            }
        }

        private void BOPFnumbutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                short BakeOvenPFnum = short.Parse(BOPFnum.Text);
                purify.Write<short>(SiemensNote.BakeOvenPFnum, BakeOvenPFnum);

            }
        }

        private void BOPFresiduenumbutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                short ExchangeBoxPFCompletednum = short.Parse(BOPFCompletednum.Text);
                purify.Write<short>(SiemensNote.ExchangeBoxPFCompletednum, ExchangeBoxPFCompletednum);

            }
        }

        private void BOPFintervalbutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                short BakeOvenPFinterval = short.Parse(BOPFinterval.Text);
                purify.Write<short>(SiemensNote.BakeOvenPFinterval, BakeOvenPFinterval);

            }
        }

        private void BOAlarmPressurebutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                float BakeOvenAlarmPressure = float.Parse(BOAlarmPressure.Text);
                purify.Write<float>(SiemensNote.BakeOvenAlarmPressure, BakeOvenAlarmPressure);

            }
        }


        private void BOBleed_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenBleed, BOBleed.Checked);
            }
        }

        private void BOExhaust_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                if (BOExhaust.Checked)
                {
                    purify.Write<bool>(SiemensNote.BakeOvenExhaust, BOExhaust.Checked);
                }
                else
                {
                    purify.Write<bool>(SiemensNote.BakeOvenExhaust, BOExhaust.Checked);
                }
                
            }
        }

        private void BOAerate_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenAerate, BOAerate.Checked);
            }
        }

        private void BOInnerdoor1Press_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenInnerdoor1Press, BOInnerdoor1Press.Checked);
                
            }
        }
        private void BOInnerdoor1Release_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenInnerdoor1Release, BOInnerdoor1Release.Checked);

            }
        }

        private void BOInnerdoor2Up_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenInnerdoor2Up, BOInnerdoor2Up.Checked);
            }
        }

        private void BOInnerdoor2Down_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenInnerdoor2Down, BOInnerdoor2Down.Checked);
            }
        }

        private void BOOuterdoor1Press_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenOuterdoor1Press, BOOuterdoor1Press.Checked);
            }
        }
        private void BOOuterdoor1Release_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenOuterdoor1Release, BOOuterdoor1Release.Checked);
            }
        }

        private void BOOuterdoor2Up_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenOuterdoor2Up, BOOuterdoor2Up.Checked);
            }
        }

        private void BOOuterdoor2Down_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenOuterdoor2Down, BOOuterdoor2Down.Checked);
            }
        }

        private void BOPF_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenPF, BOPF.Checked);
            }
        }

        private void BOAutoHeat1_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenAutoHeat1, BOAutoHeat1.Checked);
            }
        }

        private void BOAutoHeat2_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.BakeOvenAutoHeat2, BOAutoHeat2.Checked);
            }
        }

        private void BOInnerdoorOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                if(BOInnerdoorOpen.Checked)
                {
                    purify.Write<bool>(SiemensNote.BakeOvenInnerdoorOpen, true);
                }
                else
                {
                    purify.Write<bool>(SiemensNote.BakeOvenInnerdoorStop, true);
                }
                
            }
        }

        private void BOInnerdoorClose_CheckedChanged(object sender, EventArgs e)
        {
            if (BOInnerdoorClose.Checked)
            {
                purify.Write<bool>(SiemensNote.BakeOvenInnerdoorClose, true);
            }
            else
            {
                purify.Write<bool>(SiemensNote.BakeOvenInnerdoorStop, true);
            }
        }

        private void BOOuterdoorOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (BOOuterdoorOpen.Checked)
            {
                purify.Write<bool>(SiemensNote.BakeOvenOuterdoorOpen, true);
            }
            else
            {
                purify.Write<bool>(SiemensNote.BakeOvenOuterdoorStop, true);
            }
        }

        private void BOOuterdoorClose_CheckedChanged(object sender, EventArgs e)
        {
            if (BOOuterdoorClose.Checked)
            {
                purify.Write<bool>(SiemensNote.BakeOvenOuterdoorClose, true);
            }
            else
            {
                purify.Write<bool>(SiemensNote.BakeOvenOuterdoorStop, true);
            }
        }

        #endregion


        #region ExchangeBoxButton

        private void EBPFUpPressurebutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                float ExchangeBoxPFUpPressure = float.Parse(EBPFUpPressure.Text);
                purify.Write<float>(SiemensNote.ExchangeBoxPFUpPressure, ExchangeBoxPFUpPressure);

            }
        }

        private void EBPFDownPressurebutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                float ExchangeBoxPFDownPressure = float.Parse(EBPFDownPressure.Text);
                purify.Write<float>(SiemensNote.ExchangeBoxPFDownPressure, ExchangeBoxPFDownPressure);

            }
        }

        private void EBPFnumbutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                short ExchangeBoxPFnum = short.Parse(EBPFnum.Text);
                purify.Write<short>(SiemensNote.ExchangeBoxPFnum, ExchangeBoxPFnum);

            }
        }

        private void EBPFresiduenumbutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                short ExchangeBoxPFresiduenum = short.Parse(EBPFCompletednum.Text);
                purify.Write<short>(SiemensNote.ExchangeBoxPFCompletednum, ExchangeBoxPFresiduenum);

            }
        }

        private void EBPFintervalbutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                short ExchangeBoxPFinterval = short.Parse(EBPFinterval.Text);
                purify.Write<short>(SiemensNote.ExchangeBoxPFinterval, ExchangeBoxPFinterval);

            }
        }

        private void EBAlarmPressurebutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                float ExchangeBoxAlarmPressure = float.Parse(EBAlarmPressure.Text);
                purify.Write<float>(SiemensNote.ExchangeBoxAlarmPressure, ExchangeBoxAlarmPressure);

            }
        }


        private void EBBleed_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.ExchangeBoxBleed, EBBleed.Checked);
            }
        }

        private void EBExhaust_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.ExchangeBoxExhaust, EBExhaust.Checked);
            }
        }

        private void EBAerate_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.ExchangeBoxAerate, EBAerate.Checked);
            }
        }

        private void EBOuterdoorElePress_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorElePress, EBOuterdoorElePress.Checked);
            }
        }
        private void EBOuterdoorEleRelease_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorEleRelease, EBOuterdoorEleRelease.Checked);
            }
        }

        private void EBOuterdoorRelease_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorRelease, EBOuterdoorRelease.Checked);
            }
        }

        private void EBOuterdoorPress_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorPress, EBOuterdoorPress.Checked);
            }
        }

        private void EBPF_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.ExchangeBoxPF, EBPF.Checked);
            }
        }

        private void EBOuterdoorOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                if (EBOuterdoorOpen.Checked)
                {
                    purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorOpen, true);
                    purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorStop, false);
                }
                else
                {
                    purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorOpen, false);
                    purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorStop, true);
                }
            }
        }

        private void EBOuterdoorClose_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                if (EBOuterdoorClose.Checked)
                {
                    purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorClose, true);
                    purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorStop, false);
                }
                else
                {
                    purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorClose, false);
                    purify.Write<bool>(SiemensNote.ExchangeBoxOuterdoorStop, true);
                }
            }
        }

        #endregion

        private void PurifyCleanTimebutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                short _PurifyCleanTime = short.Parse(PurifyCleanTime.Text);
                purify.Write<short>(SiemensNote.PurifyCleanTime, _PurifyCleanTime);

            }
        }

        private void PurifyCleanResidueTimebutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                short _PurifyCleanResidueTime = short.Parse(PurifyCleanResidueTime.Text);
                purify.Write<short>(SiemensNote.PurifyCleanResidueTime, _PurifyCleanResidueTime);

            }
        }

        private void PurifyUpPressurebutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                float _PurifyUpPressure = float.Parse(PurifyUpPressure.Text);
                purify.Write<float>(SiemensNote.PurifyUpPressure, _PurifyUpPressure);

            }
        }

        private void PurifyDownPressurebutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                float _PurifyDownPressure = float.Parse(PurifyDownPressure.Text);
                purify.Write<float>(SiemensNote.PurifyDownPressure, _PurifyDownPressure);

            }
        }

        private void PurifyUpDewpointbutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                float _PurifyUpDewpoint = float.Parse(PurifyUpDewpoint.Text);
                purify.Write<float>(SiemensNote.PurifyUpDewpoint, _PurifyUpDewpoint);

            }
        }

        private void PurifyDownDewpointbutton_Click(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                float _PurifyDownDewpoint = float.Parse(PurifyDownDewpoint.Text);
                purify.Write<float>(SiemensNote.PurifyDownDewpoint, _PurifyDownDewpoint);

            }
        }

        private void PurifyCirculate_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.PurifyCirculate, PurifyCirculate.Checked);
            }
        }

        private void PurifyRegenerate_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.PurifyRegenerate, PurifyRegenerate.Checked);
            }
        }

        private void PurifyClean_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.PurifyClean, PurifyClean.Checked);
            }
        }

        private void PurifyPressureConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.PurifyPressureConfirm, PurifyPressureConfirm.Checked);
            }
        }

        private void PurifyDewpointConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.PurifyDewpointConfirm, PurifyDewpointConfirm.Checked);
            }
        }

        private void PurifyVacuumpumps_CheckedChanged(object sender, EventArgs e)
        {
            if (FunctionalEnable && purify.IsConnect())
            {
                purify.Write<bool>(SiemensNote.PurifyVacuumpumps, PurifyVacuumpumps.Checked);
            }
        }

        
    }
}
