using System.Collections.Generic;
using Ilms.Repository.Factory;
using Ilms.Repository.BaseRepository;
using Ilms.Repository.Repositories.Interfaces;
using Ilms.Repository;

using Ilms.Model.Demo_T_LMS;
using Dapper;
using System.Data;
using Proj.Model.Entities.Mod;
using System.Data.SqlClient;
namespace Ilms.Repository.Repository
{
    public class modRepository : i3msRepositoryBase, ImodRepository
    {
        public modRepository(Ii3msConnectionFactory i3msConnectionFactory) : base(i3msConnectionFactory)
        {

        }
        public async Task<int> Insert_Demo_T_LMS(Demo_T_LMS TBL)
        {

            try
            {
                var p = new DynamicParameters();
                if (TBL.ID == 0)
                {
                    p.Add("@P_Action", "I");
                    p.Add("@P_ID", 0);
                }
                else
                {
                    p.Add("@P_Action", "U");
                    p.Add("@P_ID", TBL.ID);
                }
                p.Add("@P_DeptId", TBL.DeptId);
                p.Add("@P_GovtPaty", TBL.GovtPaty);
                var results = await Connection.ExecuteAsync("USP_Demo_T_LMS_Copy_1", p, commandType: CommandType.StoredProcedure);
                return 1;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<int> Delete_Demo_T_LMS(int Id)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "D");
                p.Add("@P_ID", Id);

                var results = await Connection.ExecuteAsync("USP_Demo_T_LMS_Copy_1", p, commandType: CommandType.StoredProcedure);
                return results;
            }
            catch (Exception EX)
            {
                throw EX;
            }

        }
        public async Task<Demo_T_LMS> GetDemo_T_LMSById(int Id)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "E");
                p.Add("@P_ID", Id);

                var results = await Connection.QueryAsync<Demo_T_LMS>("USP_Demo_T_LMS_Copy_1", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }

            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<Demo_T_LMS>> Getall_Demo_T_LMS(Demo_T_LMS TBL)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "V");
                var results = await Connection.QueryAsync<Demo_T_LMS>("USP_Demo_T_LMS_Copy_1", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }
        public async Task<List<Demo_T_LMS>> Search_Demo_T_LMS(Demo_T_LMS TBL)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "S");
                p.Add("@P_ID", TBL.ID);

                p.Add("@P_DeptId", TBL.DeptId);
                p.Add("@P_GovtPaty", TBL.GovtPaty);
                var results = await Connection.QueryAsync<Demo_T_LMS>("USP_Demo_T_LMS_Copy_1", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }

            catch (Exception EX)
            {
                throw EX;
            }

        }
        public async Task<int> InsertOpponentData(List<BulkData> obj)
        {
            try
            {
                DataTable opponentTable = new DataTable();
                // Define the columns of the DataTable (assuming you want to store just the mobile number)
                opponentTable.Columns.Add("DeptId", typeof(int));
                opponentTable.Columns.Add("GovtPaty", typeof(int));
                opponentTable.Columns.Add("Name", typeof(string));
                //opponentTable.Columns.Add("intRegistrationID", typeof(int));

                // Add rows to the DataTable using the mobile numbers received from the AJAX request
                foreach (var opponent in obj)
                {
                    opponentTable.Rows.Add
                    (
                        opponent.DeptId,
                        opponent.GovtPaty,
                        opponent.Name
                        
                    );
                }
                var res = Convert.ToInt32(InsertOpponentTable(opponentTable));
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string InsertOpponentTable(DataTable datatable)
        {
            string connectionString = "Data Source=CSMBHUL954\\SQLEXPRESS;Initial Catalog=i3ms;TrustServerCertificate=true;Integrated Security=true;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_InsertOpponentData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter tvpParam = command.Parameters.AddWithValue("@OpponentTableTypeParameter", datatable);
                        tvpParam.SqlDbType = SqlDbType.Structured;
                        tvpParam.TypeName = "OpponentTableType1";
                        command.ExecuteNonQuery();
                        return "1";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
