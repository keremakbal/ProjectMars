using System;
using System.Text;

namespace Domain
{
    public static class ExceptionExtension
    {
        public static string CreateExceptionString(this Exception exception)
        {
            var sb = new StringBuilder();
            CreateExceptionString(sb, exception, string.Empty);
            return sb.ToString();
        }
        private static void CreateExceptionString(StringBuilder sb, Exception e, string indent)
        {
            if (indent == null)
                indent = string.Empty;
            else if (indent.Length > 0)
                sb.AppendFormat("{0}Inner ", indent);

            sb.AppendFormat("Exception Found:\n{0}Type: {1}", indent, e.GetType().FullName);
            sb.AppendFormat("\n{0}Message: {1}", indent, e.Message);
            sb.AppendFormat("\n{0}Source: {1}", indent, e.Source);
            sb.AppendFormat("\n{0}Stacktrace: {1}", indent, e.StackTrace);

            if (e.InnerException != null)
            {
                sb.Append("\n");
                CreateExceptionString(sb, e.InnerException, indent + "  ");
            }
        }
    }
}
