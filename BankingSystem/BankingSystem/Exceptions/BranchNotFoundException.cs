using System;

namespace BankingSystem.Exceptions
{
    public class BranchNotFoundException : Exception
    {
        public BranchNotFoundException(int id) : base($"Branch with ID {id} not found.")
        {
        }
    }
}
