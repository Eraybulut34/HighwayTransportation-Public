using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayTransportation.Domain.Enums
{
    public enum PaymentTypeEnum
    {
        //Tek seferde ödeme
        OneTimePayment,
        //Aylık ödeme
        MonthlyPayment,
        //Yıllık ödeme
        YearlyPayment,
        //Diğer
        Other

    }
}
