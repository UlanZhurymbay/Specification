using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Specification.Services
{
    public enum Operator
    {
        Add,
        Multiply,
    }
    public interface IStrategy
    {
        Operator Operator { get; }
        int Operation(int a, int b);
    }
    public class AddStrategy : IStrategy
    {
        public Operator Operator => Operator.Add;

        public int Operation(int a, int b)
        {
            return a + b;
        }
    }
    public class MultiplyStrategy : IStrategy
    {
        public Operator Operator => Operator.Multiply;

        public int Operation(int a, int b)
        {
            return a * b;
        }
    }
}
