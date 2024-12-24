using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AirPark
{
    public static class Utils
    {
        public static bool SafeLoad(this ConfigNode node, string value, bool oldvalue)
        {
            if (!node.HasValue(value))
            {
                //Log.Info("SafeLoad bool, node missing value: " + value + ", oldvalue: " + oldvalue);
                return oldvalue;
            }

            try { return bool.Parse(node.GetValue(value)); }
            catch { return oldvalue; }
        }

        public static Vector3 SafeLoad(this ConfigNode node, string value, Vector3 oldvalue)
        {
            if (!node.HasValue(value))
            {
                //Log.Info("SafeLoad bool, node missing value: " + value + ", oldvalue: " + oldvalue);
                return oldvalue;
            }

            try { return ConfigNode.ParseVector3(node.GetValue(value)); }
            catch { return oldvalue; }
        }

        public static string SafeLoad(this ConfigNode node, string value, string oldvalue)
        {
            if (!node.HasValue(value))
            {
                //Log.Info("SafeLoad string, node missing value: " + value + ", oldvalue: " + oldvalue);
                return oldvalue;
            }
            return node.GetValue(value);
        }
        public static int SafeLoad(this ConfigNode node, string value, int oldvalue)
        {
            if (!node.HasValue(value))
            {
                //Log.Info("SafeLoad int, node missing value: " + value + ", oldvalue: " + oldvalue);
                return oldvalue;
            }
            try { return int.Parse(node.GetValue(value)); }
            catch { return oldvalue; }
        }

    }
}
