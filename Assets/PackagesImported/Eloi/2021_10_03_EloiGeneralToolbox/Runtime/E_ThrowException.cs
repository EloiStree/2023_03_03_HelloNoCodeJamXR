using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class E_ThrowException : MonoBehaviour
    {

        public static void ThrowNotImplemented(string message = "")
        {
            throw new System.NotImplementedException(message);
        }
        public static void ThrowEasyToCodeButNotCodedYet(string message = "")
        {
            throw new EasyToCodeButNotCodedYet(message);
        }
        public static void ThrowTrustMeBroWarningException(string message = "")
        {
            throw new TrustMeBroException(message);
        }
        public static void ThrowNotMyProblemException(string whoToContactIfNeedHelpOrCorrection, string message = "")
        {
            throw new NotMyProblemException(whoToContactIfNeedHelpOrCorrection, message);
        }


        /// <summary>
        /// The problem trigger is not due to the developer but due to the use of the code or the send params
        /// </summary>
        private class NotMyProblemException : Exception
        {
            public string m_whoToContactIfNeedHelpOrCorrection;
            public NotMyProblemException(string devName, string whyItIsNotTheProblemOfTheDevCode) : base(whyItIsNotTheProblemOfTheDevCode)
            {
                m_whoToContactIfNeedHelpOrCorrection = devName;
            }
        }

        public class TrustMeBroException : Exception
        {
            public TrustMeBroException(string message = "") : base(message) { }
        }

        public class EasyToCodeButNotCodedYet : Exception
        {

            public EasyToCodeButNotCodedYet(string message="") : base(message) { }
        }
    }
}