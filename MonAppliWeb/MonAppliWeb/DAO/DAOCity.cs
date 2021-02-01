using MonAppliWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonAppliWeb.DAO
{
    public class DAOCity
    {
        public List<city> GetCities()
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //récupération des cities dans une liste
                var dbCity = dm.city.ToList();
                return dbCity;
            }
        }

        public city GetCity(int cityId)
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //récupération d'une city dans une liste
                var dbCity = dm.city.FirstOrDefault(x => x.cityID == cityId);
                return dbCity;
            }
        }
        public city GetCity(string cityName)
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                //récupération des cities dans une liste
                var dbCity = dm.city.FirstOrDefault(x => x.cityName == cityName);
                return dbCity;
            }
        }
        public int? CreateCity(string cityName)
        {
            // return null si la city existe déja
            if (GetCity(cityName) != null) return null;
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                // Création dans la BDD de la city
                city newCity = new city()
                {
                    cityName = cityName
                };

                dm.city.InsertOnSubmit(newCity);
                dm.SubmitChanges();
                return newCity.cityID;
            }
        }
    }
}
