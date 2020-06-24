using Reface.AppStarter.Attributes;
using System;

namespace Reface.AppStarter.Repository
{
    [Component]
    public class DefaultTransactionCounter : ITransactionCounter
    {
        public event EventHandler StartBegin;
        public event EventHandler StartCommit;
        public event EventHandler StartRollback;

        private int countOfBegin = 0;
        private int countOfCommit = 0;
        private bool isFinished = false;

        public void CountBegin()
        {
            if (isFinished) return;
            if (countOfBegin == 0)
                StartBegin?.Invoke(this, EventArgs.Empty);
            countOfBegin++;
        }

        public void CountCommit()
        {
            if (isFinished) return;
            countOfCommit++;
            if (countOfCommit == countOfBegin)
            {
                StartCommit?.Invoke(this, EventArgs.Empty);
                isFinished = true;
            }
        }

        public void CountRollback()
        {
            if (isFinished) return;
            StartRollback?.Invoke(this, EventArgs.Empty);
            isFinished = true;
        }
    }
}
