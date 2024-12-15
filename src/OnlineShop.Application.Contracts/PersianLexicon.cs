using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Contracts;

public class PersianLexicon
{
    public const string Normal_ShippingType = "معمولی";
    public const string VanguardPost = "پیشتاز";
    public const string NormalPost = "نرمال";
    public const string SucessOpertion = "عملیات با موفقیت انجام شد";

    public const string Error_UnValidOrder = "مبلغ سفارش نمی‌تواند کمتر از 50000 تومان باشد.";
    public const string Error_UnValidOrdeRplacementPeriod = "ثبت سفارش تنها بین ساعت 8 صبح تا 7 شب امکان‌پذیر است.";
    public const string Error_DublicateUser = "این نام کاربری قبلا استفاده شده است";
}
