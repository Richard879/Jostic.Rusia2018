using Dapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Persistence.Context;
using System.Data;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    public class TechnicalRepository : ITechnicalRepository
    {
        private readonly DapperContext _context;

        public TechnicalRepository(DapperContext context)
        {
            _context = context;
        }

        #region Métodos Asíncronos
        public async Task<bool> InsertAsync(Technical entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "TecnicoInsert";
                var parameters = new DynamicParameters();
                parameters.Add("nomTecnico", entity.nomTecnico);
                parameters.Add("nacionalidad", entity.nacionalidad);
                parameters.Add("fechaNacimiento", entity.fechaNacimiento);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Technical entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "TecnicoUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("idTecnico", entity.idTecnico);
                parameters.Add("nomTecnico", entity.nomTecnico);
                parameters.Add("nacionalidad", entity.nacionalidad);
                parameters.Add("fechaNacimiento", entity.fechaNacimiento);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "TecnicoDelete";
                var parameters = new DynamicParameters();
                parameters.Add("idTecnico", id);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Technical> GetAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "TecnicoGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("idTecnico", id);

                var entity = await connection.QuerySingleAsync<Technical>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public async Task<IEnumerable<Technical>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "TecnicoList";

                var entity = await connection.QueryAsync<Technical>(query, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public async Task<IEnumerable<Technical>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "TecnicoListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            var entity = await connection.QueryAsync<Technical>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public async Task<int> CountAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Tecnico";
            var parameters = new DynamicParameters();

            var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;
        }

        #endregion
    }
}