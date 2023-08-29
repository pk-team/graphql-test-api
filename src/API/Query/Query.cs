using Application.Query;
using Domain.Model;
using Infrastructure.Context;

namespace API.Query;

public class Query {
    public string Hello => "Hello World!";


    public List<Person> GetPeople(
        [Service] GetPeopleQuery query,
        int first = 3
    ) {
        return query.Handle(first);
    }

    public Person GetPerson(
        [Service] GetPersonQuery query,
        Guid Id
    ) {
        return query.Handle(Id);
    }
}