using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAppYD.Business.Constants
{
    public static class Messages
    {
        public static string BuildingAdded = "Bina başarıyla eklendi";
        public static string BuildingDeleted = "Bina başarıyla silindi";
        public static string BuildingUpdated = "Bina başarıyla güncellendi";
        public static string BuildingFailed = "Bina Eklenemedi";
        public static string BuildingNameAlreadyExists = "Bina adı zaten Mevcut";

        public static string RoomAdded = "Oda başarıyla eklendi";
        public static string RoomDeleted = "Oda başarıyla silindi";
        public static string RoomUpdated = "Oda başarıyla güncellendi";
        public static string RoomFailed = "Oda Eklenemedi";

        public static string StoreAdded = "Depo başarıyla eklendi";
        public static string StoreDeleted = "Depo başarıyla silindi";
        public static string StoreUpdated = "Depo başarıyla güncellendi";
        public static string StoreFailed = "Depo Eklenemedi";

        public static string RoomNameAlreadyExists = "Oda Adı Zaten Mevcut";

        public static string BuildingNotExists = "Bina Bulunamadı";

        public static string WrongValidationType = "Wrong Validation Type";
        public static string WrongLoggerType = "Wrong Logger Type";
    }
}
