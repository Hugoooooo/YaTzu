using System.Collections.Generic;

namespace System.Framework.DataLayer
{
    public class Audit
    {
        public string Company { get; set; }
        public string LoginID { get; set; }
        public string SystemID { get; set; }
        public string ClientIP { get; set; }
        public string Host { get; set; }
        public string FunctionName { get; set; }
        public List<Function> Functions { get; set; }
        public List<string> AuditHistory { get; set; }

        public Audit()
        {
            Functions = new List<Function>();
            AuditHistory = new List<string>();
        }
    }

    public class Function
    {
        public string Serno { get; set; }
        public string Module { get; set; }
        public string Name { get; set; }
        public bool NeedAudit { get; set; }
        public string EntityName { get; set; }
        public string ViewName { get; set; }

        public Function()
        {

        }
    }
}
