using System.Diagnostics.CodeAnalysis;

namespace DataAccess
{
    [SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags")]
    public enum SimplifiedIsolationLevel
    {
        /// <summary>
        /// Specifies the following:
        ///     - Statements cannot read data that has been modified but not yet committed by other transactions.
        ///     - No other transactions can modify data that has been read by the current transaction until the current transaction completes.
        ///     - Other transactions cannot insert new rows with key values that would fall in the range of keys read by any statements in the current transaction until the current transaction completes.
        /// 
        /// Range locks are placed in the range of key values that match the search conditions of each statement executed in a transaction. 
        /// This blocks other transactions from updating or inserting any rows that would qualify for any of the statements executed by the current transaction. 
        /// This means that if any of the statements in a transaction are executed a second time, they will read the same set of rows. 
        /// The range locks are held until the transaction completes. 
        /// This is the most restrictive of the isolation levels because it locks entire ranges of keys and holds the locks until the transaction completes. 
        /// Because concurrency is lower, use this option only when necessary. 
        /// </summary>
        Serializable = System.Transactions.IsolationLevel.Serializable,

        /// <summary>
        /// Specifies that statements cannot read data that has been modified but not yet committed by other transactions
        ///    and that no other transactions can modify data that has been read by the current transaction until the current transaction completes.
        /// 
        /// Shared locks are placed on all data read by each statement in the transaction and are held until the transaction completes. 
        /// This prevents other transactions from modifying any rows that have been read by the current transaction. 
        /// Other transactions can insert new rows that match the search conditions of statements issued by the current transaction. 
        /// If the current transaction then retries the statement it will retrieve the new rows, which results in phantom reads. 
        /// Because shared locks are held to the end of a transaction instead of being released at the end of each statement, concurrency is lower than the default READ COMMITTED isolation level. 
        /// Use this option only when necessary.
        /// </summary>
        RepeatableRead = System.Transactions.IsolationLevel.RepeatableRead,

        /// <summary>
        /// Specifies that statements cannot read data that has been modified but not committed by other transactions. 
        /// 
        /// This prevents dirty reads. 
        /// Data can be changed by other transactions between individual statements within the current transaction, 
        ///    resulting in nonrepeatable reads or phantom data. 
        /// This option is the SQL Server default.
        /// </summary>
        ReadCommitted = System.Transactions.IsolationLevel.ReadCommitted,


        /// <summary>
        /// Specifies that data read by any statement in a transaction will be the transactionally consistent version of the data that existed at the start of the transaction. 
        /// 
        /// The transaction can only recognize data modifications that were committed before the start of the transaction. 
        /// Data modifications made by other transactions after the start of the current transaction are not visible to statements executing in the current transaction. 
        /// The effect is as if the statements in a transaction get a snapshot of the committed data as it existed at the start of the transaction.
        /// </summary>
        Snapshot = System.Transactions.IsolationLevel.Snapshot
    }
}