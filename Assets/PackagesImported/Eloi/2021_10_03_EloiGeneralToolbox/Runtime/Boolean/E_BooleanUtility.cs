using System;
using System.Collections.Generic;

namespace Eloi
{
    public class E_BooleanUtility
    {

        public enum BoolConditionToCheck { LookForAllTrue, LookForAllFalse, LookForOneTrue, LookForOneFalse }

        public static bool IsConditionTrue (in BoolConditionToCheck conditionType, 
            in IEnumerable<bool> enumerable)
        {
            if (conditionType == BoolConditionToCheck.LookForAllTrue)
                return AreAllTrue(enumerable); 
            if (conditionType == BoolConditionToCheck.LookForAllFalse)
                return AreAllFalse(enumerable);
            if (conditionType == BoolConditionToCheck.LookForOneTrue)
                return IsOneTrue(enumerable); 
            if (conditionType == BoolConditionToCheck.LookForOneFalse)
                return IsOneFalse(enumerable);
            throw new Exception("Hum. Some enum was added but not managed");
        }


        public static bool AreAllTrue(IEnumerable<bool> enumerable)
        {
            foreach (var item in enumerable)
            {
                if (item == false)
                    return false;
            }
            return true;
        }
        public static bool AreAllFalse(IEnumerable<bool> enumerable)
        {
            foreach (var item in enumerable)
            {
                if (item == true)
                    return false;
            }
            return true;
        }
        public static bool IsOneTrue(IEnumerable<bool> enumerable)
        {
            foreach (var item in enumerable)
            {
                if (item == true)
                    return true;
            }
            return false;
        }
        public static bool IsOneFalse(IEnumerable<bool> enumerable)
        {
            foreach (var item in enumerable)
            {
                if (item == false)
                    return true;
            }
            return false;
        }
    }
}