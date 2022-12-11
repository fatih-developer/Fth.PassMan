using System;

namespace Framework.Entities.ComplexTypes
{
    public class UserDetailDto
    {
        public int id { get; set; }
        public string UserSID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string HesapDurum { get; set; }
        public int? HesapDurumKod { get; set; }
        public DateTime? Guncelleme { get; set; }
        public string Guncelleyen { get; set; }
        public bool ADState { get; set; }
        public bool OnayState { get; set; }
        public bool FirmaState { get; set; }
        public int? Kurum_No { get; set; }
        public int? Unite_Kod { get; set; }
        public string Unite { get; set; }
        public string Birim { get; set; }
        public int? Birim_Kod { get; set; }
        public int? Birim_Detay_Kod { get; set; }
        public string BirimDetay { get; set; }
        public string Unvan { get; set; }
        public string Eposta { get; set; }
        public string MobilPhone { get; set; }
        public string TCK_No { get; set; }
        public int? SicilNo { get; set; }
        public string gruplar { get; set; }
        public byte[] userImage { get; set; }

        public int EbysBirimId { get; set; }


        /// <summary>
        /// Ebys Birim Id
        /// </summary>
        public int HesapId { get; set; }

        public string VekaletEttigiBirim { get; set; }
        public int VekaletId { get; set; }
        public string VekaletEdilenUser { get; set; }
        public int VekaletAlanUserId { get; set; }
        public int VekaletVerenUserId { get; set; }
        public string VekaletEdilenUnvan { get; set; }
    }
}