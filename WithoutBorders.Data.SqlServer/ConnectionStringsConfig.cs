using System.Collections.Generic;

namespace WithoutBorders.Data.SqlServer
{
    public class ConnectionStringsConfig
    {
        public string SelectedConnection { get; set; }
        public IReadOnlyDictionary<string, string> ConnectionStrings { get; set; }
    }
}