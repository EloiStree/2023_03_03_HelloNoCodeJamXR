using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Eloi {
    public class E_CodeTag
    {


        public class NiceToHave {

            public static void Info(string message)
            { }
        }
        public class Inspector {

            [System.Serializable]
            public class WorkButNotProud {
                [TextArea(0,3)]
                [Tooltip("If you see this field. I not prouve of something in the class. And I am warning you here. If you see a better way feel free to ping me. http://eloistree.page.link/discord")]
                public string m_whyInfo;

                public WorkButNotProud(string whyInfo)
                {
                    m_whyInfo = whyInfo;
                }
            }

        }
        public class SideEffect
        {
            public static void Info(string message)
            {            }
        }
        public class QualityAssurance {

            public enum TestedStateType { NotAtAll, NotAtAllButShould, SomeQuickTest, Tested, StressTested, AlmostGoodEnough, GoodEnough, GuarantyNoBug}
            public static void TestedState(TestedStateType state) { }
            public static void CouldBeBuggy(string info) { }
            public static void RequestTestingInTheFuture() { }
            public static void RequestTestingInAsSoonAsPossible() { }
            public class State {
                public static void Quality(float pourcent) { }
                public static void Completeness(float pourcent) { }
                public static void GoodEnough(float pourcent) { }
                public static void PleasedEnough(float pourcent) { }
                public static void AlmostFinished(float pourcent) { }
            }

        }

        public class WrongLogicToWinTime {
            public static void Info(string message)
            {

            }
        }

        public static void I_am_Here()
        {
        }

        public static void ChatGPTSource() { }
        public static void ChatGPTSource(string message) { }

        public class NotSureIfGoodIdea {
            public static void Info(string message)
            {

            }
        }
        public class NotTimeNow
        {
            /// <summary>
            /// This script is use just to say that I don't have the time now but need to code something later.
            /// </summary>
            /// <param name="message"></param>
            public static void Info(string message)
            {

            }
        }

        public class NotTimeNowButUrgent
        {
             public static void Info(string message)
            {

            }
        }

        public class ToCodeLater
        {
            /// <summary>
            /// This script is use just to say that I don't have the time now but need to code something later.
            /// </summary>
            /// <param name="message"></param>
            public static void Info(string message)
            {

            }
        }
        public class NeedHelp
        {
            /// <summary>
            /// This script is use just to say that I need help and can't code this part yet.
            /// </summary>
            /// <param name="message"></param>
            public static void Info(string message)
            {

            }/// <summary>
             /// This script is use just to say that I need help and can't code this part yet.
             /// </summary>
             /// <param name="message"></param>
            public static void DontKnowHowToCodeThat(string message="")
            { }
            public static void NotSureItIsTheRightWay(string message = "")
            { }
            public static void ShouldBeAllRightButIsIt(string message = "")
            { }
        }

        public class NeedCommunityHelp
        {
            /// <summary>
            /// There is a taks that I could spend day doing that community could do if someone want to help.
            /// Feel free to search this tag if you want to help.
            /// </summary>
            /// <param name="message"></param>
            public static void Info(string message)
            {

            }
        }

        public class ToCodeLaterWhenCodeIsReady
        {
            /// <summary>
            /// This script is use just to say that I don't have the time now but need to code something later.
            /// </summary>
            /// <param name="message"></param>
            public static void Info(string message)
            {

            }
        }
        public class SleepyCode
        {
            /// <summary>
            /// This script is use just to say that I don't have the time now but need to code something later.
            /// </summary>
            /// <param name="message"></param>
            public static void Info(string message)
            {

            }
        }
        public class DirtyCode
        {
            public static void DirtyCatch()
            {
                DirtyCatch("Apprentely I had not patience to handle the catch overthere.");
            }
            public static void DirtyCatch(string message)
            {
            }

            /// <summary>
            /// This script is use just to say that I don't have the time now but need to code something later.
            /// </summary>
            /// <param name="message"></param>
            public static void Info(string message)
            {

            }
        }
        
        public class CouldBeProblemLater
        {
            /// <summary>
            /// This script is use just to say that I don't have the time now but need to code something later.
            /// </summary>
            /// <param name="message"></param>
            public static void Info(string message)
            {

            }
        }

    }
}
