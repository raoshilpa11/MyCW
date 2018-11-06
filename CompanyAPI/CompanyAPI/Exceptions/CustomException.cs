using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace CompanyAPI.Exceptions
{
    public static class CustomException
    {
        public static void HandleException(Exception exception)
        {
            if (exception is DbUpdateConcurrencyException concurrencyEx)
            {
                // A custom exception of yours for concurrency issues
                throw new ConcurrencyException(concurrencyEx.Message);
            }
            else if (exception is DbUpdateException dbUpdateEx)
            {
                if (dbUpdateEx.InnerException != null
                        && dbUpdateEx.InnerException.InnerException != null)
                {
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:  // Unique constraint error
                            case 547:   // Constraint check violation
                            case 2601:  // Duplicated key row error
                                        // Constraint violation exception
                                        // A custom exception of yours for concurrency issues
                                throw new ConcurrencyException(exception.Message);
                            default:
                                // A custom exception of yours for other DB issues
                                throw new DatabaseAccessException(
                                  dbUpdateEx.Message, dbUpdateEx.InnerException);
                        }
                    }

                    throw new DatabaseAccessException(dbUpdateEx.Message, dbUpdateEx.InnerException);
                }
            }
        }

        public class ConcurrencyException : Exception
        {
            public ConcurrencyException(string message)
               : base(message)
            {
            }
        }

        public class DatabaseAccessException : Exception
        {
            public DatabaseAccessException(string message, Exception innerException)
               : base(message)
            {
            }
        }
    }
}