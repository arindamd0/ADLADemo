using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ADLADemo
{
    [SqlUserDefinedCombiner]
    public class MergeData : ICombiner
    {
        public override IEnumerable<IRow> Combine(IRowset left, IRowset right, IUpdatableRow output)
        {
            var ipList = (from ip in right.Rows
                          select new
                          {
                              IPStart = ip.Get<long>("ip_start_int"),
                              IPEnd = ip.Get<long>("ip_end_int"),
                              country = ip.Get<string>("country"),
                              state = ip.Get<string>("state"),
                              city = ip.Get<string>("city")
                          }).ToList();

            foreach (var row in left.Rows)
            {
                output.Set<int>("Year", row.Get<int>("Year"));
                output.Set<int>("Month", row.Get<int>("Month"));
                output.Set<int>("Day", row.Get<int>("Day"));
                output.Set<long?>("TotalVisits", row.Get<long?>("TotalVisits"));
                long IP = row.Get<long>("IPInt");

                string Location = "";

                if (ipList != null)
                {
                    var loc = (from w in ipList
                               where IP >= w.IPStart && IP <= w.IPEnd
                               select new
                               {
                                   country = w.country,
                                   state = w.state,
                                   city = w.city
                               }).ToList();

                    if ((loc != null) && (loc.Count > 0))
                    {
                        if (String.IsNullOrEmpty(loc[0].state))
                        {
                            Location = String.Format("{0}, {1}", loc[0].city, loc[0].country);
                        }
                        else
                        {
                            Location = String.Format("{0}, {1}, {2}", loc[0].city, loc[0].state, loc[0].country);
                        }
                    }
                };

                output.Set<string>("Location", Location);
                yield return output.AsReadOnly();
            }
        }
    }
}
