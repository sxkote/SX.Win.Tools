namespace SX.Math.Interfaces
{
    internal interface IBracketsBalanceValidator<T>
    {
        /// <summary>
        /// Is the input is balanced
        /// </summary>
        bool IsBalanced { get; }

        /// <summary>
        /// Push nex input item in validator
        /// </summary>
        /// <param name="arg">Next item of the input</param>
        void Push(T arg);
    }

}
