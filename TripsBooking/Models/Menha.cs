using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripsBooking.Models
{
   
    [Table("QTOUT_MENHA")]
    public class Menha
    {
        [Key]
        // رقم قيد
        [Column("EMPN")]
        public int EmployeeId { get; set; }

        // الإسم
        [Column("ENAME")]
        public string? ENAME { get; set; }  // "earning" / "deduction"

        //   أيام عـمل
        [Column("IN_DAYS_ANRPC")]
        public double? IN_DAYS_ANRPC { get; set; }

        // مرتب المنحة
        [Column("SAL_ANRPC")]
        public double? SAL_ANRPC { get; set; }

        //     قيـمة المنحـة 
        [Column("VAL_MENHA_ANRPC")]
        public double? VAL_MENHA_ANRPC { get; set; }

        //  قيـمة 100% من المنحـة
        [Column("VAL_MENHA_HALF_ANRPC")]
        public double? VAL_MENHA_HALF_ANRPC { get; set; }

        //    أستحقاقات أخـرى
        [Column("OTHER_deus")]
        public double? OTHER_deus { get; set; }

        //  إضافى
        [Column("EDAFI_VAL")]
        public double? EDAFI_VAL { get; set; }

        // وجبات رمضان
        [Column("VFS")]
        public double? VFS { get; set; }

        //   إجمالى الأستحقاقــات
        [Column("TOT_DEUS")]
        public double? TOT_DEUS { get; set; }

        //    علاج أسـر وأدوية 
        [Column("VAL_DED_SICK")]
        public double? VAL_DED_SICK { get; set; }

        // علاج أسـر وأدوية رصيد
        [Column("bal_VAL_DED_SICK")]
        public double? bal_VAL_DED_SICK { get; set; }

        // كرونا
        [Column("V_HARBI")]
        public double? V_HARBI { get; set; }

        // كرونا رصيد
        [Column("TOT_HARBI")]
        public double? TOT_HARBI { get; set; }

        // قسط حج وعمره
        [Column("VHEG")]
        public double? VHEG { get; set; }

        // قسط حج وعمره رصيد
        [Column("VHEG_BAL")]
        public double? VHEG_BAL { get; set; }

        //  سلفة مدارس
        [Column("V_MOAMERA")]
        public double? V_MOAMERA { get; set; }

        //  سلفة مدارس رصيد
        [Column("T_MOAMERA")]
        public double? T_MOAMERA { get; set; }

        //  رحلات
        [Column("VAL_DED_trip")]
        public double? VAL_DED_trip { get; set; }

        //  رحلات رصيد
        [Column("BAL_DED_trip")]
        public double? BAL_DED_trip { get; set; }

 
        // رحلات ترفيهيه
        [Column("V_DED_53_PARK")]
        public double? V_DED_53_PARK { get; set; }

        // رحلات ترفيهيه رصيد
        [Column("BAL_DED_53_PARK")]
        public double? BAL_DED_53_PARK { get; set; }

        // رحلات نصف عام
        [Column("V_MID")]
        public double? V_MID { get; set; }

        // رحلات نصف عام رصيد
        [Column("BAL_MID")]
        public double? BAL_MID { get; set; }

        // مساهمة علاج أسر
        [Column("VSICK")]
        public double? VSICK { get; set; }

        // كحك العيد نقابة .ع
        [Column("V_KAHK")]
        public double? V_KAHK { get; set; }

        // كحك العيد نقابة .ع رصيد
        [Column("TOT_KAHK")]
        public double? TOT_KAHK { get; set; }

        // كحك العيد نقابة انربك
        [Column("V_NEQABA_SUMMAR")]
        public double? V_NEQABA_SUMMAR { get; set; }

        // كحك العيد نقابة انربك رصيد
        [Column("BAL_NEQABA_SUMMAR")]
        public double? BAL_NEQABA_SUMMAR { get; set; }

        // فرق معاش تكميلى
        [Column("V_DED_TKKEST")]
        public double? V_DED_TKKEST { get; set; }

        // فرق معاش تكميلى رصيد
        [Column("BAL_DED_TKKEST")]
        public double? BAL_DED_TKKEST { get; set; }

        // سهم الخير
        [Column("VAL_KAIR")]
        public double? VAL_KAIR { get; set; }

        //     معــاش تكمـيلى
        [Column("VTKMELE")]
        public double? VTKMELE { get; set; }

        //   فـــــــروق
        [Column("FARK")]
        public double? FARK { get; set; }

        //  تاى هاوس 
        [Column("V_TAY")]
        public double? V_TAY { get; set; }

        //  تاى هاوس  رصيد
        [Column("BAL_TAY")]
        public double? BAL_TAY { get; set; }

        // سلفة رمضان
        [Column("VAL_DED_SOLAF")]
        public double? VAL_DED_SOLAF { get; set; }

        // سلفة رمضان رصيد
        [Column("BAL_DED_SOLAF")]
        public double? BAL_DED_SOLAF { get; set; }

        //   أستقطاعات أخـرى
        [Column("OTHER_ded")]
        public double? OTHER_ded { get; set; }

        //  إجمالى أستقطاعات
        [Column("TOT_DED")]
        public double? TOT_DED { get; set; }

        // الصـــافى
        [Column("NET_MENHA")]
        public double? NET_MENHA { get; set; }

        [Column("MenhaYear")]
        public int MenhaYear { get; set; }

        [Column("MenhaMonth")]
        public int MenhaMonth { get; set; }

    }
}