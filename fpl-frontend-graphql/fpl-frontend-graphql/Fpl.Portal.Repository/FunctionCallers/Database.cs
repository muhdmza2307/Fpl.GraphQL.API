﻿using Fpl.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Repository.FunctionCallers
{
    public static class Database
    {
        static Database()
        {
            var created = new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var droid1 = new Droid(
                Id: new Guid("1ae34c3b-c1a0-4b7b-9375-c5a221d49e68"),
                Name: "R2-D2",
                PrimaryFunction: "Astromech",
                ChargePeriod: new TimeSpan(5, 4, 6, 6),
                Manufactured: new DateTimeOffset(3001, 1, 1, 3, 5, 7, TimeSpan.Zero),
                Created: created,
                Modified: created
            );
            droid1.Friends.Add(new Guid("94fbd693-2027-4804-bf40-ed427fe76fda"));
            droid1.Friends.Add(new Guid("c2bbf949-764b-4d4f-bce6-0404211810fa"));
            droid1.AppearsIn.Add(Episode.NEWHOPE);
            droid1.AppearsIn.Add(Episode.EMPIRE);
            droid1.AppearsIn.Add(Episode.JEDI);
            var droid2 = new Droid(
                Id: new Guid("c2bbf949-764b-4d4f-bce6-0404211810fa"),
                Name: "C-3PO",
                PrimaryFunction: "Protocol",
                ChargePeriod: new TimeSpan(1, 5, 7, 8),
                Manufactured: new DateTimeOffset(3002, 2, 2, 15, 44, 32, TimeSpan.FromHours(6)),
                Created: created,
                Modified: created
            );
            droid2.AppearsIn.Add(Episode.NEWHOPE);
            droid2.AppearsIn.Add(Episode.EMPIRE);
            droid2.AppearsIn.Add(Episode.JEDI);
            var droid3 = new Droid(
                Id: new Guid("bcf83480-32c3-4d79-ba5d-2bea3bd1a279"),
                Name: "2-1B",
                PrimaryFunction: "Surgical",
                ChargePeriod: new TimeSpan(2, 4, 7, 3),
                Manufactured: new DateTimeOffset(3003, 3, 3, 6, 5, 47, TimeSpan.FromHours(-4)),
                Created: created,
                Modified: created
            );
            droid3.AppearsIn.Add(Episode.EMPIRE);
            Droids = new List<Droid>() { droid1, droid2, droid3, };
        }
        public static List<Character>? Characters { get; }
        public static List<Droid> Droids { get; }
    }
}
