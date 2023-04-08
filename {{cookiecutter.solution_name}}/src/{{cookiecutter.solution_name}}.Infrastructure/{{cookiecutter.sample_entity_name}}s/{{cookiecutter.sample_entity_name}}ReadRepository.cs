using System.Data.Common;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;
using {{cookiecutter.solution_name}}.Infrastructure.Persistence;

namespace {{cookiecutter.solution_name}}.Infrastructure.{{cookiecutter.sample_entity_name}}s;

public class {{cookiecutter.sample_entity_name}}ReadRepository : ReadRepositoryBase<{{cookiecutter.sample_entity_name}}>, I{{cookiecutter.sample_entity_name}}ReadRepository
{
    public {{cookiecutter.sample_entity_name}}ReadRepository(DbDataSource db)
        : base(db) { }
}
