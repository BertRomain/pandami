using MonAppliWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace MonAppliWeb.DAO
{
    public class DAOZipCode
    {
        public List<zipCodes> GetZipCodes()
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                var dbZipCodes = dm.zipCodes.ToList();
                return dbZipCodes;
            }
        }
        
        public zipCodes GetZipCode(int zipCodeId)
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                var dbZipCode = dm.zipCodes.FirstOrDefault(x => x.zipCodeID == zipCodeId);
                return dbZipCode;
            }
        }
        
        public zipCodes GetZipCodeByCode(int zipCode)
        {
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                var dbZipCode = dm.zipCodes.FirstOrDefault(x => x.zipCode == zipCode);
                return dbZipCode;
            }
        }

        public int? CreateZipCode(int zipCode)
        {
            // return null si le zipCode existe déja
            if  (GetZipCodeByCode(zipCode) != null) return null;
            using (BddMemberDataContext dm = new BddMemberDataContext())
            {
                // Création dans la BDD du zipCode
                zipCodes newZipCode = new zipCodes()
                {
                    zipCode = zipCode
                };

                dm.zipCodes.InsertOnSubmit(newZipCode);
                dm.SubmitChanges();
                return newZipCode.zipCodeID;
            }
        }
    }
}