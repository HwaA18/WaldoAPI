using System;
namespace Waldo.Entity
{
    public class Store
    {
        //Each of these fields are used to identify a store in our Store table 
        public String Name { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }
        public String Address { get; set; }

        //Each of these fields are those populated in the report about stores
        public String MasksRequired { get; set; }
        public String Masks { get; set; }
        public String Gloves { get; set; }
        public String HandSanitizer { get; set; }
        public String PaperTowels { get; set; }
        public String ToiletPaper { get; set; }
        public String LiquidSoap { get; set; }
        public String BarSoap { get; set; }
        public String CleaningWipes { get; set; }
        public String AerosolDisinfectant { get; set; }
        public String Bleach { get; set; }
        public String FlushableWipes { get; set; }
        public String Tissues { get; set; }
        public String Diapers { get; set; }
        public String WaterFilters { get; set; }
        public String ColdRemedies { get; set; }
        public String CoughRemedies { get; set; }
        public String RubbingAlcohol { get; set; }
        public String Antiseptic { get; set; }
        public String Thermometer { get; set; }
        public String FirstAidKit { get; set; }
        public String WaterBottles { get; set; }
        public String Eggs { get; set; }
        public String Milk { get; set; }
        public String Bread { get; set; }
        public String Beef { get; set; }
        public String Chicken { get; set; }
        public String Pork { get; set; }
        public String Yeast { get; set; }

        //These fields are used to record information about who and when the report is filed
        public String ReportedBy { get; set; }
        public String Timestamp { get; set; }

    }
}
