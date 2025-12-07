using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace Training.DataContext;

public class CommandTimeOutInterceptor : DbCommandInterceptor
{
    private readonly TimeSpan _maxTimeout = TimeSpan.FromSeconds(5);

    public override async ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        return await HandleCommandTimeoutAsync(command, cancellationToken);
    }

    private async Task<InterceptionResult<int>> HandleCommandTimeoutAsync(DbCommand command, CancellationToken cancellationToken)
    {
        if(command.CommandTimeout > _maxTimeout.TotalSeconds)
        {
            Console.WriteLine($"Async long-running query detected: {command.CommandText}");

            await File.AppendAllTextAsync(@".\sql_log.txt", 
                    $"[{DateTime.Now}] Timeout SQL Command: {command.CommandText}\n");
        }

        var affectedRows = await command.ExecuteNonQueryAsync(cancellationToken);

        return InterceptionResult<int>.SuppressWithResult(affectedRows);
    }
}
