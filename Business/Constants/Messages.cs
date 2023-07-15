﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarsListed = "Araçlar Listelendi";

        public static string CarDeleted = "Araç Silindi";
        public static string CarUpdated = "Araç Güncellendi";
        public static string CarDailyPriceInvalid = "Araç fiyati geçersiz";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string RentalCar = "Araç Kiralandı";
        public static string ReturnCar = "Araç teslim edildi";
        public static string CarIsNotRentable = "Araç daha teslim edilmedi";

        public static string RentalDeleted = "Kiralama silindi";
        public static string CarCountOfBrandError = "Belirtilen araç markasına sadece 10 adet araç eklenebilir";
        public static string CarNameError = "Aynı isimle iki araba bulunamaz";
        public static string BrandCountError = "Marka sayısı 15'i geçemez";
    }
}
