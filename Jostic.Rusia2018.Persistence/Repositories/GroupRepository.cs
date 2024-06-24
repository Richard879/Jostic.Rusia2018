using Dapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Persistence.Context;
using System.Data;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    internal class GroupRepository : IGrupoRepository
    {
        private readonly DapperContext _context;

        public GroupRepository(DapperContext context)
        {
            _context = context;
        }

        #region Métodos Síncronos

        public bool Insert(Group entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoInsert";
                var parameters = new DynamicParameters();
                //parameters.Add("idGrupo", entity.idGrupo);
                parameters.Add("descripcion", entity.descripcion);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Group entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("idGrupo", entity.idGrupo);
                parameters.Add("descripcion", entity.descripcion);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoDelete";
                var parameters = new DynamicParameters();
                parameters.Add("idGrupo", id);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Group Get(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("idGrupo", id);

                var grupo = connection.QuerySingle<Group>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return grupo;
            }
        }

        public IEnumerable<Group> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoList";

                var grupos = connection.Query<Group>(query, commandType: CommandType.StoredProcedure);
                return grupos;
            }
        }

        public IEnumerable<Group> GetAllWithPagination(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "GrupoListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            var grupos = connection.Query<Group>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return grupos;
        }

        public int Count()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Grupo";
            var parameters = new DynamicParameters();

            var count = connection.ExecuteScalar<int>(query, commandType: CommandType.Text);
            return count;
        }
        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Group entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoInsert";
                var parameters = new DynamicParameters();
                parameters.Add("descripcion", entity.descripcion);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Group entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("idGrupo", entity.idGrupo);
                parameters.Add("descripcion", entity.descripcion);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoDelete";
                var parameters = new DynamicParameters();
                parameters.Add("idGrupo", id);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Group> GetAsync(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("idGrupo", id);

                var entity = await connection.QuerySingleAsync<Group>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoList";

                var entity = await connection.QueryAsync<Group>(query, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }

        public async Task<IEnumerable<Group>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "GrupoListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            var entity = await connection.QueryAsync<Group>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public async Task<int> CountAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Grupo";
            var parameters = new DynamicParameters();

            var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;
        }
        #endregion
    }
}