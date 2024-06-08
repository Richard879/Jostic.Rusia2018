using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Persistence.Context;
using System.Data;
using Dapper;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly DapperContext _context;

        public PaisRepository(DapperContext context)
        {
            _context = context;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Pais Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "PaisList";

                var grupos = connection.Query<Pais, Grupo, Pais>(query, (country, group) => {
                    country.grupo = group;
                    return country;
                },
                splitOn: "idGrupo");

                return grupos;
            }
        }

        public List<Pais> GetPaises()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "PaisList";

                var grupos = connection.Query<Pais, Grupo, Pais>(query, (country, group) => {
                    country.grupo = group;
                    return country;
                },
                splitOn: "idGrupo").ToList();

                return grupos;
            }
        }

        public Task<IEnumerable<Pais>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pais>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Pais> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Pais entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Pais entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pais entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Pais entity)
        {
            throw new NotImplementedException();
        }
    }
}
