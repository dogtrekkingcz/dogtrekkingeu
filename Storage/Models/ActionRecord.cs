using SharedCode.Entities;

namespace Storage.Models;

internal sealed record ActionRecord : ActionDto, IRecord
{
}