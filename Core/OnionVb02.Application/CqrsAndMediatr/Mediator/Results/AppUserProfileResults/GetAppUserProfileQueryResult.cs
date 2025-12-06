using System;
using System.Reflection.PortableExecutable;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

public class GetAppUserProfileQueryResult
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
