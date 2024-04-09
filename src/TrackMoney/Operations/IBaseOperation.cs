namespace TrackMoney.Operations;

internal interface IBaseOperation
{
    Task Run();
    Task Rollback();
}
