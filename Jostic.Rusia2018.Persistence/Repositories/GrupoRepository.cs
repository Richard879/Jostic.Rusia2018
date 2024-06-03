using Dapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    internal class GrupoRepository : IGrupoRepository
    {
        private readonly DapperContext _context;

        public GrupoRepository(DapperContext context)
        {
            _context = context;
        }

        #region Métodos Síncronos

        public bool Insert(Grupo entity)
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

        public bool Update(Grupo entity)
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

        public Grupo Get(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("idGrupo", id);

                var grupo = connection.QuerySingle<Grupo>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return grupo;
            }
        }

        public IEnumerable<Grupo> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoList";

                var grupos = connection.Query<Grupo>(query, commandType: CommandType.StoredProcedure);
                return grupos;
            }
        }

        public IEnumerable<Grupo> GetAllWithPagination(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "GrupoListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize);

            var grupos = connection.Query<Grupo>(query, param: parameters, commandType: CommandType.StoredProcedure);
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

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Grupo>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoList";

                var grupos = await connection.QueryAsync<Grupo>(query, commandType: CommandType.StoredProcedure);
                return grupos;
            }
        }

        public Task<IEnumerable<Grupo>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Grupo> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Grupo entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Grupo entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
