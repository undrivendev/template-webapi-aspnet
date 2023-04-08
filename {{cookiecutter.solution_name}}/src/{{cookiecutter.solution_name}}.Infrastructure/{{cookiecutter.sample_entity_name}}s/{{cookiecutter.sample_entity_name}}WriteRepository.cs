using {{cookiecutter.solution_name}}.Core;
using {{cookiecutter.solution_name}}.Core.{{cookiecutter.sample_entity_name}}s;
using {{cookiecutter.solution_name}}.Infrastructure.Persistence;

namespace {{cookiecutter.solution_name}}.Infrastructure.{{cookiecutter.sample_entity_name}}s;

public class {{cookiecutter.sample_entity_name}}WriteRepository : WriteRepositoryBase<{{cookiecutter.sample_entity_name}}>, I{{cookiecutter.sample_entity_name}}WriteRepository
{
    public {{cookiecutter.sample_entity_name}}WriteRepository()
        : base() { }
}
