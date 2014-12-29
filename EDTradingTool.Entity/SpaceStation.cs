﻿using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Entity
{
    /// <summary>
    /// This class represents a space station (or similar) in Elite: Dangerous
    /// </summary>
    public class SpaceStation : EntityWithIdAndName
    {
        [ForeignKey(typeof(SolarSystem), OnDelete = "SET NULL")]
        public long? SolarSystemId { get; set; }

        [ForeignKey(typeof(Federation), OnDelete = "SET NULL")]
        public long? FederationId { get; set; }
        
        [Reference]
        public List<MarketEntry> MarketEntries { get; set; }

        [Reference]
        public SolarSystem SolarSystem { get; set; }

        [Reference]
        public Federation Federation { get; set; }

        public SpaceStation()
        {
            MarketEntries = new List<MarketEntry>();
        }

        public override IEnumerable<Core.IEntity> Children()
        {
            return MarketEntries.Cast<Core.IEntity>();
        }

        public override IEnumerable<Core.IEntity> Parents()
        {
            var parents = new List<Core.IEntity>();
            if (Federation != null) parents.Add(Federation);
            if (SolarSystem != null) parents.Add(SolarSystem);
            return parents;
        }
    }
}
