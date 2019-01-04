using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ADLADemo
{
    //public static class Convertor
    //{
    //    public static long GetIP(string ip)
    //    {
    //        try
    //        {
    //            var p = ip.Replace("\"", "").Split('.');
    //            return long.Parse(p[0] + "000000000") + long.Parse(p[1]
    //             + "000000") + long.Parse(p[2] + "000") + long.Parse(p[3]);
    //        }
    //        catch
    //        {
    //            return 0;
    //        }
    //    }

    //    public static int GetPartitionID(string ip)
    //    {
    //        try
    //        {
    //            var p = ip.Replace("\"", "").Split('.');
    //            return int.Parse(p[0]);
    //        }
    //        catch
    //        {
    //            return 0;
    //        }
    //    }
    //}
}
