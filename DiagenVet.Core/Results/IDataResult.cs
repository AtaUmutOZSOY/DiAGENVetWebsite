namespace DiagenVet.Core.Results;

public interface IDataResult<T> : IResult
{
    T Data { get; }
} 