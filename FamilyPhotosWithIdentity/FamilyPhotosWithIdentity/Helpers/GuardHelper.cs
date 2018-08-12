using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotosWithIdentity.Helpers
{   /// <summary>
    /// Extension függvény osztály, fontos feltételeket ellenörző függvényeket tartalmazz.
    /// </summary>
    public static class GuardHelper
    {
        /// <summary>
        /// Elvégzi a aszükséges nul vizsgálatot, és ha rendben van minden visszatér az eredeti értékkel.
        /// Ha a kapott paraméter null, akkor kivételt ob
        /// </summary>
        /// <typeparam name="T">Az ellenörizni kivánt paraméter tipusa. Formális paraméter,mivel extension függvény irunk nem kell a hiváskor megadni</typeparam>
        /// <param name="o">a formális paraméter, amire az extension-t hivjuk</param>
        /// <returns></returns>


        public static T ThrowIfNull<T>(this T o)
        {
            if (null == o) { throw new ArgumentNullException(typeof(T).Name); }
            return o;
        }

    }
}
