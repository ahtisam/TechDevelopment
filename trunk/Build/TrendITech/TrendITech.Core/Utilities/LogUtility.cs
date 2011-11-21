using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using log4net;

namespace TrendITech.Core.Utilities
{
    internal static class LogUtility
    {

        /// <summary>
        /// Logs an error using log4net
        /// </summary>
        /// <param name="ex">The error to log</param>
        internal static void LogError(Exception ex)
        {
            MethodBase callingMethod = new System.Diagnostics.StackFrame(1, false).GetMethod();
            ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            MDC.Set("requestinfo", String.Empty);
            logger.Error(GetErrorMessageTitle(callingMethod.Name), ex);
        }

        /// <summary>
        /// Logs an error using log4net
        /// </summary>
        internal static void LogError(Exception ex, params object[] paramValues)
        {
            MethodBase callingMethod = new System.Diagnostics.StackFrame(1, false).GetMethod();
            ILog logger = LogManager.GetLogger(callingMethod.DeclaringType);

            string message = GetErrorMessageTitle(callingMethod.Name);
            if (paramValues != null)
            {
                for (int i = 0; i < paramValues.Length; i++)
                    message += String.Format("\r\n Parameter {0} = {1}", i + 1, GetParamValue(paramValues[i]));
            }

            MDC.Set("requestinfo", String.Empty);
            logger.Error(message, ex);

        }

        /// <summary>
        /// Gets the value of a parameter
        /// </summary>
        /// <param name="o">the parameter</param>
        /// <returns>string or serialised xml representation of the parameter</returns>
        private static string GetParamValue(object o)
        {
            string paramDetails = String.Empty;
            if (o != null)
            {
                try
                {
                    Type t = o.GetType();
                    if (t.IsValueType || t.IsSerializable == false || t.Name == "String")
                    {
                        paramDetails = String.Format("{0} : {1}", t, o);
                    }
                    else
                    {
                        System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(t);
                        using (System.IO.StringWriter sw = new System.IO.StringWriter())
                        {
                            s.Serialize(sw, o);
                            paramDetails = String.Format("{0} : {1}", t, sw);
                        }
                    }
                }
                catch
                {
                    paramDetails = o.ToString();
                }
            }

            return paramDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
        private static string GetErrorMessageTitle(string methodName)
        {
            if (HttpContext.Current != null)
            {
                return String.Format("Error in method '{0}'\r\nUrl '{1}'", methodName, HttpContext.Current.Request.Url);
            }
            else
                return String.Format("Error in method '{0}'", methodName);
        }
    }
}
