using TrackMoney.Operations;

namespace TrackMoney.Services;

internal class QueueOperationsService : IQueueOperationsService
{

    readonly List<IBaseOperation> operations = [];

    public void Enqueue(IBaseOperation operation)
    {
        operations.Add(operation);
    }

    public async Task ExecuteNextOperation()
    {
        if (operations.Any())
        {
            var operation = operations.First();
            operations.RemoveAt(0);
            try
            {
                await operation.Run();

            }
            catch (Exception)
            {
                await operation.Rollback();
            }
        }
    }
}
