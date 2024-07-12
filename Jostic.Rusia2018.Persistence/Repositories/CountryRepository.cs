using Dapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Persistence.Context;
using System.Data;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DapperContext _context;

        public CountryRepository(DapperContext context)
        {
            _context = context;
        }

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Country entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "PaisInsert";
                var parameters = new DynamicParameters();
                parameters.Add("nomPais", entity.nomPais);
                parameters.Add("idTecnico", entity.tecnico.idTecnico);
                parameters.Add("idGrupo", entity.grupo.idGrupo);
                parameters.Add("idContinente", entity.continente.idContinente);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
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

        public async Task<IEnumerable<Country>> GetCountriesAllAsync()
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

        public async Task<IEnumerable<Country>> GetCountriesAllFilter(Country entity)
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

                var filter = paises.Where(p => p.idPais == entity.idPais && 
                                            (entity.nomPais == String.Empty || p.nomPais == entity.nomPais) && 
                                            (entity.grupo.idGrupo == 0 || p.grupo.idGrupo == entity.grupo.idGrupo) &&
                                            (entity.grupo.descripcion == String.Empty || p.grupo.descripcion == entity.grupo.descripcion) &&
                                            (entity.tecnico.idTecnico == 0 || p.tecnico.idTecnico == entity.tecnico.idTecnico) &&
                                            (entity.tecnico.nomTecnico == String.Empty || p.tecnico.nomTecnico == entity.tecnico.nomTecnico)).ToList();

                return filter;
            }
        }

        public Task<IEnumerable<Country>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Pais";
            var parameters = new DynamicParameters();

            var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;
        }

        public async Task<IEnumerable<Country>> GetCountryValidate(Country entity)
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

                var filter = paises.Where(p => (p.nomPais == entity.nomPais) ||
                                            (p.tecnico.idTecnico == entity.tecnico.idTecnico)).ToList();

                return filter;
            }
        }
        #endregion
    }
}