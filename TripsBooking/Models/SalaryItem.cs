using System.ComponentModel.DataAnnotations.Schema;

namespace TripsBooking.Models
{
    [Table("QTOUTSAL24")]
    public class SalaryItem
    {
        // 👇 رقم الموظف (أساسي للفلترة)
        [Column("EMPN")]
        public double EmployeeId { get; set; }

        // 👇 الاسم / الكود
        [Column("ENAME")]
        public string? Name { get; set; }

        // 👇 سنوى / الكود
        [Column("sanawi")]
        public double? sanawi { get; set; }

        // 👇 عارضه / الكود
        [Column("arda")]
        public double? arda { get; set; }

        // 👇 مرضى / الكود
        [Column("maradi")]
        public double? maradi { get; set; }



        // =========================
        // 💰 EARNINGS (الاستحقاقات)
        // =========================

        [Column("BSAL")]
        public double? BSAL { get; set; }

        [Column("DYWORK")]
        public double? DYWORK { get; set; }

        [Column("INSOVER")]
        public double? INSOVER { get; set; }

        [Column("NINC_ELAWA")]
        public double? NINC_ELAWA { get; set; }

        [Column("VEXPER")]
        public double? VEXPER { get; set; }

        [Column("VSTAT")]
        public double? VSTAT { get; set; }

        [Column("PAUMAL")]
        public double? PAUMAL { get; set; }

        [Column("PWORK")]
        public double? PWORK { get; set; }

        [Column("PDL_TKRIR")]
        public double? PDL_TKRIR { get; set; }

        [Column("PDL_SPEC")]
        public double? PDL_SPEC { get; set; }

        [Column("PTMSIL")]
        public double? PTMSIL { get; set; }

        [Column("ELAWA_H_MUAHEL")]
        public double? ELAWA_H_MUAHEL { get; set; }

        [Column("PDL_SMAA")]
        public double? PDL_SMAA { get; set; }

        [Column("OTHER_DEUS")]
        public double? OTHER_DEUS { get; set; }

        [Column("PDL_MKATR")]
        public double? PDL_MKATR { get; set; }

        [Column("PDL_SPECIAL")]
        public double? PDL_SPECIAL { get; set; }

        [Column("PDL_MEAL")]
        public double? PDL_MEAL { get; set; }

        [Column("VPDL_ATLA")]
        public double? VPDL_ATLA { get; set; }

        [Column("V_SEDBK")]
        public double? V_SEDBK { get; set; }

        [Column("NWARDIA")]
        public double? NWARDIA { get; set; }

        [Column("PDL_WARDIA")]
        public double? PDL_WARDIA { get; set; }

        [Column("DEUS_MARADE_SAL")]
        public double? DEUS_MARADE_SAL { get; set; }

        [Column("DEUS_MARADE_VAR")]
        public double? DEUS_MARADE_VAR { get; set; }

        [Column("INS2019")]
        public double? INS2019 { get; set; }

        [Column("T_V_RAMADAN")]
        public double? T_V_RAMADAN { get; set; }

        [Column("PINCENTIVE")]
        public double? Pincentive { get; set; }

        [Column("PDL_SICK")]
        public double? PDL_SICK { get; set; }
        [Column("FARK_SOS")]
        public double? FARK_SOS { get; set; }
        [Column("TOTDEUS")]
        public double? TOTDEUS { get; set; }



        
            
            

        // =========================
        // 💸 DEDUCTIONS (الاستقطاعات)
        // =========================

        [Column("SOS_SAL")]
        public double? SOS_SAL { get; set; }

        [Column("VSUPPORT")]
        public double? VSUPPORT { get; set; }

        [Column("NKABA_PETRO")]
        public double? NKABA_PETRO { get; set; }

        [Column("VTKMELE")]
        public double? VTKMELE { get; set; }

        [Column("VTAX")]
        public double? VTAX { get; set; }

        [Column("DED_PERIOD")]
        public double? DED_PERIOD { get; set; }

        [Column("DED_SPORT")]
        public double? DED_SPORT { get; set; }

        [Column("SOS_SAL_MOSAHMA")]
        public double? SOS_SAL_MOSAHMA { get; set; }

        [Column("VDED82")]
        public double? VDED82 { get; set; }

        [Column("BAL82")]
        public double? BAL82 { get; set; }

        [Column("VDED56")]
        public double? VDED56 { get; set; }

        [Column("BAL56")]
        public double? BAL56 { get; set; }

        [Column("VYAM")]
        public double? VYAM { get; set; }

        [Column("BAL_YAM")]
        public double? BAL_YAM { get; set; }

        [Column("VDED70")]
        public double? VDED70 { get; set; }

        [Column("BAL70")]
        public double? BAL70 { get; set; }

        [Column("VDED57")]
        public double? VDED57 { get; set; }

        [Column("BAL57")]
        public double? BAL57 { get; set; }


        [Column("VDED53")]
        public double? VDED53 { get; set; }

        [Column("BAL53")]
        public double? BAL53 { get; set; }

        [Column("VDED55")]
        public double? VDED55 { get; set; }

        [Column("BAL55")]
        public double? BAL55 { get; set; }

        [Column("V_DED_53_PARK")]
        public double? V_DED_53_PARK { get; set; }

        [Column("BAL_DED_53_PARK")]
        public double? BAL_DED_53_PARK { get; set; }

        [Column("V_MID")]
        public double? V_MID { get; set; }

        [Column("BAL_MID")]
        public double? BAL_MID { get; set; }

        [Column("ded_alex")]
        public double? ded_alex { get; set; }

        [Column("TDED_ALEX")]
        public double? TDED_ALEX { get; set; }

        [Column("VDED60")]
        public double? VDED60 { get; set; }

        [Column("BAL60")]
        public double? BAL60 { get; set; }

        [Column("BAL53_PARENT")]
        public double? BAL53_PARENT { get; set; }

        [Column("THARBI")]
        public double? THARBI { get; set; }

        [Column("V_ALL_BANK")]
        public double? V_ALL_BANK { get; set; }

        [Column("TEL_NET")]
        public double? TEL_NET { get; set; }

        [Column("VSICK_MSHMA")]
        public double? VSICK_MSHMA { get; set; }

        [Column("OTHER_DED")]
        public double? OTHER_DED { get; set; }

        [Column("V_fathala")]
        public double? V_fathala { get; set; }

        [Column("V_HEJ")]
        public double? V_HEJ { get; set; }

        [Column("DED_MARADE")]
        public double? DED_MARADE { get; set; }

        [Column("V_57357")]
        public double? V_57357 { get; set; }

        [Column("VAL_KAIR")]
        public double? VAL_KAIR { get; set; }

        [Column("nowpay")]
        public double? nowpay { get; set; }

        [Column("V_tay")]
        public double? V_tay { get; set; }

        [Column("bal_tay")]
        public double? bal_tay { get; set; }

        [Column("vtedata")]
        public double? vtedata { get; set; }

        [Column("V_HEJ_NEW")]
        public double? V_HEJ_NEW { get; set; }

        [Column("BAL_HEJ_NEW")]
        public double? BAL_HEJ_NEW { get; set; }

        [Column("VDED83")]
        public double? VDED83 { get; set; }

        [Column("BAL83")]
        public double? BAL83 { get; set; }

        [Column("VNEQABA")]
        public double? VNEQABA { get; set; }

        [Column("BNEQABA")]
        public double? BNEQABA { get; set; }

        [Column("V_kest_takmeli")]
        public double? V_kest_takmeli { get; set; }

        [Column("T_kest_takmeli")]
        public double? T_kest_takmeli { get; set; }

        [Column("VSOLAF")]
        public double? VSOLAF { get; set; }

        [Column("BAL_SOLAF")]
        public double? BAL_SOLAF { get; set; }

        [Column("V_KAHK")]
        public double? V_KAHK { get; set; }

        [Column("BAL_KAHK")]
        public double? BAL_KAHK { get; set; }

        [Column("TOTDED")]
        public double? TOTDED { get; set; }

        [Column("FARK")]
        public double? FARK { get; set; }

        [Column("NETSAL")]
        public double? NETSAL { get; set; }

        [Column("SalaryYear")]
        public int SalaryYear { get; set; }

        [Column("SalaryMonth")]
        public int SalaryMonth { get; set; }

    }
}