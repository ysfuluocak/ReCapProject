﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarListed = "Arabalar listelendi";
        public static string RentalAdded = "Araba kiralandı";
        public static string RentalDeleted = "Araba katalogdan silindi";
        public static string RentalUpdated = "Kiralık araba güncellendi";
        public static string RentalListed = "Kiralık arabalar listelendi";
        public static string ImageNotFound = "Resim bulunamadı";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı eklendi";
        public static string UserNotFound = "Kullanıcı bunumadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Kayıt Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
    }
}
