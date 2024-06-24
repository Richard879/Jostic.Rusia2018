using Dapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Persistence.Context;
using System.Data;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    public class ContinentRepository : IContinentRepository
    {
        private readonly DapperContext _context;

        public ContinentRepository(DapperContext context)
        {
            _context = context;
        }

        #region Métodos Asíncronos
        public async Task<bool> InsertAsync(Continent entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "ContinenteInsert";
                var parameters = new DynamicParameters();
                parameters.Add("descripcion", entity.descripcion);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Continent entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "ContinenteUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("idContinente", entity.idContinente);
                parameters.Add("descripcion", entity.descripcion);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "ContinenteDelete";
                var parameters = new DynamicParameters();
                parameters.Add("idContinente", id);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Continent> GetAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "ContinenteGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("idContinente", id);

                var entity = await connection.QuerySingleAsync<Continent>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public async Task<IEnumerable<Continent>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "ContinenteList";

                var entity = await connection.QueryAsync<Continent>(query, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public async Task<IEnumerable<Continent>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "ContinenteListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            var entity = await connection.QueryAsync<Continent>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public async Task<int> CountAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Continente";
            var parameters = new DynamicParameters();

            var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;
        }
        #endregion
    }
}
