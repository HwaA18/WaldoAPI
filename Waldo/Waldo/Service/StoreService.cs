using Waldo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Waldo.Service
{
    public class StoreService
    {

        public List<Store> GetStores()
        {
            List<Store> lsStores = new List<Store>();

            SqlConnection db =
                new SqlConnection("Server=tcp:waldoserver.database.windows.net,1433;Initial Catalog=waldo;Persist Security Info=False;User ID=waldo;Password=1234@terp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            db.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Stores");
            cmd.Connection = db;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                Store s = null;

                while (reader.Read())
                {
                    s = new Store();
                    s.Name = reader["Name"].ToString();
                    s.Latitude = reader["Latitude"].ToString();
                    s.Longitude = reader["Longitude"].ToString();
                    s.Address = reader["Address"].ToString();
                    s.MasksRequired = reader["ReqMasks"].ToString();

                    s.Masks = reader["Masks"].ToString();
                    s.Gloves = reader["Gloves"].ToString();
                    s.HandSanitizer = reader["HandSanitizer"].ToString();
                    s.PaperTowels = reader["PaperTowels"].ToString();
                    s.ToiletPaper = reader["ToiletPaper"].ToString();
                    s.LiquidSoap = reader["LiquidSoap"].ToString();
                    s.BarSoap = reader["BarSoap"].ToString();
                    s.CleaningWipes = reader["CleaningWipes"].ToString();
                    s.AerosolDisinfectant = reader["AerosolDisinfectants"].ToString();
                    s.Bleach = reader["Bleach"].ToString();
                    s.FlushableWipes = reader["FlushableWipes"].ToString();
                    s.Tissues = reader["Tissues"].ToString();
                    s.Diapers = reader["Diapers"].ToString();
                    s.WaterFilters = reader["WaterFilters"].ToString();
                    s.ColdRemedies = reader["ColdRemedies"].ToString();
                    s.CoughRemedies = reader["CoughRemedies"].ToString();
                    s.RubbingAlcohol = reader["RubbingAlcohol"].ToString();
                    s.Antiseptic = reader["Antiseptic"].ToString();
                    s.Thermometer = reader["Thermometer"].ToString();
                    s.FirstAidKit = reader["FirstAidKit"].ToString();
                    s.WaterBottles = reader["WaterBottles"].ToString();
                    s.Eggs = reader["Eggs"].ToString();
                    s.Milk = reader["Milk"].ToString();
                    s.Bread = reader["Bread"].ToString();
                    s.Beef = reader["Beef"].ToString();
                    s.Chicken = reader["Chicken"].ToString();
                    s.Pork = reader["Pork"].ToString();
                    s.Yeast = reader["Yeast"].ToString();

                    lsStores.Add(s);
                }
            }

            db.Close();

            return lsStores;
        }

        public Store GetStore(int StoreId)
        {
            SqlConnection db =
                new SqlConnection("Server=tcp:waldoserver.database.windows.net,1433;Initial Catalog=waldo;Persist Security Info=False;User ID=waldo;Password=1234@terp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            db.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Stores WHERE StoreId = @StoreId");
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@StoreId", DbType = System.Data.DbType.Int32, Value = StoreId });

            cmd.Connection = db;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                if (reader.Read())
                {
                    Store s = new Store();
                    s.Name = reader["Name"].ToString();
                    s.Latitude = reader["Latitude"].ToString();
                    s.Longitude = reader["Longitude"].ToString();
                    s.Address = reader["Address"].ToString();
                    s.MasksRequired = reader["ReqMasks"].ToString();

                    s.Masks = reader["Masks"].ToString();
                    s.Gloves = reader["Gloves"].ToString();
                    s.HandSanitizer = reader["HandSanitizer"].ToString();
                    s.PaperTowels = reader["PaperTowels"].ToString();
                    s.ToiletPaper = reader["ToiletPaper"].ToString();
                    s.LiquidSoap = reader["LiquidSoap"].ToString();
                    s.BarSoap = reader["BarSoap"].ToString();
                    s.CleaningWipes = reader["CleaningWipes"].ToString();
                    s.AerosolDisinfectant = reader["AerosolDisinfectants"].ToString();
                    s.Bleach = reader["Bleach"].ToString();
                    s.FlushableWipes = reader["FlushableWipes"].ToString();
                    s.Tissues = reader["Tissues"].ToString();
                    s.Diapers = reader["Diapers"].ToString();
                    s.WaterFilters = reader["WaterFilters"].ToString();
                    s.ColdRemedies = reader["ColdRemedies"].ToString();
                    s.CoughRemedies = reader["CoughRemedies"].ToString();
                    s.RubbingAlcohol = reader["RubbingAlcohol"].ToString();
                    s.Antiseptic = reader["Antiseptic"].ToString();
                    s.Thermometer = reader["Thermometer"].ToString();
                    s.FirstAidKit = reader["FirstAidKit"].ToString();
                    s.WaterBottles = reader["WaterBottles"].ToString();
                    s.Eggs = reader["Eggs"].ToString();
                    s.Milk = reader["Milk"].ToString();
                    s.Bread = reader["Bread"].ToString();
                    s.Beef = reader["Beef"].ToString();
                    s.Chicken = reader["Chicken"].ToString();
                    s.Pork = reader["Pork"].ToString();
                    s.Yeast = reader["Yeast"].ToString();

                    db.Close();
                    return s;
                }
            }

            db.Close();

            return null;
        }
    }
}
