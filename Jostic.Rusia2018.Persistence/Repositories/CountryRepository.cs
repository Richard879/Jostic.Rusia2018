using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Persistence.Context;
using System.Data;
using Dapper;
using System.Linq;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    public class CountryRepository : IPaisRepository
    {
        private readonly DapperContext _context;

        public CountryRepository(DapperContext context)
        {
            _context = context;
        }

        #region Métodos Síncronos
        public bool Insert(Country entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Country entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Country Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GrupoList";

                var paises = connection.Query<Country>(query, commandType: CommandType.StoredProcedure);
                return paises;
            }
        }

        public IEnumerable<Country> GetPaisesAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "PaisListAll";

                var paises = connection.Query<Country, Group, Continent, Technical, Country>(query, (country, group, continent, technical) => {
                    country.grupo = group;
                    country.continente = continent;
                    country.tecnico = technical;
                    return country;
                },
                splitOn: "descripcion, idGrupo, idContinente, idTecnico").ToList();

                return paises;
            }
        }

        public IEnumerable<Country> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Métodos Asíncronos

        public Task<bool> InsertAsync(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Country> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "PaisList";

                var paises = await connection.QueryAsync<Country>(query, commandType: CommandType.StoredProcedure);
                return paises;
            }
        }

        public async Task<IEnumerable<Country>> GetPaisesAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "PaisListAll";

                var paises = await connection.QueryAsync<Country, Group, Continent, Technical, Country>(query, (country, group, continent, technical) => {
                    country.grupo = group;
                    country.continente = continent;
                    country.tecnico = technical;
                    return country;
                },
                splitOn: "descripcion, idGrupo, idContinente, idTecnico");

                return paises.ToList();
            }
        }

        public async Task<IEnumerable<Country>> GetPaisesAllFiltro(Country entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "PaisListAll";

                var paises = await connection.QueryAsync<Country, Group, Continent, Technical, Country>(query, (country, group, continent, technical) => {
                    country.grupo = group;
                    country.continente = continent;
                    country.tecnico = technical;
                    return country;
                },
                splitOn: "descripcion, idGrupo, idContinente, idTecnico");

                var filter = paises.Where(p => p.idPais == entity.idPais || 
                                            p.nomPais == entity.nomPais || 
                                            p.grupo.idGrupo == entity.grupo.idGrupo ||
                                            p.grupo.descripcion == entity.grupo.descripcion  ||
                                            p.tecnico.idTecnico == entity.tecnico.idTecnico ||
                                            p.tecnico.nomTecnico == entity.tecnico.nomTecnico).ToList();

                return filter;
            }
        }

        public Task<IEnumerable<Country>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
