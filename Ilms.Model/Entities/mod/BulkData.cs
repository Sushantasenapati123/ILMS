using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Model.Entities.Mod
{
    public class BulkData
    {
        public string vchOpponentName { get; set; }
        public int intOpponentTypeID { get; set; }
        public int SequenceId { get; set; }
        public int intRegistrationID { get; set; }
        public string govtPartyName { get; set; }
        public string govtPartyId { get; set; }
        public string sequenceIdarr { get; set; }

        public int ID { get; set; }
        public int? DeptId { get; set; }
        public int? GovtPaty { get; set; }
        public string? Name { get; set; }
    }
}
