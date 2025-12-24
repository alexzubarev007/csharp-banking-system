using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;

[GenerateBuilder]
public sealed partial record AccountQuery(AccountId[] Ids);