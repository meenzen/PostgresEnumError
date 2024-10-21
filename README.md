# Duplicate Enum Creation

1. Run the database (`docker compose up -d`)
2. Run the app
3. Observe that this exception is thrown:
    ```
    Unhandled exception. Npgsql.PostgresException (0x80004005): 42710: type "marriage_status" already exists
    at Npgsql.Internal.NpgsqlConnector.ReadMessageLong(Boolean async, DataRowLoadingMode dataRowLoadingMode, Boolean readingNotifications, Boolean isReadingPrependedMessage)
    at System.Runtime.CompilerServices.PoolingAsyncValueTaskMethodBuilder`1.StateMachineBox`1.System.Threading.Tasks.Sources.IValueTaskSource<TResult>.GetResult(Int16 token)
    at Npgsql.NpgsqlDataReader.NextResult(Boolean async, Boolean isConsuming, CancellationToken cancellationToken)
    at Npgsql.NpgsqlDataReader.NextResult(Boolean async, Boolean isConsuming, CancellationToken cancellationToken)
    at Npgsql.NpgsqlCommand.ExecuteReader(Boolean async, CommandBehavior behavior, CancellationToken cancellationToken)
    at Npgsql.NpgsqlCommand.ExecuteReader(Boolean async, CommandBehavior behavior, CancellationToken cancellationToken)
    at Npgsql.NpgsqlCommand.ExecuteNonQuery(Boolean async, CancellationToken cancellationToken)
    at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteNonQueryAsync(RelationalCommandParameterObject parameterObject, CancellationToken cancellationToken)
    at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteNonQueryAsync(RelationalCommandParameterObject parameterObject, CancellationToken cancellationToken)
    at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteNonQueryAsync(RelationalCommandParameterObject parameterObject, CancellationToken cancellationToken)
    at Microsoft.EntityFrameworkCore.Migrations.Internal.MigrationCommandExecutor.ExecuteAsync(IReadOnlyList`1 migrationCommands, IRelationalConnection connection, MigrationExecutionState executionState, Boolean beginTransaction, Boolean commitTransaction, Nullable`1 isolationLevel, CancellationToken cancellationToken)
    at Microsoft.EntityFrameworkCore.Migrations.Internal.MigrationCommandExecutor.ExecuteAsync(IReadOnlyList`1 migrationCommands, IRelationalConnection connection, MigrationExecutionState executionState, Boolean beginTransaction, Boolean commitTransaction, Nullable`1 isolationLevel, CancellationToken cancellationToken)
    at Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.NpgsqlExecutionStrategy.ExecuteAsync[TState,TResult](TState state, Func`4 operation, Func`4 verifySucceeded, CancellationToken cancellationToken)
    at Microsoft.EntityFrameworkCore.Migrations.Internal.MigrationCommandExecutor.ExecuteNonQueryAsync(IReadOnlyList`1 migrationCommands, IRelationalConnection connection, MigrationExecutionState executionState, Boolean commitTransaction, Nullable`1 isolationLevel, CancellationToken cancellationToken)
    at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.MigrateImplementationAsync(DbContext context, String targetMigration, MigrationExecutionState state, Boolean useTransaction, CancellationToken cancellationToken)
    at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.MigrateImplementationAsync(DbContext context, String targetMigration, MigrationExecutionState state, Boolean useTransaction, CancellationToken cancellationToken)
    at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.<>c.<<MigrateAsync>b__22_1>d.MoveNext()
    --- End of stack trace from previous location ---
    at Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.NpgsqlExecutionStrategy.ExecuteAsync[TState,TResult](TState state, Func`4 operation, Func`4 verifySucceeded, CancellationToken cancellationToken)
    at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.MigrateAsync(String targetMigration, CancellationToken cancellationToken)
    at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.MigrateAsync(String targetMigration, CancellationToken cancellationToken)
    at Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Internal.NpgsqlMigrator.MigrateAsync(String targetMigration, CancellationToken cancellationToken)
    at Program.<Main>$(String[] args) in /home/meenzens/dev/PostgresEnumError/PostgresEnumError/Program.cs:line 5
    at Program.<Main>(String[] args)
    Exception data:
    Severity: ERROR
    SqlState: 42710
    MessageText: type "marriage_status" already exists
    File: typecmds.c
    Line: 1177
    Routine: DefineEnum
    ```
4. Uncomment the hack `migrationBuilder.Sql("DROP TYPE IF EXISTS marriage_status;");` in the `AddEnum` migration
5. Run the app
6. Observe that no exception is thrown