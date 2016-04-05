using FullContact.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullContact.Domain.DataTransferObject
{
    /// <summary>
    /// Demographics
    /// </summary>
    public class Demographics
    {
        #region Public Properties

        public string LocationGeneral { get; set; }
        public LocationDeduced locationDeduced { get; set; }

        #endregion
    }

    /// <summary>
    /// LocationDeduced
    /// </summary>
    public class LocationDeduced
    {
        #region Public Properties

        public string NormalizedLocation { get; set; }
        public string DeducedLocation { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public Continent Continent { get; set; }
        public County county { get; set; }
        public decimal Likelihood { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        #endregion
    }

    /// <summary>
    /// City
    /// </summary>
    public class City
    {
        #region Public Properties

        public bool Deduced { get; set; }
        public string Name { get; set; }

        #endregion
    }

    /// <summary>
    /// State
    /// </summary>
    public class State
    {
        #region Public Properties

        public bool Deduced { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        #endregion
    }

    /// <summary>
    /// Country
    /// </summary>
    public class Country
    {
        #region Public Properties

        public bool Deduced { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        #endregion
    }

    /// <summary>
    /// Continent
    /// </summary>
    public class Continent
    {
        #region Public Properties

        public string Name { get; set; }
        public string Code { get; set; }

        #endregion
    }

    /// <summary>
    /// County
    /// </summary>
    public class County
    {
        #region Public Properties

        public bool Deduced { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        #endregion
    }
}
