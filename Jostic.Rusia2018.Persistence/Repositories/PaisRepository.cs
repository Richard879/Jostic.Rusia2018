using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Persistence.Context;
using System.Data;
using Dapper;
using System.Linq;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly DapperContext _context;

        public PaisRepository(DapperContext context)
        {
            _context = context;
        }

        #region Métodos Síncronos
        public bool Insert(Pais entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pais entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
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
                var query = "GrupoList";

                var paises = connection.Query<Pais>(query, commandType: CommandType.StoredProcedure);
                return paises;
            }
        }

        public IEnumerable<Pais> GetPaisesAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "PaisListAll";

                var paises = connection.Query<Pais, Grupo, Continente, Tecnico, Pais>(query, (country, group, continent, technical) => {
                    country.grupo = group;
                    country.continente = continent;
                    country.tecnico = technical;
                    return country;
                },
                splitOn: "descripcion, idGrupo, idContinente, idTecnico").ToList();

                return paises;
            }
        }

        public IEnumerable<Pais> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Métodos Asíncronos

        public Task<bool> InsertAsync(Pais entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Pais entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Pais> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pais>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "PaisList";

                var paises = await connection.QueryAsync<Pais>(query, commandType: CommandType.StoredProcedure);
                return paises;
            }
        }

        public async Task<IEnumerable<Pais>> GetPaisesAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "PaisListAll";

                var paises = await connection.QueryAsync<Pais, Grupo, Continente, Tecnico, Pais>(query, (country, group, continent, technical) => {
                    country.grupo = group;
                    country.continente = continent;
                    country.tecnico = technical;
                    return country;
                },
                splitOn: "descripcion, idGrupo, idContinente, idTecnico");

                return paises.ToList();
            }
        }

        public async Task<IEnumerable<Pais>> GetPaisesAllFiltro(Pais entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "PaisListAll";

                var paises = await connection.QueryAsync<Pais, Grupo, Continente, Tecnico, Pais>(query, (country, group, continent, technical) => {
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

        public Task<IEnumerable<Pais>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
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
