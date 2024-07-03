using Dapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Persistence.Context;
using System.Data;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    public class PhaseRepository : IPhaseRepository
    {
        private readonly DapperContext _context;

        public PhaseRepository(DapperContext context)
        {
            _context = context;
        }

        #region Métodos Asíncronos
        public async Task<int> CountAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Fase";
            var parameters = new DynamicParameters();

            var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "FaseDelete";
                var parameters = new DynamicParameters();
                parameters.Add("idFase", id);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<IEnumerable<Phase>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "FaseList";

                var entity = await connection.QueryAsync<Phase>(query, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public async Task<IEnumerable<Phase>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "FaseListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            var entity = await connection.QueryAsync<Phase>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public async Task<Phase> GetAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "FaseGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("idFase", id);

                var entity = await connection.QuerySingleAsync<Phase>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public async Task<bool> InsertAsync(Phase entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "FaseInsert";
                var parameters = new DynamicParameters();
                parameters.Add("descripcion", entity.descripcion);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Phase entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "FaseUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("idFase", entity.idFase);
                parameters.Add("descripcion", entity.descripcion);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        #endregion
    }
}