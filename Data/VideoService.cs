using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using BlazorDapperCRUD.Data;

namespace BlazorDapperCRUD.Data
{
    public class VideoService : IVideoService
    {
        private readonly SqlConnectionConfiguration _conn;

        public VideoService(SqlConnectionConfiguration conn)
        {
            _conn = conn;
        }

        public async Task<bool> VideoInsert(Video video)
        {
            using (var c = new SqlConnection(_conn.Value))
            {
                var param = new DynamicParameters();
                param.Add("TITLE", video.TITLE, DbType.String);
                param.Add("DATE_PUBLISHED", video.DATE_PUBLISHED, DbType.Date);
                param.Add("IS_ACTIVE", video.IS_ACTIVE, DbType.Boolean);

                const string query = @"INSERT INTO VIDEO (TITLE, DATE_PUBLISHED, IS_ACTIVE) VALUES(@TITLE, @DATE_PUBLISHED, @IS_ACTIVE)";
                await c.ExecuteAsync(query, new { video.TITLE, video.DATE_PUBLISHED, video.IS_ACTIVE }, commandType: CommandType.Text);
            }

            return true;
        }
    }
}
