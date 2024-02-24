using System;
using Ilms.Model.BaseEntityModel;
using Proj.Model.Entities.Mod;
namespace Ilms.Model.Demo_T_LMS
{
	public class Demo_T_LMS 
	{
		public int ID { get; set; }
		public int? DeptId { get; set; }
		public int? GovtPaty { get; set; }
        public string? Name { get; set; }

        public List<BulkData> ListData { get; set; }
    }
}

