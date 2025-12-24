using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;

[GenerateBuilder]
public sealed partial record SessionQuery(Guid[] Keys);